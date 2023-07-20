namespace Icarus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int damage = 1;
            int currentIndex;

            Console.Write("Enter state: ");
            string rawfield = Console.ReadLine();

            int[] field = ConvertStringToIntArray(rawfield);
           
            Console.WriteLine("Enter start position: ");
            currentIndex = int.Parse(Console.ReadLine()) - 1;

            PrintArray(field, currentIndex);

            Supernova(field, ref currentIndex, ref damage);

            //readkey
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            Console.ResetColor();           
            Console.Write("Press any key...");
            Console.ReadKey();
        }
        static int[] ConvertStringToIntArray(string numbersString)
        {
            string[] numberStrings = numbersString.Split(' ');
            int[] numbersArray = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbersArray[i] = int.Parse(numberStrings[i]);
            }

            return numbersArray;
        }
        static void PrintArray(int[] array, int currentIndex)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == currentIndex)
                {
                    Console.Write("| ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(array[i]);
                    Console.ResetColor();
                    Console.Write(" |");
                }
                else
                {
                    Console.Write($"| {array[i]} |");
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        static void PrintArrayWithoutColor(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {                      
                Console.Write($"| {array[i]} |");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        static void Supernova(int[] field, ref int currentIndex, ref int damage)
        {
            bool flag = true;

            do
            {
                Console.WriteLine("Supernova (y/n):");
                char yesOrNo = char.Parse(Console.ReadLine());
                if (yesOrNo != 'y' && yesOrNo != 'n')
                {
                    Console.WriteLine("Invalid answer!");
                    flag = true;
                }
                else if (yesOrNo == 'y')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("SUPERNOVA");
                    Console.ResetColor();
                    Console.WriteLine("+=+=+=+=+=");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"OVERAL DAMAGE: {damage}");
                    Console.ResetColor();
                    PrintArrayWithoutColor(field);
                    flag = false;
                    Console.WriteLine("+=+=+=+=+=");
                }
                else
                {                       
                    Movement(field, ref currentIndex, ref damage);                  
                }
            } while (flag);
            
        }
        static void Movement(int[] field, ref int currentIndex, ref int damage)
        {
            bool flag = false;
            int steps;
            string direction;

            //get information about direction
            do
            {
                Console.Write("Enter direction(left,right): ");
                direction = Console.ReadLine();
                if (direction == "left")
                {
                    flag = false;
                }
                else if (direction == "right")
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Not valid direction!");
                    flag = true;
                    Console.WriteLine("----------");
                }
            } while (flag);

            //get information about steps number
            do
            {
                Console.Write("How many steps you want to make(1,2,...): ");
                steps = int.Parse(Console.ReadLine());
                if (steps < 1)
                {
                    Console.WriteLine("Invalid steps number");
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            } while (flag);

            Console.WriteLine($"Current damage: {damage}");

            //display moving
            for (int i = 0; i < steps; i++)
            {
                if (direction == "left")
                {
                    currentIndex -= 1;
                    if (currentIndex < 0)
                    {
                        currentIndex = field.Length - 1;
                        damage += 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"New damage: {damage}");
                        Console.ResetColor();
                    }

                    field[currentIndex] -= damage;

                    PrintArray(field, currentIndex);
                }
                else if(direction == "right")
                {
                    currentIndex += 1;
                    if (currentIndex > field.Length - 1)
                    {
                        currentIndex = 0;
                        damage += 1;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"New damage: {damage}");
                        Console.ResetColor();
                    }

                    field[currentIndex] -= damage;

                    PrintArray(field, currentIndex);
                }
            }            
        }        
    }
}