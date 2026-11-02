namespace SnakeGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;
        private System.Windows.Forms.Panel panelGame = null!;
        private System.Windows.Forms.Panel panelControls = null!;
        private System.Windows.Forms.Label lblScore = null!;
        private System.Windows.Forms.Button btnUp = null!;
        private System.Windows.Forms.Button btnDown = null!;
        private System.Windows.Forms.Button btnLeft = null!;
        private System.Windows.Forms.Button btnRight = null!;
        private System.Windows.Forms.Button btnExit = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelGame = new System.Windows.Forms.Panel();
            panelControls = new System.Windows.Forms.Panel();
            lblScore = new System.Windows.Forms.Label();
            btnUp = new System.Windows.Forms.Button();
            btnDown = new System.Windows.Forms.Button();
            btnLeft = new System.Windows.Forms.Button();
            btnRight = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // panelGame
            // 
            panelGame.BackColor = System.Drawing.Color.White;
            panelGame.Location = new System.Drawing.Point(0, 0);
            panelGame.Name = "panelGame";
            panelGame.Size = new System.Drawing.Size(508, 271);
            panelGame.TabIndex = 0;
            // 
            // panelControls
            // 
            panelControls.BackColor = System.Drawing.Color.Gray;
            panelControls.Controls.Add(lblScore);
            panelControls.Controls.Add(btnUp);
            panelControls.Controls.Add(btnDown);
            panelControls.Controls.Add(btnLeft);
            panelControls.Controls.Add(btnRight);
            panelControls.Controls.Add(btnExit);
            panelControls.Location = new System.Drawing.Point(0, 271);
            panelControls.Name = "panelControls";
            panelControls.Size = new System.Drawing.Size(508, 209);
            panelControls.TabIndex = 1;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblScore.ForeColor = System.Drawing.Color.White;
            lblScore.Location = new System.Drawing.Point(24, 36);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(59, 17);
            lblScore.TabIndex = 0;
            lblScore.Text = "Xal:    0";
            // 
            // btnUp
            // 
            btnUp.Font = new System.Drawing.Font("Segoe UI Symbol", 22F, System.Drawing.FontStyle.Bold);
            btnUp.Location = new System.Drawing.Point(216, 15);
            btnUp.Name = "btnUp";
            btnUp.Size = new System.Drawing.Size(48, 49);
            btnUp.TabIndex = 1;
            btnUp.Text = "↑";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Font = new System.Drawing.Font("Segoe UI Symbol", 22F, System.Drawing.FontStyle.Bold);
            btnDown.Location = new System.Drawing.Point(216, 130);
            btnDown.Name = "btnDown";
            btnDown.Size = new System.Drawing.Size(48, 49);
            btnDown.TabIndex = 2;
            btnDown.Text = "↓";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnLeft
            // 
            btnLeft.Font = new System.Drawing.Font("Segoe UI Symbol", 22F, System.Drawing.FontStyle.Bold);
            btnLeft.Location = new System.Drawing.Point(153, 72);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new System.Drawing.Size(48, 49);
            btnLeft.TabIndex = 3;
            btnLeft.Text = "←";
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // btnRight
            // 
            btnRight.Font = new System.Drawing.Font("Segoe UI Symbol", 22F, System.Drawing.FontStyle.Bold);
            btnRight.Location = new System.Drawing.Point(279, 72);
            btnRight.Name = "btnRight";
            btnRight.Size = new System.Drawing.Size(48, 49);
            btnRight.TabIndex = 4;
            btnRight.Text = "→";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            btnExit.ForeColor = System.Drawing.Color.Black;
            btnExit.Location = new System.Drawing.Point(399, 150);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(99, 35);
            btnExit.TabIndex = 5;
            btnExit.Text = "Çıxış";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(508, 480);
            Controls.Add(panelControls);
            Controls.Add(panelGame);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Snake Game";
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
        }
    }
}
