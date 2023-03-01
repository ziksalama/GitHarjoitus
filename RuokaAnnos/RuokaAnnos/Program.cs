(aine1 PääraakaAine, aine2 Lisuke, aine3 Kastike) ruoka = (aine1.nautaa, aine2.perunaa, aine3.pippuri);
string osa1;
bool AteriaValmis;
AteriaValmis = false;

while (!AteriaValmis)
{
    Console.WriteLine("Mitä Tekee mieli? Kokoa ateriasi kirjoittamalla minkä aineen haluat");
    Console.WriteLine("Pääraaka-aine (nautaa, kanaa, kasviksia");
    osa1 = Console.ReadLine();
    if (osa1 == "nautaa")
    {
        ruoka.PääraakaAine = aine1.nautaa;
    }
    if (osa1 == "kanaa")
    {
        ruoka.PääraakaAine = aine1.kanaa;
    }
    if (osa1 == "kasviksia")
    {
        ruoka.PääraakaAine = aine1.kasviksia;
    }


    Console.WriteLine("Lisuke: perunaa, riisiä, pastaa");
    osa1 = Console.ReadLine();
    if (osa1 == "perunaa")
    {
        ruoka.Lisuke = aine2.perunaa;
    }
    if (osa1 == "riisiä")
    {
        ruoka.Lisuke = aine2.riisiä;
    }
    if (osa1 == "pastaa")
    {
        ruoka.Lisuke = aine2.pastaa;
    }

    Console.WriteLine("Kastike: curry, hapanimelä, pippuri, chili");
    osa1 = Console.ReadLine();
    if (osa1 == "curry")
    {
        ruoka.Kastike = aine3.curry;
    }
    if (osa1 == "hapanimelä")
    {
        ruoka.Kastike = aine3.hapanimelä;
    }
    if (osa1 == "pippuri")
    {
        ruoka.Kastike = aine3.pippuri;
    }
    if (osa1 == "chili")
    {
        ruoka.Kastike = aine3.chili;
    }

    Console.WriteLine(ruoka.PääraakaAine, ruoka.Lisuke, ruoka.Kastike,"-kastike" );
    Console.WriteLine($"{ruoka.PääraakaAine}");
}
public enum aine1 { nautaa, kanaa, kasviksia };
public enum aine2 { perunaa, riisiä, pastaa};
public enum aine3 { curry, hapanimelä, pippuri, chili };



