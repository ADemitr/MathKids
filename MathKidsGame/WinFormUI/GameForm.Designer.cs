namespace WinFormUI
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.timeElapsedProgressBar = new System.Windows.Forms.ProgressBar();
            this.labelMaxInARow = new System.Windows.Forms.Label();
            this.buttonCurrentinARow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.Location = new System.Drawing.Point(77, 136);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(400, 86);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "2 + 2 * 2 = 8";
            // 
            // buttonNo
            // 
            this.buttonNo.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNo.Location = new System.Drawing.Point(32, 383);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(341, 145);
            this.buttonNo.TabIndex = 2;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonYes.Location = new System.Drawing.Point(395, 383);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(341, 145);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // timeElapsedProgressBar
            // 
            this.timeElapsedProgressBar.Location = new System.Drawing.Point(92, 280);
            this.timeElapsedProgressBar.Name = "timeElapsedProgressBar";
            this.timeElapsedProgressBar.Size = new System.Drawing.Size(753, 33);
            this.timeElapsedProgressBar.TabIndex = 4;
            // 
            // labelMaxInARow
            // 
            this.labelMaxInARow.AutoSize = true;
            this.labelMaxInARow.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMaxInARow.Location = new System.Drawing.Point(79, 9);
            this.labelMaxInARow.Name = "labelMaxInARow";
            this.labelMaxInARow.Size = new System.Drawing.Size(627, 45);
            this.labelMaxInARow.TabIndex = 0;
            this.labelMaxInARow.Text = "Максимум правильных ответов подряд : ";
            // 
            // button1
            // 
            this.buttonCurrentinARow.BackColor = System.Drawing.SystemColors.Info;
            this.buttonCurrentinARow.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCurrentinARow.Location = new System.Drawing.Point(755, 93);
            this.buttonCurrentinARow.Name = "button1";
            this.buttonCurrentinARow.Size = new System.Drawing.Size(160, 168);
            this.buttonCurrentinARow.TabIndex = 5;
            this.buttonCurrentinARow.Text = "0";
            this.buttonCurrentinARow.UseVisualStyleBackColor = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 543);
            this.Controls.Add(this.buttonCurrentinARow);
            this.Controls.Add(this.labelMaxInARow);
            this.Controls.Add(this.timeElapsedProgressBar);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.descriptionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.ProgressBar timeElapsedProgressBar;
        private System.Windows.Forms.Label labelMaxInARow;
        private System.Windows.Forms.Button buttonCurrentinARow;
    }
}

