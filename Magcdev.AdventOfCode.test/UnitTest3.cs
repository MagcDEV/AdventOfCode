namespace Magcdev.AdventOfCode.test;

public class UnitTest3
{

    [Fact]
    public void Test1()
    {
        Day03 day03 = new Day03("input.txt");
        string result = day03.Part1();
        Console.WriteLine(result);
        // Method intentionally left empty.
    }

    [Fact]
    public void Test2()
    {
        Day03 day03 = new Day03("test.txt");
        string result = day03.Part2();
        Console.WriteLine(result);
    }


}
