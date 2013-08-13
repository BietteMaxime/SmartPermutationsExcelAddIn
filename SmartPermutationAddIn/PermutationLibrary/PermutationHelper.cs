using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationLibrary
{
    public static class PermutationHelper
    {
        public static List<string[]> DoPermutations(List<string[]> possibilitiesList)
        {
            int[] numberOfPossibleValues = possibilitiesList.Select(x => x.Length).ToArray();
            int numberOfResultRows = ComputeNumberOfRows(numberOfPossibleValues);

            List<string[]> matrix = new List<string[]>(numberOfResultRows);
            int[] indexTable = new int[possibilitiesList.Count];

            for (int matrixRowCount=0; matrixRowCount < numberOfResultRows; matrixRowCount++)
            {
                // Generetaing the row
                string[] row = new string[possibilitiesList.Count];
                for (int columnCount = 0; columnCount < possibilitiesList.Count; columnCount++)
                {
                    row[columnCount] = possibilitiesList[columnCount][indexTable[columnCount]];
                }

                // Moving the indexes
                for (int columnCount = 0, toAdd = 1; columnCount < possibilitiesList.Count && toAdd > 0; columnCount++)
                {
                    if (indexTable[columnCount] < numberOfPossibleValues[columnCount] - 1)
                    {
                        indexTable[columnCount] += 1;
                        toAdd--;
                    }
                    else
                    {
                        indexTable[columnCount] = 0;
                    }
                }

                matrix.Add(row);
            }

            return matrix;
        }

        public static int ComputeNumberOfRows(int[] numberOfPossibleRows)
        {
            int numberOfResultRows = 1;
            for (int i = 0; i < numberOfPossibleRows.Length; i++)
            {
                numberOfResultRows *= numberOfPossibleRows[i];
            }
            return numberOfResultRows;
        }
    }
}
