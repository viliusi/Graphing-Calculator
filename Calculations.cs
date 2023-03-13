public class Calculations
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
    public static double IntegralStart(int formulaIndex)
    {
        int type = 0;
        bool chooseType = true;
        while (chooseType == true)
        {
            Console.WriteLine(@"Choose which type of integral calculation you want to do (Press Escape to exit)
            0: Lower limit
            1: Upper limit
            2: Middle limit
            3: Trapez");

            ConsoleKey typeKey = Console.ReadKey().Key;

            switch (typeKey)
            {
                case ConsoleKey.D0:
                    type = 0;
                    chooseType = false;
                    break;
                case ConsoleKey.D1:
                    type = 1;
                    chooseType = false;
                    break;
                case ConsoleKey.D2:
                    type = 2;
                    chooseType = false;
                    break;
                case ConsoleKey.D3:
                    type = 3;
                    chooseType = false;
                    break;
                case ConsoleKey.D4:
                    type = 4;
                    chooseType = false;
                    break;
                case ConsoleKey.D5:
                    type = 5;
                    chooseType = false;
                    break;
                default:
                    break;
            }
        }

        Console.Clear();

        double startX = 0;
        double endX = 0;

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

        return Integral(formulaIndex, startX, endX, steps, type);
    }
    public static double Integral(int index, double start, double end, double steps, int type)
    {
        double result = 0;

        if (type == 0)
        {
            double x = start;

            double width = (end - start) / steps;

            while (x < end)
            {
                result += FormulaCalc(index, x) * width;
                x += width;
            }
        }
        else if (type == 1)
        {
            double width = (end - start) / steps;
            
            double x = start + width;

            while (x < end)
            {
                result += FormulaCalc(index, x) * width;
                x += width;
            }
        }
        else if (type == 2)
        {
            double width = (end - start) / steps;

            double x = start + ( width * 0.5 );

            while (x < end)
            {
                result += FormulaCalc(index, x) * width;
                x += width;
            }
        }
        else if (type == 3)
        {
            double width = (end - start) / steps;

            double x = start;
            double pastX = FormulaCalc(index, start);

            while (x < end)
            {
                x += width;

                double trapez = 0;

                if (x < pastX)
                {
                    trapez = (FormulaCalc(index, x) * width) + (pastX * width) / 2;
                }
                else if (x > pastX)
                {
                    trapez = (FormulaCalc(index, pastX) * width) + (x * width) / 2;
                }
                else
                {
                    trapez = FormulaCalc(index, x) * width;
                }

                result += FormulaCalc(index, x) * width;

                pastX = x;
            }
        }
        
        return result;
    }
    public static double FindMax(int index, double min, double max, double start, int precision)
    {
        double highestX = start;
        double highestY = FormulaCalc(index, start);

        // check for the highest y value within min and max
        for (double i = min; i < max; i += (max - min) / precision)
        {
            if (FormulaCalc(index, i) > highestY)
            {
                highestX = i;
                highestY = FormulaCalc(index, i);
            }
        }

        double lastHighestX = highestX;

        for (double i = lastHighestX - precision; i < lastHighestX + precision; i += ((lastHighestX + precision) - (lastHighestX - precision)) / (precision * precision))
        {
            if (FormulaCalc(index, i) > highestY)
            {
                highestX = i;
                highestY = FormulaCalc(index, i);
            }
        }

        return highestX;
    }
}