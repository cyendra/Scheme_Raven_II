namespace Raven.Scheme.Editor
{
    partial class EditForm
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
            this.codeBox = new System.Windows.Forms.TextBox();
            this.codeRichBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // codeBox
            // 
            this.codeBox.AcceptsReturn = true;
            this.codeBox.AcceptsTab = true;
            this.codeBox.Location = new System.Drawing.Point(12, 12);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeBox.Size = new System.Drawing.Size(251, 393);
            this.codeBox.TabIndex = 0;
            this.codeBox.WordWrap = false;
            // 
            // codeRichBox
            // 
            this.codeRichBox.AcceptsTab = true;
            this.codeRichBox.DetectUrls = false;
            this.codeRichBox.Location = new System.Drawing.Point(269, 12);
            this.codeRichBox.Name = "codeRichBox";
            this.codeRichBox.Size = new System.Drawing.Size(261, 393);
            this.codeRichBox.TabIndex = 1;
            this.codeRichBox.Text = "";
            this.codeRichBox.WordWrap = false;
            this.codeRichBox.TextChanged += new System.EventHandler(this.codeRichBox_TextChanged);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 417);
            this.Controls.Add(this.codeRichBox);
            this.Controls.Add(this.codeBox);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.RichTextBox codeRichBox;
    }
}