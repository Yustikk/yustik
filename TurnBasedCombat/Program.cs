//I want to remake this with classes! Plus add more enemies and character classes and leveling + add sounds https://www.reddit.com/r/csharp/comments/dxquzk/playing_audio_in_a_console_window/
//but first classes ofc.



// See https://aka.ms/new-console-template for more information
int PlayerHP = 40, EnemyHP = 40;
int playerATK=5, enemyATK=7;
int HealPotion = 1, DefensePotion = 0;
double Gold = 1;
//i have discovered i cant make structs here i need to figure them out together with classes bc they are top level statements
int EnemyBoost = 0, EnemyBoostRounds = 0, PlayerBoost = 0, PlayerBoostRounds = 0;

while(PlayerHP > 0 && EnemyHP > 0)
{
    //players turn
    Thread.Sleep(200);
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

    Console.WriteLine("\t\t\t-----------------------------PLAYER'S TURN-----------------------------\nPlayer HP\t:" + PlayerHP +"\nEnemy HP:\t"+EnemyHP+ "\nHeal Potions: \t" + HealPotion + "\nDefensePotion: \t" + DefensePotion + "\nGold: \t\t" + Gold);
    Console.Beep(1000, 120);
    Console.Beep(2500, 100);
    Console.Beep(2000, 200);
    Console.WriteLine("\n-------!Choose An Action:\tAttack(a),\tHeal(h),\tScavange For Treasure(any),\tShop(s)");
    ConsoleKeyInfo action = Console.ReadKey();
    while(action.Key==ConsoleKey.H && HealPotion<1)
    {
        Console.WriteLine("\n--You have no Heal Potions!");
         action = Console.ReadKey();

    }
    switch(action.Key)
    {
        case ConsoleKey.A:                              //attack
            Random random2 = new Random();
            int Hit=random2.Next(1,11);
            Thread.Sleep(500);
            if(Hit>3)
            {
                if(PlayerBoostRounds > 0)
                {
                    PlayerBoostRounds--;
                    EnemyHP = EnemyHP - PlayerBoost-playerATK;
                    Console.WriteLine("\n\n--HIT! Enemy loses " + (playerATK+PlayerBoost) + " HP!\nCurrent enemy HP: " + EnemyHP);
                }
                else
                {
                    EnemyHP = EnemyHP - playerATK;
                    Console.WriteLine("\n\n--HIT! Enemy loses " + playerATK + " HP!\nCurrent enemy HP: " + EnemyHP);
                }
                
            }
            else
            {
                Console.WriteLine("\n\n--You miss!");
            }
            
            break;
        case ConsoleKey.H: 
            if(HealPotion > 0)                          //heal 
            {
                HealPotion--;
                PlayerHP += 10;
                if (PlayerHP > 40) PlayerHP = 40;
                Console.WriteLine("\n--You healed 10 HP! \n\nCurrentHP:" + PlayerHP);
            }
            
            break;
        case ConsoleKey.S:                             //shop fully functional
            if(Gold==0)
            { Console.WriteLine("\n--You have no money. The shopkeeper kicks you out"); }
            else
            {
                bool Shop = true;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("\n\t\t\t------------------------Welcome to the shop, Traveler!-----------------------\n  --Defense Potion - 2g (d)\n  --Heal Potion 1g (h)\n  --Cancel(any)");
                do
                {
                    action = Console.ReadKey();
                    switch (action.Key)
                    {
                        case ConsoleKey.D:
                        {
                                if(Gold>=2)
                                {
                                    Console.WriteLine("\n--You've aquired a Defense Potion!");
                                    DefensePotion++;
                                    Gold -= 2;
                                }
                                else
                                {
                                    Console.WriteLine("\n--You don't have enough gold");
                                }
                                break;
                        }
                        case ConsoleKey.H:
                            {
                                if (Gold >= 1)
                                {
                                    Console.WriteLine("\n--You've aquired a Health Potion!");
                                    HealPotion++;
                                    Gold--;
                                }
                                else
                                {
                                    Console.WriteLine("\n--You don't have enough gold");
                                }
                                break;
                            }
                        default:
                            {
                                Shop= false;
                                break;
                            }
                    }
                } while (Shop);
                Console.WriteLine("\n\t\t\t------------------------See you next time, Traveler--------------------------");
            }
            
            break;
        default:                                                                ///SCAVANGE
            {
                Random random1 = new Random(); 
                int treasure=random1.Next(1,200);
                if(treasure%2==0)
                { Console.WriteLine("\n--You find 50 Silver Coins");
                    Gold = Gold + 0.5;
                }
                if(treasure%3==0)
                {
                    Console.WriteLine("\n--You have found 1 Gold Coin ");
                    Gold++;
                }
                if(treasure%7==0)
                {
                    Console.WriteLine("\n--You have found a Health Potion!");
                    HealPotion++;
                }
                if(treasure%10==0)
                {
                    Console.WriteLine("\n--You tried stealing a Gold Coin from an angry crow! Scary! \nYou lose 3 HP");
                    PlayerHP -= 3;
                }
                if(treasure%20==0)
                {
                    Console.WriteLine("\n--You saw an ant strugle to bring a piece of bread 3 times bigger than it's body to it's colony. The sight fills you with determination. \n--For the next two rounds you'll deal increased damage");
                    PlayerBoost = 3;
                    PlayerBoostRounds = 2;
                }
                Console.WriteLine("\n------------------------------------\n");
                
                break;
            }
    }
    Console.ReadKey();


        Thread.Sleep(200);
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

    Console.WriteLine("\t\t\t-----------------------------ENEMY'S TURN-----------------------------\nPlayer HP\t:" + PlayerHP +"\nEnemy HP:\t"+EnemyHP+ "\nHeal Potions: \t" + HealPotion + "\nDefensePotion: \t" + DefensePotion + "\nGold: \t\t" + Gold);
    Console.Beep(1000, 120);
    Console.Beep(600, 100);
    Console.Beep(800, 200);//ENEMY TURN

    Random random = new Random();
        int EnemyAction = random.Next(1, 12);

        if (EnemyAction == 11)
        {
            Console.WriteLine("\n--Enemy is preparing powerful attacks! Next two rounds it will deal 10 damage!");
            EnemyBoostRounds = 2;
            EnemyBoost = 3;
        }
        else
        {
            if (EnemyAction > 8 )
            {
                
                EnemyHP = EnemyHP + 3;
                if (EnemyHP > 40)
                    EnemyHP = 40;
                   Console.WriteLine("\n--Enemy heals 3 HP!\nEnemy HP: " + EnemyHP);
            }
            else
            {
                if (EnemyBoostRounds > 0)
                {
                    PlayerHP = PlayerHP - enemyATK - EnemyBoost;
                    EnemyBoostRounds--;
                    Console.WriteLine("\n--Enemy attacks you! You Lose " + (enemyATK + EnemyBoost) + " HP!");
                }
                else
                {
                    PlayerHP -= enemyATK;
                    Console.WriteLine("\n--Enemy attacks you! You Lose " + enemyATK + " HP!");
                }
            }
        }
        Console.ReadKey();


}

Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

if (EnemyHP <= 0 && PlayerHP>0)
{
    Console.WriteLine("You Won!! :DD \nYou sit down next to the dead body of your enemy and start feasting on it's flesh");
}
else if(EnemyHP <= 0 && PlayerHP<= 0)
{
    Console.WriteLine("You Killed the monster! But at what cost... You start to see your vision become blurry as you bleed out next to your enemy");
}
else if (EnemyHP > 0 && PlayerHP <= 0)
{
    Console.WriteLine("You lost. You feel yourself lose consciousness as your enemy's sword pushes deeper in your heart");
}

Console.ReadKey();
Console.WriteLine("Exiting program . . . ");
Console.ReadKey();  