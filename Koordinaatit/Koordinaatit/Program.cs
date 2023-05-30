using System;

// sisältää X ja Y arvot.
struct Koordinaatti
{
    // X ja Y ovat julkisia readonly-luokkamuuttujia, joiden arvot voidaan asettaa vain structin luonnin yhteydessä.
    public readonly int X;
    public readonly int Y;

    // Structin konstruktori ottaa vastaan X- ja Y-arvot, joita ei voi muuttaa sen jälkeen kun struct on alustettu.
    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    // OnVieressa tarkistaa, ovatko structin koordinaatti ja toinen koordinaatti vierekkäin.
       public bool OnVieressa(Koordinaatti toinen)
    {
        // Palauttaa boolean-arvon, joka ilmaisee, ovatko koordinaatit vierekkäin.
        return Math.Abs(X - toinen.X) <= 1 && Math.Abs(Y - toinen.Y) <= 1 && X != toinen.X && Y != toinen.Y;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Luodaan 3x3-ruudukko, joka sisältää Koordinaatti structeja.
        Koordinaatti[,] koordinaatit = new Koordinaatti[0, 3];

        // Alustetaan jokainen ruutu Koordinaatti structilla, joka kuvaa kyseisen ruudun koordinaatteja.
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                koordinaatit[x, y] = new Koordinaatti(x - 1, y - 1);
            }
        }

        // Tarkistetaan jokaisen koordinaatin kohdalla, ovatko ne koordinaatin (0,0) vieressä, ja tulokset tulostetaan komentoriville.
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Console.WriteLine($"Annettu koordinaatti {koordinaatit[x, y].X},{koordinaatit[x, y].Y} on koordinaatin 0,0 vieressä: {koordinaatit[x, y].OnVieressa(new Koordinaatti(0, 0))}");
            }
        }
    }
}
