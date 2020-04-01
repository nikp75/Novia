using Test.Charges;

namespace Test.Interfaces
{
    public interface IChargeCalculator
    {
        decimal Calculate(BaseStay stayBeingChargedFor);
    }
}
