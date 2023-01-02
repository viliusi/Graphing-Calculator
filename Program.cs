internal class Program
{
    public static class sharedVariables
    {
        public static int xLength;
        public static int yLength;
        public static int xOrego;
        public static int yOrego;
        public static double xOregoDouble;
        public static double yOregoDouble;
        public static double scaleRatio;
        public static double lastResult;
        public static int inputFieldWidth;
        public static Dictionary<string, string> Formulas = new Dictionary<string, string>();
    }
    private static void Main(string[] args)
    {
        Console.WriteLine(@"This is a Graphing Calculator made entirely with the use of C#
Currently it is set to render 'Sin(x)'
When the coordinate system appears, you will have the ability to interact with it
WASD to move around and look at different parts of the system
R to reset your view back to the orego
Enter to just redraw the current setup
        
Once you are ready, press any button to continue");

        Console.ReadKey();

        Renderers.resetScreenPos();
        sharedVariables.scaleRatio = 4;
        Renderers.updateOrego(ConsoleKey.Enter);

        bool keepLoop = true;

        while (keepLoop == true)
        {
            ConsoleKey movementDirection = Console.ReadKey().Key;

            switch (movementDirection)
            {
                case ConsoleKey.W:
                case ConsoleKey.A:
                case ConsoleKey.S:
                case ConsoleKey.D:
                case ConsoleKey.Enter:
                    {
                        Renderers.updateOrego(movementDirection);
                    }
                    break;
                case ConsoleKey.R:
                Renderers.resetScreenPos();
                Renderers.updateOrego(ConsoleKey.Enter);
                break;
                case ConsoleKey.I:
                string currentFormula = Console.ReadLine();
                Parsers.inputHandler(currentFormula);
                break;
                default:
                    break;
            }
        }
    }
}