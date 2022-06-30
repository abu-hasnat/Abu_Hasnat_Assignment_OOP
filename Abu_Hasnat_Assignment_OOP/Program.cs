public class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefence { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set;}
    public Weapon EquippedWaepon { get; set; }
    public Armour EquippedArmour { get; set; }

    public Hero(string name, int baseStrength, int baseDefence, int originalHealth)
    {
        Name = name;
        BaseStrength = baseStrength;
        BaseDefence = baseDefence;
        OriginalHealth = originalHealth;
        CurrentHealth = originalHealth;
 
    }
    public Hero() //default constructor
    {

    }


    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Base Strength: {BaseStrength}");
        Console.WriteLine($"Base Defence: {BaseDefence}");
        Console.WriteLine($"Original Health: {OriginalHealth}");
        Console.WriteLine($"Current Health: {CurrentHealth}");
    }

    public void ShowInvertory()
    {
        if(EquippedArmour != null)
        {
            Console.WriteLine($"Equipped Armour: {EquippedArmour.Name}");
        }
        if(EquippedWaepon != null)
        {
            Console.WriteLine($"Equipped Waepon: {EquippedWaepon}");
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        EquippedWaepon = weapon;
    }
    public void EquipArmour(Armour armour)
    {
        EquippedArmour = armour;
    }
}

public class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defence { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }

    public Monster(string name, int strength, int defence, int originalHealth)
    {
        Name = name;
        Strength = strength;
        Defence = defence;
        OriginalHealth = originalHealth;
        CurrentHealth = originalHealth;
    }

    public Monster()// Defaault Constructor
    {

    }
}

public class Armour
{
    public string Name { get; set; }
    public int Power { get; set; }

    public Armour(string name, int power)    {
        Name = name;
        Power = power;
    }

}
public static class ArmourList
{
    public static List<Armour> Armours { get; set; } = new List<Armour>();
}


public class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }

    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

public static class WeaponList
{
    public static List<Weapon> Weapons { get; set; } = new List<Weapon>();
}


public class Fight
{
    public void HeroTurn(Hero hero, Monster monster)
    {
        monster.CurrentHealth = monster.CurrentHealth - (hero.BaseStrength + hero.EquippedWaepon.Power);
        if(monster.CurrentHealth < 0) //health cannot be negative
        {
            monster.CurrentHealth = 0;
        }
    }
    public void MonsterTurn(Hero hero, Monster monster)
    {
        hero.CurrentHealth = hero.CurrentHealth - (monster.Strength - (hero.BaseStrength + hero.EquippedArmour.Power));
        if(hero.CurrentHealth < 0) //health cannot be negative
        {
            hero.CurrentHealth = 0;
        }
    }

    public bool Win(Hero hero, Monster monster)
    {
        if (monster.CurrentHealth == 0)
        {
            return true;
        }
        return false;
    }
    public bool Lose(Hero hero, Monster monster)
    {
        if(hero.CurrentHealth == 0)
        {
            return true;
        }
        return false;
    }
}

public class Game
{
    private int FightsWon = 0;
    private int FightsLost = 0;

    List<Monster> Monsters;

    Hero hero;
    Monster currentMonster;
    public Game()
    {
        Console.WriteLine("Enter player name");
        string palyerName = Console.ReadLine();

        hero = new Hero(palyerName, 50, 50, 100);
        AddMonsters();

        ArmourList.Armours.Add(new Armour("Hulk Buster", 80));
        ArmourList.Armours.Add(new Armour("Hydra Stomper", 70));
        ArmourList.Armours.Add(new Armour("War Machine", 75));

        WeaponList.Weapons.Add(new Weapon("Unibeam", 100));
        WeaponList.Weapons.Add(new Weapon("Mini Missiles", 70));
        WeaponList.Weapons.Add(new Weapon("Layser system", 80));

        Start();

    }
    public void AddMonsters()
    {
        Monsters = new List<Monster>();
        Monsters.Add(new Monster("Mandarin", 25, 25, 30));
        Monsters.Add(new Monster("Iron Monger", 30, 20, 30));
        Monsters.Add(new Monster("Justin Hammer", 15, 15, 25));
        Monsters.Add(new Monster("Norman Osborn", 17, 20, 20));
        Monsters.Add(new Monster("Sephiroth", 25, 25, 25));
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1 - Display Statistics");
        Console.WriteLine("2 - Display Inventory");
        Console.WriteLine("3 - Fight");
        Console.WriteLine("0 - Exit application");
    }

    public void DisplayHelpMenu()
    {
        Console.WriteLine("1 - Change Equipped Weapon");
        Console.WriteLine("2 - Change Equipped Armour");
        Console.WriteLine("0 - Back to Main Menu");
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"Game Played:  {FightsWon + FightsLost}");
        Console.WriteLine($"Fights Won: {FightsWon}");
        Console.WriteLine($"Fights Lost: {FightsLost}");
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        //was having trouble figuring this out
    }

    public void Start()
    {
        int userInput = 0;
        int myInt = 0;

        do
        {
            DisplayMainMenu();
            Console.WriteLine("Enter option (0-3)");
            userInput = Convert.ToInt32(Console.ReadLine());
            int chooseWeapon = 0;
            int chooseArmour = 0;

            switch(userInput)
            {
                case 1:
                    DisplayInventory();
                    break;
                case 2:
                    do
                    {
                        DisplayInventory();
                        DisplayMainMenu();
                        Console.Write("Enter option (0-3)");
                        myInt = Convert.ToInt32(Console.ReadLine());
                        switch (myInt)
                        {
                            case 1:
                                Console.WriteLine("No \tWeapon Name \tPower");
                                for (int i = 0; i < WeaponList.Weapons.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + "\t" + WeaponList.Weapons[i].Name + "\t" + WeaponList.Weapons[i].Power);
                                }
                                Console.Write("Choose your weapon: ");
                                chooseWeapon = Convert.ToInt32(Console.ReadLine());
                                hero.EquipWeapon(WeaponList.Weapons[chooseWeapon - 1]);
                                break;
                            case 2:
                                Console.WriteLine("No \tArmour Name \tPower");
                                for (int i = 0; i < ArmourList.Armours.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + "\t" + ArmourList.Armours[i].Name + "\t" + ArmourList.Armours[i].Power);
                                }
                                Console.Write("Enter number in front of weapon: ");
                                chooseArmour = Convert.ToInt32(Console.ReadLine());
                                hero.EquipArmour(ArmourList.Armours[chooseArmour - 1]);
                                break;
                            case 0:
                                Console.WriteLine("Back to Main menu");
                                break;
                            default:
                                Console.WriteLine("You must enter numbers 0, 1 or 2");
                                break;
                        }
                    }
                    while (myInt != 0);
                    break;
                case 3:
                   Fight fight = new Fight();
                    if(Monsters.Count == 0)
                    {
                        Console.WriteLine("All Monsters are killed!");
                        break;
                    }
                    var random = new Random(); // learned from youtube
                    int index = random.Next(Monsters.Count); // learned from youtube
                    currentMonster = Monsters[index];
                    do
                    {
                        Console.WriteLine($"Fighting + {hero.Name} vs {currentMonster.Name}");
                        fight.HeroTurn(hero, currentMonster);

                        if (fight.Win(hero, currentMonster))
                        {
                            Console.WriteLine($"{hero.Name} wins");
                            Monsters.Remove(currentMonster);
                            FightsWon++;
                            break;
                        }

                        fight.MonsterTurn(hero, currentMonster);
                        if (fight.Lose(hero, currentMonster))
                        {
                            Console.WriteLine("Game Over");
                            FightsLost++;
                            hero.CurrentHealth = hero.OriginalHealth;
                            AddMonsters();
                            break;
                        }
                    }
                    while (true);
                    break;
                case 0:
                    Console.WriteLine("Quite Game");
                    break;
                default:
                    Console.WriteLine("Please enter a number between 0-3");
                    break;
            }


        }
        while (myInt != 0);
    }

}
//