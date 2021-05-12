namespace TaintedCainApp.UI
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
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.lastPage = new System.Windows.Forms.Button();
            this.firstPage = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(695, 280);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(35, 23);
            this.nextPage.TabIndex = 2;
            this.nextPage.Text = ">";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            this.previousPage.Location = new System.Drawing.Point(67, 280);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(35, 23);
            this.previousPage.TabIndex = 3;
            this.previousPage.Text = "<";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // lastPage
            // 
            this.lastPage.Location = new System.Drawing.Point(736, 280);
            this.lastPage.Name = "lastPage";
            this.lastPage.Size = new System.Drawing.Size(41, 23);
            this.lastPage.TabIndex = 8;
            this.lastPage.Text = ">>";
            this.lastPage.UseVisualStyleBackColor = true;
            this.lastPage.Click += new System.EventHandler(this.lastPage_Click);
            // 
            // firstPage
            // 
            this.firstPage.Location = new System.Drawing.Point(20, 280);
            this.firstPage.Name = "firstPage";
            this.firstPage.Size = new System.Drawing.Size(41, 23);
            this.firstPage.TabIndex = 9;
            this.firstPage.Text = "<<";
            this.firstPage.UseVisualStyleBackColor = true;
            this.firstPage.Click += new System.EventHandler(this.firstPage_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(373, 280);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(0, 17);
            this.pageLabel.TabIndex = 4;
            // 
            // GenerationResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.firstPage);
            this.Controls.Add(this.lastPage);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerationResultWindow";
            this.Text = "Tainted Cain Companion";
            this.Load += new System.EventHandler(this.GenerationResultWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ResultPanel resultPanel;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button lastPage;
        private System.Windows.Forms.Button firstPage;
        private System.Windows.Forms.Label pageLabel;
    }
}