namespace PBDesk
{
    partial class Application
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.ui_authorization_groupbox = new System.Windows.Forms.GroupBox();
            this.ui_authorization_panel = new System.Windows.Forms.Panel();
            this.ui_authorization_password_textbox = new System.Windows.Forms.TextBox();
            this.ui_authorization_registration_linklabel = new System.Windows.Forms.LinkLabel();
            this.ui_authorization_signin_button = new System.Windows.Forms.Button();
            this.ui_authorization_remember_checkbox = new System.Windows.Forms.CheckBox();
            this.ui_authorization_login_textbox = new System.Windows.Forms.TextBox();
            this.ui_authorization_password_label = new System.Windows.Forms.Label();
            this.ui_authorization_login_label = new System.Windows.Forms.Label();
            this.query_signin_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.query_userinfo_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.ui_workplace_groupbox = new System.Windows.Forms.GroupBox();
            this.ui_workplace_editor_close_button = new System.Windows.Forms.Button();
            this.ui_workplace_editor_save_button = new System.Windows.Forms.Button();
            this.ui_workplace_editor_filelink_linklabel = new System.Windows.Forms.LinkLabel();
            this.ui_workplace_editor_delete_button = new System.Windows.Forms.Button();
            this.ui_workplace_editor_create_button = new System.Windows.Forms.Button();
            this.ui_workplace_editor_tabcontrol = new System.Windows.Forms.TabControl();
            this.ui_workplace_files_treeview = new System.Windows.Forms.TreeView();
            this.ui_workplace_userinfo_groupbox = new System.Windows.Forms.GroupBox();
            this.ui_workplace_userinfo_signout_button = new System.Windows.Forms.Button();
            this.ui_workplace_userinfo_username_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_tablelayoutpanel = new System.Windows.Forms.TableLayoutPanel();
            this.ui_workplace_userinfo_location_name_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_email_name_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_website_name_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_accounttype_name_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_accounttype_value_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_email_value_linklabel = new System.Windows.Forms.LinkLabel();
            this.ui_workplace_userinfo_website_value_linklabel = new System.Windows.Forms.LinkLabel();
            this.ui_workplace_userinfo_location_value_label = new System.Windows.Forms.Label();
            this.ui_workplace_userinfo_avatar_picturebox = new System.Windows.Forms.PictureBox();
            this.ui_query_status_panel = new System.Windows.Forms.Panel();
            this.ui_query_status_label = new System.Windows.Forms.Label();
            this.query_looprun_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.query_pasteslist_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.query_textfile_open_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.ui_savefile_groupbox = new System.Windows.Forms.GroupBox();
            this.ui_savefile_panel = new System.Windows.Forms.Panel();
            this.ui_savefile_save_button = new System.Windows.Forms.Button();
            this.ui_savefile_cancel_button = new System.Windows.Forms.Button();
            this.ui_savefile_access_combobox = new System.Windows.Forms.ComboBox();
            this.ui_savefile_access_label = new System.Windows.Forms.Label();
            this.ui_savefile_expiredate_combobox = new System.Windows.Forms.ComboBox();
            this.ui_savefile_expiredate_label = new System.Windows.Forms.Label();
            this.ui_savefile_fileformat_combobox = new System.Windows.Forms.ComboBox();
            this.ui_savefile_fileformat_label = new System.Windows.Forms.Label();
            this.ui_savefile_filename_textbox = new System.Windows.Forms.TextBox();
            this.ui_savefile_filename_label = new System.Windows.Forms.Label();
            this.query_createfile_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.query_deletefile_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.userdata_get_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.userdata_set_backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.ui_authorization_groupbox.SuspendLayout();
            this.ui_authorization_panel.SuspendLayout();
            this.ui_workplace_groupbox.SuspendLayout();
            this.ui_workplace_userinfo_groupbox.SuspendLayout();
            this.ui_workplace_userinfo_tablelayoutpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_workplace_userinfo_avatar_picturebox)).BeginInit();
            this.ui_query_status_panel.SuspendLayout();
            this.ui_savefile_groupbox.SuspendLayout();
            this.ui_savefile_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_authorization_groupbox
            // 
            this.ui_authorization_groupbox.BackColor = System.Drawing.SystemColors.Control;
            this.ui_authorization_groupbox.Controls.Add(this.ui_authorization_panel);
            this.ui_authorization_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_authorization_groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ui_authorization_groupbox.Location = new System.Drawing.Point(0, 0);
            this.ui_authorization_groupbox.Name = "ui_authorization_groupbox";
            this.ui_authorization_groupbox.Size = new System.Drawing.Size(894, 525);
            this.ui_authorization_groupbox.TabIndex = 0;
            this.ui_authorization_groupbox.TabStop = false;
            this.ui_authorization_groupbox.Text = "Авторизация на Pastebin";
            // 
            // ui_authorization_panel
            // 
            this.ui_authorization_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_password_textbox);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_registration_linklabel);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_signin_button);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_remember_checkbox);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_login_textbox);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_password_label);
            this.ui_authorization_panel.Controls.Add(this.ui_authorization_login_label);
            this.ui_authorization_panel.Location = new System.Drawing.Point(254, 207);
            this.ui_authorization_panel.Name = "ui_authorization_panel";
            this.ui_authorization_panel.Size = new System.Drawing.Size(402, 136);
            this.ui_authorization_panel.TabIndex = 0;
            // 
            // ui_authorization_password_textbox
            // 
            this.ui_authorization_password_textbox.Location = new System.Drawing.Point(83, 35);
            this.ui_authorization_password_textbox.Name = "ui_authorization_password_textbox";
            this.ui_authorization_password_textbox.PasswordChar = '*';
            this.ui_authorization_password_textbox.Size = new System.Drawing.Size(306, 24);
            this.ui_authorization_password_textbox.TabIndex = 9;
            this.ui_authorization_password_textbox.TextChanged += new System.EventHandler(this.ui_authorization_password_textbox_TextChanged);
            // 
            // ui_authorization_registration_linklabel
            // 
            this.ui_authorization_registration_linklabel.AutoSize = true;
            this.ui_authorization_registration_linklabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ui_authorization_registration_linklabel.Location = new System.Drawing.Point(294, 72);
            this.ui_authorization_registration_linklabel.Name = "ui_authorization_registration_linklabel";
            this.ui_authorization_registration_linklabel.Size = new System.Drawing.Size(95, 18);
            this.ui_authorization_registration_linklabel.TabIndex = 7;
            this.ui_authorization_registration_linklabel.TabStop = true;
            this.ui_authorization_registration_linklabel.Text = "Регистрация";
            this.ui_authorization_registration_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ui_authorization_registration_linklabel_LinkClicked);
            // 
            // ui_authorization_signin_button
            // 
            this.ui_authorization_signin_button.Enabled = false;
            this.ui_authorization_signin_button.Location = new System.Drawing.Point(15, 99);
            this.ui_authorization_signin_button.Name = "ui_authorization_signin_button";
            this.ui_authorization_signin_button.Size = new System.Drawing.Size(374, 34);
            this.ui_authorization_signin_button.TabIndex = 5;
            this.ui_authorization_signin_button.Text = "Войти";
            this.ui_authorization_signin_button.UseVisualStyleBackColor = true;
            this.ui_authorization_signin_button.Click += new System.EventHandler(this.ui_authorization_signin_button_Click);
            // 
            // ui_authorization_remember_checkbox
            // 
            this.ui_authorization_remember_checkbox.AutoSize = true;
            this.ui_authorization_remember_checkbox.Location = new System.Drawing.Point(15, 71);
            this.ui_authorization_remember_checkbox.Name = "ui_authorization_remember_checkbox";
            this.ui_authorization_remember_checkbox.Size = new System.Drawing.Size(165, 22);
            this.ui_authorization_remember_checkbox.TabIndex = 4;
            this.ui_authorization_remember_checkbox.Text = "Запомнить аккаунт";
            this.ui_authorization_remember_checkbox.UseVisualStyleBackColor = true;
            // 
            // ui_authorization_login_textbox
            // 
            this.ui_authorization_login_textbox.Location = new System.Drawing.Point(83, 3);
            this.ui_authorization_login_textbox.Name = "ui_authorization_login_textbox";
            this.ui_authorization_login_textbox.Size = new System.Drawing.Size(306, 24);
            this.ui_authorization_login_textbox.TabIndex = 3;
            this.ui_authorization_login_textbox.TextChanged += new System.EventHandler(this.ui_authorization_login_textbox_TextChanged);
            // 
            // ui_authorization_password_label
            // 
            this.ui_authorization_password_label.AutoSize = true;
            this.ui_authorization_password_label.Location = new System.Drawing.Point(12, 38);
            this.ui_authorization_password_label.Name = "ui_authorization_password_label";
            this.ui_authorization_password_label.Size = new System.Drawing.Size(65, 18);
            this.ui_authorization_password_label.TabIndex = 2;
            this.ui_authorization_password_label.Text = "Пароль:";
            // 
            // ui_authorization_login_label
            // 
            this.ui_authorization_login_label.AutoSize = true;
            this.ui_authorization_login_label.Location = new System.Drawing.Point(12, 6);
            this.ui_authorization_login_label.Name = "ui_authorization_login_label";
            this.ui_authorization_login_label.Size = new System.Drawing.Size(58, 18);
            this.ui_authorization_login_label.TabIndex = 0;
            this.ui_authorization_login_label.Text = "Логин: ";
            // 
            // query_signin_backgroundworker
            // 
            this.query_signin_backgroundworker.WorkerSupportsCancellation = true;
            this.query_signin_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_signin_backgroundworker_DoWork);
            this.query_signin_backgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.query_signin_backgroundworker_RunWorkerCompleted);
            // 
            // query_userinfo_backgroundworker
            // 
            this.query_userinfo_backgroundworker.WorkerReportsProgress = true;
            this.query_userinfo_backgroundworker.WorkerSupportsCancellation = true;
            this.query_userinfo_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_userinfo_backgroundworker_DoWork);
            this.query_userinfo_backgroundworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.query_userinfo_backgroundworker_ProgressChanged);
            // 
            // ui_workplace_groupbox
            // 
            this.ui_workplace_groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_close_button);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_save_button);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_filelink_linklabel);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_delete_button);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_create_button);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_editor_tabcontrol);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_files_treeview);
            this.ui_workplace_groupbox.Controls.Add(this.ui_workplace_userinfo_groupbox);
            this.ui_workplace_groupbox.Location = new System.Drawing.Point(1, -1);
            this.ui_workplace_groupbox.Name = "ui_workplace_groupbox";
            this.ui_workplace_groupbox.Size = new System.Drawing.Size(889, 519);
            this.ui_workplace_groupbox.TabIndex = 0;
            this.ui_workplace_groupbox.TabStop = false;
            this.ui_workplace_groupbox.Text = "Рабочее место";
            // 
            // ui_workplace_editor_close_button
            // 
            this.ui_workplace_editor_close_button.Enabled = false;
            this.ui_workplace_editor_close_button.Location = new System.Drawing.Point(654, 13);
            this.ui_workplace_editor_close_button.Name = "ui_workplace_editor_close_button";
            this.ui_workplace_editor_close_button.Size = new System.Drawing.Size(90, 30);
            this.ui_workplace_editor_close_button.TabIndex = 7;
            this.ui_workplace_editor_close_button.Text = "Закрыть";
            this.ui_workplace_editor_close_button.UseVisualStyleBackColor = true;
            this.ui_workplace_editor_close_button.Click += new System.EventHandler(this.ui_workplace_editor_close_button_Click);
            // 
            // ui_workplace_editor_save_button
            // 
            this.ui_workplace_editor_save_button.Enabled = false;
            this.ui_workplace_editor_save_button.Location = new System.Drawing.Point(474, 13);
            this.ui_workplace_editor_save_button.Name = "ui_workplace_editor_save_button";
            this.ui_workplace_editor_save_button.Size = new System.Drawing.Size(90, 30);
            this.ui_workplace_editor_save_button.TabIndex = 6;
            this.ui_workplace_editor_save_button.Text = "Сохранить";
            this.ui_workplace_editor_save_button.UseVisualStyleBackColor = true;
            this.ui_workplace_editor_save_button.Click += new System.EventHandler(this.ui_workplace_editor_save_button_Click);
            // 
            // ui_workplace_editor_filelink_linklabel
            // 
            this.ui_workplace_editor_filelink_linklabel.AutoEllipsis = true;
            this.ui_workplace_editor_filelink_linklabel.AutoSize = true;
            this.ui_workplace_editor_filelink_linklabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ui_workplace_editor_filelink_linklabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ui_workplace_editor_filelink_linklabel.Location = new System.Drawing.Point(747, 19);
            this.ui_workplace_editor_filelink_linklabel.Margin = new System.Windows.Forms.Padding(0);
            this.ui_workplace_editor_filelink_linklabel.Name = "ui_workplace_editor_filelink_linklabel";
            this.ui_workplace_editor_filelink_linklabel.Size = new System.Drawing.Size(133, 17);
            this.ui_workplace_editor_filelink_linklabel.TabIndex = 5;
            this.ui_workplace_editor_filelink_linklabel.TabStop = true;
            this.ui_workplace_editor_filelink_linklabel.Text = "Файл не загружен.";
            this.ui_workplace_editor_filelink_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ui_workplace_editor_filelink_linklabel_LinkClicked);
            // 
            // ui_workplace_editor_delete_button
            // 
            this.ui_workplace_editor_delete_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_workplace_editor_delete_button.Enabled = false;
            this.ui_workplace_editor_delete_button.Location = new System.Drawing.Point(564, 13);
            this.ui_workplace_editor_delete_button.Name = "ui_workplace_editor_delete_button";
            this.ui_workplace_editor_delete_button.Size = new System.Drawing.Size(90, 30);
            this.ui_workplace_editor_delete_button.TabIndex = 4;
            this.ui_workplace_editor_delete_button.Text = "Удалить";
            this.ui_workplace_editor_delete_button.UseVisualStyleBackColor = true;
            this.ui_workplace_editor_delete_button.Click += new System.EventHandler(this.ui_workplace_editor_delete_button_Click);
            // 
            // ui_workplace_editor_create_button
            // 
            this.ui_workplace_editor_create_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_workplace_editor_create_button.Location = new System.Drawing.Point(384, 13);
            this.ui_workplace_editor_create_button.Name = "ui_workplace_editor_create_button";
            this.ui_workplace_editor_create_button.Size = new System.Drawing.Size(90, 30);
            this.ui_workplace_editor_create_button.TabIndex = 0;
            this.ui_workplace_editor_create_button.Text = "Создать";
            this.ui_workplace_editor_create_button.UseVisualStyleBackColor = true;
            this.ui_workplace_editor_create_button.Click += new System.EventHandler(this.ui_workplace_editor_create_button_Click);
            // 
            // ui_workplace_editor_tabcontrol
            // 
            this.ui_workplace_editor_tabcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_workplace_editor_tabcontrol.Enabled = false;
            this.ui_workplace_editor_tabcontrol.Location = new System.Drawing.Point(384, 45);
            this.ui_workplace_editor_tabcontrol.Name = "ui_workplace_editor_tabcontrol";
            this.ui_workplace_editor_tabcontrol.SelectedIndex = 0;
            this.ui_workplace_editor_tabcontrol.Size = new System.Drawing.Size(501, 468);
            this.ui_workplace_editor_tabcontrol.TabIndex = 2;
            this.ui_workplace_editor_tabcontrol.SelectedIndexChanged += new System.EventHandler(this.ui_workplace_editor_tabcontrol_SelectedIndexChanged);
            this.ui_workplace_editor_tabcontrol.Selected += new System.Windows.Forms.TabControlEventHandler(this.ui_workplace_editor_tabcontrol_Selected);
            // 
            // ui_workplace_files_treeview
            // 
            this.ui_workplace_files_treeview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_workplace_files_treeview.LineColor = System.Drawing.Color.Empty;
            this.ui_workplace_files_treeview.Location = new System.Drawing.Point(6, 300);
            this.ui_workplace_files_treeview.Name = "ui_workplace_files_treeview";
            this.ui_workplace_files_treeview.Size = new System.Drawing.Size(372, 213);
            this.ui_workplace_files_treeview.TabIndex = 1;
            this.ui_workplace_files_treeview.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ui_workplace_files_treeview_NodeMouseDoubleClick);
            // 
            // ui_workplace_userinfo_groupbox
            // 
            this.ui_workplace_userinfo_groupbox.Controls.Add(this.ui_workplace_userinfo_signout_button);
            this.ui_workplace_userinfo_groupbox.Controls.Add(this.ui_workplace_userinfo_username_label);
            this.ui_workplace_userinfo_groupbox.Controls.Add(this.ui_workplace_userinfo_tablelayoutpanel);
            this.ui_workplace_userinfo_groupbox.Controls.Add(this.ui_workplace_userinfo_avatar_picturebox);
            this.ui_workplace_userinfo_groupbox.Location = new System.Drawing.Point(6, 23);
            this.ui_workplace_userinfo_groupbox.Name = "ui_workplace_userinfo_groupbox";
            this.ui_workplace_userinfo_groupbox.Size = new System.Drawing.Size(372, 271);
            this.ui_workplace_userinfo_groupbox.TabIndex = 0;
            this.ui_workplace_userinfo_groupbox.TabStop = false;
            this.ui_workplace_userinfo_groupbox.Text = "Информация о пользователе";
            // 
            // ui_workplace_userinfo_signout_button
            // 
            this.ui_workplace_userinfo_signout_button.Enabled = false;
            this.ui_workplace_userinfo_signout_button.Location = new System.Drawing.Point(95, 74);
            this.ui_workplace_userinfo_signout_button.Name = "ui_workplace_userinfo_signout_button";
            this.ui_workplace_userinfo_signout_button.Size = new System.Drawing.Size(271, 32);
            this.ui_workplace_userinfo_signout_button.TabIndex = 3;
            this.ui_workplace_userinfo_signout_button.Text = "Выйти";
            this.ui_workplace_userinfo_signout_button.UseVisualStyleBackColor = true;
            this.ui_workplace_userinfo_signout_button.Click += new System.EventHandler(this.ui_workplace_userinfo_signout_button_Click);
            // 
            // ui_workplace_userinfo_username_label
            // 
            this.ui_workplace_userinfo_username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ui_workplace_userinfo_username_label.Location = new System.Drawing.Point(92, 26);
            this.ui_workplace_userinfo_username_label.Name = "ui_workplace_userinfo_username_label";
            this.ui_workplace_userinfo_username_label.Size = new System.Drawing.Size(274, 45);
            this.ui_workplace_userinfo_username_label.TabIndex = 2;
            this.ui_workplace_userinfo_username_label.Text = "Информация отсутствует";
            this.ui_workplace_userinfo_username_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ui_workplace_userinfo_tablelayoutpanel
            // 
            this.ui_workplace_userinfo_tablelayoutpanel.AutoScroll = true;
            this.ui_workplace_userinfo_tablelayoutpanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_workplace_userinfo_tablelayoutpanel.BackColor = System.Drawing.Color.Transparent;
            this.ui_workplace_userinfo_tablelayoutpanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ui_workplace_userinfo_tablelayoutpanel.ColumnCount = 2;
            this.ui_workplace_userinfo_tablelayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ui_workplace_userinfo_tablelayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_location_name_label, 0, 2);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_email_name_label, 0, 0);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_website_name_label, 0, 1);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_accounttype_name_label, 0, 3);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_accounttype_value_label, 1, 3);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_email_value_linklabel, 1, 0);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_website_value_linklabel, 1, 1);
            this.ui_workplace_userinfo_tablelayoutpanel.Controls.Add(this.ui_workplace_userinfo_location_value_label, 1, 2);
            this.ui_workplace_userinfo_tablelayoutpanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ui_workplace_userinfo_tablelayoutpanel.Location = new System.Drawing.Point(6, 111);
            this.ui_workplace_userinfo_tablelayoutpanel.Margin = new System.Windows.Forms.Padding(2);
            this.ui_workplace_userinfo_tablelayoutpanel.Name = "ui_workplace_userinfo_tablelayoutpanel";
            this.ui_workplace_userinfo_tablelayoutpanel.Padding = new System.Windows.Forms.Padding(2);
            this.ui_workplace_userinfo_tablelayoutpanel.RowCount = 4;
            this.ui_workplace_userinfo_tablelayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ui_workplace_userinfo_tablelayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ui_workplace_userinfo_tablelayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ui_workplace_userinfo_tablelayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ui_workplace_userinfo_tablelayoutpanel.Size = new System.Drawing.Size(360, 155);
            this.ui_workplace_userinfo_tablelayoutpanel.TabIndex = 1;
            // 
            // ui_workplace_userinfo_location_name_label
            // 
            this.ui_workplace_userinfo_location_name_label.AutoSize = true;
            this.ui_workplace_userinfo_location_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_location_name_label.Location = new System.Drawing.Point(6, 77);
            this.ui_workplace_userinfo_location_name_label.Name = "ui_workplace_userinfo_location_name_label";
            this.ui_workplace_userinfo_location_name_label.Size = new System.Drawing.Size(152, 36);
            this.ui_workplace_userinfo_location_name_label.TabIndex = 1;
            this.ui_workplace_userinfo_location_name_label.Text = "Местоположение:";
            this.ui_workplace_userinfo_location_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_email_name_label
            // 
            this.ui_workplace_userinfo_email_name_label.AutoSize = true;
            this.ui_workplace_userinfo_email_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_email_name_label.Location = new System.Drawing.Point(6, 3);
            this.ui_workplace_userinfo_email_name_label.Name = "ui_workplace_userinfo_email_name_label";
            this.ui_workplace_userinfo_email_name_label.Size = new System.Drawing.Size(152, 36);
            this.ui_workplace_userinfo_email_name_label.TabIndex = 0;
            this.ui_workplace_userinfo_email_name_label.Text = "Электронная почта:";
            this.ui_workplace_userinfo_email_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_website_name_label
            // 
            this.ui_workplace_userinfo_website_name_label.AutoSize = true;
            this.ui_workplace_userinfo_website_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_website_name_label.Location = new System.Drawing.Point(6, 40);
            this.ui_workplace_userinfo_website_name_label.Name = "ui_workplace_userinfo_website_name_label";
            this.ui_workplace_userinfo_website_name_label.Size = new System.Drawing.Size(152, 36);
            this.ui_workplace_userinfo_website_name_label.TabIndex = 2;
            this.ui_workplace_userinfo_website_name_label.Text = "Веб-сайт:";
            this.ui_workplace_userinfo_website_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_accounttype_name_label
            // 
            this.ui_workplace_userinfo_accounttype_name_label.AutoSize = true;
            this.ui_workplace_userinfo_accounttype_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_accounttype_name_label.Location = new System.Drawing.Point(6, 114);
            this.ui_workplace_userinfo_accounttype_name_label.Name = "ui_workplace_userinfo_accounttype_name_label";
            this.ui_workplace_userinfo_accounttype_name_label.Size = new System.Drawing.Size(152, 38);
            this.ui_workplace_userinfo_accounttype_name_label.TabIndex = 3;
            this.ui_workplace_userinfo_accounttype_name_label.Text = "Тип аккаунта:";
            this.ui_workplace_userinfo_accounttype_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_accounttype_value_label
            // 
            this.ui_workplace_userinfo_accounttype_value_label.AutoEllipsis = true;
            this.ui_workplace_userinfo_accounttype_value_label.AutoSize = true;
            this.ui_workplace_userinfo_accounttype_value_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_accounttype_value_label.Location = new System.Drawing.Point(165, 114);
            this.ui_workplace_userinfo_accounttype_value_label.Name = "ui_workplace_userinfo_accounttype_value_label";
            this.ui_workplace_userinfo_accounttype_value_label.Size = new System.Drawing.Size(189, 38);
            this.ui_workplace_userinfo_accounttype_value_label.TabIndex = 5;
            this.ui_workplace_userinfo_accounttype_value_label.Text = "Информация отсутствует";
            this.ui_workplace_userinfo_accounttype_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_email_value_linklabel
            // 
            this.ui_workplace_userinfo_email_value_linklabel.AutoEllipsis = true;
            this.ui_workplace_userinfo_email_value_linklabel.AutoSize = true;
            this.ui_workplace_userinfo_email_value_linklabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_email_value_linklabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ui_workplace_userinfo_email_value_linklabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ui_workplace_userinfo_email_value_linklabel.Location = new System.Drawing.Point(165, 3);
            this.ui_workplace_userinfo_email_value_linklabel.Name = "ui_workplace_userinfo_email_value_linklabel";
            this.ui_workplace_userinfo_email_value_linklabel.Size = new System.Drawing.Size(189, 36);
            this.ui_workplace_userinfo_email_value_linklabel.TabIndex = 6;
            this.ui_workplace_userinfo_email_value_linklabel.TabStop = true;
            this.ui_workplace_userinfo_email_value_linklabel.Text = "Информация отсутствует";
            this.ui_workplace_userinfo_email_value_linklabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_workplace_userinfo_email_value_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ui_workplace_userinfo_email_value_linklabel_LinkClicked);
            // 
            // ui_workplace_userinfo_website_value_linklabel
            // 
            this.ui_workplace_userinfo_website_value_linklabel.AutoEllipsis = true;
            this.ui_workplace_userinfo_website_value_linklabel.AutoSize = true;
            this.ui_workplace_userinfo_website_value_linklabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_website_value_linklabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ui_workplace_userinfo_website_value_linklabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ui_workplace_userinfo_website_value_linklabel.Location = new System.Drawing.Point(165, 40);
            this.ui_workplace_userinfo_website_value_linklabel.Name = "ui_workplace_userinfo_website_value_linklabel";
            this.ui_workplace_userinfo_website_value_linklabel.Size = new System.Drawing.Size(189, 36);
            this.ui_workplace_userinfo_website_value_linklabel.TabIndex = 7;
            this.ui_workplace_userinfo_website_value_linklabel.TabStop = true;
            this.ui_workplace_userinfo_website_value_linklabel.Text = "Информация отсутствует";
            this.ui_workplace_userinfo_website_value_linklabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_workplace_userinfo_website_value_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ui_workplace_userinfo_website_value_linklabel_LinkClicked);
            // 
            // ui_workplace_userinfo_location_value_label
            // 
            this.ui_workplace_userinfo_location_value_label.AutoEllipsis = true;
            this.ui_workplace_userinfo_location_value_label.AutoSize = true;
            this.ui_workplace_userinfo_location_value_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_workplace_userinfo_location_value_label.Location = new System.Drawing.Point(165, 77);
            this.ui_workplace_userinfo_location_value_label.Name = "ui_workplace_userinfo_location_value_label";
            this.ui_workplace_userinfo_location_value_label.Size = new System.Drawing.Size(189, 36);
            this.ui_workplace_userinfo_location_value_label.TabIndex = 8;
            this.ui_workplace_userinfo_location_value_label.Text = "Информация отсутствует";
            this.ui_workplace_userinfo_location_value_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_workplace_userinfo_avatar_picturebox
            // 
            this.ui_workplace_userinfo_avatar_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_workplace_userinfo_avatar_picturebox.ErrorImage = null;
            this.ui_workplace_userinfo_avatar_picturebox.Location = new System.Drawing.Point(6, 26);
            this.ui_workplace_userinfo_avatar_picturebox.Name = "ui_workplace_userinfo_avatar_picturebox";
            this.ui_workplace_userinfo_avatar_picturebox.Size = new System.Drawing.Size(80, 80);
            this.ui_workplace_userinfo_avatar_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ui_workplace_userinfo_avatar_picturebox.TabIndex = 0;
            this.ui_workplace_userinfo_avatar_picturebox.TabStop = false;
            // 
            // ui_query_status_panel
            // 
            this.ui_query_status_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ui_query_status_panel.Controls.Add(this.ui_query_status_label);
            this.ui_query_status_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ui_query_status_panel.Location = new System.Drawing.Point(0, 525);
            this.ui_query_status_panel.Name = "ui_query_status_panel";
            this.ui_query_status_panel.Size = new System.Drawing.Size(894, 28);
            this.ui_query_status_panel.TabIndex = 1;
            // 
            // ui_query_status_label
            // 
            this.ui_query_status_label.AutoSize = true;
            this.ui_query_status_label.Location = new System.Drawing.Point(4, 4);
            this.ui_query_status_label.Name = "ui_query_status_label";
            this.ui_query_status_label.Size = new System.Drawing.Size(0, 18);
            this.ui_query_status_label.TabIndex = 0;
            // 
            // query_looprun_backgroundworker
            // 
            this.query_looprun_backgroundworker.WorkerSupportsCancellation = true;
            this.query_looprun_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_looprun_backgroundworker_DoWork);
            // 
            // query_pasteslist_backgroundworker
            // 
            this.query_pasteslist_backgroundworker.WorkerReportsProgress = true;
            this.query_pasteslist_backgroundworker.WorkerSupportsCancellation = true;
            this.query_pasteslist_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_pasteslist_backgroundworker_DoWork);
            this.query_pasteslist_backgroundworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.query_pasteslist_backgroundworker_ProgressChanged);
            // 
            // query_textfile_open_backgroundworker
            // 
            this.query_textfile_open_backgroundworker.WorkerSupportsCancellation = true;
            this.query_textfile_open_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_textfile_open_backgroundworker_DoWork);
            this.query_textfile_open_backgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.query_textfile_open_backgroundworker_RunWorkerCompleted);
            // 
            // ui_savefile_groupbox
            // 
            this.ui_savefile_groupbox.Controls.Add(this.ui_savefile_panel);
            this.ui_savefile_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_savefile_groupbox.Location = new System.Drawing.Point(0, 0);
            this.ui_savefile_groupbox.Name = "ui_savefile_groupbox";
            this.ui_savefile_groupbox.Size = new System.Drawing.Size(894, 525);
            this.ui_savefile_groupbox.TabIndex = 2;
            this.ui_savefile_groupbox.TabStop = false;
            this.ui_savefile_groupbox.Text = "Сохранение нового файла";
            // 
            // ui_savefile_panel
            // 
            this.ui_savefile_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_save_button);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_cancel_button);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_access_combobox);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_access_label);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_expiredate_combobox);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_expiredate_label);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_fileformat_combobox);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_fileformat_label);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_filename_textbox);
            this.ui_savefile_panel.Controls.Add(this.ui_savefile_filename_label);
            this.ui_savefile_panel.Location = new System.Drawing.Point(249, 187);
            this.ui_savefile_panel.Name = "ui_savefile_panel";
            this.ui_savefile_panel.Size = new System.Drawing.Size(398, 168);
            this.ui_savefile_panel.TabIndex = 0;
            // 
            // ui_savefile_save_button
            // 
            this.ui_savefile_save_button.Enabled = false;
            this.ui_savefile_save_button.Location = new System.Drawing.Point(201, 132);
            this.ui_savefile_save_button.Name = "ui_savefile_save_button";
            this.ui_savefile_save_button.Size = new System.Drawing.Size(194, 30);
            this.ui_savefile_save_button.TabIndex = 9;
            this.ui_savefile_save_button.Text = "Сохранить";
            this.ui_savefile_save_button.UseVisualStyleBackColor = true;
            this.ui_savefile_save_button.Click += new System.EventHandler(this.ui_savefile_save_button_Click);
            // 
            // ui_savefile_cancel_button
            // 
            this.ui_savefile_cancel_button.Location = new System.Drawing.Point(6, 132);
            this.ui_savefile_cancel_button.Name = "ui_savefile_cancel_button";
            this.ui_savefile_cancel_button.Size = new System.Drawing.Size(194, 30);
            this.ui_savefile_cancel_button.TabIndex = 8;
            this.ui_savefile_cancel_button.Text = "Отмена";
            this.ui_savefile_cancel_button.UseVisualStyleBackColor = true;
            this.ui_savefile_cancel_button.Click += new System.EventHandler(this.ui_savefile_cancel_button_Click);
            // 
            // ui_savefile_access_combobox
            // 
            this.ui_savefile_access_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_savefile_access_combobox.FormattingEnabled = true;
            this.ui_savefile_access_combobox.Items.AddRange(new object[] {
            "Публичный",
            "Скрытый",
            "Приватный"});
            this.ui_savefile_access_combobox.Location = new System.Drawing.Point(127, 100);
            this.ui_savefile_access_combobox.Name = "ui_savefile_access_combobox";
            this.ui_savefile_access_combobox.Size = new System.Drawing.Size(268, 26);
            this.ui_savefile_access_combobox.TabIndex = 7;
            // 
            // ui_savefile_access_label
            // 
            this.ui_savefile_access_label.AutoSize = true;
            this.ui_savefile_access_label.Location = new System.Drawing.Point(5, 103);
            this.ui_savefile_access_label.Name = "ui_savefile_access_label";
            this.ui_savefile_access_label.Size = new System.Drawing.Size(120, 18);
            this.ui_savefile_access_label.TabIndex = 6;
            this.ui_savefile_access_label.Text = "Режим доступа:";
            // 
            // ui_savefile_expiredate_combobox
            // 
            this.ui_savefile_expiredate_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_savefile_expiredate_combobox.FormattingEnabled = true;
            this.ui_savefile_expiredate_combobox.Items.AddRange(new object[] {
            "Постоянно",
            "10 минут",
            "1 час",
            "1 день",
            "1 неделя",
            "2 недели",
            "1 месяц",
            "6 месяцев",
            "1 год"});
            this.ui_savefile_expiredate_combobox.Location = new System.Drawing.Point(127, 67);
            this.ui_savefile_expiredate_combobox.Name = "ui_savefile_expiredate_combobox";
            this.ui_savefile_expiredate_combobox.Size = new System.Drawing.Size(268, 26);
            this.ui_savefile_expiredate_combobox.TabIndex = 5;
            // 
            // ui_savefile_expiredate_label
            // 
            this.ui_savefile_expiredate_label.AutoSize = true;
            this.ui_savefile_expiredate_label.Location = new System.Drawing.Point(5, 70);
            this.ui_savefile_expiredate_label.Name = "ui_savefile_expiredate_label";
            this.ui_savefile_expiredate_label.Size = new System.Drawing.Size(115, 18);
            this.ui_savefile_expiredate_label.TabIndex = 4;
            this.ui_savefile_expiredate_label.Text = "Срок хранения:";
            // 
            // ui_savefile_fileformat_combobox
            // 
            this.ui_savefile_fileformat_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ui_savefile_fileformat_combobox.FormattingEnabled = true;
            this.ui_savefile_fileformat_combobox.Location = new System.Drawing.Point(127, 34);
            this.ui_savefile_fileformat_combobox.Name = "ui_savefile_fileformat_combobox";
            this.ui_savefile_fileformat_combobox.Size = new System.Drawing.Size(268, 26);
            this.ui_savefile_fileformat_combobox.Sorted = true;
            this.ui_savefile_fileformat_combobox.TabIndex = 3;
            // 
            // ui_savefile_fileformat_label
            // 
            this.ui_savefile_fileformat_label.AutoSize = true;
            this.ui_savefile_fileformat_label.Location = new System.Drawing.Point(3, 39);
            this.ui_savefile_fileformat_label.Name = "ui_savefile_fileformat_label";
            this.ui_savefile_fileformat_label.Size = new System.Drawing.Size(118, 18);
            this.ui_savefile_fileformat_label.TabIndex = 2;
            this.ui_savefile_fileformat_label.Text = "Формат файла:";
            // 
            // ui_savefile_filename_textbox
            // 
            this.ui_savefile_filename_textbox.Location = new System.Drawing.Point(95, 4);
            this.ui_savefile_filename_textbox.Name = "ui_savefile_filename_textbox";
            this.ui_savefile_filename_textbox.Size = new System.Drawing.Size(300, 24);
            this.ui_savefile_filename_textbox.TabIndex = 1;
            this.ui_savefile_filename_textbox.TextChanged += new System.EventHandler(this.ui_savefile_filename_textbox_TextChanged);
            // 
            // ui_savefile_filename_label
            // 
            this.ui_savefile_filename_label.AutoSize = true;
            this.ui_savefile_filename_label.Location = new System.Drawing.Point(3, 7);
            this.ui_savefile_filename_label.Name = "ui_savefile_filename_label";
            this.ui_savefile_filename_label.Size = new System.Drawing.Size(92, 18);
            this.ui_savefile_filename_label.TabIndex = 0;
            this.ui_savefile_filename_label.Text = "Имя файла:";
            // 
            // query_createfile_backgroundworker
            // 
            this.query_createfile_backgroundworker.WorkerSupportsCancellation = true;
            this.query_createfile_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_createfile_backgroundworker_DoWork);
            this.query_createfile_backgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.query_createfile_backgroundworker_RunWorkerCompleted);
            // 
            // query_deletefile_backgroundworker
            // 
            this.query_deletefile_backgroundworker.WorkerSupportsCancellation = true;
            this.query_deletefile_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.query_deletefile_backgroundworker_DoWork);
            this.query_deletefile_backgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.query_deletefile_backgroundworker_RunWorkerCompleted);
            // 
            // userdata_get_backgroundworker
            // 
            this.userdata_get_backgroundworker.WorkerSupportsCancellation = true;
            this.userdata_get_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.userdata_get_backgroundworker_DoWork);
            this.userdata_get_backgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.userdata_get_backgroundworker_RunWorkerCompleted);
            // 
            // userdata_set_backgroundworker
            // 
            this.userdata_set_backgroundworker.WorkerSupportsCancellation = true;
            this.userdata_set_backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.userdata_set_backgroundworker_DoWork);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 553);
            this.Controls.Add(this.ui_authorization_groupbox);
            this.Controls.Add(this.ui_query_status_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(912, 600);
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBDesk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Application_FormClosing);
            this.ui_authorization_groupbox.ResumeLayout(false);
            this.ui_authorization_panel.ResumeLayout(false);
            this.ui_authorization_panel.PerformLayout();
            this.ui_workplace_groupbox.ResumeLayout(false);
            this.ui_workplace_groupbox.PerformLayout();
            this.ui_workplace_userinfo_groupbox.ResumeLayout(false);
            this.ui_workplace_userinfo_tablelayoutpanel.ResumeLayout(false);
            this.ui_workplace_userinfo_tablelayoutpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_workplace_userinfo_avatar_picturebox)).EndInit();
            this.ui_query_status_panel.ResumeLayout(false);
            this.ui_query_status_panel.PerformLayout();
            this.ui_savefile_groupbox.ResumeLayout(false);
            this.ui_savefile_panel.ResumeLayout(false);
            this.ui_savefile_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ui_authorization_groupbox;
        private System.Windows.Forms.Panel ui_authorization_panel;
        private System.Windows.Forms.Label ui_authorization_login_label;
        private System.Windows.Forms.Label ui_authorization_password_label;
        private System.Windows.Forms.Button ui_authorization_signin_button;
        private System.Windows.Forms.CheckBox ui_authorization_remember_checkbox;
        private System.Windows.Forms.TextBox ui_authorization_login_textbox;
        private System.Windows.Forms.LinkLabel ui_authorization_registration_linklabel;
        private System.Windows.Forms.TextBox ui_authorization_password_textbox;
        private System.Windows.Forms.GroupBox ui_workplace_groupbox;
        private System.Windows.Forms.GroupBox ui_workplace_userinfo_groupbox;
        private System.Windows.Forms.Panel ui_query_status_panel;
        private System.Windows.Forms.TreeView ui_workplace_files_treeview;
        private System.Windows.Forms.TabControl ui_workplace_editor_tabcontrol;

        private System.Windows.Forms.Label ui_query_status_label;
        private System.ComponentModel.BackgroundWorker query_signin_backgroundworker;
        private System.ComponentModel.BackgroundWorker query_looprun_backgroundworker;
        private System.ComponentModel.BackgroundWorker query_userinfo_backgroundworker;

        private System.Windows.Forms.Label ui_workplace_userinfo_username_label;
        private System.Windows.Forms.PictureBox ui_workplace_userinfo_avatar_picturebox;
        private System.Windows.Forms.TableLayoutPanel ui_workplace_userinfo_tablelayoutpanel;
        private System.Windows.Forms.Label ui_workplace_userinfo_location_name_label;
        private System.Windows.Forms.Label ui_workplace_userinfo_email_name_label;
        private System.Windows.Forms.Label ui_workplace_userinfo_website_name_label;
        private System.Windows.Forms.Label ui_workplace_userinfo_accounttype_name_label;
        private System.Windows.Forms.Label ui_workplace_userinfo_accounttype_value_label;
        private System.Windows.Forms.LinkLabel ui_workplace_userinfo_email_value_linklabel;
        private System.Windows.Forms.LinkLabel ui_workplace_userinfo_website_value_linklabel;
        private System.Windows.Forms.Label ui_workplace_userinfo_location_value_label;
        private System.Windows.Forms.Button ui_workplace_userinfo_signout_button;
        private System.Windows.Forms.Button ui_workplace_editor_create_button;
        private System.Windows.Forms.Button ui_workplace_editor_delete_button;
        private System.Windows.Forms.LinkLabel ui_workplace_editor_filelink_linklabel;
        private System.ComponentModel.BackgroundWorker query_pasteslist_backgroundworker;
        private System.ComponentModel.BackgroundWorker query_textfile_open_backgroundworker;
        private System.Windows.Forms.Button ui_workplace_editor_close_button;
        private System.Windows.Forms.Button ui_workplace_editor_save_button;
        private System.Windows.Forms.GroupBox ui_savefile_groupbox;
        private System.Windows.Forms.Panel ui_savefile_panel;
        private System.Windows.Forms.ComboBox ui_savefile_expiredate_combobox;
        private System.Windows.Forms.Label ui_savefile_expiredate_label;
        private System.Windows.Forms.ComboBox ui_savefile_fileformat_combobox;
        private System.Windows.Forms.Label ui_savefile_fileformat_label;
        private System.Windows.Forms.TextBox ui_savefile_filename_textbox;
        private System.Windows.Forms.Label ui_savefile_filename_label;
        private System.Windows.Forms.ComboBox ui_savefile_access_combobox;
        private System.Windows.Forms.Label ui_savefile_access_label;
        private System.Windows.Forms.Button ui_savefile_save_button;
        private System.Windows.Forms.Button ui_savefile_cancel_button;
        private System.ComponentModel.BackgroundWorker query_createfile_backgroundworker;
        private System.ComponentModel.BackgroundWorker query_deletefile_backgroundworker;
        private System.ComponentModel.BackgroundWorker userdata_get_backgroundworker;
        private System.ComponentModel.BackgroundWorker userdata_set_backgroundworker;
    }
}

