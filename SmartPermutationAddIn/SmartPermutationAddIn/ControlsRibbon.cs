using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using PermutationLibrary;
using System.Windows.Forms;

namespace SmartPermutationAddIn
{
    public partial class ControlsRibbon
    {
        private void ControlsRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonPossibleValuesGetSelectedRange_Click(object sender, RibbonControlEventArgs e)
        {
            this.editBoxPossibleValues.Text = string.Format("'{0}'!{1}",
                                                            ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet).Name,
                                                            ((Excel.Range)(Globals.ThisAddIn.Application.Selection)).get_Address());
        }

        private void buttonRulesMatrixGetSelectedRange_Click(object sender, RibbonControlEventArgs e)
        {
            this.editBoxRulesMatrix.Text = string.Format("'{0}'!{1}",
                                                            ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet).Name,
                                                            ((Excel.Range)(Globals.ThisAddIn.Application.Selection)).get_Address());
        }

        private void buttonLaunch_Click(object sender, RibbonControlEventArgs e)
        {
            //Reading the data.
            var rangePossibleValues = ((Excel.Range)Globals.ThisAddIn.Application.get_Range(this.editBoxPossibleValues.Text));
            var rangeRulesMatrix = ((Excel.Range)Globals.ThisAddIn.Application.get_Range(this.editBoxRulesMatrix.Text));
            var listPossibleValues = convertRangeToStringArrays(rangePossibleValues, true);
            var listRulesMatrix = convertRangeToStringArrays(rangeRulesMatrix, false);

            //Generating the solution.
            try
            {
                var model = new SmartPermutations(listPossibleValues, listRulesMatrix);
                string[,] permutationMatrix = model.ComputePermutationMatrix();

                //Copying the data to a new sheet.
                Excel.Worksheet newWorksheet;
                newWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add();

                var startCell = (Excel.Range)newWorksheet.Cells[1, 1];
                var endCell = (Excel.Range)newWorksheet.Cells[permutationMatrix.GetLength(0), permutationMatrix.GetLength(1)];
                var writeRange = newWorksheet.Range[startCell, endCell];

                writeRange.Value2 = permutationMatrix;
            }
            catch (ExceptionInvalidData ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<string[]> convertRangeToStringArrays(Excel.Range range, bool ignoreEmptyCells)
        {
            List<string[]> listOfArray = new List<string[]>();
            foreach (Excel.Range col in range.Columns)
            {
                List<string> listOfStrings = new List<string>();
                foreach (Excel.Range row in (Excel.Range)col.Rows)
                {
                    if (ignoreEmptyCells)
                    {
                        if (row.Text != "")
                        {
                            listOfStrings.Add(row.Text);
                        }
                    }
                    else
                    {
                        listOfStrings.Add(row.Text);
                    }
                }
                listOfArray.Add(listOfStrings.ToArray());
            }
            return listOfArray;
        }
    }
}
