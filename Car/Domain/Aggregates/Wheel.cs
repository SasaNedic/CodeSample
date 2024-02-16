namespace Car.Domain.Aggregates
{
    public class Wheel
    {
        public WheelLocation WheelLocation { get; private set; }
        // ich wuerde die Bezeichnungen auf diese Art und Weise nicht als strings speichern und benutzen. Enums sind dafuer viel besser
        // die Bezeichnung wurde eingebaut weil das so in der Anforderung stand
        public string Bezeichnung { get; private set; } = string.Empty;
        public Wheel(WheelLocation wheelLocation)
        {
            WheelLocation = wheelLocation;
            switch (wheelLocation)
            {
                // Die bezeichnungen wuerde man idealerweise in localasationsresources packen 
                case WheelLocation.VorneRechts: Bezeichnung = "Vorne rechts"; break;
                case WheelLocation.VorneLinks: Bezeichnung = "Vorne links"; break;
                case WheelLocation.HintenRechts: Bezeichnung = "Hinten rechts"; break;
                case WheelLocation.HintenLinks: Bezeichnung = "Hinten links"; break;
                default:
                    throw new ArgumentException("Die uebergebene WheelLocation ist nicht valide");
            }
        }
    }
}
