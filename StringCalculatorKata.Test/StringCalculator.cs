namespace StringCalculatorKata.Test
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var parts = numbers.Split(',');
            var result = 0;
            var negatives = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (number < 0)
                        negatives.Add(number);
                    else if (number <= 1000)
                        result += number;
                }
            }

            if (negatives.Count > 0)
            {
                var negativesList = string.Join(',', negatives);
                throw new ArgumentException($"Negative numbers not allowed: {negativesList}.");
            }

            return result;
        }
    }

}