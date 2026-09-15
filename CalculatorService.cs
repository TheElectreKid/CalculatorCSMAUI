using Microsoft.Maui.Controls.Platform.Compatibility;

public class CalculatorService
{
    public static string InputBuffer = "";
    public static int MathOperator = 0;
    public static int? PrevNum = null;

    public static void AllClear()
    {
        Console.WriteLine($"[AllClear] BEFORE -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");
        InputBuffer = "";
        MathOperator = 0;
        PrevNum = null;
        Console.WriteLine($"[AllClear] AFTER  -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");
    }
    public enum Operators {
        Addition = 1,
        Subtraction = 2,
        Multplication = 3,
        Division = 4
    }
    
    public static void CalcNumKey(string key)
    {
        InputBuffer += key;
        Console.WriteLine($"[CalcNumKey] key='{key}' -> InputBuffer='{InputBuffer}'");
    }
    public static void SetOperator(int op)
    {
        Console.WriteLine($"[SetOperator] ENTER op={op} -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");

        //Check pending for chaining
        if (PrevNum != null && InputBuffer != "")
        {
            Console.WriteLine($"[SetOperator] Chaining detected, calling CalculateTotal()");
            CalculatorService.CalculateTotal();
            Console.WriteLine($"[SetOperator] AFTER CalculateTotal() -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");
        }
        
        //Parse the InputBuffer and push to PrevNum (I hope that is correct so far?)
        if (!int.TryParse (InputBuffer, out int NewPrevNum))
        {
            Console.WriteLine("Invalid Integer!");    
            return;
        }
        PrevNum = NewPrevNum;
        
        //Clear input buffer for further input
        InputBuffer = "";
        //Set the operator as received by the paramter
        MathOperator = op;

        Console.WriteLine($"[SetOperator] EXIT -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");
        return;
    }
    public static void CalculateTotal()
    {
        Console.WriteLine($"[CalculateTotal] ENTER -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");

        //Set PrevNum as 'A'
        int a = (int) PrevNum;
        //Set InputBuffer as 'B'
        if (!int.TryParse (InputBuffer, out int b))
        {
            Console.WriteLine("Invalid Integer!");    
        }
        //Placeholder for the final result
        int result = 0;
        
        //Calculate
        switch (MathOperator)
        {
            case (int) Operators.Addition:
                result = a + b;
                break;
            case (int) Operators.Subtraction:
                result = a - b; 
                break;
            case (int) Operators.Multplication:
                result = a * b;
                break;
            case (int) Operators.Division:
                if (b != 0) result = a / b;
                break; 
        }

        Console.WriteLine($"[CalculateTotal] a={a}, b={b}, MathOperator={MathOperator} -> result={result}");

        //Return 'result' and set that inside the InputBuffer (For further calculation is possible)
        InputBuffer = result.ToString();
        PrevNum = null;
        MathOperator = 0;

        Console.WriteLine($"[CalculateTotal] EXIT -> InputBuffer='{InputBuffer}', PrevNum={PrevNum}, MathOperator={MathOperator}");
        return;
    }    
}