namespace EOL_FILE
{
    partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem analyzerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem infoInEnglishToolStripMenuItem;

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
        this.textBoxFilePath = new System.Windows.Forms.TextBox();
        this.buttonSelectFile = new System.Windows.Forms.Button();
        this.textBoxFileInfo = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.buttonAnalyze = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // textBoxFilePath
        // 
        this.textBoxFilePath.AllowDrop = true;
        this.textBoxFilePath.Location = new System.Drawing.Point(13, 58);
        this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.textBoxFilePath.Multiline = true;
        this.textBoxFilePath.Name = "textBoxFilePath";
        this.textBoxFilePath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBoxFilePath.Size = new System.Drawing.Size(438, 25);
        this.textBoxFilePath.TabIndex = 0;
        // 
        // buttonSelectFile
        // 
        this.buttonSelectFile.Location = new System.Drawing.Point(460, 58);
        this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.buttonSelectFile.Name = "buttonSelectFile";
        this.buttonSelectFile.Size = new System.Drawing.Size(76, 25);
        this.buttonSelectFile.TabIndex = 1;
        this.buttonSelectFile.Text = "FIND";
        this.buttonSelectFile.UseVisualStyleBackColor = true;
        this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
        // 
        // textBoxFileInfo
        // 
        this.textBoxFileInfo.Location = new System.Drawing.Point(13, 107);
        this.textBoxFileInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.textBoxFileInfo.Multiline = true;
        this.textBoxFileInfo.Name = "textBoxFileInfo";
        this.textBoxFileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBoxFileInfo.Size = new System.Drawing.Size(523, 306);
        this.textBoxFileInfo.TabIndex = 2;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(228, 24);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(100, 15);
        this.label1.TabIndex = 3;
        this.label1.Text = "EOL FILE ANALYZER";
        // 
        // buttonAnalyze
        // 
        this.buttonAnalyze.Location = new System.Drawing.Point(240, 428);
        this.buttonAnalyze.Name = "buttonAnalyze";
        this.buttonAnalyze.Size = new System.Drawing.Size(88, 27);
        this.buttonAnalyze.TabIndex = 4;
        this.buttonAnalyze.Text = "Analyze";
        this.buttonAnalyze.UseVisualStyleBackColor = true;
        this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(559, 464);
        this.Controls.Add(this.buttonAnalyze);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.textBoxFileInfo);
        this.Controls.Add(this.buttonSelectFile);
        this.Controls.Add(this.textBoxFilePath);
        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.Name = "Form1";
        this.Text = "EOL FILE ANALYZER";
        this.ResumeLayout(false);
        this.PerformLayout();

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.analyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoInEnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyzerToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.infoInEnglishToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 14);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // analyzerToolStripMenuItem
            // 
            this.analyzerToolStripMenuItem.Name = "analyzerToolStripMenuItem";
            this.analyzerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.analyzerToolStripMenuItem.Text = "Analyzer";
            this.analyzerToolStripMenuItem.Click += new System.EventHandler(this.analyzerToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // infoInEnglishToolStripMenuItem
            // 
            this.infoInEnglishToolStripMenuItem.Name = "infoInEnglishToolStripMenuItem";
            this.infoInEnglishToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.infoInEnglishToolStripMenuItem.Text = "Info";
            this.infoInEnglishToolStripMenuItem.Click += new System.EventHandler(this.infoInEnglishToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 464);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileInfo);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.menuStrip1); // Agregar el menú al formulario
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "APP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox textBoxFilePath;
    private System.Windows.Forms.Button buttonSelectFile;
    private System.Windows.Forms.TextBox textBoxFileInfo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonAnalyze;
}
}
