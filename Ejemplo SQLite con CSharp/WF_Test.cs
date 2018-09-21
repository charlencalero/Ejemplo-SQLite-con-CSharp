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
using System.IO;

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
            // colocar la ruta fisica xe la base de datos en sqlite.

            string pathToFolder = "C:\\BDFacturador.db";

            SQLiteConnection
            m_dbConnection =new SQLiteConnection("Data Source="+ pathToFolder + ";Version=3;");
            m_dbConnection.Open();
                     
            //string sql = "select num_ruc,tip_docu,substr(FEC_CARG,7)||'-'||substr(FEC_CARG,4,2)||'-'||substr(FEC_CARG,1,2) AS FECHA  from TXXXX_BANDFACT";

            string sql = "select *  from TXXXX_PARAM";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            // SQLiteDataReader reader = cmd.ExecuteReader();


            DataTable table = new DataTable("BdFacturador");

        
            using (SQLiteDataAdapter dr = new SQLiteDataAdapter(cmd))
            {
                using (new SQLiteCommandBuilder(dr))
                {
                    dr.Fill(table);
                    dr.Update(table);
                }

            }

            dataGridView1.DataSource= table;

        }

        private void WF_Test_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
