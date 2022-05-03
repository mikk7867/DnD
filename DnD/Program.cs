using DnD;
internal class Program
{
    public static void Main(string[] args)
    {
        Creation creator = new();
        while (true)
        {
            //menu
            Console.WriteLine("menu");
            //switch
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    creator.Start();
                    break;
                case '2':
                    //Gameplay.xxx();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong button, try again");
                    break;
            }
        }
    }
}