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

        while (true)
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
                default:
                    break;
            }
        }
    }
    static void coordinateSytemRender()
    {
        sharedVariables.xLength = Convert.ToInt32(Console.WindowWidth);
        sharedVariables.yLength = Convert.ToInt32(Console.WindowHeight);
        sharedVariables.xOrego = Convert.ToInt32(sharedVariables.xOregoDouble);
        sharedVariables.yOrego = Convert.ToInt32(sharedVariables.yOregoDouble);

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        if (0 < sharedVariables.yOrego && sharedVariables.yOrego < sharedVariables.yLength)
        {
            for (int i = 0; i < sharedVariables.xLength; i++)
            {                          /* x          y */
                Console.SetCursorPosition(i, sharedVariables.yOrego);
                Console.Write("-");
            }
        }

        if (0 < sharedVariables.xOrego && sharedVariables.xOrego < sharedVariables.xLength)
        {
            for (int i = 0; i < sharedVariables.yLength; i++)
            {
                Console.SetCursorPosition(sharedVariables.xOrego, i);
                Console.Write("|");
            }
        }
    }
    static void EquationRenderer()
    {
        // Different color from axis
        Console.ForegroundColor = ConsoleColor.Blue;

        // Helps with the if statement for rendering lines correctly
        sharedVariables.lastResult = 0;

        // This is practicaly the one that does all the math, the i basically just tells it to do this math for each x value from one end of the screen to the other
        for (int i = 0; i < sharedVariables.xLength; i++)
        {
            double xAdjusted = (i - sharedVariables.xOregoDouble) / (sharedVariables.scaleRatio * 2);

            double math = Math.Sin(xAdjusted + Math.PI);

            double result = math * sharedVariables.scaleRatio;

            int yCoords = sharedVariables.yOrego + Convert.ToInt32(result);

            if (0 < yCoords && yCoords < sharedVariables.yLength)
            {
                Console.SetCursorPosition(i, yCoords);

                double mathDiffernce = sharedVariables.lastResult - result;

                if (mathDiffernce > 0)
                {
                    Console.Write("/");
                }
                else if (mathDiffernce < 0)
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write("#");
                }
            }
            else
            {
                break;
            }

            sharedVariables.lastResult = result;
        }
    }
    static void axisNumbersRenderer()
    {
        Console.ForegroundColor = ConsoleColor.White;

        double xLengthPositive = (sharedVariables.xLength - sharedVariables.xOrego);
        double yLengthPositive = (sharedVariables.yLength - sharedVariables.yOrego);
        double xLengthAdjustedPositive = (sharedVariables.xLength - sharedVariables.xOrego) / (sharedVariables.scaleRatio * 2);
        double yLengthAdjustedPositive = (sharedVariables.yLength - sharedVariables.yOrego) / sharedVariables.scaleRatio;
        double xLengthAdjustedNegative = (xLengthPositive - sharedVariables.xLength) / (sharedVariables.scaleRatio * 2);
        double yLengthAdjustedNegative = (yLengthPositive - sharedVariables.yLength) / sharedVariables.scaleRatio;

        for (int i = 0; i < xLengthAdjustedPositive; i++)
        {
            if (0 < Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego) && Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego) < sharedVariables.xLength && 0 < sharedVariables.yOrego && sharedVariables.yOrego < sharedVariables.yLength)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego), sharedVariables.yOrego);
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i < yLengthAdjustedPositive; i++)
        {
            if (0 < Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego) && Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego) < sharedVariables.yLength && 0 < sharedVariables.xOrego && sharedVariables.xOrego < sharedVariables.xLength)
            {
                Console.SetCursorPosition(sharedVariables.xOrego, Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > xLengthAdjustedNegative; i--)
        {
            if (0 < Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego) && Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego) < sharedVariables.xLength && 0 < sharedVariables.yOrego && sharedVariables.yOrego < sharedVariables.yLength)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (sharedVariables.scaleRatio * 2)) + sharedVariables.xOrego), sharedVariables.yOrego);
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > yLengthAdjustedNegative; i--)
        {
            if (0 < Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego) && Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego) < sharedVariables.yLength && 0 < sharedVariables.xOrego && sharedVariables.xOrego < sharedVariables.xLength)
            {
                Console.SetCursorPosition(sharedVariables.xOrego, Convert.ToInt32((i * sharedVariables.scaleRatio) + sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }
    }
    static void updateOrego(System.ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.W:
                sharedVariables.yOregoDouble--;
                break;
            case ConsoleKey.A:
                sharedVariables.xOregoDouble--;
                break;
            case ConsoleKey.S:
                sharedVariables.yOregoDouble++;
                break;
            case ConsoleKey.D:
                sharedVariables.xOregoDouble++;
                break;
            default:
                break;
        }
        coordinateSytemRender();

        EquationRenderer();

        axisNumbersRenderer();
    }
    static void resetScreenPos()
    {
        sharedVariables.xOregoDouble = Console.WindowWidth * 0.3;
        sharedVariables.yOregoDouble = Console.WindowHeight * 0.5;
    }
}