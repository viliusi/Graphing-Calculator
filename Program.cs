internal class Program
{
    public static class sharedVariables
    {
        public static double xOregoDouble;
        public static double yOregoDouble;
        public static double scaleRatio;
        public static double lastResult;
        public static int numberSkip;
        public static int zoomFactor;
        public static List<int> toPrint = new List<int>();
    }
    private static void Main(string[] args)
    {
        resetScreenPos();

        ZoomHandler(ConsoleKey.Enter);

        updateOrego(ConsoleKey.Enter);

        bool formSelection = false;

        while (true)
        {
            if (formSelection == true)
            {
                Console.Clear();

                while (formSelection == true)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Select which formulas you want to see (Green = Selected, Red = Not Selected) (Press Escape to exit)");

                    for (int i = 0; i <= 5; i++)
                    {
                        if (sharedVariables.toPrint.Contains(i))
                        {
                            switch (i)
                            {
                                case 0:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        switch (i)
                        {
                            case 0:
                                Console.WriteLine("0: Sin(x)");
                                break;
                            case 1:
                                Console.WriteLine("1: Cos(x)");
                                break;
                            case 2:
                                Console.WriteLine("2: Tan(x)");
                                break;
                            case 3:
                                Console.WriteLine("3: Log(x)");
                                break;
                            case 4:
                                Console.WriteLine("4: sqrt(x)");
                                break;
                            case 5:
                                Console.WriteLine("5: x^2");
                                break;
                            default:
                                break;
                        }
                    }

                    ConsoleKey formSelectionKey = Console.ReadKey().Key;

                    switch (formSelectionKey)
                    {
                        case ConsoleKey.D0:
                            PrintListHandler(0);
                            break;
                        case ConsoleKey.D1:
                            PrintListHandler(1);
                            break;
                        case ConsoleKey.D2:
                            PrintListHandler(2);
                            break;
                        case ConsoleKey.D3:
                            PrintListHandler(3);
                            break;
                        case ConsoleKey.D4:
                            PrintListHandler(4);
                            break;
                        case ConsoleKey.D5:
                            PrintListHandler(5);
                            break;
                        case ConsoleKey.Escape:
                            formSelection = false;
                            resetScreenPos();
                            updateOrego(ConsoleKey.Enter);
                            break;
                        default:
                            break;
                    }

                    Console.Clear();
                }
            }

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
                    ZoomHandler(ConsoleKey.Enter);
                    break;
                case ConsoleKey.O:
                    ZoomHandler(ConsoleKey.O);
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.P:
                    ZoomHandler(ConsoleKey.P);
                    updateOrego(ConsoleKey.Enter);
                    break;
                case ConsoleKey.F:
                    formSelection = true;
                    break;
                default:
                    break;
            }
        }
    }
    public static void PrintListHandler(int index)
    {
        if (sharedVariables.toPrint.Contains(index))
        {
            sharedVariables.toPrint.Remove(index);
        }
        else
        {
            sharedVariables.toPrint.Add(index);
        }
    }
    public static void updateOrego(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.W:
                Program.sharedVariables.yOregoDouble += sharedVariables.scaleRatio;
                break;
            case ConsoleKey.D:
                Program.sharedVariables.xOregoDouble += (sharedVariables.scaleRatio * 2);
                break;
            case ConsoleKey.S:
                Program.sharedVariables.yOregoDouble -= sharedVariables.scaleRatio;
                break;
            case ConsoleKey.A:
                Program.sharedVariables.xOregoDouble -= (sharedVariables.scaleRatio * 2);
                break;
            default:
                break;
        }

        Renderers.coordinateSytemRender();

        Renderers.axisNumbersRenderer();

        formulaHandler();
    }
    private static void formulaHandler()
    {
        foreach (var item in sharedVariables.toPrint)
        {
            Renderers.EquationRenderer(item);
        }
    }
    public static void resetScreenPos()
    {
        Program.sharedVariables.xOregoDouble = Console.WindowWidth * 0.3;
        Program.sharedVariables.yOregoDouble = Console.WindowHeight * 0.5;
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
}