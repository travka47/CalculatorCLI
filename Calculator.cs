using Operations;
class Calculator
{
    public Operation[] operations {get; set;}

    public Calculator() {
        operations = new Operation[] {
            new Addition(),
            new Subtraction(),
            new Division(),
            new Multiplication(),
        };
    }

    protected string[] GetOperators()
    {
        return operations.Select(operation => operation.Operator).ToArray();
    }

    public void Run()
    {
        Console.WriteLine("Доступные операции: " + string.Join(", ", GetOperators()));
        Console.WriteLine("Для завершения программы введите 'exit'");

        double firstOperand, secondOperand, result;
        Operation operation;

        firstOperand = GetOperand("первый");

        while (true)
        {
            operation = GetOperation();

            if (operation is BinaryOperation)
            {
                secondOperand = GetOperand("второй");
                result = (operation as BinaryOperation)!.Execute(firstOperand, secondOperand);
            }
            else
            {
                result = (operation as UnaryOperation)!.Execute(firstOperand);
            }

            if (result is not double.NaN)
            {
                Console.WriteLine("Результат: " + result);
                firstOperand = result;
            }
        }
    }

    protected static void KillProcessIfExit(string input)
    {
        if (input.ToLower() == "exit")
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }

    protected static double GetOperand(string operandIndex)
    {
        double operand = double.NaN;
        string input;

        do
        {
            Console.Write("Введите " + operandIndex + " операнд: ");
            input = Console.ReadLine()!;

            try
            {
                operand = double.Parse(input);
            }
            catch (FormatException)
            {
                KillProcessIfExit(input);
                Console.WriteLine("Ошибка: некорректное число");
            }
            
        } while (operand is double.NaN);

        return operand;
    }

    protected Operation GetOperation()
    {
        string input;

        do
        {
            Console.Write("Введите операцию: ");
            input = Console.ReadLine()!;

            foreach (Operation operation in operations)
            {
                if (operation.Operator == input)
                {
                    return operation;
                }
            }
            
            KillProcessIfExit(input);
            Console.WriteLine("Ошибка: выберите операцию из списка: " + string.Join(", ", GetOperators()));

        } while (true);
    }

}
