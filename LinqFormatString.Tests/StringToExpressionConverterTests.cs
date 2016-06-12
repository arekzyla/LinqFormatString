using NUnit.Framework;
using System;

namespace LinqFormatString.Tests
{
    [TestFixture]
    public class StringToExpressionConverterTests
    {
        [TestCase("aaaaaaaa", ExpectedResult = "aaaaaaaa")]
        public string ShouldFormatStringCorrectly(string given)
        {
            return StringToExpressionConverter.Convert(given).Compile().Invoke();
        }

        [TestCase("{0}", "11", ExpectedResult = "11")]
        [TestCase("aaa{0}aaa", "11", ExpectedResult = "aaa11aaa")]
        [TestCase("{0}aaaaaa", "22", ExpectedResult = "22aaaaaa")]
        [TestCase("aaaaaa{0}", "22", ExpectedResult = "aaaaaa22")]
        [TestCase("{0}aaaa{0}", "22", ExpectedResult = "22aaaa22")]
        public string ShouldFormatStringCorrectly(string given, object arg)
        {
            return StringToExpressionConverter.Convert<object>(given).Compile().Invoke(arg);
        }

        [TestCase("{0}, {1}, {2}, {0}", "Aaa", "Bbbb", "Ccccc", ExpectedResult = "Aaa, Bbbb, Ccccc, Aaa")]
        [TestCase("{2} {0} {1}", "11", -2, 10, ExpectedResult = "10 11 -2")]
        public string ShouldFormatStringCorrectly(string given, object arg0, object arg1, object arg2)
        {
            return StringToExpressionConverter.Convert<object, object, object>(given).Compile().Invoke(arg0, arg1, arg2);
        }

        [TestCase("{0}, {2}, {3}")]
        [TestCase("{1}, {2}, {3}")]
        public void ShouldThrowExceptionIfPlaceholderOrderIsWrong(string given)
        {
            Assert.Throws<FormatException>(() => StringToExpressionConverter.Convert<string, string, string>(given));
        }

        [TestCase("{0}, {1}, {2}")]
        public void ShouldThrowExceptionIfNumberOfArgumentsIsWrong(string given)
        {
            Assert.Throws<FormatException>(() => StringToExpressionConverter.Convert<string, string>(given),
                "Provided number of arguments: 2 is wrong. Expected 3 arguments.");

            Assert.Throws<FormatException>(() => StringToExpressionConverter.Convert<string, string, string, string>(given),
                "Provided number of arguments: 4 is wrong. Expected 3 arguments.");
        }
    }
}
