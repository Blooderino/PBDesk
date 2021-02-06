using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBDesk
{
    static class Program
    {
        // Вы можете получить свой уникальный ключ разработчика здесь: https://pastebin.com/doc_api#1
        private const String DEV_KEY = "f6f0344c4c0452f5191192360484163f";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Application(DEV_KEY));
        }
    }
}
