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
			buttonG = new Button();
			connectionPanel = new Panel();
			isConnected = new Label();
			topPanel = new Panel();
			title = new Label();
			btnMinimize = new Button();
			btnClose = new Button();
			leftPanel.SuspendLayout();
			connectionPanel.SuspendLayout();
			topPanel.SuspendLayout();
			SuspendLayout();
			// 
			// buttonC
			// 
			buttonC.Location = new Point(158, 32);
			buttonC.Name = "buttonC";
			buttonC.Size = new Size(66, 496);
			buttonC.TabIndex = 0;
			buttonC.Text = "C";
			buttonC.UseVisualStyleBackColor = true;
			buttonC.Click += ButtonC_Click;
			// 
			// buttonD
			// 
			buttonD.Location = new Point(230, 32);
			buttonD.Name = "buttonD";
			buttonD.Size = new Size(66, 496);
			buttonD.TabIndex = 1;
			buttonD.Text = "D";
			buttonD.UseVisualStyleBackColor = true;
			buttonD.Click += ButtonD_Click;
			// 
			// buttonE
			// 
			buttonE.Location = new Point(302, 32);
			buttonE.Name = "buttonE";
			buttonE.Size = new Size(66, 496);
			buttonE.TabIndex = 2;
			buttonE.Text = "E";
			buttonE.UseVisualStyleBackColor = true;
			buttonE.Click += ButtonE_Click;
			// 
			// buttonF
			// 
			buttonF.Location = new Point(374, 32);
			buttonF.Name = "buttonF";
			buttonF.Size = new Size(66, 496);
			buttonF.TabIndex = 3;
			buttonF.Text = "F";
			buttonF.UseVisualStyleBackColor = true;
			buttonF.Click += ButtonF_Click;
			// 
			// listBox1
			// 
			listBox1.BackColor = SystemColors.ControlDarkDark;
			listBox1.BorderStyle = BorderStyle.FixedSingle;
			listBox1.ForeColor = SystemColors.Window;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Items.AddRange(new object[] { "Game of Thrones", "Super Mario" });
			listBox1.Location = new Point(3, 6);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(137, 452);
			listBox1.TabIndex = 7;
			// 
			// playButton
			// 
			playButton.BackColor = SystemColors.ControlDarkDark;
			playButton.FlatAppearance.BorderSize = 0;
			playButton.FlatStyle = FlatStyle.Flat;
			playButton.ForeColor = SystemColors.Control;
			playButton.Location = new Point(3, 464);
			playButton.Name = "playButton";
			playButton.Size = new Size(75, 24);
			playButton.TabIndex = 8;
			playButton.Text = "Oynat";
			playButton.UseVisualStyleBackColor = false;
			playButton.Click += playButton_Click;
			// 
			// leftPanel
			// 
			leftPanel.BackColor = Color.FromArgb(61, 61, 61);
			leftPanel.Controls.Add(listBox1);
			leftPanel.Controls.Add(playButton);
			leftPanel.Dock = DockStyle.Left;
			leftPanel.Location = new Point(0, 26);
			leftPanel.Name = "leftPanel";
			leftPanel.Size = new Size(152, 508);
			leftPanel.TabIndex = 9;
			// 
			// buttonG
			// 
			buttonG.Location = new Point(446, 32);
			buttonG.Name = "buttonG";
			buttonG.Size = new Size(66, 496);
			buttonG.TabIndex = 10;
			buttonG.Text = "G";
			buttonG.UseVisualStyleBackColor = true;
			buttonG.Click += ButtonG_Click;
			// 
			// connectionPanel
			// 
			connectionPanel.BackColor = Color.Maroon;
			connectionPanel.Controls.Add(isConnected);
			connectionPanel.Dock = DockStyle.Bottom;
			connectionPanel.Location = new Point(0, 534);
			connectionPanel.Name = "connectionPanel";
			connectionPanel.Size = new Size(1018, 16);
			connectionPanel.TabIndex = 11;
			// 
			// isConnected
			// 
			isConnected.AutoSize = true;
			isConnected.Dock = DockStyle.Right;
			isConnected.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
			isConnected.Location = new Point(956, 0);
			isConnected.Name = "isConnected";
			isConnected.Size = new Size(62, 13);
			isConnected.TabIndex = 0;
			isConnected.Text = "Baðlý Deðil";
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
			topPanel.Size = new Size(1018, 26);
			topPanel.TabIndex = 12;
			topPanel.MouseDown += DragForm;
			// 
			// title
			// 
			title.AutoSize = true;
			title.Font = new Font("Lato", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 162);
			title.ForeColor = SystemColors.Control;
			title.Location = new Point(4, 3);
			title.Name = "title";
			title.Size = new Size(72, 19);
			title.TabIndex = 2;
			title.Text = "2B Piano";
			// 
			// btnMinimize
			// 
			btnMinimize.Dock = DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = FlatStyle.Flat;
			btnMinimize.ForeColor = SystemColors.Control;
			btnMinimize.Location = new Point(966, 0);
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
			btnClose.Location = new Point(992, 0);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(26, 26);
			btnClose.TabIndex = 0;
			btnClose.Text = "X";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1018, 550);
			Controls.Add(buttonG);
			Controls.Add(leftPanel);
			Controls.Add(buttonC);
			Controls.Add(buttonD);
			Controls.Add(buttonE);
			Controls.Add(buttonF);
			Controls.Add(connectionPanel);
			Controls.Add(topPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Form1";
			Text = "Piyano";
			leftPanel.ResumeLayout(false);
			connectionPanel.ResumeLayout(false);
			connectionPanel.PerformLayout();
			topPanel.ResumeLayout(false);
			topPanel.PerformLayout();
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
	}
}