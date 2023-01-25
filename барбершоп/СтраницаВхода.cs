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
    public partial class СтраницаВхода : Form
    {
        public СтраницаВхода()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345");
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM `барбершоп.accdb`.`пользователи` WHERE login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'", con);
                    con.Open();
                   
                  OleDbDataReader row;
                    row = cmd.ExecuteReader();
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                         
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Данный пользователь отсутствует", "Не удалось войти");
                    }
                    con.Close();
                    ГлавнаяСтраница nes = new ГлавнаяСтраница();
                    this.Hide();
                    nes.Show();


                }
                else
                {
                    MessageBox.Show("Оба поля должны быть заполнены", "Пустые поля");
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString(), "Information");
            }
        }
    }
}
