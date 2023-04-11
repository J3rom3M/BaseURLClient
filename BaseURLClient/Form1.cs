using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using BaseURLClientLib;

namespace BaseURLClient
{
    public partial class Form1 : Form
    {
        private void FillIt(string szQuery)
        {
            MySqlConnection conn;
            MySqlDataAdapter adapt;
            DataSet datas;

            conn = null;
            try
            {
                BaseURLClientLib.ConnectSQL Connect = new ConnectSQL();
                Connect.ConnectFileTransfert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string szGroup = "categorie";
            FillIt("select url,count,categorie from feedback.urls group by " + szGroup);
        }
    }
}