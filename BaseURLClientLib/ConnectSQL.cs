using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
using System.Windows.Forms;

namespace BaseURLClientLib
{
    public class ConnectSQL
    {
        public int ConnectFileTransfert()
        {
            try
            {
                MySqlConnection conn;
                MySqlDataAdapter adapt;
                DataSet datas;
                MySqlDataReader reader;

                string szGroup;
                szGroup = "categorie";
                conn = new MySqlConnection("Server=94.23.2.166;Port=3306;DataBase=feedback;User id=utilisateur;Password=d4t4b4$34dm1n;");
                conn.Open();
                adapt = new MySqlDataAdapter();
                adapt.SelectCommand = new MySqlCommand("select url,count,categorie from feedback.urls group by " + szGroup, conn);
                datas = new DataSet();
                adapt.Fill(datas);
                reader = adapt.SelectCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Ici effectuer la mise en place de Htable ou d'un tableau a "x" colonnes afin d'y deposer les donnees obtenues de la requete SQL
                    // Et ce dans le but de redistribuer le tout dans le dataGridView pour chaque colonne respective.
                    string sz = (string)reader["Nom"];
                    Console.WriteLine("Les Noms est : " + sz);
                    Console.Read();
                }
                reader.Close();
                reader = null;
                conn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message = " + ex.StackTrace);
                return 0;
            }
        }
    }
}
