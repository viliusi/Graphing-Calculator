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
}