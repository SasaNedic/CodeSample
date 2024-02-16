namespace Car.Domain.Aggregates
{
    public class Car
    {
        public CarMarke Marke { get; private set; }
        public int Jahrgang { get; private set; }
        public int MaxSpeed { get; private set; }
        // weil es nicht ganz spezifiziert wurde ob wir nach dem initialisieren weniger/mehr Raeder haben duerfen, wird mit IReadOnlyList sichergestellt das niemand etwas entfernen/eingeben kann
        public IReadOnlyList<Wheel> Raeder { get; private set; }

        protected Car(CarMarke marke, int jahrgang)
        {
            Marke = marke;
            Jahrgang = jahrgang;
            // Hier koennte man eine Abfrage auf die Marke machen und das MaxSpeed setzen mit einem switch case
            // Weil wir hier nur MaxSpeed setzen und nicht viel anderes pruefen, ist es vielleicht overkill mit Subtypes und einer Factory oder Strategies zu arbeiten
            // Bei mehreren Properties und mehreren Marken die alle ihre eigenen Anforderungen haben, ist es leichter das auf mehrere Klassen aufzuteilen wie hier gemacht wurde.
            Raeder = new List<Wheel>() { new Wheel(WheelLocation.VorneRechts), new Wheel(WheelLocation.VorneLinks), new Wheel(WheelLocation.HintenRechts), new Wheel(WheelLocation.HintenLinks) };
        }

        public string GetStringForOutput()
        {
            return $"{Marke}, {Jahrgang}, {MaxSpeed}";
        }

        protected void SetMaxSpeed(int speed)
        {
            MaxSpeed = speed;
        }
    }
}
