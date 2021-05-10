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
            this.showcasePanel = new LibraryPanel();
            this.leaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showcasePanel
            // 
            this.showcasePanel.Location = new System.Drawing.Point(21, 23);
            this.showcasePanel.Name = "showcasePanel";
            this.showcasePanel.Size = new System.Drawing.Size(500, 96);
            this.showcasePanel.TabIndex = 0;
            this.showcasePanel.AutoScroll = true;
            this.showcasePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.showcasePanel_Paint);
            // 
            // leaveButton
            // 
            this.leaveButton.Location = new System.Drawing.Point(127, 415);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(75, 23);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "leaveButton";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // LibraryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.showcasePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibraryWindow";
            this.Text = "Tainted Cain Companion";
            this.ResumeLayout(false);

        }

        #endregion

        private LibraryPanel showcasePanel;
        private System.Windows.Forms.Button leaveButton;
    }
}