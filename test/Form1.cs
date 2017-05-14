using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;//подключаем пространства имен
using MySql.Data.MySqlClient;//подключаем пространства имен

namespace test
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            string sql = "SELECT * FROM students";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(1), reader.GetString(2) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MessageBox.Show("No rows found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message + " nananan");
            }
        }
        // connection to MySql server
        static string connStr = "server=localhost;user=root;database=test;port=3306;password='';";
        MySqlConnection conn = new MySqlConnection(connStr);
        
        private void btn_Click(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM students";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {                 
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(1), reader.GetString(2) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MessageBox.Show("No rows found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message + " nananan");
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {                      
            string insertQuery = "INSERT INTO `students`  (`num`, `FirstName`, `LastName`, `Birthday`) VALUES (NULL, '" + txtName.Text  + "', '" + txtLname.Text + "', '" + dateBday.Text + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);

           try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }
                else
                {
                    MessageBox.Show("Data Not Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
