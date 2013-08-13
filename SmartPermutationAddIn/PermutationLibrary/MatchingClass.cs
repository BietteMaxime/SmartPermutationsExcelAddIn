using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationLibrary
{
    public class MatchingClass
    {
        public string MatchingClassCodename { get; private set; }
        public RuleSet Rules { get; private set; }

        public MatchingClass(string matchingClassCodename, string[] rules, List<string[]> possibleValues)
        {
            MatchingClassCodename = matchingClassCodename;
            Rules = new RuleSet(rules, possibleValues);
        }

        public List<string[]> ComputePermutationMatrix()
        {
            List<string[]> matrix = new List<string[]>();
            foreach ( List<string[]> permutationList in Rules.GeneratePermutationsLists() )
            {
                var pseusoMatrix = PermutationHelper.DoPermutations(permutationList);
                foreach (string[] row in pseusoMatrix)
                {
                    string[] rowWithMatchingClassCodename =  new string[row.Length+1];
                    rowWithMatchingClassCodename[0] = MatchingClassCodename;
                    for (int i = 1; i < rowWithMatchingClassCodename.Length; i++)
                    {
                        rowWithMatchingClassCodename[i] = row[i - 1];
                    }
                    matrix.Add(rowWithMatchingClassCodename);
                }
            }
            return matrix;
        }
    }
}
