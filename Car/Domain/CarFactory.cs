using Car.Domain.Aggregates;
using Car.Domain.Aggregates.SubTypes;

namespace Car.Domain
{
    public class CarFactory
    {
        public static Aggregates.Car CreateCar(CarMarke carMarke, int jahrgang)
        {
            switch (carMarke)
            {
                case CarMarke.Ford: return new CarFord(jahrgang);
                case CarMarke.VW: return new CarVw(jahrgang);
                default:
                    throw new ArgumentException($"Die eingegebene Automarke wird im System nicht unterstuetzt");
            }
        }
    }
}
