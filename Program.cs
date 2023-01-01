internal class Program
{
    public static class sharedVariables
    {
        public static double xPositionCoord;
        public static double yPositionCoord;
        public static int xLength;
        public static int yLength;
        public static int xPosCoordI;
        public static int yPosCoordI;
        public static int xOrego;
        public static int yOrego;
        public static double scaleRatio;
        public static double lastResult;
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("When you have put the console into full screen, press a button to continue");
        Console.ReadKey();

        sharedVariables.scaleRatio = 4;

        coordinateSytemRender();

        EquationRenderer();

        axisNumbersRenderer();
        Thread.Sleep(5000);
        Console.ReadKey();
    }
    static void coordinateSytemRender()
    {
        sharedVariables.xPositionCoord = Console.WindowWidth * 0.3;
        sharedVariables.yPositionCoord = Console.WindowHeight * 0.5;

        sharedVariables.xLength = Convert.ToInt32(Console.WindowWidth);
        sharedVariables.yLength = Convert.ToInt32(Console.WindowHeight);
        sharedVariables.xPosCoordI = Convert.ToInt32(sharedVariables.xPositionCoord);
        sharedVariables.yPosCoordI = Convert.ToInt32(sharedVariables.yPositionCoord);
        sharedVariables.xOrego = sharedVariables.xPosCoordI;
        sharedVariables.yOrego = sharedVariables.yPosCoordI;

        Console.Clear();
        Console.SetCursorPosition(0,0);

        for(int i = 0; i < sharedVariables.xLength; i++)
        {                          /* x       y */
            Console.SetCursorPosition(i, sharedVariables.yPosCoordI);
            Console.Write("-");
        }

        for(int i = 0; i < sharedVariables.yLength; i++)
        {
            Console.SetCursorPosition(sharedVariables.xPosCoordI, i);
            Console.Write("|");
        }

        Console.SetCursorPosition(sharedVariables.xPosCoordI, sharedVariables.yPosCoordI);
        Console.Write("+");
    }
    static void EquationRenderer()
    {
        // Different color from axis
        Console.ForegroundColor = ConsoleColor.Blue;

        // Helps with the if statement for rendering lines correctly
        sharedVariables.lastResult = 0;

        // This is practicaly the one that does all the math, the i basically just tells it to do this math for each x value from one end of the screen to the other
        for(int i = 0; i < sharedVariables.xLength; i++)
        {
            double xAdjusted = (i - sharedVariables.xOrego) / sharedVariables.scaleRatio ;

            double math = Math.Sin(xAdjusted);

            double result = sharedVariables.scaleRatio * math;

            Console.SetCursorPosition(i, sharedVariables.yOrego + Convert.ToInt32(result));

            double mathDiffernce = sharedVariables.lastResult - result;

            if (mathDiffernce > 0.2)
            {
                Console.Write("/");
            }
            else if (mathDiffernce < 0.2)
            {
                Console.Write("\\");
            }
            else
            {
                Console.Write("-");
            }
            

            sharedVariables.lastResult = result;
        }
    }
    static void axisNumbersRenderer()
    {
        Console.ForegroundColor = ConsoleColor.White;

        double xLengthPositive = (sharedVariables.xLength - sharedVariables.xOrego);
        double yLengthPositive = (sharedVariables.yLength - sharedVariables.yOrego);
        double xLengthAdjustedPositive = (sharedVariables.xLength - sharedVariables.xOrego) / sharedVariables.scaleRatio;
        double yLengthAdjustedPositive = (sharedVariables.yLength - sharedVariables.yOrego) / sharedVariables.scaleRatio;
        double xLengthAdjustedNegative = (sharedVariables.xLength - xLengthPositive) / sharedVariables.scaleRatio;
        double yLengthAdjustedNegative = (sharedVariables.yLength - yLengthPositive) / sharedVariables.scaleRatio;

        for(int i = 0; i < xLengthAdjustedPositive; i++)
        {
            Console.SetCursorPosition(Convert.ToInt32((i * 8) + sharedVariables.xOrego), sharedVariables.yOrego);
            Console.Write(i);
        }

        Console.ReadKey();

        for(int i = 0; i < sharedVariables.yLength; i++)
        {
            Console.SetCursorPosition(sharedVariables.xPosCoordI, i);
            Console.Write("|");
        }
    }
}