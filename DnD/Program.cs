using DnD;
internal class Program
{
    public static void Main(string[] args)
    {
        Creation creator = new();
        if (!File.Exists("characters.txt"))
        {
            File.Create("characters.txt");
        }
        List<Character> party = new();
        while (true)
        {
            //menu
            Console.Clear();
            Console.WriteLine("DnD Menu:\n" +
                "'1' to create new character\n" +
                "'2' to view existing characters\n" +
                "'3' to form a party\n" +
                "'4' to view current party");
            //switch
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    creator.Start();
                    break;
                case '2':
                    creator.View(creator.Reader());
                    break;
                case '3':
                    party = creator.Partytime();
                    break;
                case '4':
                    if (party.Count > 0)
                    {
                        creator.View(party);
                    }
                    else
                    {
                        Console.WriteLine("fejl");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong button, try again");
                    Console.ReadKey();
                    break;
            }
        }
    }
}