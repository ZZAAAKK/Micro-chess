
namespace Micro_chess
{
    partial class Board
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
            this.Cell20 = new System.Windows.Forms.Label();
            this.Cell22 = new System.Windows.Forms.Label();
            this.Cell11 = new System.Windows.Forms.Label();
            this.Cell00 = new System.Windows.Forms.Label();
            this.Cell02 = new System.Windows.Forms.Label();
            this.Cell21 = new System.Windows.Forms.Label();
            this.Cell10 = new System.Windows.Forms.Label();
            this.Cell01 = new System.Windows.Forms.Label();
            this.Cell12 = new System.Windows.Forms.Label();
            this.scrlHistory = new System.Windows.Forms.HScrollBar();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlVictory = new System.Windows.Forms.Panel();
            this.lblVictory = new System.Windows.Forms.Label();
            this.pnlVictory.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cell20
            // 
            this.Cell20.BackColor = System.Drawing.Color.White;
            this.Cell20.Location = new System.Drawing.Point(0, 0);
            this.Cell20.Name = "Cell20";
            this.Cell20.Size = new System.Drawing.Size(100, 100);
            this.Cell20.TabIndex = 0;
            this.Cell20.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell22
            // 
            this.Cell22.BackColor = System.Drawing.Color.White;
            this.Cell22.Location = new System.Drawing.Point(200, 0);
            this.Cell22.Name = "Cell22";
            this.Cell22.Size = new System.Drawing.Size(100, 100);
            this.Cell22.TabIndex = 1;
            this.Cell22.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell11
            // 
            this.Cell11.BackColor = System.Drawing.Color.White;
            this.Cell11.Location = new System.Drawing.Point(100, 100);
            this.Cell11.Name = "Cell11";
            this.Cell11.Size = new System.Drawing.Size(100, 100);
            this.Cell11.TabIndex = 2;
            this.Cell11.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell00
            // 
            this.Cell00.BackColor = System.Drawing.Color.White;
            this.Cell00.Location = new System.Drawing.Point(0, 200);
            this.Cell00.Name = "Cell00";
            this.Cell00.Size = new System.Drawing.Size(100, 100);
            this.Cell00.TabIndex = 3;
            this.Cell00.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell02
            // 
            this.Cell02.BackColor = System.Drawing.Color.White;
            this.Cell02.Location = new System.Drawing.Point(200, 200);
            this.Cell02.Name = "Cell02";
            this.Cell02.Size = new System.Drawing.Size(100, 100);
            this.Cell02.TabIndex = 4;
            this.Cell02.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell21
            // 
            this.Cell21.BackColor = System.Drawing.Color.Black;
            this.Cell21.Location = new System.Drawing.Point(100, 0);
            this.Cell21.Name = "Cell21";
            this.Cell21.Size = new System.Drawing.Size(100, 100);
            this.Cell21.TabIndex = 5;
            this.Cell21.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell10
            // 
            this.Cell10.BackColor = System.Drawing.Color.Black;
            this.Cell10.Location = new System.Drawing.Point(0, 100);
            this.Cell10.Name = "Cell10";
            this.Cell10.Size = new System.Drawing.Size(100, 100);
            this.Cell10.TabIndex = 6;
            this.Cell10.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell01
            // 
            this.Cell01.BackColor = System.Drawing.Color.Black;
            this.Cell01.Location = new System.Drawing.Point(100, 200);
            this.Cell01.Name = "Cell01";
            this.Cell01.Size = new System.Drawing.Size(100, 100);
            this.Cell01.TabIndex = 7;
            this.Cell01.Click += new System.EventHandler(this.Cell_Click);
            // 
            // Cell12
            // 
            this.Cell12.BackColor = System.Drawing.Color.Black;
            this.Cell12.Location = new System.Drawing.Point(200, 100);
            this.Cell12.Name = "Cell12";
            this.Cell12.Size = new System.Drawing.Size(100, 100);
            this.Cell12.TabIndex = 8;
            this.Cell12.Click += new System.EventHandler(this.Cell_Click);
            // 
            // scrlHistory
            // 
            this.scrlHistory.LargeChange = 1;
            this.scrlHistory.Location = new System.Drawing.Point(0, 300);
            this.scrlHistory.Maximum = 0;
            this.scrlHistory.Name = "scrlHistory";
            this.scrlHistory.Size = new System.Drawing.Size(300, 19);
            this.scrlHistory.TabIndex = 9;
            this.scrlHistory.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlHistory_Scroll);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewGame.Location = new System.Drawing.Point(2, 322);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(145, 23);
            this.btnNewGame.TabIndex = 10;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.NewGame);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(154, 322);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // pnlVictory
            // 
            this.pnlVictory.BackColor = System.Drawing.Color.Silver;
            this.pnlVictory.Controls.Add(this.lblVictory);
            this.pnlVictory.Location = new System.Drawing.Point(0, 0);
            this.pnlVictory.Name = "pnlVictory";
            this.pnlVictory.Size = new System.Drawing.Size(300, 345);
            this.pnlVictory.TabIndex = 12;
            // 
            // lblVictory
            // 
            this.lblVictory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVictory.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictory.Location = new System.Drawing.Point(0, 0);
            this.lblVictory.Name = "lblVictory";
            this.lblVictory.Size = new System.Drawing.Size(300, 345);
            this.lblVictory.TabIndex = 0;
            this.lblVictory.Text = "Click to play!";
            this.lblVictory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVictory.Click += new System.EventHandler(this.NewGame);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(300, 347);
            this.Controls.Add(this.pnlVictory);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.scrlHistory);
            this.Controls.Add(this.Cell12);
            this.Controls.Add(this.Cell01);
            this.Controls.Add(this.Cell10);
            this.Controls.Add(this.Cell21);
            this.Controls.Add(this.Cell02);
            this.Controls.Add(this.Cell00);
            this.Controls.Add(this.Cell11);
            this.Controls.Add(this.Cell22);
            this.Controls.Add(this.Cell20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Board";
            this.Text = "Micro-chess";
            this.pnlVictory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Cell20;
        private System.Windows.Forms.Label Cell22;
        private System.Windows.Forms.Label Cell11;
        private System.Windows.Forms.Label Cell00;
        private System.Windows.Forms.Label Cell02;
        private System.Windows.Forms.Label Cell21;
        private System.Windows.Forms.Label Cell10;
        private System.Windows.Forms.Label Cell01;
        private System.Windows.Forms.Label Cell12;
        private System.Windows.Forms.HScrollBar scrlHistory;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlVictory;
        private System.Windows.Forms.Label lblVictory;
    }
}

