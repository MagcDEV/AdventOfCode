namespace Magcdev.AdventOfCode.test;

public class UnitTest1
{

    [Fact]
    public void Test1()
    {

        Day01 day01 = new Day01("input.txt");
        string result = day01.Part1();
        Console.WriteLine(result);
        Assert.True(int.TryParse(result, out _));

    }

    [Fact]
    public void Test2()
    {
        Day01 day01 = new Day01("input.txt");
        string result = day01.Part2();
        Console.WriteLine(result);
        Assert.True(int.TryParse(result, out _));

    }


}
