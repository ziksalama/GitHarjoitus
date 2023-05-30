using static System.Net.Mime.MediaTypeNames;
using System;
using System;
using System.Windows.Forms;

class MainClass
{
    public static void Main(string[] args)
    {
        int position = 0;
        int target = 6;
        int kultaraha = 0;
        bool store = false;
        string ase = "ruosteinen miekka";
        int elamat = 3;
        bool lvl1 = true;
        bool lvl2 = false;
        bool lvl3 = false;
        bool lvl4 = false;
        bool lvl5 = false;

        MessageBox.Show("Voi ei! Rohkea ritari, Don Quijote, on eksynyt syvälle tuulimyllyyn.\nAuta Don Quijotea pääsemään ulos tuulimyllyn syöväreistä", "Don Quijote ja tuulimylly");


        //Ensimmäinen taso
        while (lvl1)
        {
            DialogResult result = MessageBox.Show("Voi ei! Vihainen örkki syöksyy Don Quijotea päin? Haluatko taistella?", "Don Quijote ja tuulimylly", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int enemyHp = 20;
                while (enemyHp > 0 && elamat > 0)
                {
                    DialogResult battleResult = MessageBox.Show("Örkki hyökkää! Mitä teet?", "Taistelu", MessageBoxButtons.YesNoCancel);
                    if (battleResult == DialogResult.Yes)
                    {
                        int damage = 5;
                        enemyHp -= damage;
                        MessageBox.Show($"Osuit örkkiin {damage} pistettä vahinkoa! Örkin elämät: {enemyHp}");
                    }
                    else if (battleResult == DialogResult.No)
                    {
                        MessageBox.Show("Pakenit taistelusta, menetit 5 elämää");
                        elamat -= 5;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Puolustauduit onnistuneesti!");
                    }

                    if (enemyHp <= 0)
                    {
                        kultaraha += 30;
                        MessageBox.Show("Nujersit örkin! Löysit 30 kultaa", "Don Quijote ja tuulimylly");
                        lvl2 = true;
                    }
                    else
                    {
                        int enemyDamage = 10;
                        elamat -= enemyDamage;
                        MessageBox.Show($"Örkki hyökkää! Menetit {enemyDamage} elämää. Elämät: {elamat}");
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                position--;
            }
            else
            {
                MessageBox.Show("Väärä syöte. Valitse Kyllä tai Ei.");
                continue;
            }

            if (elamat <= 0)
            {
                MessageBox.Show("Don Quijote kuoli. Peli ohi.");
                Application.Exit();
            }

            // Näytetään pelitilanne
            string vihollisteksti = "";
            for (int i = 0; i < viholliset.Count; i++)
            {
                vihollisteksti += "Vihollinen " + (i + 1) + ": " + viholliset[i].Nimi + " (" + viholliset[i].Elamat + " elämää)\n";
            }

            MessageBox.Show("Taistelu jatkuu...\n\nDon Quijote: " + donquijote.Elamat + " elämää\n\n" + vihollisteksti, "Don Quijote ja tuulimylly - Taistelu");

            // Vaihtoehtoisten toimintojen valinta
            DialogResult result = MessageBox.Show("Mitä haluat tehdä?\n\n1. Hyökkää vihollisen kimppuun\n2. Juokse pois", "Don Quijote ja tuulimylly - Taistelu", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Valitaan hyökättävä vihollinen
                string vihollisvalinta = Microsoft.VisualBasic.Interaction.InputBox("Minkä vihollisen kimppuun hyökkäät? (Syötä vihollisen numero)", "Don Quijote ja tuulimylly - Taistelu");
                int vihollisnumero;
                if (int.TryParse(vihollisvalinta, out vihollisnumero) && vihollisnumero > 0 && vihollisnumero <= viholliset.Count)
                {
                    // Lasketaan hyökkäyksen voima satunnaisesti
                    int hyokkaysvoima = random.Next(1, 11) + donquijote.Voima;

                    // Vähennetään hyökkäyksen voima vihollisen elämistä
                    viholliset[vihollisnumero - 1].Elamat -= hyokkaysvoima;

                    // Tarkistetaan, oliko hyökkäys tappava
                    if (viholliset[vihollisnumero - 1].Elamat <= 0)
                    {
                        // Poistetaan vihollinen
                        viholliset.RemoveAt(vihollisnumero - 1);
                        MessageBox.Show("Voitit vihollisen!", "Don Quijote ja tuulimylly - Taistelu");
                    }
                    else
                    {
                        MessageBox.Show("Vihollinen selvisi hyökkäyksestä!", "Don Quijote ja tuulimylly - Taistelu");
                    }
                }
                else
                {
                    MessageBox.Show("Väärä syöte. Syötä voimassa oleva vihollisen numero.", "Don Quijote ja tuulimylly - Taistelu");
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Don Quijote juoksi pois taistelusta!", "Don Quijote ja tuulimylly - Taistelu");
                break;
            }
        }
    }

    // Peli voitettu
    MessageBox.Show("Onneksi olkoon! Voitit pelin!", "Voitto");
        
   }
