namespace VotingSystemWinForms
{
    partial class VotingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ComboBox cmbCandidates;
        private System.Windows.Forms.Button btnVote;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cmbCandidates = new System.Windows.Forms.ComboBox();
            this.btnVote = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(51, 34);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(52, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // cmbCandidates
            // 
            this.cmbCandidates.DropDownHeight = 160;
            this.cmbCandidates.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCandidates.FormattingEnabled = true;
            this.cmbCandidates.IntegralHeight = false;
            this.cmbCandidates.Location = new System.Drawing.Point(54, 97);
            this.cmbCandidates.Name = "cmbCandidates";
            this.cmbCandidates.Size = new System.Drawing.Size(136, 21);
            this.cmbCandidates.TabIndex = 1;
            this.cmbCandidates.Tag = "";
            this.cmbCandidates.Text = "select candidate";
            // 
            // btnVote
            // 
            this.btnVote.Location = new System.Drawing.Point(313, 97);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(102, 23);
            this.btnVote.TabIndex = 2;
            this.btnVote.Text = "Vote";
            this.btnVote.UseVisualStyleBackColor = true;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(191, 223);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(142, 43);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(313, 156);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(102, 23);
            this.btnViewResults.TabIndex = 4;
            this.btnViewResults.Text = "View Results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 372);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnVote);
            this.Controls.Add(this.cmbCandidates);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.Name = "VotingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Tag = "";
            this.Text = "Voting";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.VotingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
