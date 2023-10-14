namespace Lab2.Models;

public class Calculator
{
    public string? Operator { get; set; }
    public double? a { get; set; }
    public double? b { get; set; }

    public String Op
    {
        get
        {
            switch (Operator)
            {
                case Operator.add:
                    return "+";
                    
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && a != null && b != null;
    }

    public double Calculate()
    {
        switch (Operator)
        {
            case Operators.Add:
                return (double)(a + b);
                ...
            default: return double.NaN;
        }
    }
}
