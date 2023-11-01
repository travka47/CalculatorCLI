class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип калькулятора:");
        Console.WriteLine("'0' - Базовый калькулятор");
        Console.WriteLine("'1' - Инженерный калькулятор");
        Console.WriteLine("'2' - Тригонометрический калькулятор");
        Console.WriteLine("'3' - Логарифмический калькулятор");

        while (true)
        {
            switch (Console.ReadLine())
            {
                case "0": 
                    new Calculator().Run();
                    break;
                case "1": 
                    new ScientificCalculator().Run();
                    break;
                case "2": 
                    new TrigonometricCalculator().Run();
                    break;
                case "3": 
                    new LogarithmicCalculator().Run();
                    break;
                default:
                    Console.WriteLine("Ошибка: введите значение из списка");
                    break;
            }
        }
    }
}
