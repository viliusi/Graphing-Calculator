public class Renderers
{
    public static class sharedVariables
    {
        public static double xOrego;
        public static double yOrego;
        public static double Scale;
        public static double LastResult;
        public static int NumberSkip;
        public static int Zoom;
    }
    public static void CoordinateSytemRender()
    {
        Console.ForegroundColor = ConsoleColor.White;

        int xOrego = Convert.ToInt32(sharedVariables.xOrego);
        int yOrego = Convert.ToInt32(sharedVariables.yOrego);

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        if (0 < yOrego && yOrego < Console.WindowHeight)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {                          /* x     y */
                Console.SetCursorPosition(i, yOrego);
                Console.Write("-");
            }
        }

        if (0 < xOrego && xOrego < Console.WindowWidth)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(xOrego, i);
                Console.Write("|");
            }
        }
    }
    public static void EquationRenderer(int formulaIndex)
    {
        // Helps with the if statement for rendering lines correctly
        sharedVariables.LastResult = 0;

        // This is practicaly the one that does all the math, the i basically just tells it to do this math for each x value from one end of the screen to the other
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            double yValue = (i - sharedVariables.xOrego) / (sharedVariables.Scale * 2);

            double math = FormulaCalc(formulaIndex, yValue);

            if (math == double.NaN)
            {
                break;
            }

            double result = math * sharedVariables.Scale;

            int yCoords = int.MinValue;

            try
            {
                yCoords = Convert.ToInt32((result - Console.WindowHeight) * -1 - (sharedVariables.yOrego - Console.WindowHeight) * -1);
            }
            catch (OverflowException)
            {

            }

            if (0 < yCoords && yCoords < Console.WindowHeight)
            {
                Console.SetCursorPosition(i, yCoords);

                double mathDiffernce = sharedVariables.LastResult - result;

                if (mathDiffernce < 0.2)
                {
                    Console.Write("/");
                }
                else if (mathDiffernce > 0.2)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write("#");
                }
            }

            sharedVariables.LastResult = result;
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void AxisNumbersRenderer()
    {
        Console.ForegroundColor = ConsoleColor.White;

        double xLengthPositive = (Console.WindowWidth - sharedVariables.xOrego);
        double yLengthPositive = (Console.WindowHeight - sharedVariables.yOrego);
        double xLengthAdjustedPositive = (Console.WindowWidth - sharedVariables.xOrego) / (sharedVariables.Scale * 2);
        double yLengthAdjustedPositive = (Console.WindowHeight - sharedVariables.yOrego) / sharedVariables.Scale;
        double xLengthAdjustedNegative = (xLengthPositive - Console.WindowWidth) / (sharedVariables.Scale * 2);
        double yLengthAdjustedNegative = (yLengthPositive - Console.WindowHeight) / sharedVariables.Scale;

        for (int i = 0; i < xLengthAdjustedPositive; i += sharedVariables.NumberSkip)
        {
            if (0 < Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego) && Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego) < Console.WindowWidth && 0 < sharedVariables.yOrego && sharedVariables.yOrego < Console.WindowHeight)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego), Convert.ToInt32(sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i < yLengthAdjustedPositive; i += sharedVariables.NumberSkip)
        {
            if (0 < Convert.ToInt32((i * sharedVariables.Scale) + sharedVariables.yOrego) && Convert.ToInt32((i * sharedVariables.Scale) + sharedVariables.yOrego) < Console.WindowHeight && 0 < sharedVariables.xOrego && sharedVariables.xOrego < Console.WindowWidth)
            {
                Console.SetCursorPosition(Convert.ToInt32(sharedVariables.xOrego), Convert.ToInt32((i * sharedVariables.Scale) + sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > xLengthAdjustedNegative; i -= sharedVariables.NumberSkip)
        {
            if (0 < Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego) && Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego) < Console.WindowWidth && 0 < sharedVariables.yOrego && sharedVariables.yOrego < Console.WindowHeight)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (sharedVariables.Scale * 2)) + sharedVariables.xOrego), Convert.ToInt32(sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > yLengthAdjustedNegative; i -= sharedVariables.NumberSkip)
        {
            if (0 < Convert.ToInt32((i * sharedVariables.Scale) + sharedVariables.yOrego) && Convert.ToInt32((i * sharedVariables.Scale) + sharedVariables.yOrego) < Console.WindowHeight && 0 < sharedVariables.xOrego && sharedVariables.xOrego < Console.WindowWidth)
            {
                Console.SetCursorPosition(Convert.ToInt32(sharedVariables.xOrego), Convert.ToInt32((i * sharedVariables.Scale) + Convert.ToInt16(sharedVariables.yOrego)));
                Console.Write(Math.Abs(i));
            }
        }
    }
    public static double FormulaCalc(int formulaIndex, double x)
    {
        double result = double.NaN;

        switch (formulaIndex)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                return Math.Sin(x);
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                return Math.Cos(x);
            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;
                return Math.Tan(x);
            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                return Math.Log(x);
            case 4:
                Console.ForegroundColor = ConsoleColor.Magenta;
                return Math.Sqrt(x);
            case 5:
                Console.ForegroundColor = ConsoleColor.Cyan;
                return Math.Pow(x, 2);
            default:
                return result;
        }
    }
    public static void UpdateOrego(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.W:
                sharedVariables.yOrego -= sharedVariables.Scale;
                break;
            case ConsoleKey.A:
                sharedVariables.xOrego -= (sharedVariables.Scale * 2);
                break;
            case ConsoleKey.S:
                sharedVariables.yOrego += sharedVariables.Scale;
                break;
            case ConsoleKey.D:
                sharedVariables.xOrego += (sharedVariables.Scale * 2);
                break;

            default:
                break;
        }

        Renderers.CoordinateSytemRender();

        Renderers.AxisNumbersRenderer();

        Program.FormulaHandler();
    }
    public static void ResetScreenPos()
    {
        sharedVariables.xOrego = Console.WindowWidth * 0.3;
        sharedVariables.yOrego = Console.WindowHeight * 0.5;
    }
    public static void ZoomHandler(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.O:
                if (2 < sharedVariables.Scale)
                {
                    sharedVariables.Scale -= sharedVariables.Zoom;
                }
                break;

            case ConsoleKey.P:
                if (12 > sharedVariables.Scale)
                {
                    sharedVariables.Scale += sharedVariables.Zoom;
                }
                break;

            case ConsoleKey.Enter:
                sharedVariables.Scale = 4;
                sharedVariables.NumberSkip = 1;
                sharedVariables.Zoom = 1;
                break;
            default:
                break;
        }

        if (sharedVariables.Scale == 3)
        {
            sharedVariables.Zoom = 1;
            sharedVariables.NumberSkip = 5;
        }
        else if (sharedVariables.Scale == 8)
        {
            sharedVariables.Zoom = 2;
            sharedVariables.NumberSkip = 1;
        }
    }
}