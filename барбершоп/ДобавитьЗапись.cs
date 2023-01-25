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
    public partial class ДобавитьЗапись : Form
    {
        public ДобавитьЗапись()
        {
            InitializeComponent();
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345";

            OleDbConnection mcon = new OleDbConnection(connString);
            mcon.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT `Имя` FROM `барбершоп.accdb`.`сотрудники`", mcon);
            OleDbDataReader reader = cmd.ExecuteReader();
            int itemCodeOrdinal = reader.GetOrdinal("Имя");
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["Имя"].ToString());
            }
            reader.Close();
            mcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                                                                                                                                                                                                                                                                                                                                                   try
            {
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345";

                OleDbConnection mcon = new OleDbConnection(connString);
                mcon.Open();
                Random ran = new Random();
                int a = ran.Next(1, 1000);
                string cmdText = "INSERT INTO `барбершоп.accdb`.`записи` (`idЗаписи`, `ИмяКлиента`, `ВремяЗаписи`, `ТипУслуги`, `Цена`, `ИмяМастера`, `НомерКлиента`,`Статус`) VALUES (@id,@name,@data,@action,@barber,@price,@number,'Вожиданий')";
                OleDbCommand cmd = new OleDbCommand(cmdText, mcon);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@data", comboBox1.Text +":"+ dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@id", a);
                cmd.Parameters.AddWithValue("@action", textBox3.Text);
                cmd.Parameters.AddWithValue("@barber", textBox4.Text);
                cmd.Parameters.AddWithValue("@price",comboBox2.Text);
                cmd.Parameters.AddWithValue("@number", textBox6.Text);
                cmd.ExecuteNonQuery();
               
                MessageBox.Show("Добавлено");
                ГлавнаяСтраница glav = new ГлавнаяСтраница();
                glav.dTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ДобавитьЗапись_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "барбершопDataSet.сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.барбершопDataSet.сотрудники);

        }
    }
}
