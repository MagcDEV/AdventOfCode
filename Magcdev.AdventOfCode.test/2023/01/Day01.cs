namespace Magcdev.AdventOfCode.test;

public class Day01 : AoCSolution
{

    public Day01(string filename) : base(2023, 01, filename)
    {

    }

    public Day01(AoCFileType filetype) : base(2023, 01, filetype)
    {

    }

    public override string Part1()
    {

        int count = 0;
        string numero = "";

        Input.Split(Environment.NewLine).ToList().ForEach(x =>
        {
            numero = "";

            x.ToCharArray().ToList().ForEach(y =>
            {
                if (int.TryParse(y.ToString(), out int _))
                {
                    numero += y;
                }
            });

            if (numero.Length >= 1)
            {
                numero = numero.ToCharArray().AsEnumerable().First().ToString() + numero.ToCharArray().AsEnumerable().Last().ToString();
            }

            if (int.TryParse(numero, out int n))
            {
                count += n;
            }

        });

        return count.ToString();

    }

    public override string Part2()
    {
        Dictionary<string, string> numerosDeMierda = new Dictionary<string, string>
        {
            { "one", "1e" },
            { "two", "2o" },
            { "three", "3e" },
            { "four", "4r" },
            { "five", "5e" },
            { "six", "6x" },
            { "seven", "7n" },
            { "eight", "8t" },
            { "nine", "9e" }
        };

        string[] oldNumbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        int count = 0;
        string numero = "";

        Input.Split(Environment.NewLine).ToList().ForEach(x =>
        {
            int[] newNumbers = [];
            numero = "";

            oldNumbers.ToList().ForEach(y =>
            {

                newNumbers = newNumbers.Append(x.IndexOf(y)).ToArray();

            });

            Array.Sort(newNumbers, oldNumbers);

            oldNumbers.ToList().ForEach(y =>
            {
                x = x.Replace(y, numerosDeMierda[y]);

            });


            x.ToCharArray().ToList().ForEach(y =>
            {
                if (int.TryParse(y.ToString(), out int _))
                {
                    numero += y;
                }
            });

            if (numero.Length >= 1)
            {
                numero = numero.ToCharArray().AsEnumerable().First().ToString() + numero.ToCharArray().AsEnumerable().Last().ToString();
            }

            if (int.TryParse(numero, out int n))
            {
                count += n;
            }

        });

        Console.WriteLine(count);

        return count.ToString();
    }
}
