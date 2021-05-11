namespace TaintedCainApp
{
    partial class LibraryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryWindow));
            this.showcasePanel = new TaintedCainApp.LibraryPanel();
            this.leaveButton = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showcasePanel
            // 
            this.showcasePanel.AutoScroll = true;
            this.showcasePanel.Location = new System.Drawing.Point(20, 20);
            this.showcasePanel.Name = "showcasePanel";
            this.showcasePanel.Size = new System.Drawing.Size(500, 200);
            this.showcasePanel.TabIndex = 0;
            this.showcasePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.showcasePanel_Paint);
            // 
            // leaveButton
            // 
            this.leaveButton.Location = new System.Drawing.Point(20, 415);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(75, 23);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "Leave";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // nextPage
            // 
            this.nextPage.Location = new System.Drawing.Point(329, 226);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(35, 23);
            this.nextPage.TabIndex = 2;
            this.nextPage.Text = ">>";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            this.previousPage.Location = new System.Drawing.Point(168, 226);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(35, 23);
            this.previousPage.TabIndex = 3;
            this.previousPage.Text = "<<";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(210, 231);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(0, 17);
            this.pageLabel.TabIndex = 4;
            // 
            // LibraryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.showcasePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibraryWindow";
            this.Text = "Tainted Cain Companion";
            this.Load += new System.EventHandler(this.LibraryWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LibraryPanel showcasePanel;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Label pageLabel;
    }
}