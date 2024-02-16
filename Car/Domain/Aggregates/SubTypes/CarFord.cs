namespace Car.Domain.Aggregates.SubTypes
{
    public class CarFord : Car
    {
        public const int ConstForMaxSpeed = 250;

        public CarFord(int jahrgang) : base(CarMarke.Ford, jahrgang)
        {
            SetMaxSpeed(ConstForMaxSpeed);
        }
    }
}
