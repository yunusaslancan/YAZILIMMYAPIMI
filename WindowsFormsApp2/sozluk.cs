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
    class sozluk
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");

        public string ingilizce_cevir(string turkce_kelime)
        {
            string ingilizce_kelime = null;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from kelimeler where turkce_kelime='" + turkce_kelime + "'";
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ingilizce_kelime = reader.GetString("ingilizce_kelime");
            }
            con.Close();
            return ingilizce_kelime;


        } 
        public string turkce_cevir(string ingilizce_kelime)
        {
            string turkce_kelime = null;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from kelimeler where ingilizce_kelime='" + ingilizce_kelime + "'";
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                turkce_kelime = reader.GetString("turkce_kelime");
            }
            con.Close();
            return turkce_kelime;
        }
    }
}
