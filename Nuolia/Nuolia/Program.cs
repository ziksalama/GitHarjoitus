


using System.Runtime.InteropServices;

Nuoli gen = new Nuoli(Kärki.timantti, Perä.kotkansulka, 100);
Console.WriteLine("Rakenetaan nuoli!");
Console.WriteLine("-------------------------------------------------------------");
string insert;
Kärki kärki;
Perä perä;
Console.WriteLine("Minkälainen kärki? (puu, teräs vai timantti)");
insert = Console.ReadLine();
double Hinta;
Hinta = 0;
bool retryloop;
if (insert == "puu")
{
    kärki = Kärki.puu;
    Hinta += 3;

}
else if (insert == "teräs")
{
    kärki = Kärki.teräs;
    Hinta += 5;
}
else if (insert == "timantti")
{
    kärki = Kärki.timantti;
    Hinta += 50;
}
Console.WriteLine("Minkälainen perä?(lehti, kanansulka, kotkansulka");
insert = Console.ReadLine();
if (insert == "lehti")
{
    perä = Perä.lehti;
    Hinta += 0;
}
else if (insert == "kanansulka")
{
    perä = Perä.kanansulka;
    Hinta += 1;
}
else if (insert == "kotkansulka")
{
    perä = Perä.kotkansulka;
    Hinta += 5;
}

retryloop = true;
while (retryloop)
{
    Console.WriteLine("Pituus?(60-100cm)");
    insert = Console.ReadLine();
    if (Int32.Parse(insert) >= 60 && (Int32.Parse(insert) <= 100))
    {
        Hinta += 0.05 * Int32.Parse(insert);
        retryloop = false;

    }
    else
    {
        Console.WriteLine("Koita uudestaan");
        retryloop = true;
    }
}
Console.WriteLine("Hinta:" + Hinta);


class Nuoli
{

    private Kärki kärki;
    private Perä perä;
    public int cm;
    public Nuoli(Kärki kärki, Perä perä, double cm)
    {
        this.kärki = kärki;
        this.perä = perä;
        this.cm = 60;
    }

}
//public int pituus;

public enum Kärki { puu, teräs, timantti };
public enum Perä { lehti, kanansulka, kotkansulka };
