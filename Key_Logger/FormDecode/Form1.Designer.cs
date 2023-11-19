namespace FormDecode
{
    partial class Form1
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
            this.FileContent = new System.Windows.Forms.RichTextBox();
            this.Key = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FilePick = new System.Windows.Forms.Button();
            this.FileLocation = new System.Windows.Forms.RichTextBox();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.IV = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileContent
            // 
            this.FileContent.BackColor = System.Drawing.Color.White;
            this.FileContent.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileContent.Location = new System.Drawing.Point(25, 279);
            this.FileContent.Name = "FileContent";
            this.FileContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.FileContent.Size = new System.Drawing.Size(661, 164);
            this.FileContent.TabIndex = 0;
            this.FileContent.Text = "";
            // 
            // Key
            // 
            this.Key.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key.Location = new System.Drawing.Point(116, 151);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(227, 50);
            this.Key.TabIndex = 1;
            this.Key.Text = "";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nội dung File đã được giải mã:";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập Key:";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chọn File:";
            // 
            // FilePick
            // 
            this.FilePick.Location = new System.Drawing.Point(599, 86);
            this.FilePick.Name = "FilePick";
            this.FilePick.Size = new System.Drawing.Size(88, 52);
            this.FilePick.TabIndex = 5;
            this.FilePick.Text = "Chọn";
            this.FilePick.UseVisualStyleBackColor = true;
            this.FilePick.Click += new System.EventHandler(this.FilePick_Click);
            // 
            // FileLocation
            // 
            this.FileLocation.BackColor = System.Drawing.Color.White;
            this.FileLocation.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLocation.Location = new System.Drawing.Point(116, 88);
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.ReadOnly = true;
            this.FileLocation.Size = new System.Drawing.Size(486, 50);
            this.FileLocation.TabIndex = 6;
            this.FileLocation.Text = "";
            // 
            // DecodeButton
            // 
            this.DecodeButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.DecodeButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecodeButton.Location = new System.Drawing.Point(287, 215);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(160, 31);
            this.DecodeButton.TabIndex = 7;
            this.DecodeButton.Text = "Giải Mã";
            this.DecodeButton.UseVisualStyleBackColor = false;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhập IV:";
            // 
            // IV
            // 
            this.IV.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IV.Location = new System.Drawing.Point(458, 151);
            this.IV.Name = "IV";
            this.IV.Size = new System.Drawing.Size(227, 50);
            this.IV.TabIndex = 8;
            this.IV.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 43);
            this.label5.TabIndex = 10;
            this.label5.Text = "Decryptor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(713, 469);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IV);
            this.Controls.Add(this.DecodeButton);
            this.Controls.Add(this.FileLocation);
            this.Controls.Add(this.FilePick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.FileContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileContent;
        private System.Windows.Forms.RichTextBox Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FilePick;
        private System.Windows.Forms.RichTextBox FileLocation;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox IV;
        private System.Windows.Forms.Label label5;
    }
}

