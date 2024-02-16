using Car;
using Car.Domain;
using Car.Domain.Aggregates;
using Car.Domain.Aggregates.SubTypes;
using Car.Helpers;

namespace CarTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(CarMarke.Ford)]
        [TestCase(CarMarke.VW)]
        public void AnyCarMustHave4SpecificWheels(CarMarke carMarke)
        {
            var car = CarFactory.CreateCar(carMarke, 1980);
            Assert.That(car.Raeder.Count(), Is.EqualTo(4));
            Assert.IsTrue(car.Raeder.Any(x => x.WheelLocation == WheelLocation.VorneRechts && x.Bezeichnung == "Vorne rechts"));
            Assert.IsTrue(car.Raeder.Any(x => x.WheelLocation == WheelLocation.VorneLinks && x.Bezeichnung == "Vorne links"));
            Assert.IsTrue(car.Raeder.Any(x => x.WheelLocation == WheelLocation.HintenRechts && x.Bezeichnung == "Hinten rechts"));
            Assert.IsTrue(car.Raeder.Any(x => x.WheelLocation == WheelLocation.HintenLinks && x.Bezeichnung == "Hinten links"));
        }

        [Test]
        public void CarSpeedCorrectVW()
        {
            var car = CarFactory.CreateCar(CarMarke.VW, 1980);
            Assert.That(car.MaxSpeed == CarVw.ConstForMaxSpeed);
        }

        [Test]
        public void CarSpeedCorrectFord()
        {
            var car = CarFactory.CreateCar(CarMarke.Ford, 1980);
            Assert.That(car.MaxSpeed == CarFord.ConstForMaxSpeed);
        }

        [Test]
        public void CarStringForOutputTest()
        {
            var car = CarFactory.CreateCar(CarMarke.Ford, 2020);
            Assert.That(car.GetStringForOutput() == $"{car.Marke}, {car.Jahrgang}, {car.MaxSpeed}");
        }

        [Test]
        public void CarStockCanAdd()
        {
            CarStock carStock = new CarStock();
            var car1 = CarFactory.CreateCar(CarMarke.Ford, 1970);
            var car2 = CarFactory.CreateCar(CarMarke.VW, 1990);
            Assert.IsTrue(carStock.GetAllCars().Count() == 0);
            carStock.AddCar(car1);
            carStock.AddCar(car2);
            Assert.IsTrue(carStock.GetAllCars().Count() == 2);
        }

        [Test]
        public void CarStockErrorOnAddingNull()
        {
            CarStock carStock = new CarStock();
            Car.Domain.Aggregates.Car car = CarFactory.CreateCar(CarMarke.Ford, 1970);
            try
            {
                carStock.AddCar(null);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }

        [TestCase("ford, 2000")]
        public void InputParserCorrectTestFord(string input)
        {
            var result = InputParser.ParseInput(input);
            Assert.IsTrue(result.Marke == CarMarke.Ford);
            Assert.IsTrue(result.Jahrgang == 2000);
        }

        [TestCase("vw, 2000")]
        [TestCase("volkswagen, 2000")]
        public void InputParserCorrectTestVW(string input)
        {
            var result = InputParser.ParseInput(input);
            Assert.IsTrue(result.Marke == CarMarke.VW);
            Assert.IsTrue(result.Jahrgang == 2000);
        }

        [TestCase("for, 2000")]
        [TestCase("volkswagen, ")]
        [TestCase(", 2000")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("vw, 2000,")]
        [TestCase("ford, 20b0")]
        public void InputParserErrorTests(string input)
        {
            try
            {
                var result = InputParser.ParseInput(input);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CarFactoryError()
        {
            CarMarke marke = (CarMarke)(-1);
            try
            {
                CarFactory.CreateCar(marke, 2020);
                Assert.Fail();
            }catch
            { 
                Assert.Pass(); 
            }
        }

        public void WheelCreationError()
        {
            WheelLocation location = (WheelLocation)(-1);
            try
            {
                var wheel = new Wheel(location);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}