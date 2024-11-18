using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(4, 2, 1, 5, 1, 2, 4, 5)]
    public void Rectangle_ReturnsCorrectCoordinates(int x1, int y1, int x2, int y2, int x1fin, int y1fin, int x2fin, int y2fin)
    {
        Rectangle rec_1 = new Rectangle(x1, y1, x2, y2);

        Rectangle rec_2 = new Rectangle(x1fin, y1fin, x2fin, y2fin);

        Assert.Equal(rec_1.X1, rec_2.X1);
        Assert.Equal(rec_1.Y1, rec_2.Y1);
        Assert.Equal(rec_1.X2, rec_2.X2);
        Assert.Equal(rec_1.Y2, rec_2.Y2);

    }
    [Fact]
    public void Constructor_WithReversedCoordinates_ShouldNormalizeCoordinates()
    {
        Rectangle rect = new(5, 7, 2, 3);

        Assert.Equal(2, rect.X1);
        Assert.Equal(3, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(7, rect.Y2);
    }

    [Fact]
    public void Constructor_WithThinRectangle_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(2, 3, 2, 7));
        Assert.Throws<ArgumentException>(() => new Rectangle(2, 3, 5, 3));
    }

    [Fact]
    public void Constructor_WithPoints_ShouldInitializeCorrectly()
    {
        Point p1 = new(2, 3);
        Point p2 = new(5, 7);
        Rectangle rect = new(p1, p2);

        Assert.Equal(2, rect.X1);
        Assert.Equal(3, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(7, rect.Y2);
    }

    [Fact]
    public void Contains_WithPointInside_ShouldReturnTrue()
    {
        Rectangle rect = new(2, 3, 5, 7);
        Point point = new(3, 4);

        Assert.True(rect.Contains(point));
    }

    [Fact]
    public void Contains_WithPointOutside_ShouldReturnFalse()
    {
        Rectangle rect = new(2, 3, 5, 7);
        Point point = new(6, 8);

        Assert.False(rect.Contains(point));
    }

    [Fact]
    public void Contains_WithPointOnBoundary_ShouldReturnTrue()
    {
        Rectangle rect = new(2, 3, 5, 7);

        Assert.True(rect.Contains(new Point(2, 3)));
        Assert.True(rect.Contains(new Point(5, 7)));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        Rectangle rect = new(2, 3, 5, 7);
        string expected = "(2, 3):(5, 7)";

        Assert.Equal(expected, rect.ToString());
    }
}
