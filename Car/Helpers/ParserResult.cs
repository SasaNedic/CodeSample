using Car.Domain.Aggregates;

namespace Car.Helpers
{
    public class ParserResult
    {
        public CarMarke Marke { get; set; }
        public int Jahrgang { get; set; }

        public ParserResult(CarMarke marke, int jahrgang)
        {
            Marke = marke;
            Jahrgang = jahrgang;
        }
    }
}
