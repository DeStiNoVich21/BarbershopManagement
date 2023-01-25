using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace барбершоп
{
    public partial class ДобавитьСотрудников : Form
    {
        public ДобавитьСотрудников()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345"; ;
                OleDbConnection mcon = new OleDbConnection(connString);
                mcon.Open();
                Random ran = new Random();
                int a = ran.Next(1, 1000);
                string cmdText ="INSERT INTO `барбершоп.accdb`.`сотрудники` (`idСотрудника`, `Фамилия`, `Имя`, `Отчество`, `Должность`, `ДатаРождения`) VALUES(@id,@name,@firstname,@fatherhood,@Job,@data)";
                OleDbCommand cmd = new OleDbCommand(cmdText, mcon);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@data",dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@id", a);
                cmd.Parameters.AddWithValue("@fatherhood", textBox3.Text);
                cmd.Parameters.AddWithValue("@Job", textBox4.Text);
                cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
             
                cmd.ExecuteNonQuery();
                ГлавнаяСтраница glav = new ГлавнаяСтраница();
                glav.dtTable.AcceptChanges();
                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
