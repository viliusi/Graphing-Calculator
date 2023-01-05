public class Renderers
{
    public static void coordinateSytemRender()
    {
        Console.ForegroundColor = ConsoleColor.White;

        Program.sharedVariables.xLength = Convert.ToInt32(Console.WindowWidth);
        Program.sharedVariables.yLength = Convert.ToInt32(Console.WindowHeight);
        Program.sharedVariables.xOrego = Convert.ToInt32(Program.sharedVariables.xOregoDouble);
        Program.sharedVariables.yOrego = Convert.ToInt32(Program.sharedVariables.yOregoDouble);

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        if (0 < Program.sharedVariables.yOrego && Program.sharedVariables.yOrego < Program.sharedVariables.yLength)
        {
            for (int i = 0; i < Program.sharedVariables.xLength; i++)
            {                          /* x          y */
                Console.SetCursorPosition(i, Program.sharedVariables.yOrego);
                Console.Write("-");
            }
        }

        if (0 < Program.sharedVariables.xOrego && Program.sharedVariables.xOrego < Program.sharedVariables.xLength)
        {
            for (int i = 0; i < Program.sharedVariables.yLength; i++)
            {
                Console.SetCursorPosition(Program.sharedVariables.xOrego, i);
                Console.Write("|");
            }
        }
    }
    public static void EquationRenderer(Dictionary<string, double> formula)
    {
        // Different color from axis
        Console.ForegroundColor = ConsoleColor.Blue;

        // Helps with the if statement for rendering lines correctly
        Program.sharedVariables.lastResult = 0;

        // This is practicaly the one that does all the math, the i basically just tells it to do this math for each x value from one end of the screen to the other
        for (int i = 0; i < Program.sharedVariables.xLength; i++)
        {
            double x = (i - Program.sharedVariables.xOregoDouble) / (Program.sharedVariables.scaleRatio * 2);

            double math = Math.Sin(x + Math.PI);

            double result = math * Program.sharedVariables.scaleRatio;

            int yCoords = Program.sharedVariables.yOrego + Convert.ToInt32(result);

            if (0 < yCoords && yCoords < Program.sharedVariables.yLength)
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
            else
            {
                break;
            }

            Program.sharedVariables.lastResult = result;
        }
    }
    public static void axisNumbersRenderer()
    {
        Console.ForegroundColor = ConsoleColor.White;

        int skip;
        
        if (Program.sharedVariables.scaleRatio <= 2)
        {
            skip = 4;
        }
        else
        {
            skip = 1;
        }

        double xLengthPositive = (Program.sharedVariables.xLength - Program.sharedVariables.xOrego);
        double yLengthPositive = (Program.sharedVariables.yLength - Program.sharedVariables.yOrego);
        double xLengthAdjustedPositive = (Program.sharedVariables.xLength - Program.sharedVariables.xOrego) / (Program.sharedVariables.scaleRatio * 2);
        double yLengthAdjustedPositive = (Program.sharedVariables.yLength - Program.sharedVariables.yOrego) / Program.sharedVariables.scaleRatio;
        double xLengthAdjustedNegative = (xLengthPositive - Program.sharedVariables.xLength) / (Program.sharedVariables.scaleRatio * 2);
        double yLengthAdjustedNegative = (yLengthPositive - Program.sharedVariables.yLength) / Program.sharedVariables.scaleRatio;

        for (int i = 0; i < xLengthAdjustedPositive; i += skip)
        {
            if (0 < Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego) && Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego) < Program.sharedVariables.xLength && 0 < Program.sharedVariables.yOrego && Program.sharedVariables.yOrego < Program.sharedVariables.yLength)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego), Program.sharedVariables.yOrego);
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i < yLengthAdjustedPositive; i += skip)
        {
            if (0 < Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego) && Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego) < Program.sharedVariables.yLength && 0 < Program.sharedVariables.xOrego && Program.sharedVariables.xOrego < Program.sharedVariables.xLength)
            {
                Console.SetCursorPosition(Program.sharedVariables.xOrego, Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > xLengthAdjustedNegative; i -= skip)
        {
            if (0 < Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego) && Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego) < Program.sharedVariables.xLength && 0 < Program.sharedVariables.yOrego && Program.sharedVariables.yOrego < Program.sharedVariables.yLength)
            {
                Console.SetCursorPosition(Convert.ToInt32((i * (Program.sharedVariables.scaleRatio * 2)) + Program.sharedVariables.xOrego), Program.sharedVariables.yOrego);
                Console.Write(Math.Abs(i));
            }
        }

        for (int i = 0; i > yLengthAdjustedNegative; i -= skip)
        {
            if (0 < Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego) && Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego) < Program.sharedVariables.yLength && 0 < Program.sharedVariables.xOrego && Program.sharedVariables.xOrego < Program.sharedVariables.xLength)
            {
                Console.SetCursorPosition(Program.sharedVariables.xOrego, Convert.ToInt32((i * Program.sharedVariables.scaleRatio) + Program.sharedVariables.yOrego));
                Console.Write(Math.Abs(i));
            }
        }
    }
    public static void inputFieldRenderer()
    {
        Console.ForegroundColor = ConsoleColor.Gray;

        Program.sharedVariables.inputFieldWidth = Convert.ToInt32(Program.sharedVariables.xLength * 0.2);

        for (int i = 0; i < Program.sharedVariables.inputFieldWidth; i++)
        {
            for (int b = 0; b < Program.sharedVariables.yLength; b++)
            {
                Console.SetCursorPosition(Program.sharedVariables.xLength - Program.sharedVariables.inputFieldWidth + i, b);
                Console.Write("#");
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(Program.sharedVariables.xLength - Program.sharedVariables.inputFieldWidth + 1, 2);
        Console.Write("Press I for input");
    }
    public static void errorRenderer()
    {
        
    }
}