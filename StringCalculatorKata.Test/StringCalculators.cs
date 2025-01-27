namespace StringCalculatorKata.Test
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(string.Empty));
        }

        [Test]
        public void Add_SingleNumber_ReturnsItsValue()
        {
            Assert.AreEqual(5, StringCalculator.Add("5"));
        }

        [Test]
        public void Add_TwoNumbersSeparatedByComma_ReturnsTheirSum()
        {
            Assert.AreEqual(15, StringCalculator.Add("7,8"));
        }

        [Test]
        public void Add_ThreeNumbersSeparatedByComma_ReturnsTheirSum()
        {
            Assert.AreEqual(6, StringCalculator.Add("1,2,3"));
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("8,7,20", 35)]
        [TestCase("5,0,4,1001", 9)]
        [TestCase("5,0,4,1000", 1009)]
        [TestCase("26,6,90", 122)]
        public void Add_MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum(string input, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(input));
        }

        [TestCase("1,2,3,4,5,-5")]
        [TestCase("-1,1,2,9")]
        [TestCase("5,6,8,-5")]
        public void Add_StringContainingNegativeNumbers_Throws(string numbers)
        {
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
            StringAssert.StartsWith("Negative numbers not allowed:", ex.Message);
        }
    }

}