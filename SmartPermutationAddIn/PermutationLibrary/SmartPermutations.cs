using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationLibrary
{
    public class SmartPermutations
    {
        //public List<string[]> PossibleValues { get; set; }
        public List<MatchingClass> MatchingClassList { get; set; }
        
        public SmartPermutations(List<string[]> possibleValues, List<string[]> rulesMatrix)
        {
            //PossibleValues = possibleValues;
            MatchingClassList = this.MakeBenefitClassList(rulesMatrix, possibleValues);
        }

        private List<MatchingClass> MakeBenefitClassList(List<string[]> rulesMatrix, List<string[]> possibleValues)
        {
            var list = new List<MatchingClass>(rulesMatrix.Count);
            for (int i=0; i<rulesMatrix.Count; i++)
            {
                var matchingClassRules = rulesMatrix[i];
                try
                {
                    list.Add(new MatchingClass(matchingClassRules.First(), matchingClassRules.Skip(1).ToArray(), possibleValues));
                }
                catch (ExceptionInvalidData ex)
                {
                    throw new ExceptionInvalidData(string.Format("Error with matching class '{0}': {1}", matchingClassRules.First(), ex.Message));
                }
            }
            return list;
        }

        public string[,] ComputePermutationMatrix()
        {
            List<string[]> ListOfSubmatrices = new List<string[]>();
            foreach (var matchingClass in MatchingClassList)
            {
                ListOfSubmatrices = ListOfSubmatrices.Concat(matchingClass.ComputePermutationMatrix()).ToList();
            }

            var nbOfRows = ListOfSubmatrices.Count;
            var nbOfColumns = ListOfSubmatrices.First().Length;

            string[,] matrix = new string[nbOfRows, nbOfColumns];

            for (int row=0; row < nbOfRows; row++)
            {
                for (int column = 0; column < nbOfColumns;column++ )
                {
                    matrix[row, column] = ListOfSubmatrices[row][column];
                }
            }

            return matrix;
        }
    }
}
