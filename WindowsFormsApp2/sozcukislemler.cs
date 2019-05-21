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
    class sozcukislemler
    {   public MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");

        public int kelimeekle(string turkce_kelime, string ingilizce_kelime)
        {
            int donut = 0;
            try
            {
                con.Open();
                // ekleme komutunu tanımladım ve insert sorgusunu yazdım.

                MySqlCommand ekle = new MySqlCommand("insert into kelimeler(turkce_kelime,ingilizce_kelime) values  ('" + turkce_kelime + "','" + ingilizce_kelime + "')", con);

                // sorugusunu çalıştırıyorum 

                object sonuc = null;
                sonuc = ekle.ExecuteNonQuery(); // Sorgu çalıştı ve dönen değer objec türünden değişken geçti eğer değişken boş değilse eklendi boşsa eklenmedi

                if (sonuc != null)
                {
                    donut = 1;
                }

                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return donut;
        }


    }
}
