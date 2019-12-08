using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnYakinEklemeSezgiseli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 6x6 lık 0 matris oluşturuldu
        float[,] matris = {
                  { 0, 0, 0, 0, 0, 0} ,
                  { 0, 0, 0, 0, 0, 0} ,
                  { 0, 0, 0, 0, 0, 0} ,
                  { 0, 0, 0, 0, 0, 0} ,
                  { 0, 0, 0, 0, 0, 0} ,
                  { 0, 0, 0, 0, 0, 0}
                };

        private void numKontrol(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^\.^\b]"))
            {
                e.Handled = true; // eğer textbox lar içerisine rakamlar ve noktadan başka bir karakter girilir ise bu karakterin yazılmasını engelle
            }
        }

        private void Matris_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                matrisGuncelle(); // noktadan sonra rakam girilmez ise hata verebilir buyüzden bu fonksiyonumuzu try bloğu içerisinde çağırıyoruz
            }
            catch (Exception)
            {}
        }

        private void matrisGuncelle()
        {
            // matrislerin değerlerini simetrik olarak yazdır
            matris[0, 1] = matris[1, 0] = float.Parse(Matris01.Text, CultureInfo.InvariantCulture.NumberFormat); // String ifadeyi float türüne çevirdik
            matris[0, 2] = matris[2, 0] = float.Parse(Matris02.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[0, 3] = matris[3, 0] = float.Parse(Matris03.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[0, 4] = matris[4, 0] = float.Parse(Matris04.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[0, 5] = matris[5, 0] = float.Parse(Matris05.Text, CultureInfo.InvariantCulture.NumberFormat);

            matris[1, 2] = matris[2, 1] = float.Parse(Matris12.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[1, 3] = matris[3, 1] = float.Parse(Matris13.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[1, 4] = matris[4, 1] = float.Parse(Matris14.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[1, 5] = matris[5, 1] = float.Parse(Matris15.Text, CultureInfo.InvariantCulture.NumberFormat);

            matris[2, 3] = matris[3, 2] = float.Parse(Matris23.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[2, 4] = matris[4, 2] = float.Parse(Matris24.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[2, 5] = matris[5, 2] = float.Parse(Matris25.Text, CultureInfo.InvariantCulture.NumberFormat);

            matris[3, 4] = matris[4, 3] = float.Parse(Matris34.Text, CultureInfo.InvariantCulture.NumberFormat);
            matris[3, 5] = matris[5, 3] = float.Parse(Matris35.Text, CultureInfo.InvariantCulture.NumberFormat);

            matris[4, 5] = matris[5, 4] = float.Parse(Matris45.Text, CultureInfo.InvariantCulture.NumberFormat);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // varsayılan şehir isimlerinin atandığı kısım
            textBox1.Text = "Ankara";
            textBox2.Text = "Samsun";
            textBox3.Text = "İstanbul";
            textBox4.Text = "izmir";
            textBox5.Text = "Antalya";
            textBox6.Text = "Adana";
            baslangicSehri.SelectedIndex = 0;

            // varsayılan şehirlerin birbirine uzaklıkları
            Matris01.Text = "403";
            Matris02.Text = "450";
            Matris03.Text = "591";
            Matris04.Text = "488";
            Matris05.Text = "500";

            Matris12.Text = "737";
            Matris13.Text = "1090";
            Matris14.Text = "891";
            Matris15.Text = "719";

            Matris23.Text = "478";
            Matris24.Text = "695";
            Matris25.Text = "1070";

            Matris34.Text = "457";
            Matris35.Text = "915";

            Matris45.Text = "621";

            // başlangıç değerlerine sahip matrisi oluştur
            matrisGuncelle();

            // matris değerlerini kontrol ederken bu yorumsatırındaki komut kullanıldı
            //for (int i = 0; i < 6; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        richTextBox1.AppendText(string.Format("{0}\t", matris[i, j]));
            //    }
            //    richTextBox1.AppendText(Environment.NewLine + Environment.NewLine);
            //}
        }


        // Şehir isimleri güncellenirse yeni değerlerin aktarılldığı kısım
        #region SehirIsimler
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = label2.Text = textBox1.Text; // label'ların değerleri yeni şehir ismi ile değiştirildi
            baslangicSehri.Items[0] = textBox1.Text; // başlangıç şehrinin seçildiği comboBox'ta ki ifade değiştirildi
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = label8.Text = textBox2.Text;
            baslangicSehri.Items[1] = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = label9.Text = textBox3.Text;
            baslangicSehri.Items[2] = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label5.Text = label10.Text = textBox4.Text;
            baslangicSehri.Items[3] = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label6.Text = label11.Text = textBox5.Text;
            baslangicSehri.Items[4] = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label7.Text = label12.Text = textBox6.Text;
            baslangicSehri.Items[5] = textBox6.Text;
        }
        #endregion

        // matrisin simetrik özelliğini koruyabilmesi için üst üçgensel alana girilen değerleri alt üçgensel bölgeye otomatik kopyaladık
        #region matrisSimetrisi
        private void Matris12_TextChanged(object sender, EventArgs e)
        {
            Matris10.Text = Matris01.Text; // matrise girilen değerlerin yansıması atandı
        }

        private void Matris13_TextChanged(object sender, EventArgs e)
        {
            Matris20.Text = Matris02.Text;
        }

        private void Matris14_TextChanged(object sender, EventArgs e)
        {
            Matris30.Text = Matris03.Text;
        }

        private void Matris15_TextChanged(object sender, EventArgs e)
        {
            Matris40.Text = Matris04.Text;
        }

        private void Matris16_TextChanged(object sender, EventArgs e)
        {
            Matris50.Text = Matris05.Text;
        }

        private void Matris23_TextChanged(object sender, EventArgs e)
        {
            Matris21.Text = Matris12.Text;
        }

        private void Matris34_TextChanged(object sender, EventArgs e)
        {
            Matris32.Text = Matris23.Text;
        }

        private void Matris24_TextChanged(object sender, EventArgs e)
        {
            Matris31.Text = Matris13.Text;
        }

        private void Matris25_TextChanged(object sender, EventArgs e)
        {
            Matris41.Text = Matris14.Text;
        }

        private void Matris26_TextChanged(object sender, EventArgs e)
        {
            Matris51.Text = Matris15.Text;
        }

        private void Matris35_TextChanged(object sender, EventArgs e)
        {
            Matris42.Text = Matris24.Text;
        }

        private void Matris36_TextChanged(object sender, EventArgs e)
        {
            Matris52.Text = Matris25.Text;
        }

        private void Matris45_TextChanged(object sender, EventArgs e)
        {
            Matris43.Text = Matris34.Text;
        }

        private void Matris46_TextChanged(object sender, EventArgs e)
        {
            Matris53.Text = Matris35.Text;
        }

        private void Matris56_TextChanged(object sender, EventArgs e)
        {
            Matris54.Text = Matris45.Text;
        }

        #endregion

        private void hesapla_Click(object sender, EventArgs e)
        {
            int baslangic = baslangicSehri.SelectedIndex; // başlangıç şehri kaydedildi

            List<int> gidilmeyecekler = new List<int>(); // tekrar gidilmeyecek şehirleri hafızada tutabilmek için int türünde liste oluşturduk
            gidilmeyecekler.Add(baslangic); // gidilmeyecekler arasına başlangıç şehrimizi ekledik
            int enyakin = -1; // en yakın şehri matris üzerinde yeri(değeri) olmadığından -1 verdik
            float uzaklik = 0; // uzaklığı 0 dan başlattık(üzerine eklenerek ilerleyen bir değer olmadığından burasının kaç olduğu önemli değil. ama kafa karışıklılığı olmaması için 0 değerini verdik)
            float toplam = 0; // toplamı 0 dan(toplama işleminin etkisiz elemanı) başlattık 
            richTextBox1.AppendText("\nBaşlangıç şehri : " + baslangicSehri.Items[baslangic]); // başlangıç şehrimizi bildirdik
            richTextBox1.AppendText("\n\n-------------------------------------------------\n\n");

            for (int i = 1; i < 6; i++)
            {
                richTextBox1.AppendText((i + 1).ToString() + " farklı şehirden geçen en kısa yol\n"); // kaç farklı şehre uğrayacağımızı bildirdik

                richTextBox1.AppendText("\n\t" + baslangicSehri.Items[baslangic] + "(" + uzaklik + ") - "); // başlangıç şehrini ve kendisine olan uzaklığını ekrana yazdık
                for (int j = 0; j < i; j++)
                {
                    enyakin = enYakinSehir(baslangic, gidilmeyecekler.ToArray()); // en yakın şehri bulduk
                    gidilmeyecekler.Add(enyakin); // tekrar gidilmeyecekler arasına en yakın şehri ekledik
                    uzaklik = matris[baslangic, enyakin]; // iki şehir arasındaki güncel mesafeyi uzaklık değerine kaydettik
                    toplam += uzaklik; // şehirler arası uzaklığı toplam değeri üzerinde biriktirdik
                    baslangic = enyakin; // en yakın şehre olan en yakın şehri bulmak için yeni başlangıç noktasını belirledik

                    richTextBox1.AppendText(baslangicSehri.Items[baslangic] + "(" + uzaklik.ToString() + ") - "); // yeni gidilen şehri ve eski şehir ile yeni şehir arasındaki mesafeyi yazdık
                }
                uzaklik = matris[baslangicSehri.SelectedIndex, baslangic]; // başlangıç noktasına dönmek için seçilen başlangıç şehri ile son gidilen şehir arasındaki mesafe alındı
                toplam += uzaklik; // başlangıç şehri ile son şehir arasındaki yol toplama eklendi
                richTextBox1.AppendText(baslangicSehri.Items[baslangicSehri.SelectedIndex] + "(" + uzaklik + ")\n"); // geri dönüş şehri ve mesafesi yazdırıldı
                richTextBox1.AppendText("\tToplam alınan yol = " + toplam.ToString()); // toplam alınan yol ekrana yazdırıldı


                richTextBox1.AppendText("\n\n-------------------------------------------------\n\n"); // hesaplanan değerleri birbirinden ayırdık


                // bir sonraki yol için eski bilgileri temizledik
                baslangic = baslangicSehri.SelectedIndex;
                enyakin = -1;
                toplam = uzaklik = 0;
                gidilmeyecekler.Clear();
                gidilmeyecekler.Add(baslangic);
            }
        }

        private int enYakinSehir(int sehir, int[] gidilmeyecekler = null)
        {
            int enkucuk = -1; // en küçük yol değeri olarak -1 özel değerini atadık (matriste değeri olmadığından dolayı)
            for (int i = 0; i < 6; i++) // tüm matrisi kontrol etmek için döngüye girdik
            {
                if (gidilmeyecekler.Contains(i)) continue; // eğer matrisin i.elemanına daha önceden gidilmiş ise bu elemanı atlamasını söyledik

                if (enkucuk == -1) // eğer henüz en küçü değer atanmamış ise;
                {
                    if(matris[sehir, i] == 0) continue; // ve seçilen elemanın matris üzerindeki değeri 0 ise (örnek ankara ile ankara arası mesafe 0 dır) bu elemanı atladık
                    enkucuk = i; // eğer seçilen elemanın matris üzerindeki değeri 0 dan farklı ise en küçük değer olarak onu atadık
                    continue; // en küçük değer atandıktan sonra tekrardan aynı değeri kıyaslamaya gerek kalmadığından sıradaki elemana geçtik
                }
                    
                // eğer seçilen elemanın matris üzerindeki değeri 0 değil ise ve son kaydedilen en küçük değerden daha küçük bir değere sahip ise yeni en küçük değeri kaydettik
                if (matris[sehir, i] != 0 && matris[sehir, i] < matris[sehir, enkucuk]) 
                    enkucuk = i;
            }

            return enkucuk; // en kısa yola(değere) sahip yolu geri döndürdük
        }


    }
}
