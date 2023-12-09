namespace Magcdev.AdventOfCode.test;

public class UnitTest2
{

    [Fact]
    public void Test1()
    {
        Day02 day02 = new Day02("input.txt");
        string result = day02.Part1();
        Console.WriteLine(result);
        // Method intentionally left empty.
    }

    [Fact]
    public void Test2()
    {
        Day02 day02 = new Day02("input.txt");
        string result = day02.Part2();
        Console.WriteLine(result);
    }


}
