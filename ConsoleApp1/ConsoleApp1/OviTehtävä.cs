string task;
ovi OviTila;
OviTila = ovi.Tyhjä;
while (true)
{
    Console.WriteLine("Mitä haluat tehdä? ");
    Console.WriteLine("1 - Avaa ovi");
    Console.WriteLine("2 - Sulje ovi");
    Console.WriteLine("3 - Lukitse ovi");
    Console.WriteLine("4 - Avaa oven lukko");
    task = Console.ReadLine();
    if (OviTila == ovi.Tyhjä)
    {
        if (task == "1")
        {
            Console.WriteLine("Ovi on nyt auki");
            OviTila = ovi.Auki;
                 
        }
        if (task == "2")
        {
            Console.WriteLine("Ovi on nyt kiinni");
            OviTila = ovi.Kiinni;
                 
        }
        if (task == "3")
        {
            Console.WriteLine("Ovi on nyt lukossa");
            OviTila = ovi.Lukossa;
                 
        }
        if (task == "4")
        {
            Console.WriteLine("Ovi on nyt kiinni");
            OviTila = ovi.Kiinni;
                 
        }
    }
    if (task == "1" && OviTila == ovi.Kiinni)
    {
        Console.WriteLine("Ovi on nyt auki");
        OviTila = ovi.Auki;
    }
    if (task == "2" && OviTila == ovi.Auki)
    {
        Console.WriteLine("Ovi on nyt kiinni");
        OviTila = ovi.Kiinni;
    }
    if (task == "3" && OviTila == ovi.Kiinni)
    {
        Console.WriteLine("Ovi on nyt lukossa");
        OviTila = ovi.Lukossa;
    }
    if (task == "4" && OviTila == ovi.Lukossa)
    {
        Console.WriteLine("Ovi ei ole enään lukossa");
OviTila = ovi.Kiinni;
    }
    Console.WriteLine(" ");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine(" ");
}



enum ovi { Auki, Kiinni, Lukossa, Tyhjä };