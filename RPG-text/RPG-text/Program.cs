using System;
using System.Collections.Generic;

// Rajapinta varusteille
interface IEquipment
{
    int Attack { get; }
    int Defense { get; }
}

// Ase-luokka
public class Weapon : IEquipment
{
    public int Attack { get; }
    public int Defense { get; }

    public Weapon(int attack, int defense)
    {
        Attack = attack;
        Defense = defense;
    }
}

// Haarniska-luokka
public class Armor : IEquipment
{
    public int Attack { get; }
    public int Defense { get; }

    public Armor(int attack, int defense)
    {
        Attack = attack;
        Defense = defense;
    }
}

public class Monster
{
    public string Name { get; protected set; }
    public int Health { get; set; }
    public int AttackDamage { get; protected set; }
    public int DefensePower;

    public virtual void Attack(Player player)
    {
        int damage = CalculateDamage();
        player.TakeDamage(damage);
        Console.WriteLine($"Hirviö ({Name}) hyökkäsi pelaajaa vastaan ja teki {damage} vahinkoa.");
    }

    protected virtual int CalculateDamage()
    {
        // Calculate the damage based on the monster's attack damage and any additional logic
        return AttackDamage;
    }
}

public class Dragon : Monster
{
    public Dragon()
    {
        Name = "Lohikäärme";
        Health = 100;
        AttackDamage = 20;
    }

    public override void Attack(Player player)
    {
        Console.WriteLine($"Lohikäärme ({Name}) syöksee tulta ja tekee erityistä vahinkoa!");
        base.Attack(player);
    }
}

public class Orc : Monster
{
    public Orc()
    {
        Name = "Örkki";
        Health = 60;
        AttackDamage = 15;
    }

    protected override int CalculateDamage()
    {
        // Orcs have a chance to perform a critical attack
        if (new Random().Next(1, 5) == 1)
        {
            Console.WriteLine("Örkki osui pelaajaan kriittisellä iskulla!");
            return AttackDamage * 2; // Double the attack damage
        }
        else
        {
            return AttackDamage;
        }
    }
}

// Taikajuoma-luokka
public class Potion
{
    public int HealingAmount { get; }

    public Potion(int healingAmount)
    {
        HealingAmount = healingAmount;
    }
}

// Ritari-luokka
class Knight : Player
{
    public Knight(int health, int attackPower, int defensePower) : base(health, attackPower, defensePower)
    {
    }
}

// Pelaaja-luokka
public class Player
{
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int DefensePower { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public Potion EquippedPotion { get; set; }

    public Player(int health, int attackPower, int defensePower)
    {
        Health = health;
        AttackPower = attackPower;
        DefensePower = defensePower;
    }

    public void Attack(Monster monster)
    {
        int damageDealt = Math.Max(AttackPower - monster.DefensePower, 0);
        monster.Health -= damageDealt;
    }

    public void Defend()
    {
        // Implement defense logic here
        // For example, you can reduce incoming damage based on the player's defense power
    }

    public void UsePotion()
    {
        // Implement logic to use the equipped potion
        // For example, you can heal the player's health by the healing amount of the potion
    }

    public void EquipWeapon(Weapon weapon)
    {
        // Implement logic to equip the specified weapon
        // For example, you can set the EquippedWeapon property to the provided weapon
    }

    public void EquipArmor(Armor armor)
    {
        // Implement logic to equip the specified armor
        // For example, you can set the EquippedArmor property to the provided armor
    }

    public void EquipPotion(Potion potion)
    {
        // Implement logic to equip the specified potion
        // For example, you can set the EquippedPotion property to the provided potion
    }

    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(damage - DefensePower, 0);
        Health -= actualDamage;
    }
}
class Reppu
{
    private List<Tavara> tavarat;
    private double maxTilavuus;
    private double nykyinenTilavuus;
    private double maxPaino;
    private double nykyinenPaino;

    public Reppu(double maxTilavuus, double maxPaino)
    {
        tavarat = new List<Tavara>();
        this.maxTilavuus = maxTilavuus;
        this.maxPaino = maxPaino;
    }

    public bool LisaaTavara(Tavara tavara)
    {
        if (nykyinenTilavuus + tavara.Tilavuus > maxTilavuus || nykyinenPaino + tavara.Paino > maxPaino)
        {
            Console.WriteLine("Reppu on liian täynnä. Ei voida lisätä tavaraa.");
            return false;
        }

        tavarat.Add(tavara);
        nykyinenTilavuus += tavara.Tilavuus;
        nykyinenPaino += tavara.Paino;
        Console.WriteLine($"Tavara '{tavara.Nimi}' lisätty reppuun.");
        return true;
    }

    public void TulostaReppu()
    {
        Console.WriteLine("Reppu sisältää seuraavat tavarat:");
        foreach (var tavara in tavarat)
        {
            Console.WriteLine($"- {tavara.Nimi}");
        }
    }
}

class Tavara
{
    public string Nimi { get; set; }
    public double Paino { get; set; }
    public double Tilavuus { get; set; }

    public Tavara(string nimi, double paino, double tilavuus)
    {
        Nimi = nimi;
        Paino = paino;
        Tilavuus = tilavuus;
    }
}
class Store
{
    private List<Tavara> itemsForSale;

    public Store()
    {
        itemsForSale = new List<Tavara>();
    }

    public void AddItemForSale(Tavara tavara)
    {
        itemsForSale.Add(tavara);
        Console.WriteLine($"Added item '{tavara.Nimi}' to the store.");
    }

    public void DisplayItemsForSale()
    {
        Console.WriteLine("Items for sale in the store:");
        foreach (var item in itemsForSale)
        {
            Console.WriteLine($"- {item.Nimi}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create player
        Player player = new Knight(100, 10, 5);

        // Create monsters
        Monster dragon = new Dragon();
        Monster orc = new Orc();

        // Player equips weapon and armor
        Weapon sword = new Weapon(15, 0);
        Armor shield = new Armor(0, 10);

        player.EquipWeapon(sword);
        player.EquipArmor(shield);

        // Create backpack
        Reppu reppu = new Reppu(10, 15);

        // Create items
        Tavara nuoli = new Tavara("Nuoli", 0.1, 0.05);
        Tavara jousi = new Tavara("Jousi", 1, 4);
        Tavara köysi = new Tavara("Köysi", 1, 1.5);
        Tavara vesi = new Tavara("Vesi", 2, 2);
        Tavara ruoka = new Tavara("Ruoka-annos", 1, 0.5);
        Tavara miekka = new Tavara("Miekka", 5, 3);

        // Add items to the backpack
        reppu.LisaaTavara(nuoli);
        reppu.LisaaTavara(jousi);
        reppu.LisaaTavara(köysi);
        reppu.LisaaTavara(vesi);
        reppu.LisaaTavara(ruoka);
        reppu.LisaaTavara(miekka);

        // Display the backpack contents
        reppu.TulostaReppu();
        bool hub = true;
        while (hub)
        {
            Console.WriteLine("Olet ritari metsässä, löydät itsesi risteyksen luona \n Edessäsi on 3 kylttiä, yksi osoittaa kauppaan, yksi syvemmälle metsään, ja yksi luolaan");
            Console.WriteLine("Minne menet?");
            Console.WriteLine("1. Kauppaan \n2. Metsän syvyyksiin \n3.Luolaan");
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.KeyChar)
            {
                case '1':
                    hub = false; 
                    
                    
                    break;
            }

        }





        // Game loop
        bool battleOver = false;
        while (!battleOver)
        {
            Console.Clear();
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Open Backpack");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Choose an action: ");

            // Read the player's input
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();

            // Process the player's action
            switch (input.KeyChar)
            {
                case '1':
                    // Attack action
                    Console.WriteLine("Choose a target:");
                    Console.WriteLine("1. Dragon");
                    Console.WriteLine("2. Orc");
                    Console.WriteLine();
                    Console.Write("Choose a target: ");
                    ConsoleKeyInfo targetInput = Console.ReadKey();
                    Console.WriteLine();

                    // Process the target selection
                    Monster target = null;
                    switch (targetInput.KeyChar)
                    {
                        case '1':
                            target = dragon;
                            break;
                        case '2':
                            target = orc;
                            break;
                    }

                    // Perform the attack
                    if (target != null)
                    {
                        player.Attack(target);
                        Console.WriteLine($"You attacked {target.Name}!");
                        Console.WriteLine($"Player's health: {player.Health}");
                        Console.WriteLine($"{target.Name}'s health: {target.Health}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid target.");
                    }

                    break;
                case '2':
                    // Defend action
                    player.Defend();
                    Console.WriteLine("You defended against an attack!");
                    Console.WriteLine($"Player's health: {player.Health}");
                    break;
                case '3':
                    // Open backpack action
                    reppu.TulostaReppu();
                    break;
                case '4':
                    // Quit action
                    battleOver = true;
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}