using System.Net;

namespace Magcdev.AdventOfCode.test;

public class Day02 : AoCSolution
{
    public Day02(string filename) : base(2023, 02, filename)
    {

    }

    public Day02(AoCFileType filetype) : base(2023, 02, filetype)
    {

    }

    public override string Part1()
    {
        List<Tuple<int, string>> gameBallList = new List<Tuple<int, string>>();
        int count = 0;
        int numberOfGame = 0;

        // every iteration is a game : Game 1, Game 2, etc.
        Input.Split(Environment.NewLine).ToList().ForEach(x =>
        {
            bool isPossible = true;
            gameBallList.Clear();
            numberOfGame = numberOfGame + 1;
            Console.WriteLine(x);//"Game 2: 5 blue; 1 red, 3 blue; 1 red, 7 blue, 1 green; 1 red, 8 blue; 7 blue, 1 red; 4 blue, 1 green, 1 red"

            x = x.Substring(x.IndexOf(":") + 1);

            x.Split(";").ToList().ForEach(y =>
            {
                // y for example is y =" 1 red, 3 blue"
                y = y.Trim(); // we remove the leading and traillings blank spaces
                y.Split(",").ToList().ForEach(z =>
                {
                    z = z.Trim();
                    // now here we can create or tuple and add it to the gameBallList our list of touples
                    // list1.Add(Tuple.Create(1, "Alice")); this is the example
                    gameBallList.Add(Tuple.Create(int.Parse(z.Split(" ").AsEnumerable().First().ToString()),
                    z.Split(" ").AsEnumerable().Last().ToString()));
                });
            });

            gameBallList.ForEach(y =>
            {
                switch (y.Item2)
                {
                    case ("red"):
                        if (y.Item1 > 12)
                        {
                            isPossible = false;
                        }
                        break;
                    case ("green"):
                        if (y.Item1 > 13)
                        {
                            isPossible = false;
                        }
                        Console.WriteLine("blue");
                        break;
                    case ("blue"):
                        if (y.Item1 > 14)
                        {
                            isPossible = false;
                        }
                        break;
                    default:
                        break;
                }
            });

            if (isPossible)
            {
                count += numberOfGame;

            }

        });

        return count.ToString();
    }

    public override string Part2()
    {
        List<Tuple<int, string>> gameBallList = new List<Tuple<int, string>>();
        int count = 0;
        int numberOfGame = 0;

        // every iteration is a game : Game 1, Game 2, etc.
        Input.Split(Environment.NewLine).ToList().ForEach(x =>
        {
            gameBallList.Clear();
            numberOfGame = numberOfGame + 1;
            Console.WriteLine(x);//"Game 2: 5 blue; 1 red, 3 blue; 1 red, 7 blue, 1 green; 1 red, 8 blue; 7 blue, 1 red; 4 blue, 1 green, 1 red"

            x = x.Substring(x.IndexOf(":") + 1);

            x.Split(";").ToList().ForEach(y =>
            {
                // y for example is y =" 1 red, 3 blue"
                y = y.Trim(); // we remove the leading and traillings blank spaces
                y.Split(",").ToList().ForEach(z =>
                {
                    z = z.Trim();
                    // now here we can create or tuple and add it to the gameBallList our list of touples
                    // list1.Add(Tuple.Create(1, "Alice")); this is the example
                    gameBallList.Add(Tuple.Create(int.Parse(z.Split(" ").AsEnumerable().First().ToString()),
                    z.Split(" ").AsEnumerable().Last().ToString()));
                });
            });

            int minValueRed = gameBallList.Where(x => x.Item2 == "red").Max(x => x.Item1);
            int minValueGreen = gameBallList.Where(x => x.Item2 == "green").Max(x => x.Item1);
            int minValueBlue = gameBallList.Where(x => x.Item2 == "blue").Max(x => x.Item1);

            count += (minValueRed * minValueGreen * minValueBlue);

        });
        return count.ToString();

    }
}
