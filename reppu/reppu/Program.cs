using System;

public class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

public class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

public class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

public class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

public class Vettä : Tavara
{
    public Vettä() : base(2, 2) { }
}

public class Ruokaa : Tavara
{
    public Ruokaa() : base(1, 0.5) { }
}

public class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

public class Backpack
{
    private Tavara[] _tavarat;
    private int _maxTavarat;
    private double _maxPaino;
    private double _maxTilavuus;

    public int TavaraMäärä => _tavarat.Length;
    public double YhteinenPaino => _tavarat.Sum(item => item.Paino);
    public double YhteinenTilavuus => _tavarat.Sum(item => item.Tilavuus);
    public bool IsFull => TavaraMäärä >= _maxTavarat || YhteinenPaino >= _maxPaino || YhteinenTilavuus >= _maxTilavuus;

    public Backpack(int maxTavarat, double maxPaino, double maxTilavuus)
    {
        _maxTavarat = maxTavarat;
        _maxPaino = maxPaino;
        _maxTilavuus = maxTilavuus;
        _tavarat = new Tavara[0];
    }

    public bool Add(Tavara item)
    {
        if (IsFull)
        {
            return false;
        }

        var newItems = new Tavara[TavaraMäärä + 1];
        Array.Copy(_tavarat, newItems, TavaraMäärä);
        newItems[TavaraMäärä] = item;
        _tavarat = newItems;
        return true;
    }

    public void RepunSisältö()
    {
        Console.WriteLine($"Tavaroiden määrä: {TavaraMäärä}");
        Console.WriteLine($"Tavaroiden paino: {YhteinenPaino} / {_maxPaino}");
        Console.WriteLine($"Tavaroiden tilavuus: {YhteinenTilavuus} / {_maxPaino}");
        Console.WriteLine($"Tilaa jäljellä: {TilaaJäljellä()}");
    }

    private string TilaaJäljellä()
    {
        var TavaroitaTila = _maxTavarat - TavaraMäärä;
        var PainoTila = _maxPaino - YhteinenPaino;
        var TilavuusTila = _maxTilavuus - YhteinenTilavuus;
        return $"Tavarat: {TavaroitaTila}, Paino: {PainoTila}, Tilavuus: {TilavuusTila}";
    }
}

public class Program
{
    public static void Main()
    {
        var ReppuPeppu = new Backpack(10, 30, 20);

        while (true)
        {
            Console.WriteLine(" ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Mitä lisätään reppuun?");
            Console.WriteLine("1. Nuoli");
            Console.WriteLine("2. Jousi");
            Console.WriteLine("3. Köysi");
            Console.WriteLine("4. Vettä");
            Console.WriteLine("5. Ruokaa");
            Console.WriteLine("6. Miekka");
            Console.WriteLine("0. Ei mitään");

            var input = Console.ReadLine();

            if (int.TryParse(input, out var choice))
            {
                switch (choice)
                {
                    case 0:
                        return;
                    default:
                    case 1:
                        Lisää(ReppuPeppu, new Nuoli());
                        break;
                    case 2:
                        Lisää(ReppuPeppu, new Jousi());
                        break;
                    case 3:
                        Lisää(ReppuPeppu, new Köysi());
                        break;
                    case 4:
                        Lisää(ReppuPeppu, new Vettä());
                        break;
                    case 5:
                        Lisää(ReppuPeppu, new Ruokaa());
                        break;
                    case 6:
                        Lisää(ReppuPeppu, new Miekka());
                        break;

                }
            }
            else
            {
                Console.WriteLine("Ei onnistu");
            }
        }
    }
    private static void Lisää(Backpack backpack, Tavara item)
    {
        if (backpack.Add(item))
        {
            Console.WriteLine($"{item.GetType().Name} lisättiin reppuun");
            backpack.RepunSisältö();
        }
        else
        {
            Console.WriteLine($"Tavaran {item.GetType().Name} lisääminen reppuun ei onnistu. Reppu on täynnä.");
        }
    }
}