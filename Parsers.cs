public class Parsers
{
    public class sharedVariables
    {
        public static string[] results;
    }
    public static void inputHandler(string formula)
    {
        string[] functionNameSplit = formula.Split('=');

        string[] formulaSplitParanthesis = functionNameSplit[2].Split('(', ')');

        for (int i = 0; i < formulaSplitParanthesis.Length; i++)
        {
            sharedVariables.results = formulaSplitParanthesis[i].Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
        
        Program.sharedVariables.Formulas.Add(functionNameSplit[0], Convert.ToString(sharedVariables.results)); 

        Console.WriteLine(Program.sharedVariables.Formulas);
        Console.ReadKey();

        foreach (var term in sharedVariables.results)
        {
            int number;

            bool success = int.TryParse(term, out number);
            if (success)
            {
                Console.WriteLine($"Converted '{term}' to {number}.");
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{term ?? "<null>"}' failed.");
            }
        }


    }
}