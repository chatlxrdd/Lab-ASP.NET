using System;
namespace Lab2.Models
{
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? a { get; set; }
        public double? b { get; set; }

        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.add:
                        return "+";
                    case Operators.sub:
                        return "-";
                    case Operators.div:
                        return "/";
                    case Operators.mul:
                        return "*";
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
                case Operators.add:
                    return (double)(a + b);
                case Operators.sub:
                    return (double)(a - b);
                case Operators.div:
                    return (double)(a / b);
                case Operators.mul:
                    return (double)(a * b);

                default: return double.NaN;
            }
        }
    }
}

