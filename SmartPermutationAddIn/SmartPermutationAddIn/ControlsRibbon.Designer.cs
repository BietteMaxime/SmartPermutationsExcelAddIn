namespace SmartPermutationAddIn
{
    partial class ControlsRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ControlsRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SmartPermutations = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.editBoxPossibleValues = this.Factory.CreateRibbonEditBox();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.editBoxRulesMatrix = this.Factory.CreateRibbonEditBox();
            this.buttonLaunch = this.Factory.CreateRibbonButton();
            this.buttonPossibleValuesGetSelectedRange = this.Factory.CreateRibbonButton();
            this.buttonRulesMatrixGetSelectedRange = this.Factory.CreateRibbonButton();
            this.SmartPermutations.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // SmartPermutations
            // 
            this.SmartPermutations.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.SmartPermutations.Groups.Add(this.group1);
            this.SmartPermutations.Groups.Add(this.group2);
            this.SmartPermutations.Groups.Add(this.group3);
            this.SmartPermutations.Label = "Smart Permutations";
            this.SmartPermutations.Name = "SmartPermutations";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonLaunch);
            this.group1.Name = "group1";
            // 
            // editBoxPossibleValues
            // 
            this.editBoxPossibleValues.Label = "Range";
            this.editBoxPossibleValues.Name = "editBoxPossibleValues";
            this.editBoxPossibleValues.Text = null;
            // 
            // group2
            // 
            this.group2.Items.Add(this.editBoxPossibleValues);
            this.group2.Items.Add(this.buttonPossibleValuesGetSelectedRange);
            this.group2.Label = "Possible Values";
            this.group2.Name = "group2";
            // 
            // group3
            // 
            this.group3.Items.Add(this.editBoxRulesMatrix);
            this.group3.Items.Add(this.buttonRulesMatrixGetSelectedRange);
            this.group3.Label = "Rules Matrix";
            this.group3.Name = "group3";
            // 
            // editBoxRulesMatrix
            // 
            this.editBoxRulesMatrix.Label = "Range";
            this.editBoxRulesMatrix.Name = "editBoxRulesMatrix";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonLaunch.Image = global::SmartPermutationAddIn.Properties.Resources.another_green_start_button_md;
            this.buttonLaunch.Label = "Launch Permutations";
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.ShowImage = true;
            this.buttonLaunch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonLaunch_Click);
            // 
            // buttonPossibleValuesGetSelectedRange
            // 
            this.buttonPossibleValuesGetSelectedRange.Label = "Get selected range";
            this.buttonPossibleValuesGetSelectedRange.Name = "buttonPossibleValuesGetSelectedRange";
            this.buttonPossibleValuesGetSelectedRange.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonPossibleValuesGetSelectedRange_Click);
            // 
            // buttonRulesMatrixGetSelectedRange
            // 
            this.buttonRulesMatrixGetSelectedRange.Label = "Get selected range";
            this.buttonRulesMatrixGetSelectedRange.Name = "buttonRulesMatrixGetSelectedRange";
            this.buttonRulesMatrixGetSelectedRange.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonRulesMatrixGetSelectedRange_Click);
            // 
            // ControlsRibbon
            // 
            this.Name = "ControlsRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.SmartPermutations);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ControlsRibbon_Load);
            this.SmartPermutations.ResumeLayout(false);
            this.SmartPermutations.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab SmartPermutations;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonLaunch;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxPossibleValues;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonPossibleValuesGetSelectedRange;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxRulesMatrix;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonRulesMatrixGetSelectedRange;
    }

    partial class ThisRibbonCollection
    {
        internal ControlsRibbon ControlsRibbon
        {
            get { return this.GetRibbon<ControlsRibbon>(); }
        }
    }
}
