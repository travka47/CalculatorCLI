namespace Operations
{
    public enum OperatorType
    {
        Unary,
        Binary
    }

    public abstract class Operation
    {
        public abstract string Operator { get; }
        public abstract OperatorType Type { get; }
    }

    public abstract class UnaryOperation : Operation
    {
        public override OperatorType Type { get; } = OperatorType.Unary;

        public abstract double Execute(double operand);
    }

    public abstract class BinaryOperation : Operation
    {
        public override OperatorType Type { get; } = OperatorType.Binary;

        public abstract double Execute(double firstOperand, double secondOperand);
    }



    public class Addition : BinaryOperation
    {
        public override string Operator { get; } = "+";

        public override double Execute(double firstOperand, double secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }

    class Subtraction : BinaryOperation
    {
        public override string  Operator { get; } = "-";

        public override double Execute(double firstOperand, double secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }

    class Multiplication : BinaryOperation
    {
        public override string Operator { get; } = "*";

        public override double Execute(double firstOperand, double secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }

    class Division : BinaryOperation
    {
        public override string Operator { get; } = "/";

        public override double Execute(double firstOperand, double secondOperand)
        {
            if (secondOperand == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль");
                return double.NaN;
            }
            return firstOperand / secondOperand;
        }
    }

    class SquareRoot : UnaryOperation
    {
        public override string Operator { get; } = "sqrt";

        public override double Execute(double operand)
        {
            if (operand < 0)
            {
                Console.WriteLine("Ошибка: невозможно извлечь корень из отрицательного числа");
                return double.NaN;
            }
            return Math.Sqrt(operand);
        }
    }

    class Power : BinaryOperation
    {
        public override string Operator { get; } = "pow";

        public override double Execute(double operand, double exponent)
        {
            return Math.Pow(operand, exponent);
        }
    }

    class Exponent : UnaryOperation
    {
        public override string Operator { get; } = "exp";

        public override double Execute(double operand)
        {
            return Math.Exp(operand);
        }
    }

    class Percentage : BinaryOperation
    {
        public override string Operator { get; } = "%";

        public override double Execute(double operand, double percent)
        {
            return (operand * percent) / 100.0;
        }
    }

    class Sin : UnaryOperation
    {
        public override string Operator { get; } = "sin";
        public override double Execute(double operand)
        {
            double angleInRadians = Math.PI * operand / 180;
            return Math.Round(Math.Sin(angleInRadians), 6);
        }
    }

    class Cos : UnaryOperation
    {
        public override string Operator { get; } = "cos";
        public override double Execute(double operand)
        {
            double angleInRadians = Math.PI * operand / 180;
            return Math.Round(Math.Cos(angleInRadians), 6);
        }
    }

    class Tan : UnaryOperation
    {
        public override string Operator { get; } = "tg";
        public override double Execute(double operand)
        {
            if (operand == 90 || operand == 270)
            {
                Console.WriteLine("Ошибка: тангенс не существует");
                return double.NaN;
            }
            double angleInRadians = Math.PI * operand / 180;
            return Math.Round(Math.Tan(angleInRadians), 6);
        }
    }

    class ArcSin : UnaryOperation
    {
        public override string Operator { get; } = "arcsin";
        public override double Execute(double operand)
        {
            double angleInRadians = Math.Asin(operand);
            return Math.Round(180 * angleInRadians / Math.PI, 6);
        }
    }

    class ArcCos : UnaryOperation
    {
        public override string Operator { get; } = "arccos";
        public override double Execute(double operand)
        {
            double angleInRadians = Math.Acos(operand);
            return Math.Round(180 * angleInRadians / Math.PI, 6);
        }
    }

    class ArcTan : UnaryOperation
    {
        public override string Operator { get; } = "arctg";
        public override double Execute(double operand)
        {
            double angleInRadians = Math.Atan(operand);
            return Math.Round(180 * angleInRadians / Math.PI, 6);
        }
    }

    class Logarithm : BinaryOperation
    {
        public override string Operator { get; } = "log";
        public override double Execute(double firstOperand, double secondOPerand)
        {
            if (firstOperand <= 0 || secondOPerand <= 0 || secondOPerand == 1)
            {
                Console.WriteLine("Ошибка: некорректные аргументы");
                return double.NaN;
            }
            return Math.Log(firstOperand, secondOPerand);
        }   
    }

    class NaturalLogarithm : UnaryOperation
    {
        public override string Operator { get; } = "ln";
        public override double Execute(double operand)
        {
            if (operand <= 0)
            {
                Console.WriteLine("Ошибка: некорректный аргумент");
                return double.NaN;
            }
            return Math.Log(operand);
        }
    }

    class DecimalLogarithm : UnaryOperation
    {
        public override string Operator { get; } = "lg";

        public override double Execute(double operand)
        {
            if (operand <= 0)
            {
                Console.WriteLine("Ошибка: некорректный аргумент");
                return double.NaN;
            }
            return Math.Log10(operand);
        }
    }
    

}