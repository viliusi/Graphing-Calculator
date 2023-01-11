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
        Dictionary<string, string> Formulas = new Dictionary<string, string>();

        int segmentNum = 1;

        int numAdd = 0;

        char[] numToAddArray = new char[9];

        string numToAdd;

        string lastOperation = "=0";

        for (int i = 0; i < formulaArray.Length; i++)
        {

            char test = formulaArray[i];

            switch (test)
            {
                case '+': // +
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "+" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case '-': // -
                    if (numToAddArray[0] == '\0')
                    {
                        numToAddArray[numAdd] = test;
                        numAdd++;
                    }
                    else
                    {
                        numToAdd = ConvertToString(numToAddArray);
                        Formulas.Add(lastOperation, numToAdd);
                        lastOperation = "-" + segmentNum;
                        segmentNum++;
                        numAdd = 0;
                        numToAddArray = NullArray(numToAddArray);
                    }
                    break;
                case '*': // *
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "*" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case '/': // /
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "/" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case '(': // (
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "(" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case ')': // )
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = ")" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case '^':
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "^" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                case 's': // Sin
                    i += 2;
                    numToAdd = ConvertToString(numToAddArray);
                    Formulas.Add(lastOperation, numToAdd);
                    lastOperation = "sin" + segmentNum;
                    segmentNum++;
                    numAdd = 0;
                    numToAddArray = NullArray(numToAddArray);
                    break;
                default:
                    numToAddArray[numAdd] = test;
                    numAdd++;
                    break;
            }
        }

        numToAdd = ConvertToString(numToAddArray);
        Formulas.Add(lastOperation, numToAdd);

        Program.sharedVariables.allFormulaNames.Add(Convert.ToString(nameSplit[0]));

        Program.sharedVariables.FormulasForRendering.Add(nameSplit[0], Formulas);

        Program.sharedVariables.toRenderFormulaNames.Add(nameSplit[0]);
    }
    public static char[] NullArray(char[] toBeNulled)
    {
        for (int i = 0; i < toBeNulled.Length; i++)
        {
            toBeNulled[i] = '\0';
        }

        return toBeNulled;
    }
    public static string ConvertToString(char[] input)
    {
        string String = new string(input);

        String = String.Replace("\0", "");

        return String;
    }
    public static double Calculator(Dictionary<string, string> Formula, double x)
    {
        // Noting down where start paranthesis and end parenthesis is
        int[] indexOfSP = new int[Formula.Count]; 
        int[] indexOfEP = new int[Formula.Count];
        
        for (int i = 0; i < Formula.Count; i++)
        {
            string test = Formula.ElementAt(i).Key;

            if (test.Contains("("))
            {
                indexOfSP.Append(i);
            }
            else if (test.Contains(")"))
            {
                indexOfEP.Append(i);
            }
            else
            {
                
            }
        }

        double result = 0;

        return result;
    }
}