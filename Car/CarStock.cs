namespace Car
{
    public class CarStock
    {
        // Hier koennten wir vieles fuer Caching benutzen, wie z.B die MemoryCache class von Microsoft.Extensions.Caching.Memory, oder von System.Runtime.Caching
        // weil wir hier aber nur etwas kleines machen, reicht auch eine Liste
        private IList<Domain.Aggregates.Car> cars;

        public CarStock()
        {
            cars = new List<Domain.Aggregates.Car>();
        }

        public void AddCar(Domain.Aggregates.Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException($"Ein Car object darf nicht null sein");
            }
            
            cars.Add(car);
        }

        public List<Domain.Aggregates.Car> GetAllCars()
        {
            return cars.ToList();
        }
    }
}
