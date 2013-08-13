using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationLibrary;

namespace TestPermutationLibrary
{
    [TestClass]
    public class UnitTestPermutationHelper
    {
        [TestMethod]
        public void TestPermutation()
        {
            var possibleValues = new List<string[]> { new string[] { "Rule1Val1", "Rule1Val2", "Rule1Val3", "Rule1Val4" }, new string[] { "Rule2Val1", "Rule2Val2" } };
            var expected = new List<string[]> { new string[] { "Rule1Val1", "Rule2Val1" }, new string[] { "Rule1Val2", "Rule2Val1" },
                                                new string[] { "Rule1Val3", "Rule2Val1" }, new string[] { "Rule1Val4", "Rule2Val1" }, 
                                                new string[] { "Rule1Val1", "Rule2Val2" }, new string[] { "Rule1Val2", "Rule2Val2" },
                                                new string[] { "Rule1Val3", "Rule2Val2" }, new string[] { "Rule1Val4", "Rule2Val2" } };
            var output = PermutationHelper.DoPermutations(possibleValues);
            Assert.AreEqual(expected.Count, output.Count);
            for (int i = 0; i < output.Count; i++)
            {
                Assert.IsTrue(output[i].All(x => expected[i].Contains(x)),string.Format("Output is not the same for row number {0}",i));
            }
        }
    }
}
