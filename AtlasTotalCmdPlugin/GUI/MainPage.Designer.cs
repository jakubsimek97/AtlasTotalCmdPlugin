namespace TCPoints.GUI
{
    partial class MainPage
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
            dataGridView1 = new DataGridView();
            export = new Button();
            switchXY = new Button();
            loadExternalDll = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1092, 667);
            dataGridView1.TabIndex = 0;
            dataGridView1.SizeChanged += dataGridView1_SizeChanged;
            // 
            // export
            // 
            export.Location = new Point(1048, 719);
            export.Name = "export";
            export.Size = new Size(75, 23);
            export.TabIndex = 1;
            export.Text = "Export";
            export.UseVisualStyleBackColor = true;
            export.Click += export_Click;
            // 
            // switchXY
            // 
            switchXY.Location = new Point(534, 12);
            switchXY.Name = "switchXY";
            switchXY.Size = new Size(75, 23);
            switchXY.TabIndex = 2;
            switchXY.Text = "Switch X/Y";
            switchXY.UseVisualStyleBackColor = true;
            switchXY.Click += switchXY_Click;
            // 
            // loadExternalDll
            // 
            loadExternalDll.Location = new Point(31, 719);
            loadExternalDll.Name = "loadExternalDll";
            loadExternalDll.Size = new Size(75, 23);
            loadExternalDll.TabIndex = 3;
            loadExternalDll.Text = "Load DLL";
            loadExternalDll.UseVisualStyleBackColor = true;
            loadExternalDll.Click += loadExternalDll_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 763);
            Controls.Add(loadExternalDll);
            Controls.Add(switchXY);
            Controls.Add(export);
            Controls.Add(dataGridView1);
            Name = "MainPage";
            Text = "TCPoints";
            KeyDown += MainPage_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button export;
        private Button switchXY;
        private Button loadExternalDll;
    }
}