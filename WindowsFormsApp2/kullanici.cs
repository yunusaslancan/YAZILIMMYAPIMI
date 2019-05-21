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
    class kullanici
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");
        int i;
        public string[] giris(string kullaniciadi,string sifre)
        {
            i = 0;
            string[] uye = new string[3];
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from kullanicilar where kullanici_adi='" + kullaniciadi + "' and sifre = '" + sifre + "'";
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                uye[0] = reader.GetString("adi");
                uye[1] = reader.GetString("kullanici_adi");
                uye[2]=reader.GetString("mail");
                
            }
            con.Close();

            return uye;
        }


        public int kayitol (string adi,string kullanici_adi,string mail,string sifre)
        {
            int donut = 0;
            

            try
            {
                con.Open();
                // ekleme komutunu tanımladım ve insert sorgusunu yazdım.

                MySqlCommand ekle = new MySqlCommand("insert into kullanicilar(adi,kullanici_adi,mail,sifre) values  ('"+adi+"','" + kullanici_adi + "','" + mail + "','" + sifre + "')", con);

                // sorugusunu çalıştırıyorum 

                object sonuc = null;
                sonuc = ekle.ExecuteNonQuery(); // Sorgu çalıştı ve dönen değer objec türünden değişken geçti eğer değişken boş değilse eklendi boşsa eklenmedi

                if (sonuc != null)
                {
                    donut = 1;
                }

                con.Close();

            }
            catch (Exception HataYakala)
            {
                MessageBox.Show("Hata:" + HataYakala.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return donut;

        }
    }
}
