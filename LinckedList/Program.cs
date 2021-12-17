using System;

namespace LinckedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinckList<int> LL = new LinckList<int>();
            LL.Notify += DisplayMessage;

            Console.WriteLine("Add elements to Stack and press Enter to finish" +
                              "\npress 1 to add the first one" +
                              "\npress 2 to add the last one" +
                              "\npress 3 to remove the first one");

            bool temp = true;
            while (temp == true)
            {
                try
                {
                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.D1:
                            {
                                Console.Write("member:");
                                LL.AddFirst(int.Parse(Console.ReadLine()));
                                break;
                            }

                        case ConsoleKey.D2:
                            {
                                Console.Write("member:");
                                LL.AddLast(int.Parse(Console.ReadLine()));
                                break;
                            }

                        case ConsoleKey.D3:
                            {
                                Console.Write("member to delete:");
                                LL.Delete(int.Parse(Console.ReadLine()));
                                break;
                            }

                        case ConsoleKey.Enter:
                            {
                                temp = false;
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Please, choose what you want to do");
                                break;
                            }
                    }
                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("try again");
                    Console.ResetColor();
                    continue;
                }

            }

            foreach (int item in LL)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }

        private static void DisplayMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
