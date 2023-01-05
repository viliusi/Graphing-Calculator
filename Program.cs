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
        public static Dictionary<string, Dictionary<string, double>> FormulasForRendering = new Dictionary<string, Dictionary<string, double>>();
        public static List<string> allFormulaNames = new List<string>();
        public static List<string> toRenderFormulaNames = new List<string>();
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

        resetScreenPos();
        sharedVariables.scaleRatio = 4;
        updateOrego(ConsoleKey.Enter);

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
                        updateOrego(movementDirection);
                    }
                    break;
                case ConsoleKey.R:
                    resetScreenPos();
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.I:
                    string currentFormula = Console.ReadLine();
                    Parsers.inputHandler(currentFormula);
                    break;
                case ConsoleKey.O:
                    if (sharedVariables.scaleRatio >= 2)
                    {
                        sharedVariables.scaleRatio -= 1;
                    }
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.P:
                    sharedVariables.scaleRatio += 1;
                    updateOrego(ConsoleKey.Enter);
                    break;
                default:
                    break;
            }
        }
    }
    public static void updateOrego(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.W:
                Program.sharedVariables.yOregoDouble -= sharedVariables.scaleRatio;
                break;
            case ConsoleKey.A:
                Program.sharedVariables.xOregoDouble += (sharedVariables.scaleRatio * 2);
                break;
            case ConsoleKey.S:
                Program.sharedVariables.yOregoDouble += sharedVariables.scaleRatio;
                break;
            case ConsoleKey.D:
                Program.sharedVariables.xOregoDouble -= (sharedVariables.scaleRatio * 2);
                break;
            default:
                break;
        }
        Renderers.coordinateSytemRender();

        EquationHandler();

        Renderers.axisNumbersRenderer();

        //inputFieldRenderer();
    }
    public static void resetScreenPos()
    {
        Program.sharedVariables.xOregoDouble = Console.WindowWidth * 0.3;
        Program.sharedVariables.yOregoDouble = Console.WindowHeight * 0.5;
    }
    public static void EquationHandler()
    {
        int[] indexOfFormulas = new int[sharedVariables.toRenderFormulaNames.Count];

        int index = 0;

        for (int i = 0; i < sharedVariables.toRenderFormulaNames.Count; i++)
        {
            string toTest = sharedVariables.toRenderFormulaNames[i];

            for (int b = 0; b < sharedVariables.FormulasForRendering.Count; b++)
            {
                string testingAgainst = sharedVariables.FormulasForRendering.ElementAt(b).Key;

                if (toTest == testingAgainst)
                {
                    indexOfFormulas[index] = b;
                    index++;
                }
            }
        }

        for (int i = 0; i < indexOfFormulas.Length; i++)
        {
            int formulaToSend = indexOfFormulas[i];

            Dictionary<string, double> safeTravelsFormula = sharedVariables.FormulasForRendering.ElementAt(formulaToSend).Value;

            Renderers.EquationRenderer(safeTravelsFormula);
        }
    }
    public static void AddToRender(string name)
    {
        sharedVariables.toRenderFormulaNames.Add(name);
    }
    public static void RemoveFromRender(string name)
    {
        sharedVariables.toRenderFormulaNames.Remove(name);
    }
    public static void AddEquationToLists(string name)
    {
        sharedVariables.allFormulaNames.Add(name);
    }
}