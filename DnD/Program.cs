using DnD;
internal class Program
{
    public static void Main(string[] args)
    {
        Creation creator = new();
        //creates file to use for storing characters if the file does not exist
        if (!File.Exists("characters.txt"))
        {
            File.Create("characters.txt");
        }
        //creates a character list to use for the party
        List<Character> party = new();
        while (true)
        {
            Console.Clear();
            //printout of menu
            Console.WriteLine("DnD Menu:\n" +
                "'1' to create new character\n" +
                "'2' to view existing characters\n" +
                "'3' to form a party\n" +
                "'4' to view current party\n" +
                "'0' to exit the program");
            //switch based on key press
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    //method to create a new character
                    creator.Start();
                    break;
                case '2':
                    //method to print out all existing characters
                    creator.View(creator.Reader());
                    break;
                case '3':
                    //method to create a party
                    party = creator.Partytime();
                    break;
                case '4':
                    //if party contains at least one character
                    if (party.Count > 0)
                    {
                        //method to print out current party
                        creator.View(party);
                    }
                    else
                    {
                        //error message
                        Console.WriteLine("Party is empty, try another option");
                    }
                    break;
                case '0':
                    //closes the console
                    Environment.Exit(0);
                    //exists only to avoid build error
                    break;
                default:
                    //error message
                    Console.WriteLine("Wrong button, try again");
                    break;
            }
            //fix to avoid potentially skipping code from methods
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}