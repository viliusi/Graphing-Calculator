public class Parsers
{
    public class sharedVariables
    {
        public static string[] results;
    }
    public static void inputHandler(string formula)
    {
        formula = "f(x) = 2.4 + ( -0.4 - 3 ) ^ 2 + sin( x + 3 )";

        formula = formula.Replace(" ", "");

        string[] nameSplit = formula.Split('=');

        Program.sharedVariables.Formulas.Add(nameSplit[0], nameSplit[1]);

        string formulaCut = nameSplit[1];

        char[] formulaArray = new char[formulaCut.Length];

        for (int i = 0; i < formulaCut.Length; i++)
        {
            formulaArray[i] = formula[i];
        }

        int[] formulaIndexStartParanthesis = new int[formulaArray.Count(s => s == '(')];
        int[] formulaIndexEndParanthesis = new int[formulaArray.Count(s => s == ')')];

        Dictionary<string, double> Formulas = new Dictionary<string, double>();

        double numToAdd;

        int segmentNum = 0;

        int numAdd = 0;

        char[] numToAddArray = new char[9];

        string lastOperation = "=";

        for (int i = 0; i < formulaArray.Length; i++)
        {
            char test = formulaArray[i];

            switch (test)
            {
                case '+': // +
                    numToAdd = makeDouble(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "+";
                    segmentNum++;
                    break;
                case '-': // -

                    break;
                case '*': // *

                    break;
                case '/': // /

                    break;
                case '(': // (

                    break;
                case ')': // )

                    break;
                case '^':
                    // ^=
                    break;
                case 's': // Sin
                    i = i + 3;
                    lastOperation = "Sin(";
                    break;
                default:
                    numToAddArray[numAdd] = test;
                    break;
            }
        }
    }
    public static double makeDouble(char[] numberSegment)
    {
        int[] commaLocationArray = new int[0];

        for (int i = 0; i < numberSegment.Length; i++)
        {
            char test = numberSegment[i];

            if (test == '.')
            {
                commaLocationArray[0] = i;
            }
        }

        char[] beforeComma = new char[numberSegment.Length];
        char[] afterComma = new char[numberSegment.Length];

        int beforeCommaLoc = 0;
        int afterCommaLoc = 0;

        for (int i = 0; i <= numberSegment.Length; i++)
        {
            int comLoc = commaLocation;

            if (i < commaLocation)
            {
                beforeComma[beforeCommaLoc] = numberSegment[i];
                beforeCommaLoc++;
            }
            else if (i > commaLocation)
            {
                afterComma[afterCommaLoc] = numberSegment[i];
                afterCommaLoc++;
            }
        }

        beforeCommaLoc = beforeComma.Length;
        afterCommaLoc = afterComma.Length;

        char[] beforeCommaShort = new char[beforeCommaLoc];
        char[] afterCommaShort = new char[afterCommaLoc];

        for (int i = 0; i < beforeCommaLoc; i++)
        {
            beforeCommaShort[i] = beforeComma[i];
        }
        for (int i = 0; i < afterCommaLoc; i++)
        {
            afterCommaShort[i] = afterComma[i];
        }
        
        Console.WriteLine(beforeCommaLoc);

        for (int i = 0; i < beforeCommaLoc; i++)
        {
            Console.Clear();
            Console.WriteLine(beforeCommaShort[i]);
            Thread.Sleep(500);
        }


        // double numberFinal = int.Parse(string.Concat(beforeCommaShort)) + '.' + int.Parse(string.Concat(afterCommaShort));

        // concat

        double numberFinal = 2;

        Console.WriteLine(numberFinal);
        Console.ReadKey();

        return numberFinal;
    }
}