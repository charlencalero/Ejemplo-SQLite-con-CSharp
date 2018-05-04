using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Ejemplo_SQLite_con_CSharp
{
    public partial class WF_Test : Form
    {
        public WF_Test()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection
            m_dbConnection =new SQLiteConnection("Data Source=BDSQLite/BDFacturador.sqlite;Version=3;");
            m_dbConnection.Open();

         
            string sql = "select * from TXXXX_BANDFACT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);

        }

        private void WF_Test_Load(object sender, EventArgs e)
        {

        }
    }
}
