public class Equation
{
    public class sharedVariables
    {
        public static string name;
    }
    public Equation(string formula)
    {
        formula = "f(x) = 2.4 + ( -0.4 - 3 ) + x + 3";

        formula = formula.Replace(" ", "");

        string[] nameSplit = formula.Split('=');

        sharedVariables.name = nameSplit[0];

        string formulaCut = nameSplit[1];

        char[] formulaArray = new char[formulaCut.Length];

        for (int i = 0; i < formulaCut.Length; i++)
        {
            formulaArray[i] = formulaCut[i];
        }

        equationDecypherer(formulaArray);
    }
    public static void equationDecypherer(char[] formulaArray)
    {
        Dictionary<string, char[]> Formulas = new Dictionary<string, char[]>();

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
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "+";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case '-': // -
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "-";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case '*': // *
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "*";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case '/': // /
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "/";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case '(': // (
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "(";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case ')': // )
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = ")";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case '^':
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "^";
                    segmentNum++;
                    numAdd = 0;
                    break;
                case 's': // Sin
                    i += 2;
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "sin";
                    segmentNum++;
                    numAdd = 0;
                    break;
                default:
                    numToAddArray[numAdd] = test;
                    numAdd++;
                    break;
            }
        }

        int indexofForm = Program.sharedVariables.allFormulaNames.IndexOf(Convert.ToString(sharedVariables.name[0]));

        // Program.sharedVariables.FormulasForRendering.Add(nameSplit[0], );
        // Program.sharedVariables.allFormulaNames.Add(Convert.ToString(nameSplit[0]));
    }
}