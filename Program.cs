using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            int musteri_sayisi;

            string[][][] masalar = new string[3][][];
            masalar[0] = new string[5][];
            masalar[0][0] = new string[4];
            masalar[0][1] = new string[4];
            masalar[0][2] = new string[4];
            masalar[0][3] = new string[4];
            masalar[0][4] = new string[4];

            masalar[1] = new string[3][];
            masalar[1][0] = new string[8];
            masalar[1][1] = new string[8];
            masalar[1][2] = new string[8];

            masalar[2] = new string[2][];
            masalar[2][0] = new string[10];
            masalar[2][1] = new string[10];


            Console.WriteLine("Lutfen resterona gelecek kisi sayisini giriniz");
            musteri_sayisi=Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            string[] musteriler = new string[musteri_sayisi];
            int artan = musteri_sayisi- 64;
            string[] artan_musteriler=null;

            if (artan>0)
            {
                artan_musteriler=new string[artan];
            }
            musteriOlustur(musteriler);
            yerlestirme(masalar, musteriler, artan_musteriler);
            yerleri_gosterme(masalar, artan_musteriler);
            Console.ReadLine();

        }
    
        public static void musteriOlustur(string[] musteri)
        {    
            Random rnd = new Random();

            string[] name = {"Ahmet","Ali","Leman","Isık","Uygur","Jale","Rafet","Defne","Bahar","Evrim","Nejati","Onder","Aziz","Aslİ","Tugba","Kubra","Burak","Ipek","Pelin","Salih",};
            string[] lastname = {" ALSU"," ACEM"," LOKUM"," IHLAMUR"," UYMAZ"," BULUT"," RAKUM"," DEGIRMEN"," BOG"," ERIK"," HIZIR"," OLGUZ"," AKDAG"," IlGAZ"," TEMIZ"," PARLAK"," SIMSEK"," PANTER"," GEZER"," KABUK", };
               
            for(int i=0;i<musteri.Length;i++)
            {
                int raSayi1 = rnd.Next(1, 20);
                int raSayi2 = rnd.Next(1, 20);
                musteri[i]=name[raSayi1]+lastname[raSayi2];
            }
        }

        public static void yerlestirme(string[][][] yerler,string[] kisiler,string[] artan)
        {
                int masa_numara = 0;
                int yer_numara = 0;
                int yer_sayisi = 0;
                int b=0;
                int b2 = 0;
                double yuzde_orani = (100.00 * kisiler.Length) / 64.00;
                double Dortlu_yer_sayisi;
                if ((Math.Ceiling(4 * yuzde_orani / 100.00)) > 4)
                {
                    Dortlu_yer_sayisi = 4;
                }
                else
                    Dortlu_yer_sayisi = (Math.Ceiling(4 * yuzde_orani / 100.00));

                double Sekizli_yer_sayisi;
                if ((Math.Floor(8 * yuzde_orani / 100.00)) > 8)
                {
                    Sekizli_yer_sayisi = 8;
                }
                else
                    Sekizli_yer_sayisi = (Math.Floor(8 * yuzde_orani / 100.00));
                double Onlu_yer_sayisi;
                if ((Math.Floor(10 * yuzde_orani / 100.00)) > 10)
                {
                    Onlu_yer_sayisi = 10;
                }
                else
                    Onlu_yer_sayisi = (Math.Floor(10 * yuzde_orani / 100.00));
                double fazlaliklar = kisiler.Length - (Dortlu_yer_sayisi * 5.00 + Sekizli_yer_sayisi * 3.00 + Onlu_yer_sayisi * 2.00); 

                for(int n=0; n<kisiler.Length;n++)
                {
                    if (b2 == kisiler.Length || b2==64)
                        break;

                    int i2 = 2;
                    for(int i=0;i<3;i++)
                    {

                        switch(i)
                        {
                            case 0: masa_numara = 5; yer_numara = 4; yer_sayisi = (int)Dortlu_yer_sayisi;
                                break;
                            case 1: masa_numara = 3; yer_numara = 8; yer_sayisi = (int)Sekizli_yer_sayisi;
                                break;
                            case 2: masa_numara = 2; yer_numara = 10; yer_sayisi = (int)Onlu_yer_sayisi;
                                break;
                            default:
                                break;
                        }

                        if (b2 >= kisiler.Length || b2 == 64)
                            break;

                        for (int j = 0; j < masa_numara; j++)
                        {
                            int j2 = yer_numara - 1;
                            int sayac = yer_sayisi;
                            if (fazlaliklar > 0 && i2 == 2 && yer_sayisi != 10 && j < 2 && kisiler.Length <= 64)
                            {
                                b2++;
                                int yer_sayisi2 = (int) Onlu_yer_sayisi;
                                yerler[i2][j][yer_sayisi2] = kisiler[kisiler.Length - (int)fazlaliklar];
                                fazlaliklar--;
                            }
                            if (fazlaliklar > 0 && i2 == 1 && yer_sayisi != 8 && j < 3 && kisiler.Length <= 64)
                            {
                                b2++;
                                int yer_sayisi2 = (int) Sekizli_yer_sayisi;
                                yerler[i2][j][yer_sayisi2] = kisiler[kisiler.Length - (int)fazlaliklar];
                                fazlaliklar--;
                            }
                            if (fazlaliklar > 0 && i2 == 0 && yer_sayisi != 4 && j < 5 && kisiler.Length <= 64)
                            {
                                b2++;
                                int yer_sayisi2 = (int) Dortlu_yer_sayisi;
                                yerler[i2][j][yer_sayisi2] = kisiler[kisiler.Length - (int)fazlaliklar];
                                fazlaliklar--;
                            }

                            j2--;

                            if (b2 == kisiler.Length || b2 == 64)
                                break;

                            for(int y=0;y<yer_sayisi;y++)
                            {
                                yerler[i][j][y] = kisiler[b];
                                b++;
                                b2++;
                                if (b2 == kisiler.Length || b2 == 64)
                                    break;
                            }

                        }
                       i2--;
                    }
                }
            if(kisiler.Length>64) 
            {
                double masa_sayisi = Math.Ceiling(artan.Length / 4.00);
                for(int k=0;k<artan.Length;k++)
                {
                    artan[k]=kisiler[64+k];
                    b++;
                }
            }
        }

        public static void yerleri_gosterme(string[][][] yerler, string[] artan)
        {
            int masa_numara = 0; int yer_numara = 0; int yer_sayisi = 0;
            string yer_ismi = ("");

            for (int i = 0; i < 3; i++)
            {
                if (yerler[i][0][0] == null)
                {
                    break;
                }
                switch (i)
                {
                    case 0: masa_numara = 5; yer_numara = 4; yer_ismi = ("4'lu");
                        break;
                    case 1: masa_numara = 3; yer_numara = 8; yer_ismi = ("8'li");
                        break;
                    case 2: masa_numara = 2; yer_numara = 10; yer_ismi = ("10'lu");
                        break;
                    default:
                        break;
                }
                Console.WriteLine(yer_ismi + " MASALAR :");
                Console.WriteLine();

                for (int j = 0; j < masa_numara; j++)
                {
                    if (yerler[i][j][0] == null)
                    {
                        break;
                    }
                    int sayac = yer_sayisi;
                    Console.WriteLine((j + 1) + ". Masa ");
                    Console.WriteLine("-------------");

                    for (int y = 0; y < yer_numara; y++)
                    {
                        if (yerler[i][j][y] != null)
                        {
                            Console.Write((y + 1) + ". Sandalye = ");
                            Console.WriteLine(yerler[i][j][y]);
                        }
                    }
                    Console.WriteLine();
                }
            }

            if (artan != null)
            {
                Console.WriteLine("Fazladan gereken masa sayisi :" + (artan.Length / 4 + 1));

                Console.WriteLine("Ve musterilerin bilgileri:");
                foreach (string i in artan)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
