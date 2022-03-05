using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCardVerification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
           
        int[] dizi = new int[16];
        int toplam = 0;
        int sayac = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var i in textBox1.Text)
                {
                    int sayi = Convert.ToInt16(i.ToString());
                    dizi[sayac] = sayi;
                    if (sayac % 2 == 0)
                    {
                        dizi[sayac] *= 2;

                        if (dizi[sayac] >= 10)
                        {
                            dizi[sayac] -= 10;
                            dizi[sayac]++;
                        }
                        toplam += dizi[sayac];

                    }
                    else if (sayac % 2 == 1)
                    {
                        toplam += dizi[sayac];

                    }
                    sayac++;
                }

                if (textBox1.Text.Length == 16 && toplam % 10 == 0)
                {
                    label1.Text = "Kart Bilgileri Doğru";
                    label1.ForeColor = Color.Green;
                    toplam = 0;
                    sayac = 0;
                }
                else
                {
                    label1.Text = "Kart Bilgileri Yanlış";
                    label1.ForeColor = Color.Red;
                    toplam = 0;
                    sayac = 0;
                }

                if (textBox1.Text.Length == 0)
                {
                    label1.Text = "Lütfen Sayı Giriniz.";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("16 karakteri aşamazsınız yada sayı dışında birşey giremezsiniz.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toplam = 0;
                sayac = 0;
                textBox1.Clear();
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Lütfen sayı giriniz.";
            label1.ForeColor = Color.Red;
        }
    }    
}