public class Equation
{
    public static void equationDecypherer(string formula)
    {
        formula = "f(x) = 2.4 + ( -0.4 - 3 ) + x + 3";

        formula = formula.Replace(" ", "");

        string[] nameSplit = formula.Split('=');

        string name = nameSplit[0];

        string formulaCut = nameSplit[1];

        char[] formulaArray = new char[formulaCut.Length];

        for (int i = 0; i < formulaCut.Length; i++)
        {
            formulaArray[i] = formulaCut[i];
        }
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
                    lastOperation = "+" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case '-': // -
                    if (numToAddArray[0] == '\0')
                    {
                        numToAddArray[numAdd] = test;
                        numAdd++;
                    }
                    else
                    {
                        Formulas.Add(lastOperation, numToAddArray);
                        lastOperation = "-" + segmentNum;
                        segmentNum++;
                        numAdd = 0;
                        numToAddArray = nullArray(numToAddArray);
                    }
                    break;
                case '*': // *
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "*" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case '/': // /
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "/" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case '(': // (
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "(" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case ')': // )
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = ")" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case '^':
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "^" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                case 's': // Sin
                    i += 2;
                    Formulas.Add(lastOperation, numToAddArray);
                    lastOperation = "sin" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = nullArray(numToAddArray);
                    break;
                default:
                    numToAddArray[numAdd] = test;
                    numAdd++;
                    break;
            }
        }

        Program.sharedVariables.allFormulaNames.Add(Convert.ToString(nameSplit[0]));

        Program.sharedVariables.FormulasForRendering.Add(nameSplit[0], Formulas);

        Program.sharedVariables.toRenderFormulaNames.Add(nameSplit[0]);
    }
    public static char[] nullArray(char[] toBeNulled)
    {
        for (int i = 0; i < toBeNulled.Length; i++)
        {
            toBeNulled[i] = '\0';
        }

        return toBeNulled;
    }
}