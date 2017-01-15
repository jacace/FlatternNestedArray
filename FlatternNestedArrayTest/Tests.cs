using FlatternNestedArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace FlatternNestedArrayTest
{
    [TestClass]
    public class Tests
    {

        /// <summary>
        /// Function to test the happy path :)
        /// </summary>
        /// <param name="a">First element in the input nested array</param>
        /// <param name="b">Second element in the input nested array</param>
        /// <param name="c">Third element in the input nested array</param>
        /// <param name="d">Fourth element in the input nested array</param>
        [TestMethod]
        [Test]
        [TestCase(1, 2, 3, 4)]        
        public void TestHappyPath(int a, int b, int c, int d)
        {
            IArrayElement nestedArr = new ArrElement(new IntElement[] { new IntElement(c) });
            int[] outputArr = NegativeTestWithFourParams(a, b, nestedArr, d);
            NUnit.Framework.Assert.IsTrue(outputArr != null && outputArr[0] == a && outputArr[1] == b && outputArr[2] == c && outputArr[3] == d);
        }

        /// <summary>
        /// Function with multiple negative test cases
        /// </summary>
        [TestMethod]
        [Test]
        [TestCase(1, 2, null, 4)]
        [TestCase(1, 2, "Negative Test", 4)]
        [TestCase(1, 2, new int[] { }, 4)]
        [TestCase(1, 2, new string[] { "Negative Test" }, 4)]
        [TestCase(1, 2, new object[] { new int[] { 3 } }, 4)]
        public int[] NegativeTestWithFourParams(int a, int b, IArrayElement c, int d)
        {
            if (c == null || c.GetType() != typeof(ArrElement))
            {
                NUnit.Framework.Assert.Fail();
                return null;
            }

            IArrayElement[] nestedArr = new IArrayElement[3];
            nestedArr[0] = new IntElement(a);
            nestedArr[1] = new IntElement(b);
            nestedArr[2] = c;
            ArrElement innerArr = new ArrElement(nestedArr);

            IArrayElement[] outerArr = new IArrayElement[2];
            outerArr[0] = innerArr;
            outerArr[1] = new IntElement(d);
            int[] outputArr = NestedArray.Flattern(outerArr);

            NUnit.Framework.Assert.IsTrue(outputArr != null && outputArr[0] == a && outputArr[1] == b && outputArr[3] == d);
            return outputArr;
        }


        /// <summary>
        /// Test Cases to perform negative testing
        /// </summary>
        /// <param name="innerArr">First object</param>
        /// <param name="num">Second number</param>
        [TestMethod]
        [Test]
        [TestCase(null, 4)]
        [TestCase("Negative test", 4)]
        public void NegativeTestWithTwoParams(ArrElement innerArr, int d)
        {
            if (innerArr == null || innerArr.GetType() != typeof(ArrElement))
            {
                NUnit.Framework.Assert.Fail();
                return;
            }

            IArrayElement[] outerArr = new IArrayElement[2];
            outerArr[0] = innerArr;
            outerArr[1] = new IntElement(d);

            int[] outputArr = NestedArray.Flattern(outerArr);
            NUnit.Framework.Assert.IsTrue(outputArr != null && outputArr[3] == d);
        }
    }
}
