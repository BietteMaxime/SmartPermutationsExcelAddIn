using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationLibrary;
using PermutationLibrary.Rules;

namespace TestPermutationLibrary
{
    [TestClass]
    public class UnitTestMatchingClass
    {
        [TestMethod]
        public void TestBenefitClassMatrixGen()
        {
            var matchingClassCodename = "MatchingClassTest";
            var rules = new string[] { "IN('Rule1Val1','Rule1Val2','Rule1Val3')", " ALL" };
            var possibleValues = new List<string[]> { new string[] { "Rule1Val1", "Rule1Val2", "Rule1Val3" }, new string[] { "Rule2Val1", "Rule2Val2" } };
            var matchingClass = new MatchingClass(matchingClassCodename, rules, possibleValues);

            var output = matchingClass.ComputePermutationMatrix();
            var expected = new List<string[]>() {   new string[] { "MatchingClassTest", "Rule1Val1", "*" },
                                                    new string[] { "MatchingClassTest", "Rule1Val2", "*" },
                                                    new string[] { "MatchingClassTest", "Rule1Val3", "*" } };
            Assert.AreEqual(expected.Count, output.Count);
            for (int i = 0; i < output.Count; i++)
            {
                Assert.IsTrue(output[i].All(x => expected[i].Contains(x)), string.Format("Output is not the same for row number {0}", i));
            }
        }
    }
}
