using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Sample_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void m_btnGetName_Click(object sender, EventArgs e)
        {
            string dbConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=firstdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sc = new SqlConnection(dbConnStr);
           sc.Open();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            int NameID;

            if (int.TryParse(m_tbID.Text, out NameID))
            {

                cmd.CommandText = "SELECT Name FROM Names WHERE ID = " + NameID;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sc;


                reader = cmd.ExecuteReader();
                if (reader.Read())
                  m_tbName.Text = reader.GetString(0);
            }
            else
            {
                m_tbName.Text = "";
            }

            sc.Close();
        }
    }
}
