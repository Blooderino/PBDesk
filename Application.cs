using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace PBDesk
{
    public partial class Application : Form
    {
        private Pastebin pastebin;

        private Query
            query_signin,
            query_userinfo,
            query_userinfo_avatar,
            query_pasteslist,
            query_textfile_open,
            query_createfile,
            query_deletefile;

        private Parser
            parser_userinfo,
            parser_pasteslist;

        private PasteNode query_textfile_open_current;

        private String 
            query_createfile_text,
            query_createfile_access,
            query_createfile_expiredate,
            query_createfile_format,
            query_deletefile_pastekey,
            userdata_filename;

        private bool userdata_get_success;

        // Делегат для вызова метода из главного потока
        private delegate void ui_UpdateHandler();

        // Конструктор класса
        public Application(in String dev_key)
        {
            InitializeComponent();

            this.pastebin = new Pastebin(dev_key);
            this.ui_savefile_fileformat_combobox.Items.AddRange(this.pastebin.PasteFormats.ToArray());
            this.ui_savefile_fileformat_combobox.SelectedItem = "text";
            this.ui_savefile_expiredate_combobox.SelectedIndex = 0;
            this.ui_savefile_access_combobox.SelectedIndex = 0;
            this.userdata_filename = "pbdesk.data";
            this.ui_authorization_loginpassword_Enable(false);
            this.userdata_get_success = false;

            if (!this.userdata_get_backgroundworker.IsBusy)
                this.userdata_get_backgroundworker.RunWorkerAsync();
        }

        // Выводит статус последнего выполненого запроса 
        public void ui_query_status_label_SetText(in String text, in Query query = null)
        {
            this.ui_query_status_label.Text = text;

            if (query != null)
                this.ui_query_status_label.Text += " (Код ответа: " + query.Code + ")";
        }

        // Включает/выключает панель входа
        private void ui_authorization_loginpassword_Enable(Boolean enable)
        {
            this.ui_authorization_login_label.Enabled = enable;
            this.ui_authorization_login_textbox.Enabled = enable;
            this.ui_authorization_password_label.Enabled = enable;
            this.ui_authorization_password_textbox.Enabled = enable;
            this.ui_authorization_remember_checkbox.Enabled = enable;
            this.ui_authorization_signin_button.Enabled = enable;
            this.ui_authorization_registration_linklabel.Enabled = enable;
        }

        // Включает/выключает кнопку входа в зависимости от наполнения текстовых полей логина и пароля
        private void ui_authorization_signin_button_SetEnabled()
        {
            this.ui_authorization_signin_button.Enabled = 
                this.ui_authorization_login_textbox.Text.Length > 0 && 
                this.ui_authorization_password_textbox.Text.Length > 0;
        }

        // Событие при изменении текста в текстовом поле логина
        private void ui_authorization_login_textbox_TextChanged(object sender, EventArgs e)
        {
            this.ui_authorization_signin_button_SetEnabled();
        }

        // Событие при изменении текста в текстовом поле пароля
        private void ui_authorization_password_textbox_TextChanged(object sender, EventArgs e)
        {
            this.ui_authorization_signin_button_SetEnabled();
        }

        // Событие при нажатии ссылки регистрации
        private void ui_authorization_registration_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://pastebin.com/signup");
        }

        // Событие при нажатии кнопки входа
        private void ui_authorization_signin_button_Click(object sender, EventArgs e)
        {
            // Подготовка к авторизации
            this.ui_authorization_loginpassword_Enable(false);
            this.ui_query_status_label.Text = "Авторизация в аккаунте Pastebin...";

            // Запуск фоного потока для выполнения авторизации
            if (!this.query_signin_backgroundworker.IsBusy)
                this.query_signin_backgroundworker.RunWorkerAsync();
        }

        // Работа в фоновом потоке процесса авторизации
        private void query_signin_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Попытка авторизации
            this.query_signin = this.pastebin.SignIn
                (this.ui_authorization_login_textbox.Text, this.ui_authorization_password_textbox.Text);
        }

        // Завершение процесса авторизации
        private void query_signin_backgroundworker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Удалось выполнить запрос
            if (this.query_signin != null)
            {
                // Успешная авторизация
                if (this.query_signin.Status == Query.STATUS_SUCCESS)
                {
                    this.ui_query_status_label_SetText("Вы успешно авторизовались.", this.query_signin);

                    // Запуск процесса повторяющися запросов получения данных о пользователе и списке файлов
                    if (!this.query_looprun_backgroundworker.IsBusy)
                        this.query_looprun_backgroundworker.RunWorkerAsync();

                    // Запуск процесса записи пользовательских данных (ключ, логин, пароль) в зашифрованном виде
                    if (this.ui_authorization_remember_checkbox.Checked)
                        if (!this.userdata_set_backgroundworker.IsBusy)
                            this.userdata_set_backgroundworker.RunWorkerAsync();

                    // Смена панели авторизации на панель рабочего места
                    this.Controls.Remove(this.ui_authorization_groupbox);
                    this.Controls.Add(this.ui_workplace_groupbox);
                }
                // Ошибка авторизации
                else
                {
                    if (this.query_signin.Status == Query.STATUS_FAILURE)
                    {
                        /* 
                         * Неверный тип запроса при авторизации, ошибка со стороны разработчика, 
                         * обязательно должен быть POST.
                         */
                        if (Encoding.UTF8.GetString(this.query_signin.Response.ToArray()).Contains(
                            "use POST request, not GET"))
                            this.ui_query_status_label_SetText(
                                "Неверный тип запроса.", this.query_signin);

                        /*
                         * Недействительный ключ разработчика, ошибка со стороны разработчика,
                         * можно получить при посещении документации Pastebin.
                         */
                        else if (Encoding.UTF8.GetString(this.query_signin.Response.ToArray()).Contains(
                            "invalid api_dev_key"))
                            this.ui_query_status_label_SetText(
                                "Недействительный ключ разработчика.", this.query_signin);

                        /*
                         * Неверные логин и/или пароль, ошибка со стороны пользователя,
                         * необходимо сначала зарегестрироваться на сайте Pastebin.
                         */
                        else if (Encoding.UTF8.GetString(this.query_signin.Response.ToArray()).Contains(
                            "invalid login"))
                            this.ui_query_status_label_SetText(
                                "Неверные логин и/или пароль.", this.query_signin);

                        /*
                         * Данный аккаунт не подтвержден, ошибка со стороны пользователя,
                         * пользователь не закончил регистрацию. Необходимо проверить электронную почту.
                         */
                        else if (Encoding.UTF8.GetString(this.query_signin.Response.ToArray()).Contains(
                            "account not active"))
                            this.ui_query_status_label_SetText(
                                "Данный аккаунт не подтвержден.", this.query_signin);


                        /*
                         * Недопустимый набор параметров запроса, ошибка со стороны разработчика,
                         * необходимо проверять корректность сформированных запросов.
                         */
                        else if (Encoding.UTF8.GetString(this.query_signin.Response.ToArray()).Contains(
                            "invalid POST parameters"))
                            this.ui_query_status_label_SetText(
                                "Недопустимый набор параметров запроса.", this.query_signin);

                        /*
                         * Сервер ответил неизвестной ошибкой.
                         */
                        else
                            this.ui_query_status_label_SetText(
                                "Неизвестная ошибка при авторизации.", this.query_signin);
                    }

                    this.ui_authorization_loginpassword_Enable(true);
                }
            }
            // Не удалось выполнить запрос
            else
            {
                this.ui_query_status_label_SetText("Не удалось выполнить запрос авторизации.");
                this.ui_authorization_loginpassword_Enable(true);
            }
        }

        // Работа в фоновом потоке процесса получения данных о пользователе
        private void query_userinfo_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Попытка получить данные о пользователе
            this.query_userinfo = this.pastebin.UserInfo();

            // Удалось выполнить запрос
            if (this.query_userinfo != null)
                // Успешно получена информация о пользователе
                if (this.query_userinfo.Status == Query.STATUS_SUCCESS)
                {
                    // Загружаем новые данные в парсер
                    Parser parser = new Parser
                    (
                        Parser.MODE_STRING,
                        Encoding.UTF8.GetString(this.query_userinfo.Response.ToArray())
                    );

                    String old_text = this.parser_userinfo != null ? this.parser_userinfo.Text : "";

                    // Запускаем обновление данных, если предыдущие данные отличаются от новых
                    if (parser != null)
                    {
                        if (!parser.Text.Equals(old_text))
                        {
                            this.parser_userinfo = parser;
                            this.query_userinfo_avatar = this.pastebin.LoadFile(
                                this.parser_userinfo.GetParameter("user/user_avatar_url"));

                            // Отдаем потоку команду о том, что данные изменились
                            this.query_userinfo_backgroundworker.ReportProgress(0);
                        }
                    }
                    else
                        this.parser_userinfo = parser;
                }
        }

        // Обновление графического интерфейса после выполнения запроса пользовательских данных
        private void ui_workplace_userinfo_Update()
        {
            // Удалось выполнить запрос
            if (this.query_userinfo != null)
            {
                // Данные об аккаунте успешно загружены
                if (this.query_userinfo.Status == Query.STATUS_SUCCESS)
                {

                    if (this.query_userinfo_avatar != null)
                    {
                        // Аватар пользователя успешно загружена
                        if (this.query_userinfo_avatar.Status == Query.STATUS_SUCCESS)
                        {
                            // Загрузка изображения из набора байтов
                            using (MemoryStream memory = new MemoryStream(this.query_userinfo_avatar.Response.ToArray()))
                                this.ui_workplace_userinfo_avatar_picturebox.Image =
                                    Image.FromStream(memory);

                            this.ui_query_status_label_SetText(
                                "Аватар пользователя успешно загружен.", this.query_userinfo_avatar);
                        }
                        // Не удалось загрузить аватар
                        else
                            this.ui_query_status_label_SetText(
                                "Не удалось загрузить аватар пользователя.", this.query_userinfo_avatar);
                    }
                    else
                        this.ui_query_status_label_SetText("Не удалось загрузить аватар пользователя.");

                    // Заполняем имя пользователя
                    this.ui_label_SetText
                    (
                        this.ui_workplace_userinfo_username_label,
                        this.parser_userinfo.GetParameter("user/user_name"),
                        "Информация отсутствует"
                    );

                    // Заполняем электронную почту пользователя
                    this.ui_linklabel_SetText
                    (
                        this.ui_workplace_userinfo_email_value_linklabel,
                        this.parser_userinfo.GetParameter("user/user_email"),
                        "Информация отсутствует"
                    );

                    // Заполняем данные о веб-сайте
                    this.ui_linklabel_SetText
                    (
                        this.ui_workplace_userinfo_website_value_linklabel,
                        this.parser_userinfo.GetParameter("user/user_website"),
                        "Информация отсутствует"
                    );

                    // Заполняем местоположение пользователя
                    this.ui_label_SetText
                    (
                        this.ui_workplace_userinfo_location_value_label,
                        this.parser_userinfo.GetParameter("user/user_location"),
                        "Информация отсутствует"
                    );

                    // Заполняем данные о типе аккаунта
                    this.ui_label_SetText
                    (
                        this.ui_workplace_userinfo_accounttype_value_label,
                        this.parser_userinfo.GetParameter("user/user_account_type").Equals("1") ? "Продвинутый" : "Обычный",
                        "Информация отсутствует"
                    );

                    this.ui_query_status_label_SetText(
                        "Данные о пользователе успешно загружены.", this.query_userinfo);
                }
                // Выполнение запроса завершилось ошибкой
                else
                {
                    /*
                     * Недействительный ключ разработчика, ошибка со стороны разработчика,
                     * можно получить при посещении документации Pastebin.
                     */
                    if (Encoding.UTF8.GetString(this.query_userinfo.Response.ToArray()).Contains(
                         "invalid api_dev_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ разработчика.", this.query_userinfo);

                    /*
                     * Неверный параметр запроса, ошибка со стороны разработчика,
                     * всегда должен быть 'userdetails'.
                     */
                    else if (Encoding.UTF8.GetString(this.query_userinfo.Response.ToArray()).Contains(
                         "invalid api_option"))
                        this.ui_query_status_label_SetText(
                            "Неверный параметр запроса.", this.query_userinfo);

                    /*
                     * Недействительный ключ пользователя, ошибка со стороны разработчика,
                     * можно получить при переавторизации.
                     */
                    else if (Encoding.UTF8.GetString(this.query_userinfo.Response.ToArray()).Contains(
                         "invalid api_user_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ пользователя.", this.query_userinfo);

                    /*
                     * Сервер ответил неизвестной ошибкой.
                     */
                    else
                        this.ui_query_status_label_SetText(
                            "Не удалось загрузить данные о пользователе.", this.query_userinfo);
                }

                this.ui_workplace_userinfo_signout_button.Enabled = true;
            }
            // Не удалось выполнить запрос
            else
                this.ui_query_status_label_SetText(
                    "Не удалось выполнить запрос обновления пользовательских данных.");
        }

        // Работа фонового потока при обнаружении изменения данных о пользователе
        private void query_userinfo_backgroundworker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Обновляем интерфейс из параллельного потока
            if (this.InvokeRequired)
                this.Invoke(new Application.ui_UpdateHandler(this.ui_workplace_userinfo_Update));
            // Обновляем интерфейс из текущего потока
            else
                this.ui_workplace_userinfo_Update();
        }

        // Событие при нажатии кнопки "Сохранить"
        private void ui_workplace_editor_currentfile_save_button_Click(object sender, EventArgs e)
        {

        }

        // Событие при нажатии кнопки "Закрыть"
        private void ui_workspace_editor_currentfile_close_file_Click(object sender, EventArgs e)
        {
            this.ui_workplace_editor_tabcontrol.Controls.Remove(
                this.ui_workplace_editor_tabcontrol.SelectedTab);

            if (this.ui_workplace_editor_tabcontrol.Controls.Count > 0)
                this.ui_workplace_editor_tabcontrol.SelectedIndex = 0;
            else
                this.ui_workplace_editor_controls_SetStatus();
        }

        // Устанавливает текст в выбранный текстовый ярлык
        private void ui_label_SetText(in Label label, in String text, in String default_text)
        {
            if (!String.IsNullOrEmpty(text))
                label.Text = text;
            else
                label.Text = default_text;
        }

        // Устанавливает текст в выбранный текстовый ссылочный ярлык
        private void ui_linklabel_SetText(in LinkLabel link_label, in String text, in String default_text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                link_label.Text = text;
                link_label.LinkColor = Color.Blue;
                link_label.LinkBehavior = LinkBehavior.HoverUnderline;
            }
            else
            {
                link_label.Text = default_text;
                link_label.LinkColor = SystemColors.ControlText;
                link_label.LinkBehavior = LinkBehavior.NeverUnderline;
            }
        }

        // Событие при нажатии на ссылку веб-сайта из пользовательской информации
        private void ui_workplace_userinfo_website_value_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ui_workplace_userinfo_website_value_linklabel.LinkBehavior != LinkBehavior.NeverUnderline)
                System.Diagnostics.Process.Start(this.ui_workplace_userinfo_website_value_linklabel.Text);
        }

        // Событие при нажатии на адрес электронной почты из пользовательской информации
        private void ui_workplace_userinfo_email_value_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ui_workplace_userinfo_email_value_linklabel.LinkBehavior != LinkBehavior.NeverUnderline)
                System.Diagnostics.Process.Start("mailto:" + this.ui_workplace_userinfo_email_value_linklabel.Text);
        }

        // Отмена всех фоновых потоков
        private void query_backgroundworkers_CancelAll()
        {
            if (this.query_signin_backgroundworker != null)
                if (this.query_signin_backgroundworker.IsBusy)
                    this.query_signin_backgroundworker.CancelAsync();

            if (this.query_userinfo_backgroundworker != null)
                if (this.query_userinfo_backgroundworker.IsBusy)
                    this.query_userinfo_backgroundworker.CancelAsync();

            if (this.query_pasteslist_backgroundworker != null)
                if (this.query_pasteslist_backgroundworker.IsBusy)
                    this.query_pasteslist_backgroundworker.CancelAsync();

            if (this.query_looprun_backgroundworker != null)
                if (this.query_looprun_backgroundworker.IsBusy)
                    this.query_looprun_backgroundworker.CancelAsync();

            if (this.query_textfile_open_backgroundworker != null)
                if (this.query_textfile_open_backgroundworker.IsBusy)
                    this.query_textfile_open_backgroundworker.CancelAsync();

            if (this.query_createfile_backgroundworker != null)
                if (this.query_createfile_backgroundworker.IsBusy)
                    this.query_createfile_backgroundworker.CancelAsync();

            if (this.query_deletefile_backgroundworker != null)
                if (this.query_deletefile_backgroundworker.IsBusy)
                    this.query_deletefile_backgroundworker.CancelAsync();

            if (this.userdata_get_backgroundworker != null)
                if (this.userdata_get_backgroundworker.IsBusy)
                    this.userdata_get_backgroundworker.CancelAsync();

            if (this.userdata_set_backgroundworker != null)
                if (this.userdata_set_backgroundworker.IsBusy)
                    this.userdata_set_backgroundworker.CancelAsync();
        }

        // Событие при закрывании окна программы
        private void Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.query_backgroundworkers_CancelAll();
        }

        // Событие при нажатии кнопки "Выйти"
        private void ui_workplace_userinfo_signout_button_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.userdata_filename))
                File.Delete(this.userdata_filename);

            this.pastebin.ApiUserKey = "";
            this.query_backgroundworkers_CancelAll();
            this.Controls.Remove(this.ui_workplace_groupbox);
            this.ui_authorization_loginpassword_Enable(true);
            this.ui_authorization_login_textbox.Text = "";
            this.ui_authorization_password_textbox.Text = "";
            this.ui_authorization_remember_checkbox.Checked = false;
            this.ui_query_status_label_SetText("Вы вышлы из своего аккаунта.");
            this.Controls.Add(this.ui_authorization_groupbox);
        }
        
        // Работа в фоновом потоке открытия файла
        private void query_textfile_open_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.query_textfile_open = this.pastebin.LoadText(this.query_textfile_open_current.PasteKey);
        }

        // Завершение открытия полученного файла
        private void query_textfile_open_backgroundworker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Удалось выполнить запрос
            if (this.query_textfile_open != null)
            {
                // Текст файла успешно загружен
                if (this.query_textfile_open.Status == Query.STATUS_SUCCESS)
                {
                    bool opened = false;
                    int opened_index = 0;

                    // Поиск данного файла среди уже открытых
                    for (int i = 0; i < this.ui_workplace_editor_tabcontrol.Controls.Count && !opened; i++)
                        if (((String)this.ui_workplace_editor_tabcontrol.Controls[i].Tag).Equals(
                            this.query_textfile_open_current.PasteUrl))
                        {
                            opened = true;
                            opened_index = i;
                        }

                    // Такой документ ещё не открыт
                    if (!opened)
                    {
                        this.ui_workplace_editor_tabcontrol.Enabled = true;

                        // Создание новой страницы
                        EditorPage tab = new EditorPage
                        (
                            this.query_textfile_open_current.PasteTitle + " (" +
                                this.query_textfile_open_current.PasteFormatShort + ")",
                            false,
                            this.query_textfile_open_current.PasteUrl,
                            Encoding.UTF8.GetString(this.query_textfile_open.Response.ToArray())
                        );

                        this.ui_workplace_editor_tabcontrol.Controls.Add(tab);

                        // Переключение на данную страницу
                        this.ui_workplace_editor_tabcontrol.SelectedIndex =
                            this.ui_workplace_editor_tabcontrol.Controls.Count - 1;
                    }
                    // Такой документ уже открыт
                    else
                    {
                        // Обновление текста на странице
                        ((EditorPage)ui_workplace_editor_tabcontrol.Controls[opened_index]).ContainedText =
                            Encoding.UTF8.GetString(this.query_textfile_open.Response.ToArray());

                        // Переключение на страницу
                        this.ui_workplace_editor_tabcontrol.SelectedIndex = opened_index;
                    }

                    this.ui_workplace_editor_controls_SetStatus();
                    this.ui_query_status_label_SetText("Файл " + this.query_textfile_open_current.PasteTitle + " (" +
                        this.query_textfile_open_current.PasteFormatShort + ") " + "успешно загружен.",
                        this.query_textfile_open);
                }
                // Не удалось загрузить текст файла
                else
                {
                    this.ui_workplace_editor_controls_SetStatus();
                    this.ui_query_status_label_SetText("Не удалось загрузить файл " +
                        this.query_textfile_open_current.PasteTitle + " (" +
                        this.query_textfile_open_current.PasteFormatShort + ").",
                        this.query_textfile_open);
                }
            }
            // Не удалось выполнить запрос
            else
            {
                this.ui_workplace_editor_controls_SetStatus();
                this.ui_query_status_label_SetText("Не удалось выполнить запрос загрузки файла " +
                        this.query_textfile_open_current.PasteTitle + " (" +
                        this.query_textfile_open_current.PasteFormatShort + ").");
            }
        }

        // Устанавливает текст для ссылочного ярлыка с ссылкой на файл
        private void ui_workplace_editor_controls_SetStatus()
        {
            if (this.ui_workplace_editor_tabcontrol.SelectedTab != null)
            {
                if (((String) this.ui_workplace_editor_tabcontrol.SelectedTab.Tag).Contains("не сохранен"))
                {
                    this.ui_linklabel_SetText
                    (
                        this.ui_workplace_editor_filelink_linklabel,
                        "",
                        "Файл не cохранен"
                    );

                    this.ui_workplace_editor_delete_button.Enabled = false;
                }
                else
                {
                    this.ui_linklabel_SetText
                    (
                        this.ui_workplace_editor_filelink_linklabel,
                        (String) this.ui_workplace_editor_tabcontrol.SelectedTab.Tag,
                        "Файл не загружен"
                    );

                    this.ui_workplace_editor_delete_button.Enabled = true;
                }

                this.ui_workplace_editor_save_button.Enabled =
                    ((EditorPage)this.ui_workplace_editor_tabcontrol.SelectedTab).Editable;
                this.ui_workplace_editor_close_button.Enabled = true;
            }
            else
            {
                this.ui_linklabel_SetText
                    (
                        this.ui_workplace_editor_filelink_linklabel,
                        "",
                        "Файл не загружен"
                    );

                this.ui_workplace_editor_delete_button.Enabled = false;
                this.ui_workplace_editor_save_button.Enabled = false;
                this.ui_workplace_editor_close_button.Enabled = false;
            }
        }

        // Событие при изменении выбранной страницы в редакторе
        private void ui_workplace_editor_tabcontrol_Selected(object sender, TabControlEventArgs e)
        {
            this.ui_workplace_editor_controls_SetStatus();
        }

        // Событие при изменении выбранной страницы в редакторе (с помощью индекса)
        private void ui_workplace_editor_tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ui_workplace_editor_controls_SetStatus();
        }

        // Событие при нажатии на текст ссылочного ярлка с ссылкой на текущий файл
        private void ui_workplace_editor_filelink_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ui_workplace_editor_filelink_linklabel.LinkBehavior != LinkBehavior.NeverUnderline)
                System.Diagnostics.Process.Start(this.ui_workplace_editor_filelink_linklabel.Text);
        }

        // Закрывает выбранное текстовое поле при нажатии кнопки "Удалить"
        private void ui_workplace_editor_delete_button_Click(object sender, EventArgs e)
        {
            if (!this.query_deletefile_backgroundworker.IsBusy)
            {
                this.query_deletefile_pastekey = (String) this.ui_workplace_editor_tabcontrol.SelectedTab.Tag;
                this.query_deletefile_pastekey = this.query_deletefile_pastekey.Replace("https://pastebin.com/", "");
                this.query_deletefile_backgroundworker.RunWorkerAsync();
            }
        }

        // Создает новое текстовое поле при нажатии кнопки "Создать"
        private void ui_workplace_editor_create_button_Click(object sender, EventArgs e)
        {
            this.ui_workplace_editor_tabcontrol.Enabled = true;
            this.ui_workplace_editor_tabcontrol.Controls.Add(new EditorPage("Untitled", true, "Файл не сохранен"));
            this.ui_workplace_editor_tabcontrol.SelectedIndex = this.ui_workplace_editor_tabcontrol.Controls.Count - 1;
            this.ui_workplace_editor_controls_SetStatus();
        }

        // Включает или выключает элементы управления панели сохранения файла
        private void ui_savefile_SetEnabled(Boolean enabled)
        {
            this.ui_savefile_filename_textbox.Enabled = enabled;
            this.ui_savefile_fileformat_combobox.Enabled = enabled;
            this.ui_savefile_expiredate_combobox.Enabled = enabled;
            this.ui_savefile_access_combobox.Enabled = enabled;
            this.ui_savefile_cancel_button.Enabled = enabled;
            this.ui_savefile_save_button.Enabled = enabled;
        }

        // Стандартные настройки для окна сохранения файлов
        private void ui_savefile_SetDefault()
        {
            this.ui_savefile_SetEnabled(true);
            this.ui_savefile_filename_textbox.Text = "";
            this.ui_savefile_fileformat_combobox.SelectedItem = "text";
            this.ui_savefile_expiredate_combobox.SelectedIndex = 0;
            this.ui_savefile_expiredate_combobox.SelectedIndex = 0;
            this.ui_savefile_save_button.Enabled = false;
        }

        // Возвращает рабочее места без сохранения нового файла при нажатии кнопки "Отмена"
        private void ui_savefile_cancel_button_Click(object sender, EventArgs e)
        {
            if (this.query_createfile_backgroundworker != null)
                if (this.query_createfile_backgroundworker.IsBusy)
                    this.query_createfile_backgroundworker.CancelAsync();

            this.Controls.Remove(this.ui_savefile_groupbox);
            this.Controls.Add(this.ui_workplace_groupbox);
            this.ui_savefile_SetDefault();
        }

        // Событие изменения имени файла в окне сохранения
        private void ui_savefile_filename_textbox_TextChanged(object sender, EventArgs e)
        {
            this.ui_savefile_save_button.Enabled = this.ui_savefile_filename_textbox.Text.Length > 0;
        }

        // Работа фонового потока по полученнию данных пользователя из файла настроек
        private void userdata_get_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(this.userdata_filename))
                {
                    Parser parser = new Parser(Parser.MODE_STRING);
                    parser.ReadFromFile(this.userdata_filename, this.pastebin.ApiDevKey);
                    this.pastebin.ApiUserKey = parser.GetParameter("user/key");
                    this.userdata_get_success = true;
                }
                else
                {
                    this.pastebin.ApiUserKey = "";
                    this.userdata_get_success = false;
                }
            }
            catch (Exception)
            {
                this.pastebin.ApiUserKey = "";
                this.userdata_get_success = false;
            }
        }

        // Завершение работы фонового потока по полученнию данных пользователя из файла настроек
        private void userdata_get_backgroundworker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (this.userdata_get_success)
            {
                if (!this.query_looprun_backgroundworker.IsBusy)
                    this.query_looprun_backgroundworker.RunWorkerAsync();

                // Смена панели авторизации на панель рабочего места
                this.Controls.Remove(this.ui_authorization_groupbox);
                this.Controls.Add(this.ui_workplace_groupbox);
            }
            else
                this.ui_authorization_loginpassword_Enable(true);
        }

        // Работа фонового потока по записи данных пользователя в файл настроек
        private void userdata_set_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(this.userdata_filename))
                    File.Delete(this.userdata_filename);

                Parser parser = new Parser
                (
                    Parser.MODE_STRING,
                    "<user><login>" + this.ui_authorization_login_textbox.Text + "</login>" +
                    "<password>" + this.ui_authorization_password_textbox.Text + "</password>" +
                    "<key>" + this.pastebin.ApiUserKey + "</key></user>"
                );

                parser.WriteToFile(this.userdata_filename, this.pastebin.ApiDevKey);
            }
            catch (Exception) { }
        }

        // Событие при нажатии кнопки закрытия
        private void ui_workplace_editor_close_button_Click(object sender, EventArgs e)
        {
            this.ui_workplace_editor_tabcontrol.Controls.Remove(
                this.ui_workplace_editor_tabcontrol.SelectedTab);
            this.ui_workplace_editor_controls_SetStatus();
        }

        // Запуск сохранения файла при нажатии кнопки "Сохранить"
        private void ui_savefile_save_button_Click(object sender, EventArgs e)
        {
            this.query_createfile_access = Pastebin.PASTE_ACCESS_LIMITATION_PUBLIC;
            this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_NEVER;
            this.query_createfile_text = ((EditorPage)this.ui_workplace_editor_tabcontrol.SelectedTab).ContainedText.Length > 0 ?
                    ((EditorPage)this.ui_workplace_editor_tabcontrol.SelectedTab).ContainedText :
                    "Automatically generated text";

            // Устанавливаем режим приватности файла
            if (((String)this.ui_savefile_access_combobox.SelectedItem).Contains("Приватный"))
                this.query_createfile_access = Pastebin.PASTE_ACCESS_LIMITATION_PRIVATE;
            else if (((String)this.ui_savefile_access_combobox.SelectedItem).Contains("Скрытый"))
                this.query_createfile_access = Pastebin.PASTE_ACCESS_LIMITATION_UNLISTED;

            // Устанавливаем срок жизни файла
            if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("10 минут"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_TEN_MINUTES;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("1 час"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_ONE_HOUR;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("1 день"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_ONE_DAY;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("1 неделя"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_ONE_WEEK;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("2 недели"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_TWO_WEEKS;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("1 месяц"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_ONE_MONTH;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("6 месяцев"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_SIX_MONTHS;
            else if (((String)this.ui_savefile_expiredate_combobox.SelectedItem).Contains("1 год"))
                this.query_createfile_expiredate = Pastebin.PASTE_EXPIRE_DATE_ONE_YEAR;

            this.query_createfile_format = (String) this.ui_savefile_fileformat_combobox.SelectedItem;

            if (!this.query_createfile_backgroundworker.IsBusy)
              this.query_createfile_backgroundworker.RunWorkerAsync();
        }

        // Завершение работы фонового потока по сохранению файла
        private void query_createfile_backgroundworker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (this.query_createfile != null)
                if (this.query_createfile.Status == Query.STATUS_SUCCESS)
                {
                    this.ui_query_status_label_SetText("Файл успешно создан.", this.query_createfile);
                    this.Controls.Remove(this.ui_savefile_groupbox);
                    this.ui_workplace_editor_tabcontrol.Controls.Remove(
                        this.ui_workplace_editor_tabcontrol.SelectedTab);
                    this.Controls.Add(this.ui_workplace_groupbox);
                    this.ui_savefile_SetDefault();
                }
                else
                {
                    /*
                    * Недействительный ключ разработчика, ошибка со стороны разработчика,
                    * можно получить при посещении документации Pastebin.
                    */
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "invalid api_dev_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ разработчика.", this.query_createfile);

                    /*
                     * Недействительный ключ пользователя, ошибка со стороны разработчика,
                     * можно получить при переавторизации.
                     */
                    else if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "invalid api_user_key") ||
                         Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                             "invalid or expired api_user_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ пользователя.", this.query_createfile);

                    /*
                     * Невозможно создать более 25 скрытых файлов для обычного аккаунта,
                     * ограничение сервиса, следует выбрать другой тип приватности.
                     */
                    else if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "maximum number of 25 unlisted"))
                        this.ui_query_status_label_SetText(
                            "Доступно только 25 скрытых файлов для обычного аккаунта.", this.query_createfile);

                    /*
                     * Невозможно создать более 10 приватных файлов для обычного аккаунта,
                     * ограничение сервиса, следует выбрать другой тип приватности.
                     */
                    else if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "maximum number of 10 private"))
                        this.ui_query_status_label_SetText(
                            "Доступно только 10 приватных файлов для обычного аккаунта.", this.query_createfile);

                    /*
                     * Файл не может превышать конкретный объем, ограничение сервиса,
                     * необходимо уменьшить объем текста в файле.
                     */
                    else if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "maximum paste file size exceeded"))
                        this.ui_query_status_label_SetText(
                            "Превышен максимальный допустимый размер для файла.", this.query_createfile);

                    /*
                     * Недействительный параметр срока хранения файла, ошибка со стороны разработчика,
                     * стоит уточнить в документации допустимые значения.
                     */
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "invalid api_paste_expire_date"))
                        this.ui_query_status_label_SetText(
                            "Недействительный параметр срока хранения файла.", this.query_createfile);

                    /*
                     * Недействительный параметр приватности файла, ошибка со стороны разработчика,
                     * стоит уточнить в документации допустимые значения.
                     */
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "invalid api_paste_private"))
                        this.ui_query_status_label_SetText(
                            "Недействительный параметр приватности файла.", this.query_createfile);

                    /*
                     * Недействительный параметр формата файла, ошибка со стороны разработчика,
                     * стоит уточнить в документации допустимые значения.
                     */
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "invalid api_paste_format"))
                        this.ui_query_status_label_SetText(
                            "Недействительный параметр формата файла.", this.query_createfile);

                    /*
                     * Попытка передать пустой файл.
                     */ 
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "api_paste_code was empty"))
                        this.ui_query_status_label_SetText(
                            "Файл не может быть пустым.", this.query_createfile);

                    /*
                     * Достигнут предел по количеству создаваемых файлов
                     */
                    if (Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()).Contains(
                         "maximum pastes per 24h"))
                        this.ui_query_status_label_SetText(
                            "Доступно создание только 20 файлов в сутки для обычного аккаунта.",
                            this.query_createfile);

                    /*
                     * Сервер ответил неизвестной ошибкой.
                     */
                    else
                        this.ui_query_status_label_SetText(
                            "Не удалось создать файл на сервере." + 
                            Encoding.UTF8.GetString(this.query_createfile.Response.ToArray()), 
                            this.query_createfile);
                }
            else
            {
                this.ui_query_status_label_SetText(
                    "Не удалось выполнить запрос по созданию файла.", this.query_createfile);
                this.ui_savefile_SetDefault();
            }
        }

        // Либо сохраняет на сервере уже имеющийся документ, либо создает новый
        private void ui_workplace_editor_save_button_Click(object sender, EventArgs e)
        {
            if (!((String) ((EditorPage) this.ui_workplace_editor_tabcontrol.SelectedTab).Tag).StartsWith("https://"))
            {
                this.Controls.Remove(this.ui_workplace_groupbox);
                this.Controls.Add(this.ui_savefile_groupbox);
            }
        }

        // Завершение работы фонового потока по удалению файла
        private void query_deletefile_backgroundworker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Удалось выполнить запрос
            if (this.query_deletefile != null)
            {
                // Файл успешно уадлен
                if (this.query_deletefile.Status == Query.STATUS_SUCCESS)
                {
                    int index = this.ui_workplace_editor_tabcontrol.SelectedIndex - 1;

                    this.ui_workplace_editor_tabcontrol.Controls.Remove(
                        this.ui_workplace_editor_tabcontrol.SelectedTab);

                    if (index > -1)
                        this.ui_workplace_editor_tabcontrol.SelectedIndex = index;
                    else
                        this.ui_workplace_editor_controls_SetStatus();

                }
                // Файл не был удален
                else
                {
                    /*
                    * Недействительный ключ разработчика, ошибка со стороны разработчика,
                    * можно получить при посещении документации Pastebin.
                    */
                    if (Encoding.UTF8.GetString(this.query_deletefile.Response.ToArray()).Contains(
                         "invalid api_dev_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ разработчика.", this.query_deletefile);

                    /*
                     * Неверный параметр запроса, ошибка со стороны разработчика,
                     * всегда должен быть 'list'.
                     */
                    else if (Encoding.UTF8.GetString(this.query_deletefile.Response.ToArray()).Contains(
                         "invalid api_option"))
                        this.ui_query_status_label_SetText(
                            "Неверный параметр запроса.", this.query_deletefile);

                    /*
                     * Недействительный ключ пользователя, ошибка со стороны разработчика,
                     * можно получить при переавторизации.
                     */
                    else if (Encoding.UTF8.GetString(this.query_deletefile.Response.ToArray()).Contains(
                         "invalid api_user_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ пользователя.", this.query_deletefile);

                    /*
                     * Недостаточно прав для удаления файла, ошибка со стороны разработчика,
                     * пользователь должен иметь возможность удалять все свои файлы.
                     */
                    else if (Encoding.UTF8.GetString(this.query_deletefile.Response.ToArray()).Contains(
                         "invalid permission to remove paste"))
                        this.ui_query_status_label_SetText(
                            "Недостаточно прав для удаления файла.", this.query_deletefile);

                    /*
                     * Сервер ответил неизвестной ошибкой.
                     */
                    else
                        this.ui_query_status_label_SetText(
                            "Не удалось удалить файл.", this.query_deletefile);
                }
            }
            else
                this.ui_query_status_label_SetText(
                    "Не удалось выполнить запрос на удаление файла.");
        }

        // Работа фонового потока по удалению файла
        private void query_deletefile_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.query_deletefile = this.pastebin.DeletePaste(this.query_deletefile_pastekey);
        }

        // Работа фонового потока по сохранению файла
        private void query_createfile_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.query_createfile = this.pastebin.CreatePaste
            (
                this.ui_savefile_filename_textbox.Text,
                this.query_createfile_text,
                this.query_createfile_format,
                this.query_createfile_access, 
                this.query_createfile_expiredate
            );
        }

        // Событие при двойном щелчке мыши по узлу дерева файлов
        private void ui_workplace_files_treeview_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs mouse_double_click_event)
        {
            // Если данный узел отвечает за конкретный документ, то выполнить запрос загрузки текста файла
            if (mouse_double_click_event.Node.Tag != null)
            {
                if (((String)mouse_double_click_event.Node.Tag).Contains(PasteNode.PASTE_NODE_DEFAULT_TAG))
                {
                    this.query_textfile_open_current = (PasteNode)mouse_double_click_event.Node;

                    if (!this.query_textfile_open_backgroundworker.IsBusy)
                        this.query_textfile_open_backgroundworker.RunWorkerAsync();
                }
            }
        }

        // Работа в фоновом потоке обновления списка файлов
        private void query_pasteslist_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Выполняем запрос на получение списка файлов
            this.query_pasteslist = this.pastebin.PastesList();

            // Удалось выполнить запрос
            if (this.query_pasteslist != null)
                // Удалось получить список файлов
                if (this.query_pasteslist.Status == Query.STATUS_SUCCESS)
                {
                    Parser parser = new Parser
                    (
                        Parser.MODE_STRING,
                        Encoding.UTF8.GetString(this.query_pasteslist.Response.ToArray()),
                        true
                    );

                    if (parser != null)
                    {
                        String old_text = this.parser_pasteslist == null ? "" : this.parser_pasteslist.Text;

                        if (!parser.Text.Equals(old_text))
                        {
                            this.parser_pasteslist = parser;
                            this.query_pasteslist_backgroundworker.ReportProgress(0);
                        }
                    }
                }
        }

        // Обновление графического интерфейса после выполнения запроса на обновления списка файлов
        private void ui_worksplace_pasteslist_Update()
        {
            // Удалось выполнить запрос
            if (this.query_pasteslist != null)
            {
                // Список файлов успешно получен
                if (this.query_pasteslist.Status == Query.STATUS_SUCCESS)
                {
                    // Блокируем перерисовку дерева файлов
                    this.ui_workplace_files_treeview.BeginUpdate();

                    // Список файлов не пуст
                    if (!this.parser_pasteslist.Text.Contains("No pastes found."))
                    {
                        // Создаем список отдельных блоков информации о каждом файле
                        List<String> list_paste_info = this.parser_pasteslist.GetParameters("tempxmldoc/paste");

                        if (ui_workplace_files_treeview.Nodes.Count == 0)
                            this.ui_workplace_files_treeview.Nodes.Add(new TreeNode("Файлы"));

                        /*
                         * Удаляем из списка файлы (а также закрываем редактор данного файла), 
                         * информация о которых отсутствует
                         */
                        for (int i = 0; i < this.ui_workplace_files_treeview.Nodes[0].Nodes.Count; i++)
                        {
                            for (int j = 0; j < this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Nodes.Count; j++)
                            {
                                bool exists = false;

                                // Проверяем, есть ли указанный в файл в новом списке
                                for (int k = 0; k < list_paste_info.Count && !exists; k++)
                                    if (list_paste_info[k].Contains(((PasteNode)this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Nodes[j]).PasteKey))
                                        exists = true;

                                // Файл не существует в новом списке
                                if (!exists)
                                {
                                    exists = true;

                                    // Находим и закрываем вкладку с этим файлом
                                    for (int k = 0; k < this.ui_workplace_editor_tabcontrol.TabPages.Count && exists; k++)
                                        if (((String)((EditorPage)this.ui_workplace_editor_tabcontrol.TabPages[k]).Tag).Contains(
                                            ((PasteNode)this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Nodes[j]).PasteKey))
                                        {
                                            this.ui_workplace_editor_tabcontrol.Controls.Remove(this.ui_workplace_editor_tabcontrol.TabPages[k]);
                                            exists = false;
                                        }

                                    // Удаляем этот файл из дерева
                                    this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Nodes[j].Remove();
                                    j--;
                                }

                                // Если тип файлов остался без узлов, то удаляем данный узел
                                if (this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Nodes.Count == 0)
                                {
                                    this.ui_workplace_files_treeview.Nodes[0].Nodes[i].Remove();
                                    i--;
                                }
                            }
                        }

                        // Добавляем в список новые файлы
                        for (int i = 0; i < list_paste_info.Count; i++)
                        {
                            Parser parser = new Parser(Parser.MODE_STRING, list_paste_info[i]);
                            PasteNode paste = new PasteNode
                            (
                                parser.GetParameter("paste/paste_key"),
                                parser.GetParameter("paste/paste_date"),
                                parser.GetParameter("paste/paste_title"),
                                parser.GetParameter("paste/paste_size"),
                                parser.GetParameter("paste/paste_expire_date"),
                                parser.GetParameter("paste/paste_private"),
                                parser.GetParameter("paste/paste_format_long"),
                                parser.GetParameter("paste/paste_format_short"),
                                parser.GetParameter("paste/paste_url"),
                                parser.GetParameter("paste/paste_hits")
                            );

                            bool exists = false;
                            int index = 0;

                            // Проверяем список типов файлов на наличие полученного типа
                            for (int j = 0; j < this.ui_workplace_files_treeview.Nodes[0].Nodes.Count && !exists; j++)
                            {
                                index = j;

                                if (this.ui_workplace_files_treeview.Nodes[0].Nodes[j].Text.Equals(
                                    paste.PasteFormatLong + " (" + paste.PasteFormatShort + ") "))
                                    exists = true;
                            }

                            // Данный тип файлов не существует
                            if (!exists)
                            {
                                TreeNode type = 
                                    new TreeNode(paste.PasteFormatLong + " (" + paste.PasteFormatShort + ") ");
                                type.Tag = PasteNode.PASTE_NODE_FILE_TYPE_TAG;
                                this.ui_workplace_files_treeview.Nodes[0].Nodes.Add(type);

                                index = this.ui_workplace_files_treeview.Nodes[0].Nodes.Count - 1;
                                this.ui_workplace_files_treeview.Nodes[0].Nodes[index].Nodes.Add(paste);
                            }
                            // Данный тип файлов существует
                            else
                            {
                                exists = false;

                                // Проверяем список файлов в данном разделе на совпадение по уникальному ключу
                                for (int j = 0; j < this.ui_workplace_files_treeview.Nodes[0].Nodes[index].Nodes.Count && !exists; j++)
                                    if (((PasteNode)this.ui_workplace_files_treeview.Nodes[0].Nodes[index].Nodes[j]).PasteKey.Equals(paste.PasteKey))
                                        exists = true;

                                // Если файл существует, то добавляем данный файл
                                if (!exists)
                                    this.ui_workplace_files_treeview.Nodes[0].Nodes[index].Nodes.Add(paste);
                            }
                        }
                    }
                    // Список файлов пуст
                    else
                        this.ui_workplace_files_treeview.Controls.Clear();

                    this.ui_workplace_files_treeview.Enabled = true;
                    this.ui_workplace_files_treeview.EndUpdate();
                    this.ui_query_status_label_SetText
                        ("Данные о файлах успешно загружены.", this.query_pasteslist);
                }
                // Список файлов не получен
                else
                {
                    /*
                     * Недействительный ключ разработчика, ошибка со стороны разработчика,
                     * можно получить при посещении документации Pastebin.
                     */
                    if (Encoding.UTF8.GetString(this.query_pasteslist.Response.ToArray()).Contains(
                         "invalid api_dev_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ разработчика.", this.query_pasteslist);

                    /*
                     * Неверный параметр запроса, ошибка со стороны разработчика,
                     * всегда должен быть 'list'.
                     */
                    else if (Encoding.UTF8.GetString(this.query_pasteslist.Response.ToArray()).Contains(
                         "invalid api_option"))
                        this.ui_query_status_label_SetText(
                            "Неверный параметр запроса.", this.query_pasteslist);

                    /*
                     * Недействительный ключ пользователя, ошибка со стороны разработчика,
                     * можно получить при переавторизации.
                     */
                    else if (Encoding.UTF8.GetString(this.query_pasteslist.Response.ToArray()).Contains(
                         "invalid api_user_key"))
                        this.ui_query_status_label_SetText(
                            "Недействительный ключ пользователя.", this.query_pasteslist);

                    /*
                     * Сервер ответил неизвестной ошибкой.
                     */
                    else
                        this.ui_query_status_label_SetText(
                            "Не удалось загрузить данные о файлах.", this.query_pasteslist);
                }
            }
            // Не удалось выполнить запрос
            else
                this.ui_query_status_label_SetText
                        ("Не удалось выполнить запрос на обновление данных о файлах.");
        }

        // Работа фонового потока при обнаружении изменений в списке файлов
        private void query_pasteslist_backgroundworker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Обновляем интерфейс из параллельного потока
            if (this.InvokeRequired)
                this.Invoke(new Application.ui_UpdateHandler(this.ui_worksplace_pasteslist_Update));
            // Обновляем интерфейс из текущего потока
            else
                this.ui_worksplace_pasteslist_Update();
        }

        // Работа фонового потока, отвечающего за запуск фонового потока
        private void query_looprun_backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Запуск цикличного обновления данных (1 раз в cекунду)
            while (true)
            {
                // Запуск сбора данных пользователя
                if (!this.query_userinfo_backgroundworker.IsBusy)
                    this.query_userinfo_backgroundworker.RunWorkerAsync();

                // Запуск сбора данных о файлах
                if (!this.query_pasteslist_backgroundworker.IsBusy)
                    this.query_pasteslist_backgroundworker.RunWorkerAsync();

                // Пауза в 1 секунду
                Thread.Sleep(1000);
            }
        }
    }
}
