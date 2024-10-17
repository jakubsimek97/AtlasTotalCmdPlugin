namespace TCPoints.GUI
{
    partial class LoadExternalDll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dllTypes = new TreeView();
            getPathDll = new Button();
            SuspendLayout();
            // 
            // dllTypes
            // 
            dllTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dllTypes.Location = new Point(19, 18);
            dllTypes.Name = "dllTypes";
            dllTypes.Size = new Size(264, 327);
            dllTypes.TabIndex = 0;
            // 
            // getPathDll
            // 
            getPathDll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            getPathDll.Location = new Point(19, 351);
            getPathDll.Name = "getPathDll";
            getPathDll.Size = new Size(264, 23);
            getPathDll.TabIndex = 1;
            getPathDll.Text = "Open DLL";
            getPathDll.UseVisualStyleBackColor = true;
            getPathDll.Click += getPathDll_Click;
            // 
            // LoadExternalDll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 387);
            Controls.Add(getPathDll);
            Controls.Add(dllTypes);
            Name = "LoadExternalDll";
            Text = "Load External DLL";
            ResumeLayout(false);
        }

        #endregion

        private TreeView dllTypes;
        private Button getPathDll;
    }
}