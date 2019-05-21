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
    public partial class Form1 : Form
    {
        public MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");
        int i; string[] gelenkullanici;

        kullanici kul = new kullanici();
        sozluk szlk = new sozluk();
        sozcukislemler szc = new sozcukislemler();
        kelimeog klm = new kelimeog();

        public Form1()
        {
            InitializeComponent();
            listele();
        }

        public void listele()
        {
            listView1.Columns.Add("turkce_kelime", 40); //listtview ' e iki sütün ekliyoruz
            listView1.Columns.Add("ingilizce_kelime", 40);

            listView1.View = View.Details;
            listView1.GridLines = true;
            ListViewItem item = new ListViewItem();

            con.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM kelimeler", con);
            MySqlDataReader dr = komut.ExecuteReader();

            while(dr.Read())
            {
                item = listView1.Items.Add(dr.GetInt32(0).ToString());
                item.SubItems.Add(dr.GetString(1));

            }
            con.Close();
        }

    private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            /*try
            {
                con.Open();//oluşturduğumuz tanımı çalıştırarak açılmasını sağlıyoruz
                if (con.State != ConnectionState.Closed)//tanımın durumunu kontrol ediyoruz bağlı mı değil mi 
                {
                  //  MessageBox.Show("baglanti basarili bir sekilde gerceklesti");// bağlı ise buradaki işlemler gerçekleşiyor
                }
                else
                {
                  //  MessageBox.Show("malesef baglanti yapilamadi...!");// bağlı değilse buradaki işlemler gerçekleşiyor 
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("hata!" + err.Message, "hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/



           Rectangle r= new Rectangle(


           tabPage1.Left,


           tabPage1.Top,


           tabPage1.Width,


           tabPage1.Height);





            tabControl1.Region = new Region(r);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gelenkullanici = new string[3];
            gelenkullanici = kul.giris(textbox1.Text, textbox2.Text);
            if (gelenkullanici!=null)
            {
                MessageBox.Show("Giriş Başarılı");
                tabControl1.SelectTab(4);
                textBox5.Text = gelenkullanici[0];
                textBox4.Text = gelenkullanici[1];
                textBox3.Text = gelenkullanici[2];

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.");
            }
        }

     
        private void button3_Click(object sender, EventArgs e)
        {
            int donut;
            donut = kul.kayitol(adi.Text,kullaniciadi.Text,mail.Text,sifre.Text);
            if(donut == 1)
            {
                MessageBox.Show("kayıt başarılı...");
                tabControl1.SelectTab(0);
            }
            else
            {
                MessageBox.Show("kayıt başarısız...");
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
             
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ingilizce_kelime = szlk.ingilizce_cevir(textBox7.Text);
            if (ingilizce_kelime!=null)
            {
                textBox6.Text = ingilizce_kelime;
            }
            else
            {
                MessageBox.Show("Aradığınız kelime bulunamadı");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(9);        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string turkce_kelime = szlk.turkce_cevir(textBox8.Text);
            if (turkce_kelime != null)
            {
                textBox9.Text = turkce_kelime;
            }
            else
            {
                MessageBox.Show("Aradığınız kelime bulunamadı");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(10);

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int donut;
            donut =szc.kelimeekle(turkce_kelime.Text,ingilizce_kelime.Text);
            if (donut == 1)
            {
                MessageBox.Show("kayıt başarılı...");
                tabControl1.SelectTab(0);
            }
            else
            {
                MessageBox.Show("kayıt başarısız...");
            }
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            tabControl1.SelectTab(6);

        }

        private void button17_Click(object sender, EventArgs e)
        {
            listView1.Columns.Add("turkce_kelime", 40); //listtview ' e iki sütün ekliyoruz
            listView1.Columns.Add("ingilizce_kelime", 40);

            listView1.View = View.Details;
            listView1.GridLines = true;
            ListViewItem item = new ListViewItem();
            
            con.Open();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM kelimeler", con);
            MySqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                item = listView1.Items.Add(dr.GetString("turkce_kelime").ToString());
                item.SubItems.Add(dr.GetString("ingilizce_kelime"));

            }
            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }





        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
            {
                string ki = "";
                for (int i = 0; i < 100; i++)
                {
                    if (textBox10.Text[i] != '-')
                    {
                        ki += textBox10.Text[i].ToString();
                        continue;
                    }
                    else break;
                }
                MessageBox.Show(ki.ToString());
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=ingilizce_sozluk;Uid=root;Pwd='';");
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ingilizce_kelime from kelimeler where id=" + Convert.ToInt32(ki);
                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();


                string ingilizce_kelime = "";
                while (reader.Read())
                {

                    ingilizce_kelime = reader.GetValue(0).ToString();
                }
                con.Close();
                if(ingilizce_kelime == textBox11.Text)
                {
                    MessageBox.Show("Dogru bildiniz");
                    InsertData();
                }
                else
                    MessageBox.Show("Yanlıs bildiniz");

                //textBox11.Text = ingilizce_kelime;
            }
           else
            {
                MessageBox.Show("bos olamaz");
            }
            



        }
        public void InsertData()
        {
            int count = 0;
            count++;
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ranking (skor,mounth,year) values (" + count + ", " + DateTime.Now.Month + ", " + DateTime.Now.Year + ")";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string turkce_kelime = klm.kelime_ogren();
            textBox10.Text= turkce_kelime;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public void PullData()
        {
            
        
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT mounth, SUM(skor) as 'From' from ranking where year =" + comboBox1.SelectedItem + " group by mounth";
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                string output = "";
                string[] month = new string[12];
                int[] pointsArray = new int[12];
                while (reader.Read())
                {
                    for(int i=0; i < months.Length; i++)
                    {
                        if((int)reader.GetValue(0) == i+1)
                        {
                            month[i] = months[i];
                            output += month[i] + " - " + reader.GetValue(1).ToString() + " kelime bilindi \n";
                           
                        }
                    }

                }
                MessageBox.Show(output);
                con.Close();


            
          
        }

        private void button23_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("2018 verileri getiriliyor...");
                    PullData();
                    break;
                case 1:
                    MessageBox.Show("2019 verileri getiriliyor...");
                    PullData();
                    break;
                default:
                    break;






            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(7);
        }
    }
}
