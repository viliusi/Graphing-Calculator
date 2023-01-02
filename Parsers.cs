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

        char[] formulaArray = new char[nameSplit[1].Length];

        for (int i = 0; i < formula.Length; i++)
        {
            formulaArray[i] = formula[i];
        }

        int[] formulaIndexStartParanthesis = new int[formulaArray.Count(s => s == '(')];
        int[] formulaIndexEndParanthesis = new int[formulaArray.Count(s => s == ')')];

        int segmentNum = 0;

        int neededLength = formulaArray.Count(s => s == '(');
        string[] segmentedFormula = new string[neededLength];

        char[] toAdd = new char[formulaArray.Length];

        for (int i = 0; i < formulaArray.Length; i++)
        {
            switch (formulaArray[i])
            {
                case '(':
                segmentedFormula[segmentNum] = Convert.ToString(toAdd);
                toAdd[segmentNum] = formulaArray[i];
                break;
                case ')':
                toAdd[segmentNum] = formulaArray[i];
                segmentedFormula[segmentNum] = Convert.ToString(toAdd);
                break;
                default:
                toAdd[segmentNum] = formulaArray[i];
                break;
            }
        }

        for (int i = 0; i < segmentedFormula.Length; i++)
        {
            Console.WriteLine(segmentedFormula[i]);
        }

        Console.ReadKey();

        // int[] formulaIndexPlus = new int[formula.Count(p => p == '+')];
        // int[] formulaIndexMinus = new int[formula.Count(m => m == '-')];
        // int[] formulaIndexMultiply = new int[formula.Count(m => m == '*')];
        // int[] formulaIndexDivide = new int[formula.Count(d => d == '/')];
        // int[] formulaIndexPower = new int[formula.Count(c => c == '^')];
    }
}