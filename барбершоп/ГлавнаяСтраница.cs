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
    public partial class ГлавнаяСтраница : Form
    {
        public DataSet dtSet;
        public DataTable dTable;
        public DataSet dttSet;
        public DataTable dtTable;
        public ГлавнаяСтраница()
        {
            InitializeComponent();
            обновитель();
            обновительв();
        }
        public void обновитель()
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345";
            dataGridView1.AllowUserToAddRows = false;

            string strSQL = "SELECT* FROM `барбершоп.accdb`.`записи`";
            // create Objects of ADOConnection and ADOCommand  
            OleDbConnection myConn = new OleDbConnection(strDSN);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
            myConn.Open();
            dtSet = new DataSet();
            myCmd.Fill(dtSet, "записи");
            dTable = dtSet.Tables[0];
            dataGridView1.DataSource = dtSet.Tables["записи"].DefaultView;

            myConn.Close();
        }
        public void обновительв()
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/User/source/repos/барбершоп — копия/барбершоп/барбершоп.accdb ;Persist Security Info=True;Jet OLEDB:Database Password=12345";
            string strSQL = "SELECT * FROM `барбершоп.accdb`.`сотрудники`";

            OleDbConnection myConn = new OleDbConnection(strDSN);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
            myConn.Open();
            dttSet = new DataSet();
            myCmd.Fill(dtSet, "сотрудники");
            dtTable = dtSet.Tables[0];
            dataGridView2.DataSource = dtSet.Tables["сотрудники"].DefaultView;

           myConn.Close();
        }
        private void ГлавнаяСтраница_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ДобавитьЗапись dop = new ДобавитьЗапись();
            dop.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Записи_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ДобавитьСотрудников сот = new ДобавитьСотрудников();
            сот.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            УдалитьСота zap = new УдалитьСота();
            zap.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                   }

        private void button3_Click(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            УдалитьЗапись zapp = new УдалитьЗапись();
            zapp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            обновитель();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            обновительв();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Статус sat = new Статус();
            sat.ShowDialog();
        }
    }
}
