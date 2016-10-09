using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnn;
            Stopwatch watch = new Stopwatch();
            a: bool askersayi = true;
            Console.Write("Toplam asker: ");
            string n = Console.ReadLine();

            if (String.IsNullOrEmpty(n))
            {
                Console.Write(" Asker sayisi bos geçilemez...\n");
                goto a;
            }
            foreach (char item in n)
            {
                if (item < 47 || item > 58)
                {
                    askersayi = false;
                    break;
                }
            }

            if (n.Length < 9)
            {
                if (askersayi == false || Convert.ToInt32(n) < 3)
                {
                    Console.Write(" Girdiginiz karakter hatali yada asker sayisi 2'den az\n");
                    goto a;
                }
            }
            else
            {
                Console.Write(" Asker sayisi 8 haneden fazla olamaz\n");
                goto a;
            }


            int asker = Convert.ToInt32(n);
            int[] dizi = new int[asker];

            b: bool adimsayi = true;
            Console.Write("Adim sayisi: ");
            string a = Console.ReadLine();
            if (String.IsNullOrEmpty(a))
            {
                Console.Write(" Adim sayisi bos geçilemez...\n");
                goto b;
            }
            foreach (char item in a)
            {
                if (item < 47 || item > 58)
                {
                    adimsayi = false;
                    break;
                }
            }
            if (a.Length < 9)
            {
                if (adimsayi == false || Convert.ToInt32(a) < 1)
                {
                    Console.Write(" Girdiginiz karakter hatali yada 0 dan büyük bir adim sayisi giriniz.\n");
                    goto b;
                }
            }
            else
            {
                Console.Write(" Adim sayisi 8 haneden fazla olamaz\n");
                goto b;
            }
            int adim = Convert.ToInt32(a);



            watch.Start();
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = i + 1;
            }

            int sayac = 1;
            int hiza = 0;
            while (true)
            {
                if (asker != 2)
                {
                    if (hiza >= dizi.Length)
                    {
                        hiza = 0;
                    }

                    if (dizi[hiza] == 0)
                    {
                        hiza++;
                    }
                    else
                    {
                        if (dizi[hiza] == 0) sayac--;

                        if (sayac % adim == 0)
                        {
                            dizi[hiza] = 0;
                            asker = asker - 1;
                        }
                        hiza++;
                        sayac++;
                    }
                }
                else break;
            }

            bool virgul = true;
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] != 0)
                {
                    if (virgul)
                    {
                        Console.Write("\n" + n + " asker ve " + a + " adim girdiniz.\nSonuç : [" + dizi[i].ToString() + ",");
                        virgul = false;
                    }
                    else Console.Write(dizi[i].ToString() + "]");
                }
            }

            watch.Stop();

            Console.WriteLine("\nÇalisma süresi: " + watch.Elapsed.TotalMilliseconds + " milisaniye\n");

            c: Console.Write("Yeni islem yapmak istiyorsaniz(E) çikis için (H) tiklayiniz. ");
            string yeniislem = Console.ReadLine();
            if (String.IsNullOrEmpty(yeniislem))
            {
                Console.Write(" Lütfen yapmak istediginiz islemi seçiniz...\n");
                goto c;
            }

            if (yeniislem == "E" || yeniislem == "e")
                goto a;
            else if (yeniislem == "H" || yeniislem == "h")
                Console.Write("Goodbye");
            else
            {
                Console.Write(" Uygun Karekterler giriniz.\n");
                goto c;
            } 
        }

    }

}


