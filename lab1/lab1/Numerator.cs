namespace lab1;

internal class RationalNumbers
{
    public RationalNumbers(int numerator, int denominator)
    {
        var gcd = GCD(numerator, denominator);

        if (denominator == 0) throw new Exception("Деление на 0");
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public int Numerator { get; }

    public int Denominator { get; }


    public override string ToString()
    {
        return Convert.ToString(Numerator) + "/" + Convert.ToString(Denominator);
    }

    public static RationalNumbers operator +(RationalNumbers counter1, RationalNumbers counter2)
    {
        return new RationalNumbers(
            counter1.Numerator * counter2.Denominator + counter2.Numerator * counter1.Denominator,
            counter1.Denominator * counter2.Denominator);
    }

    public static RationalNumbers operator -(RationalNumbers counter1, RationalNumbers counter2)
    {
        var num = counter1.Numerator * counter2.Denominator - counter2.Numerator * counter1.Denominator;
        var den = counter1.Denominator * counter2.Denominator;
        var gcd = GCD(num, den);
        num = num / gcd;
        den = den / gcd;
        return new RationalNumbers(num, den);
    }

    public static bool operator ==(RationalNumbers a, RationalNumbers b)
    {
        return a.Denominator == b.Denominator && a.Denominator == b.Denominator;
    }

    public static bool operator !=(RationalNumbers a, RationalNumbers b)
    {
        return !(a == b);
    }

    public static bool operator <(RationalNumbers a, RationalNumbers b)
    {
        return a.Numerator / a.Denominator < b.Numerator / b.Denominator;
    }

    public static bool operator >(RationalNumbers a, RationalNumbers b)
    {
        return a.Numerator / a.Denominator > b.Numerator / b.Denominator;
    }

    public static RationalNumbers operator -(RationalNumbers a)
    {
        return new RationalNumbers(-a.Numerator, a.Denominator);
    }

    private static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}