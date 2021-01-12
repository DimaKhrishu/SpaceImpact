using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace ConsoleApplication8
{

    public class Program
    {
        public class Bullet
        {
            public int x;
            public int y;
            public Bullet(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void Main(string[] args)
        {

            List<Bullet> bullets = new List<Bullet>();

            
            int maxscore = 0,
                count = 0,
                speed = 0,
                speed2 = 100;

            int PlayerX = 20,
                PlayerY = 40,
                Enemy1Y = int.MinValue,
                Enemy1X = 0;



            Random rand = new Random();


            Console.SetWindowSize(40, 60);
            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.WriteLine("@");

            while (true)
            {
                //int k=0;
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


                        bullets.Add(new Bullet(PlayerX, PlayerY)); 


                    }
                }


                for (int g = 0; g < bullets.Count; g++)
                {
                    //Console.SetCursorPosition(0, 50);
                    //Console.WriteLine(bullets.Count);

                    if (bullets[g].y > 0)
                    {
                        Console.SetCursorPosition(bullets[g].x, bullets[g].y);
                        bullets[g].y -= 1;
                        Console.WriteLine("*");
                    }
                    else
                    {
                        bullets.RemoveAt(g);
                        g--;
                    }

                }
                for (int i = 0; i <= 6; i++)
                {
                    for (int g = 0; g < bullets.Count; g++)
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
                        if (g >= 0 && g <= bullets.Count)
                        {
                            if (bullets[g].y == Enemy1X || bullets[g].y == Enemy1X + 1)
                            {
                                if (bullets[g].x == Enemy1Y + i)
                                {
                                    Enemy1X = 0;
                                    Enemy1Y = int.MinValue;
                                    speed2 -= 3;
                                    bullets.RemoveAt(g);
                                    g--;
                                }

                            }
                        }
                    }
                }
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

                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.WriteLine("A");
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Score: " + count);
                Console.SetCursorPosition(1, 2);
                Console.WriteLine("Max Score: " + maxscore);
                Thread.Sleep(200);




            }
        }
    }
}
