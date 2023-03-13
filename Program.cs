internal class Program
{
    public static class sharedVariables
    {
        public static bool formSelection;
        public static bool caulculationSelection;
        public static List<int> toPrint = new List<int>();
    }
    private static void Main(string[] args)
    {
        Renderers.ResetScreenPos();

        Renderers.ZoomHandler(ConsoleKey.Enter);

        Renderers.UpdateOrego(ConsoleKey.Enter);

        sharedVariables.formSelection = false;

        while (true)
        {
            InputHandler(Console.ReadKey().Key);
        }
    }
    public static void InputHandler(ConsoleKey movementDirection)
    {
        switch (movementDirection)
        {
            case ConsoleKey.W:
            case ConsoleKey.A:
            case ConsoleKey.S:
            case ConsoleKey.D:
            case ConsoleKey.Enter:
                {
                    Renderers.UpdateOrego(movementDirection);
                }
                break;
            case ConsoleKey.R:
                Renderers.ResetScreenPos();
                Renderers.UpdateOrego(ConsoleKey.Enter);
                Renderers.ZoomHandler(ConsoleKey.Enter);
                break;
            case ConsoleKey.O:
                Renderers.ZoomHandler(ConsoleKey.O);
                Renderers.UpdateOrego(ConsoleKey.Enter);
                break;
            case ConsoleKey.P:
                Renderers.ZoomHandler(ConsoleKey.P);
                Renderers.UpdateOrego(ConsoleKey.Enter);
                break;
            case ConsoleKey.F:
                sharedVariables.formSelection = true;
                Selection();
                break;
            case ConsoleKey.C:
                sharedVariables.caulculationSelection = true;
                CalculationSetup();
                break;
            default:
                break;
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
    public static void FormulaHandler()
    {
        foreach (var item in sharedVariables.toPrint)
        {
            Renderers.EquationRenderer(item);
        }
    }
    public static void Selection()
    {
        if (sharedVariables.formSelection == true)
        {
            Console.Clear();

            while (sharedVariables.formSelection == true)
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
                        sharedVariables.formSelection = false;
                        Renderers.ResetScreenPos();
                        Renderers.UpdateOrego(ConsoleKey.Enter);
                        Renderers.ZoomHandler(ConsoleKey.Enter);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
    public static void CalculationSetup()
    {
        double result = double.NaN;

        while (sharedVariables.caulculationSelection == true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Select which calculation you want to do (Press Escape to exit)");

            Console.WriteLine("0: Lower limit");

            Console.WriteLine("1: Upper limit");

            Console.WriteLine("2: Middle limit");

            Console.WriteLine("3: Trapez");

            ConsoleKey typeSelect = Console.ReadKey().Key;

            switch (typeSelect)
            {
                case ConsoleKey.D0:
                    result = IntegralStart(0);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(result);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D1:
                    result = IntegralStart(1);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(result);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    result = IntegralStart(2);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(result);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    result = IntegralStart(3);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(result);
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                    sharedVariables.caulculationSelection = false;
                    Renderers.ResetScreenPos();
                    Renderers.UpdateOrego(ConsoleKey.Enter);
                    Renderers.ZoomHandler(ConsoleKey.Enter);
                    break;
                default:
                    break;
            }
            Console.Clear();
        }
    }
    public static double IntegralStart(int type)
    {
        double startX = 0;
        double endX = 0;

        int formulaIndex = -1;
        bool chooseFormula = true;
        while (chooseFormula == true)
        {
            Console.WriteLine(@"Pick a formula
                            0: Sin(x)
                            1: Cos(x)
                            2: Tan(x)
                            3: Log(x)
                            4: sqrt(x)
                            5: x^2");

            ConsoleKey formula = Console.ReadKey().Key;

            switch (formula)
            {
                case ConsoleKey.D0:
                    formulaIndex = 0;
                    chooseFormula = false;
                    break;
                case ConsoleKey.D1:
                    formulaIndex = 1;
                    chooseFormula = false;
                    break;
                case ConsoleKey.D2:
                    formulaIndex = 2;
                    chooseFormula = false;
                    break;
                case ConsoleKey.D3:
                    formulaIndex = 3;
                    chooseFormula = false;
                    break;
                case ConsoleKey.D4:
                    formulaIndex = 4;
                    chooseFormula = false;
                    break;
                case ConsoleKey.D5:
                    formulaIndex = 5;
                    chooseFormula = false;
                    break;
                default:
                    chooseFormula = true;
                    break;
            }
        }

        bool chooseStart = true;
        while (chooseStart == true)
        {
            Console.Clear();

            Console.WriteLine("Choose a starting point: (Must be less than ending)");

            try
            {
                startX = Double.Parse(Console.ReadLine());

                chooseStart = false;
            }
            catch (System.Exception)
            {
                chooseStart = true;
            }
        }

        bool chooseEnd = true;
        while (chooseEnd == true)
        {
            Console.Clear();

            Console.WriteLine("Choose an ending point: (Must be greater than starting)");

            try
            {
                endX = Double.Parse(Console.ReadLine());

                chooseEnd = false;
            }
            catch (System.Exception)
            {
                chooseEnd = true;
            }
        }

        int steps = 0;

        bool chooseSteps = true;
        while (chooseSteps == true)
        {
            Console.Clear();

            Console.WriteLine("Choose how many steps you want to take: (Must be greater than 0)");

            try
            {
                steps = int.Parse(Console.ReadLine());

                if (steps > 0)
                {
                    chooseSteps = false;
                }
                else
                {
                    chooseSteps = true;
                }
            }
            catch (System.Exception)
            {
                chooseSteps = true;
            }
        }

        Console.Clear();

        return Calculations.Integral(formulaIndex, startX, endX, steps, type);
    }
}