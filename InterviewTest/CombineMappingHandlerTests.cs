using NUnit.Framework;
using System;

namespace Interview.UnitTest
{
    [TestFixture]
    public class CombineMappingHandlerTests
    {
        IMappingHandler _mappingHandler;

        [SetUp]
        public void Setup()
        {
            IDataSource datasource = new LocalDataSource();
            _mappingHandler = new CombineMappingHandler(datasource);
        }

        [Test]
        public void IsValidInput_InputNothing_ArgumentNullException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => { _mappingHandler.IsValidInput(); });

            StringAssert.Contains("the input data can not be null", ex.Message);
        }

        [TestCase(-1, 2, 3)]
        public void IsValidInput_InputContainsLessThan0_ArgumentOutOfRangeException(params int[] input)
        {
            var ex = Assert.Catch<ArgumentOutOfRangeException>(() => { _mappingHandler.IsValidInput(input); });

            StringAssert.Contains("the input data must between 0 and 9", ex.Message);
        }

        [TestCase(2, 3, 10)]
        public void IsValidInput_InputContainsGreatThan9_ArgumentOutOfRangeException(params int[] input)
        {
            var ex = Assert.Catch<ArgumentOutOfRangeException>(() => { _mappingHandler.IsValidInput(input); });

            StringAssert.Contains("the input data must between 0 and 9", ex.Message);
        }

        [TestCase(-1, 2, 3, 10)]
        public void IsValidInput_InputContainsGreatThan9AndLessThan0_ArgumentOutOfRangeException(params int[] input)
        {
            var ex = Assert.Catch<ArgumentOutOfRangeException>(() => { _mappingHandler.IsValidInput(input); });

            StringAssert.Contains("the input data must between 0 and 9", ex.Message);
        }

        [TestCase(0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void IsValidInput_InputBetween0And9_ReturnsTrue(params int[] input)
        {
            Assert.IsTrue(_mappingHandler.IsValidInput(input));
        }

        [TestCase(0)]
        public void Mapping_Input0_ReturnsEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsEmpty(result);
        }

        [TestCase(1)]
        public void Mapping_Input1_ReturnsEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsEmpty(result);
        }

        [TestCase(0, 1)]
        public void Mapping_Input0And1_ReturnsEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsEmpty(result);
        }

        [TestCase(2)]
        public void Mapping_InputOneWithout0And1_ReturnsNotEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [TestCase(2, 3)]
        [TestCase(9, 3, 2)]
        public void Mapping_InputManyWithout0And1_ReturnsNotEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [TestCase(0, 2)]
        [TestCase(9, 0)]
        [TestCase(9, 1)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 0, 1, 3)]
        public void Mapping_InputManyWith0Or1_ReturnsNotEmpty(params int[] input)
        {
            var result = _mappingHandler.Mapping(input);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }
    }
}
