using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"data source=Registration.accdb";
            //This is command that inserts into the database
            string dbcommand = "insert into [Registration]([FULLNAME],[PHONENO],[EMAIL]) values ('" +this.textBox1.Text + "','" + this.textBox2.Text +"','" + this.textBox3.Text + "')";
           // string Date = DateTime.Now.ToString();
           // string Logid = "1328601";
           // string status = "Ground Floor";
           // string Time = DateTime.Now.ToString();
            OleDbConnection conn = new OleDbConnection(dbconnection);
            OleDbCommand comm = new OleDbCommand(dbcommand, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            //this links parameters with values 
           // comm.Parameters.AddWithValue("@logid", Logid);
           // comm.Parameters.AddWithValue("@status", status);
          //  comm.Parameters.AddWithValue("@date", Date);
          //  comm.Parameters.AddWithValue("@time", Time);

            conn.Open();//This opens the connection created 
            comm.ExecuteNonQuery();//This exectues the command given    
            conn.Close();//This closes the connection

            await Task.Delay(1500);
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;

        }
    }
}
