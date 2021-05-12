namespace TaintedCainApp
{
    partial class GenerationResultWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationResultWindow));
            this.resultPanel = new ResultPanel(root);
            this.SuspendLayout();
            // 
            // resultPanel
            // 
            this.resultPanel.Location = new System.Drawing.Point(20, 12);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(750, 208);
            this.resultPanel.TabIndex = 0;
            this.resultPanel.AutoScroll = true;
            // 
            // GenerationResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerationResultWindow";
            this.Text = "Tainted Cain Companion";
            this.Load += new System.EventHandler(this.GenerationResultWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ResultPanel resultPanel;
    }
}