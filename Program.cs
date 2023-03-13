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

                Console.WriteLine("Select which formulas you want to see (Press Escape to exit)");

                for (int i = 0; i <= 7; i++)
                {
                    if (sharedVariables.toPrint.Contains(i))
                    {
                        switch (i)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
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
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Red;
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
                        case 6:
                            Console.WriteLine("6: x^(2/3)+xsqrt(1-x^2)");
                            break;
                        case 7:
                            Console.WriteLine("7: x^(2/3)-xsqrt(1-x^2)");
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
                    case ConsoleKey.D6:
                        PrintListHandler(6);
                        break;
                    case ConsoleKey.D7:
                        PrintListHandler(7);
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
        if (sharedVariables.caulculationSelection == true)
        {
            Console.Clear();

            while (sharedVariables.caulculationSelection == true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                int formulaIndex = -1;
                bool chooseFormula = true;
                while (chooseFormula == true)
                {
                    Console.WriteLine(@"Pick a formula:
            0: Sin(x)
            1: Cos(x)
            2: Tan(x)
            3: Log(x)
            4: sqrt(x)
            5: x^2
            6: x^(2/3)+xsqrt(1-x^2)
            7: x^(2/3)-xsqrt(1-x^2)");

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
                        case ConsoleKey.D6:
                            formulaIndex = 6;
                            chooseFormula = false;
                            break;
                        case ConsoleKey.D7:
                            formulaIndex = 7;
                            chooseFormula = false;
                            break;
                        default:
                            chooseFormula = true;
                            break;
                    }

                    Console.WriteLine(@"Select which calculation you want to do (Press Escape to exit)
                0: Integral
                1: Find highest point");

                    ConsoleKey formSelectionKey = Console.ReadKey().Key;

                    switch (formSelectionKey)
                    {
                        case ConsoleKey.D0:
                            Calculations.IntegralStart(formulaIndex);
                            break;
                        case ConsoleKey.D1:
                            double x = Calculations.FindMax(formulaIndex, -100, 100, 0, 100);

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("The highest point is at x = " + x + " and at that point y = " + Calculations.FormulaCalc(formulaIndex, x));
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
        }
    }
}