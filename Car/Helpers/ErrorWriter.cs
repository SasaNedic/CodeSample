namespace Car.Helpers
{
    public static class ErrorWriter
    {
        public static void WriteError(Exception ex)
        {
            Console.WriteLine($"Leider ist ein fehler passiert: {ex.Message}\n");
        }
    }
}