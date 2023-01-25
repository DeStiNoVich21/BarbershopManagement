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
    public partial class Статус : Form
    {
        public Статус()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345"; ;
            OleDbConnection con = new OleDbConnection(connString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE `барбершоп.accdb`.`записи` SET `Статус` = '"+comboBox1.Text+"' WHERE (`idЗаписи` = '"+textBox3.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            ГлавнаяСтраница glav = new ГлавнаяСтраница();
            glav.dTable.AcceptChanges();
            MessageBox.Show("Добавлено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
