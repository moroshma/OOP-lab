using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab1.Tests;

[TestClass]
[TestSubject(typeof(RationalNumbers))]
public class RationalNumbersTest
{
    [TestMethod]
    public void ToStringTest()
    {
        var rn = new RationalNumbers(2, 4);
        Assert.IsTrue(rn.ToString() == "1/2");
    }

    [TestMethod]
    public void ConstructExp()
    {
        try
        {
            var rn = new RationalNumbers(1, 0);
        }
        catch (Exception ex)
        {
            Assert.IsTrue(true);
        }
    }

    [TestMethod]
    public void Construct()
    {
        var r = new RationalNumbers(2, 4);
        Assert.IsTrue(r.Numerator == 1 && r.Denominator == 2);

        var t3 = new RationalNumbers(1, 2);
        Assert.IsTrue(t3.Numerator == 1 && t3.Denominator == 2);
    }

    [TestMethod]
    public void Sum()
    {
        var num1 = new RationalNumbers(1, 2);
        var num2 = new RationalNumbers(2, 9);
        var num3 = new RationalNumbers(13, 18);
        Assert.IsTrue(num1 + num2 == num3);
    }

    [TestMethod]
    public void Div()
    {
        var num1 = new RationalNumbers(1, 2);
        var num2 = new RationalNumbers(2, 9);
        var num3 = new RationalNumbers(5, 18);
        Assert.IsTrue(num1 - num2 == num3);
    }

    [TestMethod]
    public void Equal()
    {
        var num1 = new RationalNumbers(1, 2);
        var num2 = new RationalNumbers(1, 2);
        Assert.IsTrue(num1 == num2);
    }

    [TestMethod]
    public void NotEqual()
    {
        var num1 = new RationalNumbers(1, 2);
        var num2 = new RationalNumbers(1, 3);
        Assert.IsTrue(num1 != num2);
    }
}