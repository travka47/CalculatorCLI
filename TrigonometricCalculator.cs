using Operations;
class TrigonometricCalculator : Calculator
{
    public TrigonometricCalculator(){
        operations = new Operation[] {
            new Sin(),
            new Cos(),
            new Tan(),
            new ArcSin(),
            new ArcCos(),
            new ArcTan(),
        };
    }

}