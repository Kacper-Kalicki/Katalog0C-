
/*Do programu nalezy dolaczyc plik .txt 
 Standardowy schemat ulozenia informacji w pliku:
 1. marka (string)
 2. model (string)
 3. rocznik (int)
 4. pojemnosc (int)
 5. przebieg (int)
 6. skrzynia biegow (string)*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.CS
{
    public class Samochod
    {
        /*1*/
        public string marka;
        /*2*/
        public string model;
        /*3*/
        public int rocznik;
        /*4*/
        public int pojemnosc;
        /*5*/
        public int przebieg;
        /*6*/
        public string tp_skr_bieg;
        //Lista obiektow
        List<Samochod> mobil = new List<Samochod>();
        /// <summary>
        /// Odczytuje dane z pliku tworzac liste obiektow z parametrami
        /// </summary>
        public void Odczyt()
        {

            int counter = 0;

            string linia;
            int linia1;
            int n1 = 1, n2 = 1;
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"D:\C#\Katalog.CS\baza.txt");
            mobil.Add(new Samochod());
            while ((linia = file.ReadLine()) != null)
            {

                bool wynik = int.TryParse(linia, out linia1);
                if (wynik == false)
                {
                    if (n1 == 1)
                    {
                        mobil[counter].marka = linia;
                        n1++;
                    }
                    else if (n1 == 2)
                    {
                        mobil[counter].model = linia;
                        n1++;
                    }
                    else if (n1 == 3)
                    {
                        mobil[counter].tp_skr_bieg = linia;
                        n1 = 1;
                        counter++;
                        mobil.Add(new Samochod());

                    }
                }
                else if (wynik == true)
                {
                    if (n2 == 1)
                    {
                        mobil[counter].rocznik = linia1;
                        n2++;

                    }
                    else if (n2 == 2)
                    {
                        mobil[counter].pojemnosc = linia1;
                        n2++;
                    }
                    else if (n2 == 3)
                    {
                        mobil[counter].przebieg = linia1;
                        n2 = 1;
                    }
                }



            }
            mobil.RemoveAt(counter);
            file.Close();

        }
        /// <summary>
        /// Czysty test
        /// </summary>
        public void Test()
        {
            Console.WriteLine(mobil[1].marka);

        }
        /// <summary>
        /// Zapisuje nowy element dodajac kolejny element listy i dopisujac go do pliku
        /// </summary>
        public void Zapis()
        {
            Console.Clear();
            int numer = mobil.Count;
            mobil.Add(new Samochod());
            Console.WriteLine("Witaj. Teraz dodamy nowy samochod do katalogu.");
            Console.Write("Prosze podaj jego marke: ");
            mobil[numer].marka = Console.ReadLine();
            Console.Write("Prosze podaj jego model: ");
            mobil[numer].model = Console.ReadLine();
            Console.Write("Prosze podaj jego rocznik: ");
            mobil[numer].rocznik = int.Parse(Console.ReadLine());
            Console.Write("Prosze podaj jego pojemnosc: ");
            mobil[numer].pojemnosc = int.Parse(Console.ReadLine());
            Console.Write("Prosze podaj jego przebieg: ");
            mobil[numer].przebieg = int.Parse(Console.ReadLine());
            Console.Write("Prosze podaj jego typ skrzyni biegow: ");
            mobil[numer].tp_skr_bieg = Console.ReadLine();

            System.IO.StreamWriter plik =
            new StreamWriter(@"D:\C#\Katalog.CS\baza.txt");
            for (int i = 1; i <= mobil.Count; i++)
            {
                plik.WriteLine(mobil[i - 1].marka);
                plik.WriteLine(mobil[i - 1].model);
                plik.WriteLine(mobil[i - 1].rocznik);
                plik.WriteLine(mobil[i - 1].pojemnosc);
                plik.WriteLine(mobil[i - 1].przebieg);
                if (i < mobil.Count)
                    plik.WriteLine(mobil[i - 1].tp_skr_bieg);
                else if (i == mobil.Count)
                    plik.Write(mobil[i - 1].tp_skr_bieg);
            }
            plik.Close();
            Console.Clear();
            Console.WriteLine("Gotowe.");



        }
        /// <summary>
        /// Wypisuje liste wszystkich mozliwych elementow
        /// </summary>
        public void Lista()
        {
            Console.Clear();
            Console.WriteLine("Oto cala lista dostepnych samochodow:" + Environment.NewLine);
            for (int i = 0; i < mobil.Count; i++)
            {
                Console.WriteLine("Marka: " + mobil[i].marka);
                Console.WriteLine("Model: " + mobil[i].model);
                Console.WriteLine("Rocznik: "+mobil[i].rocznik);
                Console.WriteLine("Pojemnosc: "+mobil[i].pojemnosc);
                Console.WriteLine("Przebieg: "+mobil[i].przebieg);
                Console.WriteLine("Typ skrzyni biegow: "+mobil[i].tp_skr_bieg + Environment.NewLine);
            }

        }
        /// <summary>
        /// Wypisuje liste wedlug pewnego warunku
        /// </summary>
        public void War_Lista()
        {
            Console.Clear();
            Console.WriteLine("Po jakim parametrze wyszukac: ");
            Console.WriteLine("1. Po roczniku.");
            Console.WriteLine("2. Po pojemnosci.");
            Console.WriteLine("3. Po przebiegu.");
            Console.Write("Numer: ");
            string info = Console.ReadLine();
            Console.Clear();
            Console.Write("Mniejsze (1) czy Wieksze (2): ");
            string mn_wi = Console.ReadLine();
            Console.Clear();
            Console.Write("Podaj sama wartosc po ktorej sortowac: ");
            string par = Console.ReadLine();
            int liczba = int.Parse(par);
            Console.Clear();
            Console.WriteLine("Oto wyniki: " + Environment.NewLine);
            switch (info)
            {
                case "1": //rocznik
                    {
                        Console.WriteLine("Sortowane po roczniku.");
                        if (mn_wi == "1")
                        {
                            Console.WriteLine("Mniejsze od wartosci: " + liczba+Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].rocznik <= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }

                                else
                                    continue;
                            }
                        }
                        else if (mn_wi == "2")
                        {
                            Console.WriteLine("Wieksze od wartosci: " + liczba + Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].rocznik >= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }

                                else
                                    continue;
                            }
                        }
                        else
                        {
                        Console.Clear();
                        Console.WriteLine("Zle oznaczenie");
                        }

                        break;
                    }
                case "2": //pojemnosc
                    {
                        Console.WriteLine("Sortowane po pojemnosci.");
                        if (mn_wi == "1")
                        {
                            Console.WriteLine("Mniejsze od wartosci: " + liczba + Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].pojemnosc <= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }

                                else
                                    continue;
                            }
                        }
                        else if (mn_wi == "2")
                        {
                            Console.WriteLine("Wieksze od wartosci: " + liczba + Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].pojemnosc >= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }

                                else
                                    continue;
                            }
                        }
                        else
                        {
                        Console.Clear();
                        Console.WriteLine("Zle oznaczenie");
                        }

                        break;
                    }
                case "3": //przebieg
                    {
                        Console.WriteLine("Sortowane po przebiegu.");
                        if (mn_wi == "1")
                        {
                            Console.WriteLine("Mniejsze od wartosci: " + liczba + Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].przebieg <= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }

                                else
                                    continue;
                            }
                        }
                        else if (mn_wi == "2")
                        {
                            Console.WriteLine("Wieksze od wartosci: " + liczba + Environment.NewLine);
                            for (int i = 0; i < mobil.Count(); i++)
                            {
                                if (mobil[i].przebieg >= liczba)
                                {
                                    Console.WriteLine("Marka: " + mobil[i].marka);
                                    Console.WriteLine("Model: " + mobil[i].model);
                                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                                }
                                else
                                    continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Zle oznaczenie");
                        }

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Niewlasciwa wartosc.");
                        break;
                    }

            }

        }
        /// <summary>
        /// Wypisuje informacje o pojedynczym obiekcie
        /// </summary>
        public void Poj_model()
        {
            Console.WriteLine("Oto lista modeli wybierz jeden dla szczegolowych informacji: ");
            Console.Write(Environment.NewLine);
            for (int i = 0; i < mobil.Count; i++)
            {
                Console.WriteLine(mobil[i].model + Environment.NewLine);
            }
            Console.Write("Podaj model: ");
            string mdl = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Oto wynik: "+ Environment.NewLine);
            for (int i = 0; i < mobil.Count; i++)
            {
                if (mdl == mobil[i].model)
                {
                    Console.WriteLine("Marka: " + mobil[i].marka);
                    Console.WriteLine("Model: " + mobil[i].model);
                    Console.WriteLine("Rocznik: " + mobil[i].rocznik);
                    Console.WriteLine("Pojemnosc: " + mobil[i].pojemnosc);
                    Console.WriteLine("Przebieg: " + mobil[i].przebieg);
                    Console.WriteLine("Typ skrzyni biegow: " + mobil[i].tp_skr_bieg + Environment.NewLine);
                    break;
                }
                else
                    continue;
            }

        }
        /// <summary>
        /// Sortuje dostepne obiekty wedlug wskazan uzytkownika
        /// </summary>
        public void Sort()
        {
            Console.Clear();
            Console.WriteLine("Po czym posortowac: ");
            Console.WriteLine("1. Po roczniku.");
            Console.WriteLine("2. Po pojemnosci.");
            Console.WriteLine("3. Po przebiegu.");
            Console.Write("Numer: ");
            string odpo = Console.ReadLine();
            Console.Clear();
            Console.Write("Malejaco (1) czy Rosnaco (2): ");
            string mal_ro = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Oto one: " + Environment.NewLine);
            List<int> sortownica = new List<int>();
            switch(odpo)
            {
                case "1":
                    {
                        Console.WriteLine("Sortowane po roczniku.");
                        for (int i = 0; i < mobil.Count; i++)
                        {
                            sortownica.Add(new int());
                            sortownica[i] = mobil[i].rocznik;
                        }
                        sortownica.Sort();

                        if(mal_ro=="1")
                        {
                            Console.WriteLine("Malejaco.");
                            for (int i = sortownica.Count-1; i >= 0; i--)
                            {
                                int a = 0;
                                while(true)
                                {

                                if(sortownica[i]==mobil[a].rocznik)
                                {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                }
                                else 
                                    a++;
                                }

                            }
                        }
                        else if (mal_ro=="2")
                        {
                            Console.WriteLine("Rosnaco.");
                            for (int i = 0; i <= mobil.Count-1; i++)
                            {
                                int a = 0;
                                while (true)
                                {

                                    if (sortownica[i] == mobil[a].rocznik)
                                    {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                    }
                                    else
                                        a++;
                                }

                            }
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Sortowane po pojemnosci.");
                        for (int i = 0; i < mobil.Count; i++)
                        {
                            sortownica.Add(new int());
                            sortownica[i] = mobil[i].pojemnosc;
                        }
                        sortownica.Sort();

                        if (mal_ro == "1")
                        {
                            Console.WriteLine("Malejaco.");
                            for (int i = sortownica.Count - 1; i >= 0; i--)
                            {
                                int a = 0;
                                while (true)
                                {

                                    if (sortownica[i] == mobil[a].pojemnosc)
                                    {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                    }
                                    else
                                        a++;
                                }

                            }
                        }
                        else if (mal_ro == "2")
                        {
                            Console.WriteLine("Rosnaco.");
                            for (int i = 0; i <= mobil.Count - 1; i++)
                            {
                                int a = 0;
                                while (true)
                                {

                                    if (sortownica[i] == mobil[a].pojemnosc)
                                    {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                    }
                                    else
                                        a++;
                                }

                            }
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Sortowane po przebiegu.");
                        for (int i = 0; i < mobil.Count; i++)
                        {
                            sortownica.Add(new int());
                            sortownica[i] = mobil[i].przebieg;
                        }
                        sortownica.Sort();

                        if (mal_ro == "1")
                        {
                            Console.WriteLine("Malejaco.");
                            for (int i = sortownica.Count - 1; i >= 0; i--)
                            {
                                int a = 0;
                                while (true)
                                {

                                    if (sortownica[i] == mobil[a].przebieg)
                                    {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                    }
                                    else
                                        a++;
                                }

                            }
                        }
                        else if (mal_ro == "2")
                        {
                            Console.WriteLine("Rosnaco.");
                            for (int i = 0; i <= mobil.Count - 1; i++)
                            {
                                int a = 0;
                                while (true)
                                {

                                    if (sortownica[i] == mobil[a].przebieg)
                                    {
                                        Console.WriteLine("Marka: " + mobil[a].marka);
                                        Console.WriteLine("Model: " + mobil[a].model);
                                        Console.WriteLine("Rocznik: " + mobil[a].rocznik);
                                        Console.WriteLine("Pojemnosc: " + mobil[a].pojemnosc);
                                        Console.WriteLine("Przebieg: " + mobil[a].przebieg);
                                        Console.WriteLine("Typ skrzyni biegow: " + mobil[a].tp_skr_bieg + Environment.NewLine);
                                        a = 0;
                                        break;
                                    }
                                    else
                                        a++;
                                }

                            }
                        }
                        break;
                    }
            }
            sortownica.Clear();
        }
        /// <summary>
        /// Usuwa plik wybrany przez uzytkownika
        /// </summary>
        public void Kasacja()
        {
            Console.Clear();
            Console.Write("Oto lista modeli. Wybierz element, ktory chcesz usunac: ");
            for(int i=0;i<mobil.Count;i++)
            {
                Console.WriteLine(i+1+". "+mobil[i].model+Environment.NewLine);
            }
            Console.Write("Wybierz podajac nazwe: ");
            string dekl = Console.ReadLine();
            int numerek=0;
            while(true)
            {

                if (dekl == mobil[numerek].model)
                {
                    mobil.RemoveAt(numerek);
                    break;
                }
                else
                    numerek++;
            }
            System.IO.StreamWriter plik =
            new StreamWriter(@"D:\C#\Katalog.CS\baza.txt");
            plik.Dispose();
            plik.Close();
            System.IO.StreamWriter plik1 =
            new StreamWriter(@"D:\C#\Katalog.CS\baza.txt");
            for (int i = 1; i <= mobil.Count; i++)
            {
                plik1.WriteLine(mobil[i - 1].marka);
                plik1.WriteLine(mobil[i - 1].model);
                plik1.WriteLine(mobil[i - 1].rocznik);
                plik1.WriteLine(mobil[i - 1].pojemnosc);
                plik1.WriteLine(mobil[i - 1].przebieg);
                if (i < mobil.Count)
                    plik1.WriteLine(mobil[i - 1].tp_skr_bieg);
                else if (i == mobil.Count)
                    plik1.Write(mobil[i - 1].tp_skr_bieg);
            }
            plik1.Close();
            Console.Clear();
            Console.WriteLine("Gotowe.");
        }
    }
    public class Program
    {
       public static void Main(string[] args)
        {
            Samochod komp = new Samochod();
            komp.Odczyt();
                Console.WriteLine("Witam w moim katalogu.");
            Console.ReadKey();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Oto opcje: ");
                Console.WriteLine("1. Dodanie nowego modelu.");
                Console.WriteLine("2. Lista wszystkich obiektow w katalogu");
                Console.WriteLine("3. Wypisuje modele wedlug podanego parametru.");
                Console.WriteLine("4. Szczegolowe informacje o wybranym modelu.");
                Console.WriteLine("5. Sortowanie modeli.");
                Console.WriteLine("6. Usuwa niepotrzebny model.");
                Console.WriteLine("7. Wyjscie z programu.");
                Console.Write("Podaj numer: ");
                string odp = Console.ReadLine();
                switch(odp)
                {
                //Wywolanie poszczegolnych opcji
                    case "1":
                    {
                        komp.Zapis();
                        break;
                    }
                case "2":
                    {
                        komp.Lista();
                        break;
                    }
                case "3":
                    {
                        komp.War_Lista();
                        break;
                    }
                case "4":
                    {
                        komp.Poj_model();
                        break;
                    }
                case "5":
                    {
                            komp.Sort();
                            break;
                    }
                case "6":
                    {
                        komp.Kasacja();
                        break;
                    }
                case "7":
                    {
                            Console.Clear();
                            Console.WriteLine("Dowidzenia");
                            Console.ReadKey();
                            return;
                    }
                default:
                    {
                            Console.Clear();
                            Console.WriteLine("Nie umisz czytac?");
                        break;
                    }
                }
            }
        }
    }
}