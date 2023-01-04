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
            formulaArray[i] = formulaCut[i];
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
                    numToAdd = 0;
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
                    numAdd++;
                    break;
            }
        }
    }
    public static double makeDouble(char[] numberSegment)
    {
        int actualLength = 0;

        for (int i = 0; i < numberSegment.Length; i++)
        {
            char test = numberSegment[i];

            if (test != '\0')
            {
                actualLength++;
            }
        }

        int commaLocation = Array.IndexOf(numberSegment, '.');

        int beforeCommaLoc = 0;
        int afterCommaLoc = 0;

        int digitsBeforeComma = commaLocation;
        int digitsAfterComma = actualLength - commaLocation;

        char[] beforeComma = new char[digitsBeforeComma];
        char[] afterComma = new char[digitsAfterComma];

        for (int i = 0; i <= actualLength; i++)
        {
            int comLoc = commaLocation;

            char toAdd = numberSegment[i];

            if (i < commaLocation && toAdd != '.')
            {
                beforeComma[beforeCommaLoc] = toAdd;
                beforeCommaLoc++;
            }
            else if (i > commaLocation && toAdd != '.')
            {
                afterComma[afterCommaLoc] = toAdd;
                afterCommaLoc++;
            }
        }

        // double numberFinal = int.Parse(string.Concat(beforeCommaShort)) + '.' + int.Parse(string.Concat(afterCommaShort));

        // concat

        double numberFinal = double.Parse(string.Concat(beforeComma + "." + afterComma));

        Console.WriteLine(numberFinal);
        Console.ReadKey();

        return numberFinal;
    }
}