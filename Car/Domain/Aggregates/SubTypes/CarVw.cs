namespace Car.Domain.Aggregates.SubTypes
{
    public class CarVw : Car
    {
        public const int ConstForMaxSpeed = 180;

        public CarVw(int jahrgang) : base(CarMarke.VW, jahrgang)
        {
            SetMaxSpeed(ConstForMaxSpeed);
        }
    }
}