using System;
using System.Linq;

namespace DotNetRunner.Debug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dnrClient = DnrClient.CreateAsync().GetAwaiter().GetResult();

            while(true)
            {
                var command = Console.ReadLine();

                if(command == "exit")
                {
                    break;
                }

                var card = dnrClient
                    .Cards
                    .Where(c => string.Compare(c.Title, command, true) == 0)
                    .FirstOrDefault();

                if(card == null)
                {
                    Console.WriteLine("Couldn't find it.");
                }
                else
                {
                    Console.WriteLine(card.ImageUrl);
                }
            }
        }
    }
}