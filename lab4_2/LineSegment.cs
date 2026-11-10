using System;

class LineSegment
{
    private double _x;
    private double _y;

    public LineSegment(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public bool Contains(double value)
    {
        return value >= Math.Min(_x, _y) &&
               value <= Math.Max(_x, _y);
    }

    public static double operator !(LineSegment line)
    {
        return Math.Abs(line._y - line._x);
    }

    public static LineSegment operator ++(LineSegment line)
    {
        return new LineSegment(
            line._x + 1, line._y + 1);
    }

    public static explicit operator int(LineSegment line)
    {
        return (int)line._x;
    }

    public static implicit operator double(LineSegment line)
    {
        return line._y;
    }

    public static LineSegment operator +(
        LineSegment line, int value)
    {
        return new LineSegment(
            line._x + value, line._y + value);
    }

    public static LineSegment operator +(
        int value, LineSegment line)
    {
        return line + value;
    }

    public static bool operator <(
        LineSegment line, int value)
    {
        return line.Contains(value);
    }

    public static bool operator >(
        LineSegment line, int value)
    {
        return !line.Contains(value);
    }

    public override string ToString()
    {
        return "[" + _x + "; " + _y + "]";
    }
}