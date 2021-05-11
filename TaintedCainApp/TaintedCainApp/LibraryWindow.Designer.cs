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
            this.leaveButton = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.pageNumberChosingPanel = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.sortTypeChosingPanel = new System.Windows.Forms.Panel();
            this.lastPage = new System.Windows.Forms.Button();
            this.firstPage = new System.Windows.Forms.Button();
            this.showcasePanel = new TaintedCainApp.LibraryPanel();
            this.SuspendLayout();
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
            this.nextPage.Location = new System.Drawing.Point(695, 231);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(35, 23);
            this.nextPage.TabIndex = 2;
            this.nextPage.Text = ">";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // previousPage
            // 
            this.previousPage.Location = new System.Drawing.Point(67, 231);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(35, 23);
            this.previousPage.TabIndex = 3;
            this.previousPage.Text = "<";
            this.previousPage.UseVisualStyleBackColor = true;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(373, 231);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(75, 17);
            this.pageLabel.TabIndex = 4;
            // 
            // pageNumberChosingPanel
            // 
            this.pageNumberChosingPanel.Location = new System.Drawing.Point(20, 267);
            this.pageNumberChosingPanel.Name = "pageNumberChosingPanel";
            this.pageNumberChosingPanel.Size = new System.Drawing.Size(500, 26);
            this.pageNumberChosingPanel.TabIndex = 5;
            this.pageNumberChosingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pageNumberChosingPanel_Paint);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(445, 345);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // sortTypeChosingPanel
            // 
            this.sortTypeChosingPanel.Location = new System.Drawing.Point(20, 299);
            this.sortTypeChosingPanel.Name = "sortTypeChosingPanel";
            this.sortTypeChosingPanel.Size = new System.Drawing.Size(500, 26);
            this.sortTypeChosingPanel.TabIndex = 7;
            this.sortTypeChosingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sortTypeChosingPanel_Paint);
            // 
            // lastPage
            // 
            this.lastPage.Location = new System.Drawing.Point(736, 231);
            this.lastPage.Name = "lastPage";
            this.lastPage.Size = new System.Drawing.Size(41, 23);
            this.lastPage.TabIndex = 8;
            this.lastPage.Text = ">>";
            this.lastPage.UseVisualStyleBackColor = true;
            this.lastPage.Click += new System.EventHandler(this.lastPage_Click);
            // 
            // firstPage
            // 
            this.firstPage.Location = new System.Drawing.Point(20, 231);
            this.firstPage.Name = "firstPage";
            this.firstPage.Size = new System.Drawing.Size(41, 23);
            this.firstPage.TabIndex = 9;
            this.firstPage.Text = "<<";
            this.firstPage.UseVisualStyleBackColor = true;
            this.firstPage.Click += new System.EventHandler(this.firstPage_Click);
            // 
            // showcasePanel
            // 
            this.showcasePanel.AutoScroll = true;
            this.showcasePanel.Location = new System.Drawing.Point(20, 20);
            this.showcasePanel.Name = "showcasePanel";
            this.showcasePanel.Size = new System.Drawing.Size(757, 200);
            this.showcasePanel.TabIndex = 0;
            this.showcasePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.showcasePanel_Paint);
            // 
            // LibraryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.firstPage);
            this.Controls.Add(this.lastPage);
            this.Controls.Add(this.sortTypeChosingPanel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.pageNumberChosingPanel);
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
        private System.Windows.Forms.Panel pageNumberChosingPanel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Panel sortTypeChosingPanel;
        private System.Windows.Forms.Button lastPage;
        private System.Windows.Forms.Button firstPage;
    }
}