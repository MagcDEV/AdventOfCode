using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Magcdev.AdventOfCode.test;

public class Day03 : AoCSolution
{
    public Day03(string filename) : base(2023, 03, filename)
    {

    }

    public Day03(AoCFileType filetype) : base(2023, 03, filetype)
    {

    }

    public override string Part1()
    {

        List<int> partsNumbers = [];
        List<string> inputList = [.. Input.Split(Environment.NewLine)];
        // The regex pattern to match numbers
        string pattern = @"\d+";

        inputList = inputList.Prepend("............................................................................................................................................").ToList();
        inputList.Add("............................................................................................................................................");
        string baseLine = "..............................................................................................................................................";


        for (int i = 1; i < inputList.Count - 1; i++)
        {
            string prevLine = "." + inputList[i - 1] + ".";
            string currentLine = "." + inputList[i] + ".";
            string nextLine = "." + inputList[i + 1] + ".";

            MatchCollection matches = Regex.Matches(currentLine, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Number {match.Value} found at position {match.Index}");

                string x = prevLine.Substring(match.Index - 1, match.Value.Length + 2);
                string y = currentLine.Substring(match.Index - 1, match.Value.Length + 2);
                string z = nextLine.Substring(match.Index - 1, match.Value.Length + 2);

                if (!x.Equals(baseLine.Substring(match.Index - 1, match.Value.Length + 2))
                    || !z.Equals(baseLine.Substring(match.Index - 1, match.Value.Length + 2))
                    || !y.StartsWith('.') || !y.EndsWith('.'))
                {
                    Console.WriteLine(int.Parse(match.Value));
                    partsNumbers.Add(int.Parse(match.Value));
                }

            }

            Console.WriteLine($"Number of parts: {partsNumbers.Sum()}");

        }

        return partsNumbers.Sum().ToString();
    }

    public override string Part2()
    {

        List<string> lines = [.. Input.Split(Environment.NewLine)];

        var lineLength = lines[0].Length;
        var numbersRegex = new Regex(@"\d+");

        var numbers = lines.SelectMany(
            (line, lineNumber) => numbersRegex.Matches(line)
            .Select(x => new
            {
                Value = int.Parse(x.Value),
                LineNumber = lineNumber,
                StartIndex = x.Index,
                x.Length,
                EndIndex = x.Index + x.Length
            })
        );

        foreach (var number in numbers)
        {

            // Build line scan range
            var start = Math.Clamp(number.StartIndex - 1, 0, lineLength);
            var end = Math.Clamp(number.EndIndex + 1, 0, lineLength);
            var length = end - start;

            Console.WriteLine(number);

        }

        Console.WriteLine(numbers);

        numbers.ToList().ForEach(x => { });



        return "returned";
    }
}
