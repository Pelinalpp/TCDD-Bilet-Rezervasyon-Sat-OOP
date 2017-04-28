using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcddTren
{
    public partial class frmTCDD : Form
    {
        public frmTCDD()
        {
            InitializeComponent();
        }
        //Kişinin puan bilgisi tutulmak için oluşturuldu.
        List<Kisi> kisiler = new List<Kisi>();
        //Birçok yerde nesne oluşturulmasının önüne geçmek için global oluşturuldu.
        Rezervasyon rezervasyon = new Rezervasyon();
        Yolcu yolcu = new Yolcu();
        Sefer seferBilgisi = new Sefer();
        Bilet bilet = new Bilet();
        //tüm biletlerin parasını toplamak için oluşturuldu ve müşterinin toplam parayı görüp onayını aldıktan sonra bilete dönüştürmek için oluşturuldu.
        decimal toplamUcret = 0;
        //Kayıtlı kişinin eski puanının üzerine yeni puanının eklenmesi için oluşturuldu.
        public void KisiAra()
        {
            yolcu.PuanHesapla();
            
            foreach (Kisi i in kisiler)
            {
                if (yolcu.TcKimlikNo == i.TcKimlikNo)
                {
                    i.Puan += yolcu.Puan;
                }            
            }

            kisiler.Add(yolcu);
        }

        private void btneYonsecIleri_Click(object sender, EventArgs e)
        {
            //textboxların boş girilmemesi durumu için yazıldı.
            if (cbNereden.Text == "Seçiniz" || cbNereye.Text == "Seçiniz")
                MessageBox.Show("Kalkış ve varış noktalarını giriniz.");
            else if (txtYolcuSayisi.Text == "")
                MessageBox.Show("Yolcu sayısını giriniz.");
            //kalkış ve varış noktalarının aynı olması durumu için yazıldı
            else if (cbNereden.Text == cbNereye.Text)
                MessageBox.Show("Kalkış ve varış noktalarını farklı seçiniz.");
            //Bütün kriterlere uyuyorsa bilgiler kaydedildi.
            else
            {
                seferBilgisi.Kalkis = cbNereden.Text;
                seferBilgisi.Varis = cbNereye.Text;

                seferBilgisi.GidisTarih = Convert.ToDateTime(dtGidis.Value.Day + "." + dtGidis.Value.Month + "." + dtGidis.Value.Year);
                //Gidiş-Dönüş şeklindeyse dönüş tarihi de alındı.
                if (rbGidisDonus.Checked == true)
                    seferBilgisi.DonusTarih = Convert.ToDateTime(dtDonus.Value.Day + "." + dtDonus.Value.Month + "." + dtDonus.Value.Year);
                //diğer taba geçildi.
                tabContBiletAl.SelectedTab = tpKoltukSec;
            }
        }

        private void rbGidisDonus_CheckedChanged(object sender, EventArgs e)
        {
            //gidiş-dönüş için datetimepicker etkinleştirildi.
            dtGidis.Enabled = true;
            dtDonus.Enabled = true;
        }

        private void rbTekYon_CheckedChanged(object sender, EventArgs e)
        {
            //tek yön ise dönüş tarihi etkisizleştiriliyor.
            dtGidis.Enabled = true;
            dtDonus.Enabled = false;
        }

        private void btneKoltukIleri_Click(object sender, EventArgs e)
        {
            //Koltuk seçimi işlemi yapılıyor.
            if (sayacKoltukSec < Convert.ToInt32(txtYolcuSayisi.Text))
                MessageBox.Show("Yolcu sayısı kadar koltuk seçiniz!");
            else
                tabContBiletAl.SelectedTab = tpYolcuEkle;
        }

        int sayacKoltukSec = 0;
        //Koltuk seçimi işlemi yapılıyor.
        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            if (sayacKoltukSec == Convert.ToInt32(txtYolcuSayisi.Text))
                MessageBox.Show("Girdiğiniz yolcu sayısına ulaştınız daha fazla koltuk seçemezsiniz.");
            else
            {
                Button btn = (Button)sender;
                if (btn.BackColor == Color.MediumTurquoise)
                {
                    //Butonların isimleri koltuk numaralarıdır.
                    //Bilet numaralarına bu isimler atandı.
                    Rezervasyon biletno = new Rezervasyon(Convert.ToInt32(btn.Text));
                    btn.BackColor = Color.Crimson;
                    btn.Enabled = false;
                    sayacKoltukSec++;
                }
            }
        }

        //Birden fazla veya 1 yolcu olması durumu için sayaç tutuldu.
        int sayac = 1;

        private void btneYolcuBilgisiIleri_Click(object sender, EventArgs e)
        {
            //Tek yolcu bilgisi kaydı veya son yolcu kaydı işlemi yapıldı
            if (sayac == Convert.ToInt32(txtYolcuSayisi.Text))
            {
                if (rbTam.Checked == true)
                {
                    yolcu = new Tam();
                    //yolcunun ücreti tam tarifeye göre hesaplanır.
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.
                    
                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    //yolcunun puanını hesaplamak için çağırıldı.
                    KisiAra();

                    //Eğer puan kullanılacaksa puandan ve ücretten düşmek için oluşturuldu.
                    if (cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    //Yolcu ücretlerinin toplamını görmek için
                    toplamUcret += yolcu.Ucret;
                }
                if (rbOgrenci.Checked == true)
                {
                    yolcu = new Ogrenci();
                    //yolcunun ücreti öğrenci tarifeye göre hesaplanır.
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.

                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    KisiAra();

                    if (cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    toplamUcret += yolcu.Ucret;
                }
                if (rbEngelli.Checked == true)
                {
                    //yolcunun ücreti engelli tarifeye göre hesaplanır.
                    yolcu = new Engelli();
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.

                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    KisiAra();

                    if(cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    toplamUcret += yolcu.Ucret;
                }
                //yolcunun ad soyad tc kimlik ne ve ücret bilgileri yolcuda sakladı
                //şimdide sefer bilgileri(kalkış-varış noktaları, kalkış-varış tarihleri vb.) yolcuya kaydediliyor.
                yolcu.sefer = seferBilgisi;
                //yolcu bilgisi rezervasyon tipindeki listeye ekleniyor.
                rezervasyon.RezervasyonEkle(yolcu);

                //diğer taba geçiliyor.
                tabContBiletAl.SelectedTab = tpOdemeTipiSec;
            }
            //birden fazla müşteri varsa kullanılır.
            else
            {
                if (rbTam.Checked == true)
                {
                    yolcu = new Tam();
                    //yolcunun ücreti tam tarifeye göre hesaplanır.
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.

                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    KisiAra();

                    if (cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    toplamUcret += yolcu.Ucret;
                }
                if (rbOgrenci.Checked == true)
                {
                    yolcu = new Ogrenci();
                    //yolcunun ücreti öğrenci tarifeye göre hesaplanır.
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.

                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    KisiAra();

                    if (cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    toplamUcret += yolcu.Ucret;
                }
                if (rbEngelli.Checked == true)
                {
                    yolcu = new Engelli();
                    yolcu.UcretHesapla(seferBilgisi.Kalkis, seferBilgisi.Varis);
                    if (rbGidisDonus.Checked == true)
                        yolcu.UcretCarp(); //Eğer gidiş-dönüş ise 2 bilet için ücret 2 ile çarpıldı.

                    yolcu.Ad = txtAd.Text;
                    yolcu.Soyad = txtSoyad.Text;
                    yolcu.TcKimlikNo = Convert.ToUInt64(txtTcKimlikNo.Text);

                    KisiAra();

                    if (cbPuanKullan.Checked == true)
                    {
                        yolcu.PuanCikar(yolcu.Ucret);
                    }
                    toplamUcret += yolcu.Ucret;
                }
                //yolcunun ad soyad tc kimlik ne ve ücret bilgileri yolcuda sakladı
                //şimdide sefer bilgileri(kalkış-varış noktaları, kalkış-varış tarihleri vb.) yolcuya kaydediliyor.
                yolcu.sefer = seferBilgisi;
                //yolcu bilgisi rezervasyon tipindeki listeye ekleniyor.
                rezervasyon.RezervasyonEkle(yolcu);
                //diğer yolcu için textboxlar ve mesajlar(label) düzenleniyor.
                sayac++;
                txtAd.Text = txtSoyad.Text = txtTcKimlikNo.Text = "";
                lblBilgi.Text = sayac.ToString() + ". müşterinin bilgisini gir:";
            }
        }

        private void btneOdemeTipiIleri_Click(object sender, EventArgs e)
        {
            //Ödeme tipi belirleniyor.
            if (rbKrediKarti.Checked == true)
            {
                KrediKarti k = new KrediKarti();
                rezervasyon.OdemeTipi = k;
            }
            if (rbNakit.Checked == true)
            {
                Nakit n = new Nakit();
                rezervasyon.OdemeTipi = n;
            }

            //müşterinin onayı için tutar textbox'a atıldı.
            txtTutar.Text = toplamUcret.ToString();

            //diğer taba geçiliyor.
            tabContBiletAl.SelectedTab = tpTutarGoster;
        }

        private void btnTutarOnay_Click(object sender, EventArgs e)
        {
            //Ödeme başarılı mesajı
            MessageBox.Show(rezervasyon.OdemeTipi.Odeme());
            //Rezervasyon bilete çevrildi.
            bilet.BiletEkle(rezervasyon);
            //Biletler listelendi
            txtListele.Text = bilet.BiletListele();
            //Diğer taba geçildi.
            tabContBiletAl.SelectedTab = tpBilet;
        }

        private void tpYonSec_Click(object sender, EventArgs e)
        {

        }
    }
}
