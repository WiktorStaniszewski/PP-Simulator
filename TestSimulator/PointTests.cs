using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void DefaultValue_ReturnsCorrectValues()
    {
        Point point = new();
        Assert.Equal(0, point.X);
        Assert.Equal(0, point.Y);
    }
    [Theory]
    [InlineData(1, 2, "(1, 2)")]
    [InlineData(5, 14, "(5, 14)")]
    public void ToString_ReturnsCorrectValue(int x, int y, string expected)
    {
        Point point = new(x, y);
        Assert.Equal(expected, point.ToString());
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 8, Direction.Left, -1, 8)]
    [InlineData(19, 10, Direction.Right, 20, 10)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    public void Next_ReturnsCorrectValues(int x, int y, Direction direction, int xpected, int ypected)
    {
        Point point = new(x, y);
        Point next_point = point.Next(direction);
        Point expectedPoint = new(xpected, ypected);
        Assert.Equal(next_point, expectedPoint);
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 8, Direction.Left, -1, 9)]
    [InlineData(19, 10, Direction.Right, 20, 9)]
    [InlineData(-1, -1, Direction.Up, 0, 0)]
    public void NextDiagonal_ReturnsCorrectValues(int x, int y, Direction direction, int xpected, int ypected)
    {
        Point point = new(x, y);
        Point next_point = point.NextDiagonal(direction);
        Point expectedPoint = new(xpected, ypected);
        Assert.Equal(next_point, expectedPoint);
    }
}
