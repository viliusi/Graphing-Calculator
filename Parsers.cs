public class Parsers
{
    public class sharedVariables
    {
        public static string[] results;
    }
    public static void inputHandler(string formula)
    {
        formula = "f(x) = 2 * ( -0.4 - 3 ) ^ 2 + sin(x + 3)";

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
                numToAdd = Convert.ToDouble(numToAddArray);
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

        Console.ReadKey();
    }
}