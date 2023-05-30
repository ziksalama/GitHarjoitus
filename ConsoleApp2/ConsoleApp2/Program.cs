using System;

class Tavara
{
    public double paino;
    public double tilavuus;

    public Tavara(double paino, double tilavuus)
    {
        this.paino = paino;
        this.tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

class Reppu
{
    private Tavara[] tavarat;
    private int maxTavaraMaara;
    private double maxKantoPaino;
    private double maxTilavuus;
    private int tavaroidenMaara;
    private double tavaroidenPaino;
    private double tavaroidenTilavuus;

    public Reppu(int maxTavaraMaara, double maxKantoPaino, double maxTilavuus)
    {
        this.tavarat = new Tavara[maxTavaraMaara];
        this.maxTavaraMaara = maxTavaraMaara;
        this.maxKantoPaino = maxKantoPaino;
        this.maxTilavuus = maxTilavuus;
        this.tavaroidenMaara = 0;
        this.tavaroidenPaino = 0;
        this.tavaroidenTilavuus = 0;
    }

    public bool Lisää(Tavara tavara)
    {
        if (tavaroidenMaara == maxTavaraMaara || tavaroidenPaino + tavara.paino > maxKantoPaino || tavaroidenTilavuus + tavara.tilavuus > maxTilavuus)
        {
            return false;
        }
        tavarat[tavaroidenMaara] = tavara;
        tavaroidenMaara++;
        tavaroidenPaino += tavara.paino;
        tavaroidenTilavuus += tavara.tilavuus;
        return true;
    }

    public void TulostaTilanne()
    {
        Console.WriteLine("Tavaroiden määrä: " + tavaroidenMaara);
        Console.WriteLine("Tavaroiden paino: " + tavaroidenPaino + "/" + maxKantoPaino);
        Console.WriteLine("Tavaroiden tilavuus: " + tavaroidenTilavuus + "/" + maxTilavuus);
        Console.WriteLine("Jäljellä oleva kapasiteetti: " + (maxTavaraMaara - tavaroidenMaara));
    }
}

class pääohjelma
{
    static void Main(string[] args)
    {
        // Create a new backpack with maximum capacity of 5 items, maximum weight of 10, and maximum volume of 10
        Reppu Sisältö = new Reppu(5, 10, 10);

        // Print the initial backpack capacity information
        Console.WriteLine("Uusi reppu luotu: max. {0} tavaraa, max. paino {1}, max. tilavuus {2}", Sisältö.MaxTavarat, Sisältö.MaxPaino, Sisältö.MaxTilavuus);
        Console.WriteLine("Reppu on tyhjä. Jäljellä oleva kapasiteetti: {0} tavaraa, {1} painoa, {2} tilavuutta", Sisältö.JäljelläTavarat, Sisältö.JäljelläPaino, Sisältö.JäljelläTilavuus);

        // Loop until the user chooses to exit
        while (true)
        {
            // Print the menu
            Console.WriteLine("\nValitse tavara lisättäväksi:");
            Console.WriteLine("1. Nuoli");
            Console.WriteLine("2. Jousi");
            Console.WriteLine("3. Köysi");
            Console.WriteLine("4. Vesi");
            Console.WriteLine("5. Ruoka-annos");
            Console.WriteLine("6. Miekka");
            Console.WriteLine("0. Poistu");

            // Read the user's choice
            Console.Write("Valintasi: ");
            string choiceStr = Console.ReadLine();
            int choice;
            if (!int.TryParse(choiceStr, out choice))
            {
                Console.WriteLine("Virheellinen valinta.");
                continue;
            }

            // Add the selected item to the backpack
            Tavara item = null;
            switch (choice)
            {
                case 0:
                    // Exit the program
                    return;
                case 1:
                    item = new Nuoli();
                    break;
                case 2:
                    item = new Jousi();
                    break;
                case 3:
                    item = new Köysi();
                    break;
                case 4:
                    item = new Vesi();
                    break;
                case 5:
                    item = new RuokaAnnos();
                    break;
                case 6:
                    item = new Miekka();
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta.");
                    continue;
            }
            if (!Sisältö.Lisää(item))
            {
                Console.WriteLine("Tavaran lisääminen epäonnistui, repussa ei ole tarpeeksi tilaa.");
            }
            else
            {
                Console.WriteLine("{0} lisätty repun sisältöön.", item.GetType().Name);
                Console.WriteLine("Jäljellä oleva kapasiteetti: {0} tavaraa, {1} painoa, {2} tilavuutta", Sisältö.JäljelläTavarat, Sisältö.JäljelläPaino, Sisältö.JäljelläTilavuus);
            }
        }
    }
}
