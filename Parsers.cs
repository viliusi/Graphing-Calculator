public class Parsers
{
    public class sharedVariables
    {
        public static string[] results;
    }
    public static void inputHandler(string formula)
    {
        formula = "f(x) = sin(x + 3) + 2 * -0.4 - (3 ^ 2)";

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

        int segmentNum = 0;

        // RAM
        char third = ' ';
        char second = ' ';
        char first = ' ';

        Dictionary<string, double> Formulas = new Dictionary<string, double>();

        double numToAdd;

        string lastOperation = "=";

        for (int i = 0; i < formulaArray.Length; i++)
        {
            char test = formulaArray[i];

            switch (test)
            {
                case '+':
                
                Formulas.Add(lastOperation, numToAdd);

                lastOperation = "+";
                segmentNum++;
                break;
                case '-':

                break;
                case '*':

                break;
                case '/':

                break;
                case '(':

                break;
                case ')':

                break;
                case '^':

                break;
                default:
                numToAdd 
                break;
            }

            third = second;
            second = first;
            first = test;

            if (third == 'S' && second == 'I' && first == 'N')
            {
                // Sin segment found
            }
            else if (third == 'T' && second == 'A' && first == 'N')
            {
                // Tan segment found
            }
            else if (third == 'C' && second == 'O' && first == 'S')
            {
                // Cos segment found
            }
            else
            {
                // Do nothing
            }
        }

        Console.ReadKey();

        // int[] formulaIndexPlus = new int[formula.Count(p => p == '+')];
        // int[] formulaIndexMinus = new int[formula.Count(m => m == '-')];
        // int[] formulaIndexMultiply = new int[formula.Count(m => m == '*')];
        // int[] formulaIndexDivide = new int[formula.Count(d => d == '/')];
        // int[] formulaIndexPower = new int[formula.Count(c => c == '^')];
    }
}