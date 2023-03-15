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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
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
            case 6:
                Console.ForegroundColor = ConsoleColor.Red;
                return Math.Sqrt(1 - Math.Pow(Math.Abs(x) - 1, 2));
            case 7:
                Console.ForegroundColor = ConsoleColor.Red;
                if (-2 <= x && x <= 2)
                {
                    return Math.Pow(x, 2) - 4;
                }
                else
                {
                    return double.NaN;
                }
            case 8:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                return 1 / (1 + Math.Pow(Math.E, -x));
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
                default:
                    break;
            }
        }

        Console.Clear();

        double startX = Program.Choose("Choose a starting point:");

        double endX = double.MinValue;

        while (startX >= endX)
        {
            endX = Program.Choose("Choose an ending point: (Must be greater than starting)");
        }

        int steps = -1;
        while (steps <= 1)
        {
            double step = Program.Choose("Choose the Steps: (Must be greater than 0)");

            try
            {
                steps = Convert.ToInt32(step);
            }
            catch (System.Exception)
            {

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

            double x = start + (width * 0.5);

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
    public static void Extrememum(int formulaIndex)
    {
        int type = -1;
        bool chooseType = true;
        while (chooseType == true)
        {
            Console.WriteLine(@"Choose which type of extrememum calculation you want to do (Press Escape to exit)
            0: Minimum
            1: Maximum");

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
                default:
                    break;
            }
        }

        double start = Program.Choose("Choose a starting point:");

        double end = double.MinValue;
        while (start >= end)
        {
            end = Program.Choose("Choose an ending point: (Must be greater than starting)");
        }

        int precision = -1;
        while (precision <= 1)
        {
            double prec = Program.Choose("Choose the precision: (Must be greater than 0)");

            try
            {
                precision = Convert.ToInt32(prec);
            }
            catch (System.Exception)
            {

            }
        }

        if (type == 0)
        {
            FindMin(formulaIndex, start, end, precision);
        }
        else if (type == 1)
        {
            FindMax(formulaIndex, start, end, precision);
        }
    }
    public static void FindMax(int index, double min, double max, int precision)
    {
        double highestX = min;
        double highestY = FormulaCalc(index, highestX);

        // check for the highest y value within min and max
        for (double i = min; i < max; i += (max - min) / precision)
        {
            if (FormulaCalc(index, i) > highestY || FormulaCalc(index, i) != double.NaN)
            {
                highestX = i;
                highestY = FormulaCalc(index, i);
            }
        }

        double lastHighestX = highestX;

        double iPredict = lastHighestX - precision;
        if (iPredict < min)
        {
            iPredict = min;
        }
        else if (iPredict > max)
        {
            iPredict = max;
        }

        double iMaxPredict = lastHighestX + precision;
        if (iMaxPredict < min)
        {
            iMaxPredict = min;
        }
        else if (iMaxPredict > max)
        {
            iMaxPredict = max;
        }

        for (double i = iPredict; i < iMaxPredict; i += ((lastHighestX + precision) - (lastHighestX - precision)) / (precision * precision))
        {
            if (FormulaCalc(index, i) > highestY || FormulaCalc(index, i) != double.NaN)
            {
                highestX = i;
                highestY = FormulaCalc(index, i);
            }
        }

        highestX = Math.Round(highestX, 2);
        highestY = Math.Round(FormulaCalc(index, highestX), 2);

        Program.ShowResultXY("The highest X location was: ", highestX, " With the value of: ", highestY);
    }
    public static void FindMin(int index, double min, double max, int precision)
    {
        double lowestX = min;
        double lowestY = FormulaCalc(index, lowestX);

        // check for the highest y value within min and max
        for (double i = min; i < max; i += (max - min) / precision)
        {
            if (FormulaCalc(index, i) < lowestY || FormulaCalc(index, i) != double.NaN)
            {
                lowestX = i;
                lowestY = FormulaCalc(index, i);
            }
        }

        double lastLowestX = lowestX;

        double iPredict = lastLowestX - precision;
        if (iPredict < min)
        {
            iPredict = min;
        }
        else if (iPredict > max)
        {
            iPredict = max;
        }

        double iMaxPredict = lastLowestX + precision;
        if (iMaxPredict < min)
        {
            iMaxPredict = min;
        }
        else if (iMaxPredict > max)
        {
            iMaxPredict = max;
        }

        for (double i = iPredict; i < iMaxPredict; i += ((lastLowestX + precision) - (lastLowestX - precision)) / (precision * precision))
        {
            if (FormulaCalc(index, i) < lowestY || FormulaCalc(index, i) != double.NaN)
            {
                lowestX = i;
                lowestY = FormulaCalc(index, i);
            }
        }

        lowestX = Math.Round(lowestX, 2);
        lowestY = Math.Round(FormulaCalc(index, lowestX), 2);

        Program.ShowResultXY("The lowest X location was: ", lowestX, " With the value of: ", lowestY);
    }
}