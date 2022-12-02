namespace Input
{

    public static class ReadPuzzleInput
    {
        public static string GetFullTextTest(int day)
        {
            // Read the file as one string.
            // NewLine and CrregReturn replkace with "|"
            return System.IO.File.ReadAllText($@"TestInputs\Day{day.ToString("00")}.txt").Replace("\r\n", "|");

        }

        public static string[] GetTextArrayTest(int day)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines($@"TestInputs\Day{day.ToString("00")}.txt");
            return lines;
        }

        public static string GetFullText(int day)
        {
            // Read the file as one string.
            // NewLine and CrregReturn replkace with "|"
            var text =  System.IO.File.ReadAllText($@"Day{day.ToString("00")}.txt").Replace("\r\n", "|");
            return text;

        }

        public static string[] GetTextArray(int day)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines($@"Day{day.ToString("00")}.txt");
            return lines;
        }

    }
}