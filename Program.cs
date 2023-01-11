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
        public static Dictionary<string, Dictionary<string, string>> FormulasForRendering = new Dictionary<string, Dictionary<string, string>>();
        public static List<string> allFormulaNames = new List<string>();
        public static List<string> toRenderFormulaNames = new List<string>();
        public static int numberSkip;
        public static int zoomFactor;
    }
    private static void Main(string[] args)
    {
        resetScreenPos();

        ZoomHandler(ConsoleKey.Enter);

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
                    Equation.equationDecypherer(currentFormula);
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.O:
                    ZoomHandler(ConsoleKey.O);
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.P:
                    ZoomHandler(ConsoleKey.P);
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
        // Setting up an int array to setup where our formulas for rendering are situated
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

        // using the indexes we got, we retrieve the formulas and set them away to the renderer
        for (int i = 0; i < indexOfFormulas.Length; i++)
        {
            int formulaToSend = indexOfFormulas[i];

            Dictionary<string, string> safeTravelsFormula = sharedVariables.FormulasForRendering.ElementAt(formulaToSend).Value;

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
    public static void ZoomHandler(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.O:
            if (2 < sharedVariables.scaleRatio)
            {
                sharedVariables.scaleRatio -= sharedVariables.zoomFactor;
            }
            break;


            case ConsoleKey.P:
            if (12 > sharedVariables.scaleRatio)
            {
                sharedVariables.scaleRatio += sharedVariables.zoomFactor;
            }
            break;

            case ConsoleKey.Enter:
            sharedVariables.scaleRatio = 4;
            sharedVariables.numberSkip = 1;
            sharedVariables.zoomFactor = 1;
            break;
            default:
            break;
        }

        if (sharedVariables.scaleRatio == 3)
        {
            sharedVariables.zoomFactor = 1;
            sharedVariables.numberSkip = 5;
        }
        else if (sharedVariables.scaleRatio == 8)
        {
            sharedVariables.zoomFactor = 2;
            sharedVariables.numberSkip = 1;
        }
    }
    public static double makeDouble(char[] numberSegment)
    {
        int actualLength = 0;

        for (int i = 0; i < numberSegment.Length; i++)
        {
            char test = numberSegment[i];

            if (test != '\0')
            {
                actualLength++;
            }
        }

        int commaLocation = Array.IndexOf(numberSegment, '.');

        int beforeCommaLoc = 0;
        int afterCommaLoc = 0;

        int digitsBeforeComma = commaLocation;
        int digitsAfterComma = actualLength - commaLocation;

        char[] beforeComma = new char[digitsBeforeComma];
        char[] afterComma = new char[digitsAfterComma];

        for (int i = 0; i <= actualLength; i++)
        {
            int comLoc = commaLocation;

            char toAdd = numberSegment[i];

            if (i < commaLocation && toAdd != '.')
            {
                beforeComma[beforeCommaLoc] = toAdd;
                beforeCommaLoc++;
            }
            else if (i > commaLocation && toAdd != '.')
            {
                afterComma[afterCommaLoc] = toAdd;
                afterCommaLoc++;
            }
        }

        int beforeCommaInt = int.Parse(beforeComma);
        int afterCommaInt = int.Parse(afterComma);

        string doubleString = new string(beforeCommaInt + "," + afterCommaInt);

        double numberFinal = double.Parse(doubleString);

        return numberFinal;
    }
}