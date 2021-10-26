namespace PromotionEngine.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // startup file
            new Startup(args);

            // loop through when press enter
            Main(args);
        }
    }
}
