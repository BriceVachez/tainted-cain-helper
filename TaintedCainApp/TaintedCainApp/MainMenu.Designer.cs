namespace TaintedCainApp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.updateData = new System.Windows.Forms.Button();
            this.loadedItems = new System.Windows.Forms.Label();
            this.launchApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateData
            // 
            this.updateData.Location = new System.Drawing.Point(306, 267);
            this.updateData.Name = "updateData";
            this.updateData.Size = new System.Drawing.Size(165, 23);
            this.updateData.TabIndex = 0;
            this.updateData.Text = "Update data";
            this.updateData.UseVisualStyleBackColor = true;
            this.updateData.Click += new System.EventHandler(this.updateDataButton_Click);
            // 
            // loadedItems
            // 
            this.loadedItems.AutoSize = true;
            this.loadedItems.Location = new System.Drawing.Point(324, 90);
            this.loadedItems.Name = "loadedItems";
            this.loadedItems.Size = new System.Drawing.Size(108, 17);
            this.loadedItems.TabIndex = 1;
            this.loadedItems.Text = "Items loaded : 0";
            // 
            // launchApplication
            // 
            this.launchApplication.Location = new System.Drawing.Point(306, 297);
            this.launchApplication.Name = "launchApplication";
            this.launchApplication.Size = new System.Drawing.Size(165, 23);
            this.launchApplication.TabIndex = 2;
            this.launchApplication.Text = "Launch application";
            this.launchApplication.UseVisualStyleBackColor = true;
            this.launchApplication.Click += new System.EventHandler(this.launchApplication_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.launchApplication);
            this.Controls.Add(this.loadedItems);
            this.Controls.Add(this.updateData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Tainted Cain Companion";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateData;
        private System.Windows.Forms.Label loadedItems;
        private System.Windows.Forms.Button launchApplication;
    }
}

