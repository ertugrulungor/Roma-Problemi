using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int dd;

        a: bool askersayi = true;
            Console.Write("Toplam asker: ");
            string n = Console.ReadLine();
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
                    Console.Write("Girdiğiniz karakter hatalı yada asker sayısı 2'den az\n");
                    goto a;
                }
            }
            else
            {
                Console.Write("Asker sayısı 8 haneden fazla olamaz\n");
                goto a;
            }


            int asker = Convert.ToInt32(n);
            int[] dizi = new int[asker];

        b: bool adimsayi = true; Console.Write("Adım sayısı: ");
            string a = Console.ReadLine();
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
                    Console.Write("Girdiğiniz karakter hatalı yada adım sayısı asker sayısından büyük\n");
                    goto b;
                }
            }
            else
            {
                Console.Write("Adım sayısı 8 haneden fazla olamaz\n");
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

            Console.WriteLine("\nÇalışma süresi: " + watch.Elapsed.TotalMilliseconds + " milisaniye");
            Console.ReadLine();

        }

    }

}


