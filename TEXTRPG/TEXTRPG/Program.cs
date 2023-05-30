using System;
//Peli toimii pop up ikkunoiden avuilla
using System.Windows.Forms;

class MainClass
{
    public static void Main(string[] args)
    {
        int position = 0;
        int target = 6;
        int kultaraha = 0;
        bool store = false;
        int pelaajaHP = 100;
        int orcHP = 100;
        int dragonHP = 200;
        string ase = "ruosteinen miekka";
        bool lvl1 = true;
        bool lvl2 = false;
        bool lvl3 = false;
        bool lvl4 = false;
        bool lvl5 = false;
        bool orcbattle = false;
        bool dragonbattle = false;
        bool reppuauki = false;

        Console.WriteLine("Voi ei! Rohkea ritari, Don Quijote, on eksynyt syvälle tuulimyllyyn.\nAuta Don Quijotea pääsemään ulos tuulimyllyn syöväreistä");
        Console.WriteLine("Don Quijote ja tuulimylly");

        while (lvl1)
        {
            Console.WriteLine("Voi ei! Vihainen örkki syöksyy Don Quijotea päin? Otatko miekan esiin? (K/E)");
            string input = Console.ReadLine();

            if (input.ToLower() == "k")
            {
                lvl1 = false;
                position++;
                Console.WriteLine("Löysit 30 kultaa");
                kultaraha += 30;
                orcbattle = true;
            }
            else if (input.ToLower() == "e")
            {
                position--;
            }
            else
            {
                Console.WriteLine("Väärä syöte. Valitse Hyökkää tai Puollusta.");
                continue;
            }

            if (position < 0)
            {
                Console.WriteLine("\"Kuolit\"");
                lvl1 = false;
            }
            else if (position == target)
            {
                Console.WriteLine("\"Voitit\"");
                lvl1 = false;
            }
            else
            {
                Console.WriteLine(new string('-', position) + "0" + new string('-', target - position - 1) + "X");
            }
        }

        while (orcbattle)
        {
            // Pelaajan vuoro:
            Console.WriteLine("Don Quijotella on " + pelaajaHP + " HP jäljellä");
            Console.WriteLine("Örkillä on " + orcHP + " HP jäljellä");
            Console.WriteLine("Valitse hyökkäys:");
            Console.WriteLine("1. Lyö käyttäen " + ase + "(10-15 vahinkoa)");
            if (ase == "Jousi")
            {
                Console.WriteLine("2. Ampua jousella (15-20 vahinkoa)");
            }
            if (ase != "Jousi")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Ampua jousella (15-20 vahinkoa)");
                Console.ResetColor();
            }
            Console.WriteLine("3. Nosta kilpi (Antaa 10-20 HP:tä)");
            Console.WriteLine("4. Avaa reppu");

            ConsoleKeyInfo input = Console.ReadKey(true);
            int pelaajaDMG = 0;

            //Vahingon tekeminen
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    pelaajaDMG = new Random().Next(10, 16);
                    Console.WriteLine("Lyötit örkkiä miekalla ja teit " + pelaajaDMG + " vahinkoa!");
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    if (ase != "Jousi")
                    {
                        Console.WriteLine("Koitit osua jousella, kunnes tajusit että sinulla ei ole jousta");
                        Console.Clear();
                    }
                    if (ase == "Jousi")
                    {
                        pelaajaDMG = new Random().Next(15, 21);
                        Console.WriteLine("Ampuit örkkiä jousella ja teit " + pelaajaDMG + " vahinkoa!");
                        Console.Clear();
                    }
                    break;
                case ConsoleKey.D3:
                    pelaajaHP += new Random().Next(10, 20);
                    Console.WriteLine("käytit kilpeä");
                    Console.Clear();
                    break;
                case ConsoleKey.D4:
                    reppuauki = true;
                    Console.WriteLine("Avasit repun");
                    if (reppuauki)
                    {
                        Console.WriteLine("Reppu sisältää seuraavat tavarat:");
                        // Näytä repun sisältö
                        // Inventory
                        Console.WriteLine("1. kolikko");
                        // palaa taisteluun
                        Console.WriteLine("0. Takaisin taisteluun");

                        ConsoleKeyInfo repunInput = Console.ReadKey(true);
                        switch (repunInput.Key)
                        {
                            case ConsoleKey.D0:
                                reppuauki = false;
                                Console.WriteLine("Suljit repun");
                                Console.Clear();
                                continue;


                            case ConsoleKey.D1:
                                reppuauki = false;

                                          
                            default:
                                Console.WriteLine("Valitse numero 0 palataksesi takaisin taisteluun.");
                                Console.Clear();
                                continue;
                        }
                    }

                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Valitse numero 1, 2, 3 tai 4 hyökkäystä varten.");
                    Console.Clear();
                    continue;
            }

            orcHP -= pelaajaDMG;

            if (orcHP <= 0)
            {
                Console.WriteLine("Voitit taistelun!");
                orcbattle = false;
                lvl2 = true;
            }

            // Orkin vuoro:
            int orcAttack = new Random().Next(5, 16);
            pelaajaHP -= orcAttack;
            Console.WriteLine("Orkki iski sinua " + orcAttack + " vahinkoa!");

            if (pelaajaHP <= 0)
            {
                Console.WriteLine("Hävisit taistelun...");
                break;
            }


            while (lvl2)
        {
            DialogResult result2 = MessageBox.Show("Don Quijote näkee edessään tuulimyllyn lahjakaupan, astutko sisään?", "Don Quijote ja tuulimylly", MessageBoxButtons.YesNo);
            if (result2 == DialogResult.Yes)
            {
                lvl2 = false;

                store = true;
            }
            else if (result2 == DialogResult.No)
            {
                lvl3 = true;
                lvl2 = false;
            }
            else
            {
                MessageBox.Show("Väärä syöte. Valitse Hyökkää tai Puollusta.");
                continue;
            }

            if (position < 0)
            {
                MessageBox.Show("\"Kuolit\"");
                lvl1 = false;
            }
            else if (position == target)
            {
                MessageBox.Show("\"Voitit\"");
                lvl1 = false;
            }
            else
            {

                MessageBox.Show(new string('-', position) + "0" + new string('-', target - position - 1) + "X", "Don Quijoten matka uloskäynnille");
            }
            while (lvl3)
            {
                DialogResult result3 = MessageBox.Show("Don Quijote näkee edessään tuulimyllyn lahjakaupan, astutko sisään?", "Don Quijote ja tuulimylly", MessageBoxButtons.YesNo);
                if (result3 == DialogResult.Yes)
                {
                    lvl2 = false;

                    store = true;
                }
                else if (result3 == DialogResult.No)
                {
                    lvl3 = true;
                    lvl2 = false;
                    store = false;
                }
                else
                {
                    MessageBox.Show("Väärä syöte. Valitse Hyökkää tai Puollusta.");
                    continue;
                }

                if (position < 0)
                {
                    MessageBox.Show("\"Kuolit\"");
                    lvl1 = false;
                }
                else if (position == target)
                {
                    MessageBox.Show("\"Voitit\"");
                    lvl1 = false;
                }

            }
            while (store)
            {
                MessageBox.Show("Astut kauppaan");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                
                Console.WriteLine("Valitse ase: ");
                Console.WriteLine("1. Miekka 15-20 (10 kultarahaa)");
                Console.WriteLine("2. Kirves 20-30dmg (20 kultarahaa)");
                Console.WriteLine("3. Jousi (30 kultarahaa)");
                Console.WriteLine("4. Poistu kaupasta");

                ConsoleKeyInfo input = Console.ReadKey();

                //Chekkaa pelaajan valinnan
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        if (kultaraha >= 10)
                        {
                            Console.WriteLine("Ostit Miekan");
                            ase = "Miekka";
                            kultaraha -= 10;
                            Console.WriteLine("Sinulle jäi:" + kultaraha + "kultaa");
                            store = false;
                            lvl3 = true; // uusi rivi
                        }
                        else
                        {
                            Console.WriteLine("Sinulla ei ole tarpeeksi kultaa.");
                        }
                        break;
                    case ConsoleKey.D2:
                        if (kultaraha >= 20)
                        {
                            Console.WriteLine("Ostit Kirveen");
                            ase = "Kirves";
                            kultaraha -= 20;
                            Console.WriteLine("Sinulle jäi:" + kultaraha + "kultaa");
                            store = false;
                            lvl3 = true; // uusi rivi
                        }
                        else
                        {
                            Console.WriteLine("Sinulla ei ole tarpeeksi kultaa.");
                        }
                        break;
                    case ConsoleKey.D3:
                        if (kultaraha >= 30)
                        {
                            Console.WriteLine("Ostit Jousen");
                            ase = "Jousi";
                            kultaraha -= 30;
                            Console.WriteLine("Sinulle jäi:" + kultaraha + "kultaa");
                            store = false;
                            lvl3 = true; // uusi rivi
                        }
                        else
                        {
                            Console.WriteLine("Sinulla ei ole tarpeeksi kultaa.");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Poistut kaupasta");
                        store = false;
                        lvl3 = true; // uusi rivi
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        break;
                }

                Console.WriteLine("Sinulla on nyt " + kultaraha + " kultarahaa.");
                Console.WriteLine("Sinulla on nyt " + ase + ".");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                
            }
        }
            while (lvl3)
            {
                DialogResult result3 = MessageBox.Show("Astuttuaan kaupasta ulos, Don Quijote näkee auringon valon tulevan tunnelista, astutko sinne päin, vai takaisin kauppaan?", "Don Quijote ja tuulimylly", MessageBoxButtons.YesNo);
                if (result3 == DialogResult.Yes)
                {
                    dragonbattle = true;

                    lvl3 = false;
                }
                else if (result3 == DialogResult.No)
                {
                    lvl3 = false;
                    store = true;
                }


                else
                {

                    MessageBox.Show(new string('-', position) + "0" + new string('-', target - position - 1) + "X", "Don Quijoten matka uloskäynnille");
                }

            }
            while (dragonbattle)
            {
                
                // Pelaajan vuoro:
                Console.WriteLine("Don Quijotella on " + pelaajaHP + " HP jäljellä");
                Console.WriteLine("Lohikäärmeellä on " + dragonHP + " HP jäljellä");
                Console.WriteLine("Valitse hyökkäys:");
                if (ase == "Miekka")
                {
                    Console.WriteLine("1. Lyö käyttäen " + ase + "(15-20 vahinkoa)");
                }
                if (ase == "Kirves")
                {
                    Console.WriteLine("1. Lyö käyttäen " + ase + "(20-30 vahinkoa)");
                }
                else if (ase != "Kirves" || ase != "Miekka")
                {
                    Console.WriteLine("1. Lyö käyttäen ruosteinen miekka (10-15 vahinkoa)");
                }
                if (ase == "Jousi")
                {
                    Console.WriteLine("2. Ampua jousella (15-40 vahinkoa)");
                }
                if (ase != "Jousi")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("2. Ampua jousella (15-20 vahinkoa)");
                    Console.ResetColor();
                }
                Console.WriteLine("3. Nosta kilpi (Antaa 10-20 HP:tä)");

                ConsoleKeyInfo input = Console.ReadKey(true);
                int pelaajaDMG = 0;


                //Vahingon tekeminen
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        pelaajaDMG = new Random().Next(10, 16);
                        Console.WriteLine("Lyötit örkkiä miekalla ja teit " + pelaajaDMG + " vahinkoa!");
                        break;
                    case ConsoleKey.D2:
                        if (ase != "Jousi")
                        {
                            Console.WriteLine("Koitit osua jousella, kunnes tajusit että sinulla ei ole jousta");
                        }
                        if (ase == "Jousi")
                        {
                            pelaajaDMG = new Random().Next(15, 21);
                            Console.WriteLine("Ampuit örkkiä jousella ja teit " + pelaajaDMG + " vahinkoa!");
                        }

                        break;

                    case ConsoleKey.D3:
                        pelaajaHP += new Random().Next(10, 20);
                        Console.WriteLine("käytit kilpeä");
                        break;
                    default:
                        Console.WriteLine("Valitse numero 1, 2 tai 3 hyökkäystä varten.");
                        continue;
                }

                dragonHP -= pelaajaDMG;

                if (dragonHP <= 0)
                {
                    Console.WriteLine("Voitit taistelun!");
                    break;
                    dragonbattle = false;
                    

                }

                // Orkin vuoro:
                int dragonAttack = new Random().Next(16, 27);
                pelaajaHP -= dragonAttack;
                Console.WriteLine("Orkki iski sinua " + dragonAttack + " vahinkoa!");

                if (pelaajaHP <= 0)
                {
                    Console.WriteLine("Hävisit taistelun...");
                    break;
                }
            }
        }
    }