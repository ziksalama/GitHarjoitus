﻿//nuoli muuttaja
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Rakenetaan nuoli!");
Console.WriteLine("-------------------------------------------------------------");
string insert;
Kärki kärki = Kärki.puu;
Perä perä = Perä.lehti;
//int pituus = 0;

Console.WriteLine("Minkälainen kärki? (puu, teräs vai timantti)");
insert = Console.ReadLine();
bool retryloop;
if (insert == "puu")
{
    kärki = Kärki.puu;


}
else if (insert == "teräs")
{
    kärki = Kärki.teräs;

}
else if (insert == "timantti")
{
    kärki = Kärki.timantti;

}
Console.WriteLine("Minkälainen perä?(lehti, kanansulka, kotkansulka");
insert = Console.ReadLine();
if (insert == "lehti")
{
    perä = Perä.lehti;

}
else if (insert == "kanansulka")
{
    perä = Perä.kanansulka;

}
else if (insert == "kotkansulka")
{
    perä = Perä.kotkansulka;

}
retryloop = true;
while (retryloop)
{
    Console.WriteLine("Pituus?(60-100cm)");
    insert = Console.ReadLine();
    if (Int32.Parse(insert) >= 60 && (Int32.Parse(insert) <= 100))
    {
        nuoli.Pituus = Int32.Parse(insert);
        retryloop = false;

    }
    else
    {
        Console.WriteLine("Koita uudestaan");
        retryloop = true;
    }
}

nuoli uusinuoli = new nuoli(kärki, perä, 60);

Console.WriteLine("hinta:" + uusinuoli.palautahinta());
int pituus = uusinuoli.Pituus;

public class nuoli  
{
    private Kärki kärki;
    private Perä perä;
    private double kokohinta;
    private int pituus;

    public nuoli(Kärki kärki, Perä perä, int pituus)
    {
        this.kärki = kärki;
        this.perä = perä;
        this.pituus = pituus;
    }

    public int Pituus
    {
        get { return pituus; }
        private set { pituus = value; }
    }

    public double palautahinta()
    {
        if (kärki == Kärki.puu)
        {
            kokohinta += 3;
        }
        if (kärki == Kärki.teräs)
        {
            kokohinta += 5;
        }
        if (kärki == Kärki.timantti)
        {
            kokohinta += 50;
        }
        if (perä == Perä.lehti)
        {
            kokohinta += 0;
        }
        if (perä == Perä.kanansulka)
        {
            kokohinta += 1;
        }
        if (perä == Perä.kotkansulka)
        {
            kokohinta += 5;
        }

        kokohinta += 0.05 * pituus;

        return kokohinta;
    }
}



public enum Kärki { puu, teräs, timantti };
public enum Perä { lehti, kanansulka, kotkansulka }