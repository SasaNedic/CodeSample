using Car.Domain.Aggregates;

namespace Car.Helpers
{
    public class InputParser
    {
        // hier habe ich mich fuer ein Tuple entschieden weil wir mit sehr kleinen Objekten arbeiten, idealerweise wuerde man hier eine result klasse benutzen.
        public static ParserResult ParseInput(string? userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                throw new Exception($"Die eingabe war leer");
            }

            CarMarke markeInput;
            int jahrgangInput;

            string[] inputs = userInput.Split(",");
            if (inputs.Length != 2 || inputs.Any(x => x == string.Empty))
            {
                throw new Exception("Die Eingabe war nicht in einem validen Format. Bitte Marke und Jahrgang eingeben, getrennt durch ein komma. z.B. \"Ford, 1998\"");
            }

            switch (inputs[0].Trim().ToLower())
            {
                case "vw":
                case "volkswagen":
                    markeInput = CarMarke.VW;
                    break;
                case "ford":
                    markeInput = CarMarke.Ford;
                    break;
                default:
                    throw new Exception($"Die eingegebene Marke {inputs[0]}, wird nicht im System unterstuetzt");
            }

            if (int.TryParse(inputs[1].Trim().ToLower(), out int jahrgangInputParsed))
            {
                jahrgangInput = jahrgangInputParsed;
            }
            else
            {
                throw new Exception($"Der eingegebene Wert fuer den Jahrgang ist felherhaft: {inputs[1]}");
            };

            return new ParserResult(markeInput, jahrgangInput);
        }
    }
}
