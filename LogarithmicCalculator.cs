using Operations;
class LogarithmicCalculator : Calculator
{
    public LogarithmicCalculator(){
        operations = new Operation[] {
            new Logarithm(),
            new NaturalLogarithm(),
            new DecimalLogarithm(),
        };
    }

}