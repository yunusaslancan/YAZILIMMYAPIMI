using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
namespace WindowsFormsApp2
{
    class kelimeog
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");

        public string kelime_ogren()
        {
            Random r = new Random();
            int rand = r.Next(1,25);
            
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select turkce_kelime,id from kelimeler where id="+rand;
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            string turkce_kelime="", id = "";
            while(reader.Read())
            {
                
                turkce_kelime= reader.GetValue(0).ToString();
                id = reader.GetValue(1).ToString();
            }
            con.Close();

            return id + " - " +turkce_kelime;
        }
       


        

        }
}
