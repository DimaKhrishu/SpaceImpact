using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace ConsoleApplication8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            //variables
            int maxscore = 0,
                count = 0,
                speed = 0,
                speed2 = 100;

            int PlayerX = 20,
                PlayerY = 40,
                Shoot1X = 0,
                Shoot1Y = 0,
                Enemy1Y = int.MinValue,
                Enemy1X = 0;

            bool CanShoot = true;
                 

            Random rand = new Random();

            //game initialization
            Console.SetWindowSize(40, 40);
            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.WriteLine("@");

            //moving
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (PlayerX > 0)
                        {
                            PlayerX -= 2;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (PlayerX < Console.WindowWidth - 6)
                        {
                            PlayerX += 2;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        if (CanShoot == true)
                        {
                            Shoot1X = PlayerX;
                            Shoot1Y = PlayerY + 5;
                            CanShoot = false;
                        }
                        

                    }
                }
                //shoot
                if (CanShoot == false)
                {
                    Console.SetCursorPosition(Shoot1X, Shoot1Y);
                    Console.WriteLine("*");
                    if (Shoot1Y != 0)
                        Shoot1Y -= 1;
                    else
                    {
                        CanShoot = true;
                    }
                }


                //Update

                Console.Clear();

                if (Enemy1Y == int.MinValue)
                {
                    Enemy1Y = rand.Next(0, 34);
                    speed2 -= 1;
                    count += 1;
                    if (count > maxscore)
                        maxscore = count;
                }
                if (Enemy1X < 40)
                {
                    Console.SetCursorPosition(Enemy1Y, Enemy1X);
                    Console.WriteLine("V-*-V");
                    Enemy1X += 1 + speed;
                    if (count > 5)
                    {
                        speed += 1;
                        count = 0;

                    }
                }
                else
                {
                    Enemy1X = 0;
                    Enemy1Y = int.MinValue;
                }


                

                //Collision 

                for (int i = 0; i <= 6; i++)
                {
                    if (PlayerY == Enemy1X)
                    {
                        if (PlayerX == Enemy1Y + i || PlayerX + 1 == Enemy1Y + i || PlayerX + 2 == Enemy1Y + i || PlayerX + 3 == Enemy1Y + i || PlayerX + 4 == Enemy1Y + i)
                        {
                            count = 0;
                            speed = 0;
                            break;
                        }
                    }

                    if (Shoot1Y == Enemy1X || Shoot1Y == Enemy1X + 1)
                    {
                        if (Shoot1X == Enemy1Y + i )
                        {
                            Enemy1X = 0;
                            Enemy1Y = int.MinValue;
                            speed2 -= 3;
                            Shoot1Y = PlayerY;
                            Shoot1X = PlayerX;
                        }
                        
                    }
                }



                

                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.WriteLine("A");
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("SCORE: " + count);
                Console.SetCursorPosition(1, 2);
                Console.WriteLine("Max Score: " + maxscore);
                Thread.Sleep(speed2);

                


            }
        }
    }
}