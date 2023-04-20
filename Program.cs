using System;

namespace TRPG
{
    internal class Program
    {
        enum ClassType
        { None = 0, Worrior = 1, Ninza = 2, Magician = 3, Sheriff = 4 }

        struct Player
        {
            internal int hp;
            internal int atk;
        }

        enum MonsterType
        {
            None = 0, Aberration = 1, Orc = 2, Goblin = 3, Ogre = 4, Dragon = 5
        }

        struct Monster
        {
            internal int hp;
            internal int atk;
        }

        static void RandomMonsterGen(out Monster monster)
        {
            Random random = new Random( );
            int randomMonsterGen = random.Next(1, 5);

            switch(randomMonsterGen)
            {
                case (int)MonsterType.Aberration:
                    Console.WriteLine($"[Aberration] popped up!!");
                    monster.hp = 40;
                    monster.atk = 15;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine($"[Orc] popped up!!");
                    monster.hp = 80;
                    monster.atk = 30;
                    break;
                case (int)MonsterType.Goblin:
                    Console.WriteLine($"[Goblin] popped up!!");
                    monster.hp = 60;
                    monster.atk = 20;
                    break;
                case (int)MonsterType.Ogre:
                    Console.WriteLine($"[Ogre] popped up!!");
                    monster.hp = 90;
                    monster.atk = 30;
                    break;
                case (int)MonsterType.Dragon:
                    Console.WriteLine($"[Dragon] popped up!!");
                    monster.hp = 100;
                    monster.atk = 50;
                    break;
                default:
                    monster.hp = 0;
                    monster.atk = 0;
                    break;
            }
        }


        static ClassType ChooseClass( )
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("\nWelcome to TxT.RPG \n[ Choice your Class.] ");
            Console.WriteLine(" [1] Worrior");
            Console.WriteLine(" [2] Ninza");
            Console.WriteLine(" [3] Magician");
            Console.WriteLine(" [4] Sheriff");

            string input = Console.ReadLine( );

            switch(input)
            {
                case "1":
                    choice = ClassType.Worrior;
                    Console.WriteLine($"You are a [{choice}]");
                    break;
                case "2":
                    choice = ClassType.Ninza;
                    Console.WriteLine($"You are a [{choice}]");
                    break;
                case "3":
                    choice = ClassType.Magician;
                    Console.WriteLine($"You are a [{choice}]");
                    break;
                case "4":
                    choice = ClassType.Sheriff;
                    Console.WriteLine($"You are a [{choice}]");
                    break;
                default:
                    break;
            }
            return choice;
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch(choice)
            {
                case ClassType.Worrior:
                    player.hp = 200;
                    player.atk = 15;
                    Console.WriteLine($"HP : {player.hp} / ATK : {player.atk}");
                    break;
                case ClassType.Ninza:
                    player.hp = 120;
                    player.atk = 25;
                    Console.WriteLine($"HP : {player.hp} / ATK : {player.atk}");
                    break;
                case ClassType.Magician:
                    player.hp = 100;
                    player.atk = 30;
                    Console.WriteLine($"HP : {player.hp} / ATK : {player.atk}");
                    break;
                case ClassType.Sheriff:
                    player.hp = 150;
                    player.atk = 20;
                    Console.WriteLine($"HP : {player.hp} / ATK : {player.atk}");
                    break;
                default:
                    player.hp = 0;
                    player.atk = 0;
                    break;
            }
        }

        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("\nYou enter the Wolrd, Now");

                Console.WriteLine(" [1] Going to Battle Field");
                Console.WriteLine(" [2] Get out the World");

                string input = Console.ReadLine( );
                if(input == "1")
                {
                    BattleField(ref player);
                    break;
                }
                else
                {
                    ChooseClass( );
                }
            }
        }

        static void BattleField(ref Player player)
        {            
            while(true)
            {
                //몬스터 생성 몬스터 알림.
                Console.WriteLine("\nMonsters are comming...");

                Monster monster;
                RandomMonsterGen(out monster);
                Console.WriteLine($"HP : {monster.hp} / ATK : {monster.atk}");

                Console.WriteLine(" [1] Get ready for a fight.");
                Console.WriteLine(" [2] Silently run away.");
               
                
                string input = Console.ReadLine( );

                if(input == "1")
                {
                    Fight(ref player, ref monster);
                    break;
                }
                else if(input == "2")
                {
                    Random randomRun = new Random( );
                    int run = randomRun.Next(1, 101);

                    if(run <= 33)
                    {
                        Console.WriteLine("The monsters passed me by");
                        EnterGame(ref player);
                    }
                    else
                        Console.WriteLine("I got caught by the monsters!!");
                        Fight(ref player, ref monster);
                }
                else
                    EnterGame(ref player);
                    break;
            }

        }


        static void Fight(ref Player player, ref Monster monster )
        {
            Console.WriteLine("\nFight!!");
            while(true)
            {
                monster.hp -= player.atk;

                if(monster.hp <= 0)
                {
                    Console.WriteLine("You Win!!! \nYou killed Monster.");
                    Console.WriteLine($"current HP : {player.hp}");
                    BattleField(ref player);
                    break;
                }

                player.hp -= monster.atk;
                if(player.hp <= 0)
                {
                    Console.WriteLine("You Died....\nMonster killed you.");
                    Retry( );
                    break;
                }
            }
        }

        static void Retry()
        {
            Console.WriteLine("Try Again??");
            Console.WriteLine(" [1] Yeah~ .I'm Thinking, I'm back!!");
            Console.WriteLine(" [2] No...pray for me");

            string input = Console.ReadLine( );

            while(true)
            {
                if(input == "1")
                {
                    ChooseClass( ); // 여기서 모든 데이터 초기화 해서 다시시작 하려면 어케하지!?
                }
                else
                    Console.WriteLine("[ GAME OVER ]");
                    break;
            }
        }


        static void Main(string[] args)
        {
            while(true)
            {
                ClassType choice = ChooseClass();

                if(choice != ClassType.None)
                {
                    Player player;

                    CreatePlayer(choice,out player);

                    EnterGame(ref player );
                    break;
                }

            }

        }





    }
}