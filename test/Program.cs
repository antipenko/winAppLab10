using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
            //измените имя бд на ваше, а также имя пользователя и пароль если нужно
            string connStr = "server=localhost;user=root;database=test;port=3306;password=root;";
            var conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Подключаемся к MySQL...");
                String strConn = "Подключаемся к MySQL..";
                
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Соединение закрыто. Готово!");
        }
    }
}
