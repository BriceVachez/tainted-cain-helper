﻿namespace TaintedCainApp
{
    partial class MainAppWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAppWindow));
            this.library = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // library
            // 
            this.library.Location = new System.Drawing.Point(-1, -1);
            this.library.Name = "library";
            this.library.Size = new System.Drawing.Size(136, 23);
            this.library.TabIndex = 0;
            this.library.Text = "Library";
            this.library.UseVisualStyleBackColor = true;
            this.library.Click += new System.EventHandler(this.library_Click_Click);
            // 
            // MainAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.library);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainAppWindow";
            this.Text = "Tainted Cain Companion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button library;
    }
}