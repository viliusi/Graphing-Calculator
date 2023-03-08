public class Renderers
{
    public static void coordinateSytemRender()
    {
        Console.ForegroundColor = ConsoleColor.White;

        int xOrego = Convert.ToInt32(Program.sharedVariables.xOregoDouble);
        int yOrego = Convert.ToInt32(Program.sharedVariables.yOregoDouble);

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
    public static void EquationRenderer(/*Dictionary<string, string> formula*/ int formulaIndex)
    {
        // Helps with the if statement for rendering lines correctly
        Program.sharedVariables.lastResult = 0;

        // This is practicaly the one that does all the math, the i basically just tells it to do this math for each x value from one end of the screen to the other
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            double x = (Program.sharedVariables.xOregoDouble - i) / (Program.sharedVariables.scaleRatio * 2 );

            double math = formulaCalc(formulaIndex, x);

            if (math == double.NaN)
            {
                break;
            }

            double result = math * Program.sharedVariables.scaleRatio;

            int yCoords = int.MinValue;

            try
            {
                yCoords = ( Convert.ToInt32(Program.sharedVariables.yOregoDouble + result - Console.WindowHeight ) ) * -1; 
            }
            catch (OverflowException)
            {
                
            }

            if (0 < yCoords && yCoords < Console.WindowHeight)
            {
                Console.SetCursorPosition(i, yCoords);

                double mathDiffernce = Program.sharedVariables.lastResult - result;

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

            Program.sharedVariables.lastResult = result;
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void axisNumbersRenderer()
    {
        Console.ForegroundColor = ConsoleColor.White;

        double xLengthPositive = (Console.WindowWidth - Program.sharedVariables.xOregoDouble);
        double yLengthPositive = (Console.WindowHeight - Program.sharedVariables.yOregoDouble);
        double xLengthAdjustedPositive = (Console.WindowWidth - Program.sharedVariables.xOregoDouble) / (Program.sharedVariables.scaleRatio * 2);
        double yLengthAdjustedPositive = (Console.WindowHeight - Program.sharedVariables.yOregoDouble) / Program.sharedVariables.scaleRatio;
        double xLengthAdjustedNegative = (xLengthPositive - Console.WindowWidth) / (Program.sharedVariables.scaleRatio * 2);
        double yLengthAdjustedNegative = (yLengthPositive - Console.WindowHeight) / Program.sharedVariables.scaleRatio;

        for (int i = 0; i < xLengthAdjustedPositive; i += Program.sharedVariables.numberSkip)
        {
            if (0 < Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble) && Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble) < Console.WindowWidth && 0 < Program.sharedVariables.yOregoDouble && Program.sharedVariables.yOregoDouble < Console.WindowHeight)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble), Convert.ToInt32(Program.sharedVariables.yOregoDouble));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i < yLengthAdjustedPositive; i += Program.sharedVariables.numberSkip)
        {
            if (0 < Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOregoDouble) && Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOregoDouble) < Console.WindowHeight && 0 < Program.sharedVariables.xOregoDouble && Program.sharedVariables.xOregoDouble < Console.WindowWidth)
            {
                Console.SetCursorPosition(Convert.ToInt32(Program.sharedVariables.xOregoDouble), Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOregoDouble));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > xLengthAdjustedNegative; i -= Program.sharedVariables.numberSkip)
        {
            if (0 < Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble) && Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble) < Console.WindowWidth && 0 < Program.sharedVariables.yOregoDouble && Program.sharedVariables.yOregoDouble < Console.WindowHeight)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOregoDouble), Convert.ToInt32(Program.sharedVariables.yOregoDouble));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > yLengthAdjustedNegative; i -= Program.sharedVariables.numberSkip)
        {
            if (0 < Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOregoDouble) && Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOregoDouble) < Console.WindowHeight && 0 < Program.sharedVariables.xOregoDouble && Program.sharedVariables.xOregoDouble < Console.WindowWidth)
            {
                Console.SetCursorPosition(Convert.ToInt32(Program.sharedVariables.xOregoDouble), Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Convert.ToInt16(Program.sharedVariables.yOregoDouble)));
                Console.Write(Math.Abs(i));
            }
        }
    }
    public static double formulaCalc(int formulaIndex, double x)
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
}