using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }
    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void IncorrectSize_ThrowAgumentException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallTorusMap(size));
    }
    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ReturnsCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 20, Direction.Down, 0, 19)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    public void Next_ReturnsTheCorrectPoint(int x, int y,  Direction direction, int xpected, int ypected)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        var expectedPoint = new Point(xpected, ypected);
        Assert.Equal(expectedPoint, nextPoint);
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    public void NextDiagonal_ReturnsTheCorrectPoint(int x, int y, Direction direction, int xpected, int ypected)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        var expectedPoint = new Point(xpected, ypected);
        Assert.Equal(expectedPoint, nextPoint);
    }
}
