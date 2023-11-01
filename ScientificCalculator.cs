using Operations;
class ScientificCalculator : Calculator
{
    public ScientificCalculator(){
        operations = new Operation[] {
            new Addition(),
            new Subtraction(),
            new Division(),
            new Multiplication(),
            new Percentage(),
            new SquareRoot(),
            new Power(),
            new Exponent(),
        };
    }

}