namespace Mikroislemciler
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttonC = new Button();
			buttonD = new Button();
			buttonE = new Button();
			buttonF = new Button();
			listBox1 = new ListBox();
			playButton = new Button();
			leftPanel = new Panel();
			StopSongButton = new Button();
			GameButton = new Button();
			PianoButton = new Button();
			buttonG = new Button();
			connectionPanel = new Panel();
			isConnected = new Label();
			topPanel = new Panel();
			title = new Label();
			btnMinimize = new Button();
			btnClose = new Button();
			CS4 = new Button();
			DS4 = new Button();
			FS4 = new Button();
			A4 = new Button();
			B4 = new Button();
			C5 = new Button();
			D5 = new Button();
			E5 = new Button();
			F5 = new Button();
			G5 = new Button();
			GS4 = new Button();
			AS4 = new Button();
			DS5 = new Button();
			CS5 = new Button();
			FS5 = new Button();
			PianoPanel = new Panel();
			panel1 = new Panel();
			leftPanel.SuspendLayout();
			connectionPanel.SuspendLayout();
			topPanel.SuspendLayout();
			PianoPanel.SuspendLayout();
			SuspendLayout();
			// 
			// buttonC
			// 
			buttonC.BackColor = Color.White;
			buttonC.FlatStyle = FlatStyle.Flat;
			buttonC.Location = new Point(-1, -2);
			buttonC.Name = "buttonC";
			buttonC.Size = new Size(75, 510);
			buttonC.TabIndex = 1;
			buttonC.Text = "C4";
			buttonC.TextAlign = ContentAlignment.BottomCenter;
			buttonC.UseVisualStyleBackColor = false;
			buttonC.Click += Button_Click;
			buttonC.MouseDown += Button_MouseDown;
			buttonC.MouseUp += Button_MouseUp;
			// 
			// buttonD
			// 
			buttonD.BackColor = Color.White;
			buttonD.FlatStyle = FlatStyle.Flat;
			buttonD.Location = new Point(72, -2);
			buttonD.Name = "buttonD";
			buttonD.Size = new Size(75, 510);
			buttonD.TabIndex = 2;
			buttonD.Text = "D4";
			buttonD.TextAlign = ContentAlignment.BottomCenter;
			buttonD.UseVisualStyleBackColor = false;
			buttonD.Click += Button_Click;
			buttonD.MouseDown += Button_MouseDown;
			buttonD.MouseUp += Button_MouseUp;
			// 
			// buttonE
			// 
			buttonE.BackColor = Color.White;
			buttonE.FlatStyle = FlatStyle.Flat;
			buttonE.Location = new Point(147, -2);
			buttonE.Name = "buttonE";
			buttonE.Size = new Size(75, 510);
			buttonE.TabIndex = 3;
			buttonE.Text = "E4";
			buttonE.TextAlign = ContentAlignment.BottomCenter;
			buttonE.UseVisualStyleBackColor = false;
			buttonE.Click += Button_Click;
			buttonE.MouseDown += Button_MouseDown;
			buttonE.MouseUp += Button_MouseUp;
			// 
			// buttonF
			// 
			buttonF.BackColor = Color.White;
			buttonF.FlatStyle = FlatStyle.Flat;
			buttonF.Location = new Point(221, -2);
			buttonF.Name = "buttonF";
			buttonF.Size = new Size(75, 510);
			buttonF.TabIndex = 4;
			buttonF.Text = "F4";
			buttonF.TextAlign = ContentAlignment.BottomCenter;
			buttonF.UseVisualStyleBackColor = false;
			buttonF.Click += Button_Click;
			buttonF.MouseDown += Button_MouseDown;
			buttonF.MouseUp += Button_MouseUp;
			// 
			// listBox1
			// 
			listBox1.BackColor = SystemColors.ControlDarkDark;
			listBox1.BorderStyle = BorderStyle.FixedSingle;
			listBox1.ForeColor = SystemColors.Window;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Items.AddRange(new object[] { "Game of Thrones", "Harry Potter", "Merry Christmas", "Super Mario" });
			listBox1.Location = new Point(3, 6);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(152, 92);
			listBox1.TabIndex = 7;
			// 
			// playButton
			// 
			playButton.BackColor = SystemColors.ControlDarkDark;
			playButton.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
			playButton.FlatAppearance.BorderSize = 0;
			playButton.FlatStyle = FlatStyle.Flat;
			playButton.ForeColor = SystemColors.Control;
			playButton.Location = new Point(0, 116);
			playButton.Name = "playButton";
			playButton.Size = new Size(152, 41);
			playButton.TabIndex = 0;
			playButton.Text = "Se�ili �ark�y� oynat";
			playButton.UseVisualStyleBackColor = false;
			playButton.Click += playButton_Click;
			// 
			// leftPanel
			// 
			leftPanel.BackColor = Color.FromArgb(61, 61, 61);
			leftPanel.Controls.Add(StopSongButton);
			leftPanel.Controls.Add(GameButton);
			leftPanel.Controls.Add(PianoButton);
			leftPanel.Controls.Add(playButton);
			leftPanel.Controls.Add(listBox1);
			leftPanel.Dock = DockStyle.Left;
			leftPanel.Location = new Point(0, 26);
			leftPanel.Name = "leftPanel";
			leftPanel.Size = new Size(152, 508);
			leftPanel.TabIndex = 9;
			// 
			// StopSongButton
			// 
			StopSongButton.BackColor = SystemColors.ControlDarkDark;
			StopSongButton.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
			StopSongButton.FlatAppearance.BorderSize = 0;
			StopSongButton.FlatStyle = FlatStyle.Flat;
			StopSongButton.ForeColor = SystemColors.Control;
			StopSongButton.Location = new Point(0, 163);
			StopSongButton.Name = "StopSongButton";
			StopSongButton.Size = new Size(152, 41);
			StopSongButton.TabIndex = 0;
			StopSongButton.Text = "�ark�y� Durdur";
			StopSongButton.UseVisualStyleBackColor = false;
			StopSongButton.Click += StopSongButton_Click;
			// 
			// GameButton
			// 
			GameButton.BackColor = SystemColors.ControlDarkDark;
			GameButton.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
			GameButton.FlatAppearance.BorderSize = 0;
			GameButton.FlatStyle = FlatStyle.Flat;
			GameButton.ForeColor = SystemColors.Control;
			GameButton.Location = new Point(2, 227);
			GameButton.Name = "GameButton";
			GameButton.Size = new Size(152, 41);
			GameButton.TabIndex = 0;
			GameButton.Text = "Se�ili �ark� Oyununu ba�lat";
			GameButton.UseVisualStyleBackColor = false;
			GameButton.Click += GameButton_Click;
			// 
			// PianoButton
			// 
			PianoButton.BackColor = SystemColors.ControlDarkDark;
			PianoButton.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
			PianoButton.FlatAppearance.BorderSize = 0;
			PianoButton.FlatStyle = FlatStyle.Flat;
			PianoButton.ForeColor = SystemColors.Control;
			PianoButton.Location = new Point(2, 314);
			PianoButton.Name = "PianoButton";
			PianoButton.Size = new Size(152, 41);
			PianoButton.TabIndex = 0;
			PianoButton.Text = "Piyano";
			PianoButton.UseVisualStyleBackColor = false;
			PianoButton.Click += PianoButton_Click;
			// 
			// buttonG
			// 
			buttonG.BackColor = Color.White;
			buttonG.FlatStyle = FlatStyle.Flat;
			buttonG.Location = new Point(295, -2);
			buttonG.Name = "buttonG";
			buttonG.Size = new Size(75, 510);
			buttonG.TabIndex = 5;
			buttonG.Text = "G4";
			buttonG.TextAlign = ContentAlignment.BottomCenter;
			buttonG.UseVisualStyleBackColor = false;
			buttonG.Click += Button_Click;
			buttonG.MouseDown += Button_MouseDown;
			buttonG.MouseUp += Button_MouseUp;
			// 
			// connectionPanel
			// 
			connectionPanel.BackColor = Color.Maroon;
			connectionPanel.Controls.Add(isConnected);
			connectionPanel.Dock = DockStyle.Bottom;
			connectionPanel.Location = new Point(0, 534);
			connectionPanel.Name = "connectionPanel";
			connectionPanel.Size = new Size(1095, 16);
			connectionPanel.TabIndex = 11;
			// 
			// isConnected
			// 
			isConnected.AutoSize = true;
			isConnected.Dock = DockStyle.Right;
			isConnected.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
			isConnected.Location = new Point(1033, 0);
			isConnected.Name = "isConnected";
			isConnected.Size = new Size(62, 13);
			isConnected.TabIndex = 0;
			isConnected.Text = "Ba�l� De�il";
			// 
			// topPanel
			// 
			topPanel.BackColor = Color.FromArgb(61, 61, 61);
			topPanel.Controls.Add(title);
			topPanel.Controls.Add(btnMinimize);
			topPanel.Controls.Add(btnClose);
			topPanel.Dock = DockStyle.Top;
			topPanel.Location = new Point(0, 0);
			topPanel.Name = "topPanel";
			topPanel.Size = new Size(1095, 26);
			topPanel.TabIndex = 12;
			topPanel.MouseDown += DragForm;
			// 
			// title
			// 
			title.AutoSize = true;
			title.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 162);
			title.ForeColor = SystemColors.Control;
			title.Location = new Point(4, 3);
			title.Name = "title";
			title.Size = new Size(73, 20);
			title.TabIndex = 2;
			title.Text = "2B Piano";
			// 
			// btnMinimize
			// 
			btnMinimize.Dock = DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = FlatStyle.Flat;
			btnMinimize.ForeColor = SystemColors.Control;
			btnMinimize.Location = new Point(1043, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new Size(26, 26);
			btnMinimize.TabIndex = 1;
			btnMinimize.Text = "_";
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += btnMinimize_Click;
			// 
			// btnClose
			// 
			btnClose.Dock = DockStyle.Right;
			btnClose.FlatAppearance.BorderSize = 0;
			btnClose.FlatStyle = FlatStyle.Flat;
			btnClose.ForeColor = SystemColors.Control;
			btnClose.Location = new Point(1069, 0);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(26, 26);
			btnClose.TabIndex = 0;
			btnClose.Text = "X";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// CS4
			// 
			CS4.BackColor = Color.Black;
			CS4.FlatStyle = FlatStyle.Flat;
			CS4.ForeColor = SystemColors.Control;
			CS4.Location = new Point(46, -2);
			CS4.Name = "CS4";
			CS4.Size = new Size(53, 246);
			CS4.TabIndex = 13;
			CS4.Text = "CS4";
			CS4.TextAlign = ContentAlignment.BottomCenter;
			CS4.UseVisualStyleBackColor = false;
			CS4.Click += Button_Click;
			CS4.MouseDown += Button_MouseDown;
			CS4.MouseUp += Button_MouseUp;
			// 
			// DS4
			// 
			DS4.BackColor = Color.Black;
			DS4.FlatStyle = FlatStyle.Flat;
			DS4.ForeColor = SystemColors.Control;
			DS4.Location = new Point(119, -2);
			DS4.Name = "DS4";
			DS4.Size = new Size(53, 246);
			DS4.TabIndex = 14;
			DS4.Text = "DS4";
			DS4.TextAlign = ContentAlignment.BottomCenter;
			DS4.UseVisualStyleBackColor = false;
			DS4.Click += Button_Click;
			DS4.MouseDown += Button_MouseDown;
			DS4.MouseUp += Button_MouseUp;
			// 
			// FS4
			// 
			FS4.BackColor = Color.Black;
			FS4.FlatStyle = FlatStyle.Flat;
			FS4.ForeColor = SystemColors.Control;
			FS4.Location = new Point(268, -2);
			FS4.Name = "FS4";
			FS4.Size = new Size(53, 246);
			FS4.TabIndex = 15;
			FS4.Text = "FS4";
			FS4.TextAlign = ContentAlignment.BottomCenter;
			FS4.UseVisualStyleBackColor = false;
			FS4.Click += Button_Click;
			FS4.MouseDown += Button_MouseDown;
			FS4.MouseUp += Button_MouseUp;
			// 
			// A4
			// 
			A4.BackColor = Color.White;
			A4.FlatStyle = FlatStyle.Flat;
			A4.Location = new Point(369, -2);
			A4.Name = "A4";
			A4.Size = new Size(75, 510);
			A4.TabIndex = 16;
			A4.Text = "A4";
			A4.TextAlign = ContentAlignment.BottomCenter;
			A4.UseVisualStyleBackColor = false;
			A4.Click += Button_Click;
			A4.MouseDown += Button_MouseDown;
			A4.MouseUp += Button_MouseUp;
			// 
			// B4
			// 
			B4.BackColor = Color.White;
			B4.FlatStyle = FlatStyle.Flat;
			B4.Location = new Point(442, -2);
			B4.Name = "B4";
			B4.Size = new Size(75, 510);
			B4.TabIndex = 17;
			B4.Text = "B4";
			B4.TextAlign = ContentAlignment.BottomCenter;
			B4.UseVisualStyleBackColor = false;
			B4.Click += Button_Click;
			B4.MouseDown += Button_MouseDown;
			B4.MouseUp += Button_MouseUp;
			// 
			// C5
			// 
			C5.BackColor = Color.White;
			C5.FlatStyle = FlatStyle.Flat;
			C5.Location = new Point(517, -2);
			C5.Name = "C5";
			C5.Size = new Size(75, 510);
			C5.TabIndex = 18;
			C5.Text = "C5";
			C5.TextAlign = ContentAlignment.BottomCenter;
			C5.UseVisualStyleBackColor = false;
			C5.Click += Button_Click;
			C5.MouseDown += Button_MouseDown;
			C5.MouseUp += Button_MouseUp;
			// 
			// D5
			// 
			D5.BackColor = Color.White;
			D5.FlatStyle = FlatStyle.Flat;
			D5.Location = new Point(590, -2);
			D5.Name = "D5";
			D5.Size = new Size(75, 510);
			D5.TabIndex = 19;
			D5.Text = "D5";
			D5.TextAlign = ContentAlignment.BottomCenter;
			D5.UseVisualStyleBackColor = false;
			D5.Click += Button_Click;
			D5.MouseDown += Button_MouseDown;
			D5.MouseUp += Button_MouseUp;
			// 
			// E5
			// 
			E5.BackColor = Color.White;
			E5.FlatStyle = FlatStyle.Flat;
			E5.Location = new Point(665, -2);
			E5.Name = "E5";
			E5.Size = new Size(75, 510);
			E5.TabIndex = 20;
			E5.Text = "E5";
			E5.TextAlign = ContentAlignment.BottomCenter;
			E5.UseVisualStyleBackColor = false;
			E5.Click += Button_Click;
			E5.MouseDown += Button_MouseDown;
			E5.MouseUp += Button_MouseUp;
			// 
			// F5
			// 
			F5.BackColor = Color.White;
			F5.FlatStyle = FlatStyle.Flat;
			F5.Location = new Point(739, -2);
			F5.Name = "F5";
			F5.Size = new Size(75, 510);
			F5.TabIndex = 21;
			F5.Text = "F5";
			F5.TextAlign = ContentAlignment.BottomCenter;
			F5.UseVisualStyleBackColor = false;
			F5.Click += Button_Click;
			F5.MouseDown += Button_MouseDown;
			F5.MouseUp += Button_MouseUp;
			// 
			// G5
			// 
			G5.BackColor = Color.White;
			G5.FlatStyle = FlatStyle.Flat;
			G5.Location = new Point(813, -2);
			G5.Name = "G5";
			G5.Size = new Size(75, 510);
			G5.TabIndex = 22;
			G5.Text = "G5";
			G5.TextAlign = ContentAlignment.BottomCenter;
			G5.UseVisualStyleBackColor = false;
			G5.Click += Button_Click;
			G5.MouseDown += Button_MouseDown;
			G5.MouseUp += Button_MouseUp;
			// 
			// GS4
			// 
			GS4.BackColor = Color.Black;
			GS4.FlatStyle = FlatStyle.Flat;
			GS4.ForeColor = SystemColors.Control;
			GS4.Location = new Point(343, -2);
			GS4.Name = "GS4";
			GS4.Size = new Size(53, 246);
			GS4.TabIndex = 24;
			GS4.Text = "GS4";
			GS4.TextAlign = ContentAlignment.BottomCenter;
			GS4.UseVisualStyleBackColor = false;
			GS4.Click += Button_Click;
			GS4.MouseDown += Button_MouseDown;
			GS4.MouseUp += Button_MouseUp;
			// 
			// AS4
			// 
			AS4.BackColor = Color.Black;
			AS4.FlatStyle = FlatStyle.Flat;
			AS4.ForeColor = SystemColors.Control;
			AS4.Location = new Point(417, -2);
			AS4.Name = "AS4";
			AS4.Size = new Size(53, 246);
			AS4.TabIndex = 25;
			AS4.Text = "AS4";
			AS4.TextAlign = ContentAlignment.BottomCenter;
			AS4.UseVisualStyleBackColor = false;
			AS4.Click += Button_Click;
			AS4.MouseDown += Button_MouseDown;
			AS4.MouseUp += Button_MouseUp;
			// 
			// DS5
			// 
			DS5.BackColor = Color.Black;
			DS5.FlatStyle = FlatStyle.Flat;
			DS5.ForeColor = SystemColors.Control;
			DS5.Location = new Point(637, -2);
			DS5.Name = "DS5";
			DS5.Size = new Size(53, 246);
			DS5.TabIndex = 26;
			DS5.Text = "DS5";
			DS5.TextAlign = ContentAlignment.BottomCenter;
			DS5.UseVisualStyleBackColor = false;
			DS5.Click += Button_Click;
			DS5.MouseDown += Button_MouseDown;
			DS5.MouseUp += Button_MouseUp;
			// 
			// CS5
			// 
			CS5.BackColor = Color.Black;
			CS5.FlatStyle = FlatStyle.Flat;
			CS5.ForeColor = SystemColors.Control;
			CS5.Location = new Point(565, -2);
			CS5.Name = "CS5";
			CS5.Size = new Size(53, 246);
			CS5.TabIndex = 27;
			CS5.Text = "CS5";
			CS5.TextAlign = ContentAlignment.BottomCenter;
			CS5.UseVisualStyleBackColor = false;
			CS5.Click += Button_Click;
			CS5.MouseDown += Button_MouseDown;
			CS5.MouseUp += Button_MouseUp;
			// 
			// FS5
			// 
			FS5.BackColor = Color.Black;
			FS5.FlatStyle = FlatStyle.Flat;
			FS5.ForeColor = SystemColors.Control;
			FS5.Location = new Point(786, -2);
			FS5.Name = "FS5";
			FS5.Size = new Size(53, 246);
			FS5.TabIndex = 29;
			FS5.Text = "FS5";
			FS5.TextAlign = ContentAlignment.BottomCenter;
			FS5.UseVisualStyleBackColor = false;
			FS5.Click += Button_Click;
			FS5.MouseDown += Button_MouseDown;
			FS5.MouseUp += Button_MouseUp;
			// 
			// PianoPanel
			// 
			PianoPanel.Controls.Add(FS5);
			PianoPanel.Controls.Add(CS5);
			PianoPanel.Controls.Add(DS5);
			PianoPanel.Controls.Add(AS4);
			PianoPanel.Controls.Add(GS4);
			PianoPanel.Controls.Add(CS4);
			PianoPanel.Controls.Add(G5);
			PianoPanel.Controls.Add(DS4);
			PianoPanel.Controls.Add(D5);
			PianoPanel.Controls.Add(FS4);
			PianoPanel.Controls.Add(A4);
			PianoPanel.Controls.Add(E5);
			PianoPanel.Controls.Add(buttonC);
			PianoPanel.Controls.Add(buttonE);
			PianoPanel.Controls.Add(buttonD);
			PianoPanel.Controls.Add(buttonF);
			PianoPanel.Controls.Add(buttonG);
			PianoPanel.Controls.Add(B4);
			PianoPanel.Controls.Add(C5);
			PianoPanel.Controls.Add(F5);
			PianoPanel.Location = new Point(155, 26);
			PianoPanel.Margin = new Padding(3, 2, 3, 2);
			PianoPanel.Name = "PianoPanel";
			PianoPanel.Size = new Size(916, 508);
			PianoPanel.TabIndex = 30;
			// 
			// panel1
			// 
			panel1.Location = new Point(155, 27);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1944, 508);
			panel1.TabIndex = 31;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1095, 550);
			Controls.Add(leftPanel);
			Controls.Add(connectionPanel);
			Controls.Add(topPanel);
			Controls.Add(PianoPanel);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Form1";
			Text = "Piyano";
			KeyDown += Form1_KeyDown;
			KeyUp += Form1_KeyUp;
			leftPanel.ResumeLayout(false);
			connectionPanel.ResumeLayout(false);
			connectionPanel.PerformLayout();
			topPanel.ResumeLayout(false);
			topPanel.PerformLayout();
			PianoPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonF;
		private ListBox listBox1;
		private Button playButton;
		private Panel leftPanel;
		private Button buttonG;
		private Panel connectionPanel;
		private Panel topPanel;
		private Button btnMinimize;
		private Button btnClose;
		private Label isConnected;
		private Label title;
		private Button CS4;
		private Button DS4;
		private Button FS4;
		private Button A4;
		private Button B4;
		private Button C5;
		private Button D5;
		private Button E5;
		private Button F5;
		private Button G5;
		private Button GS4;
		private Button AS4;
		private Button DS5;
		private Button CS5;
		private Button FS5;
        private Panel PianoPanel;
        private Button PianoButton;
        private Button GameButton;
        private Panel panel1;
        private Button StopSongButton;
    }
}