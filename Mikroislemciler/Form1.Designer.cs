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
            button1 = new Button();
            button2 = new Button();
            leftPanel.SuspendLayout();
            connectionPanel.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // buttonC
            // 
            buttonC.Location = new Point(181, 43);
            buttonC.Margin = new Padding(3, 4, 3, 4);
            buttonC.Name = "buttonC";
            buttonC.Size = new Size(75, 661);
            buttonC.TabIndex = 0;
            buttonC.Text = "C4";
            buttonC.UseVisualStyleBackColor = true;
            buttonC.Click += Button_Click;
            buttonC.MouseDown += Button_MouseDown;
            buttonC.MouseUp += Button_MouseUp;
            // 
            // buttonD
            // 
            buttonD.Location = new Point(263, 43);
            buttonD.Margin = new Padding(3, 4, 3, 4);
            buttonD.Name = "buttonD";
            buttonD.Size = new Size(75, 661);
            buttonD.TabIndex = 1;
            buttonD.Text = "D4";
            buttonD.UseVisualStyleBackColor = true;
            buttonD.Click += Button_Click;
            buttonD.MouseDown += Button_MouseDown;
            buttonD.MouseUp += Button_MouseUp;
            // 
            // buttonE
            // 
            buttonE.Location = new Point(345, 43);
            buttonE.Margin = new Padding(3, 4, 3, 4);
            buttonE.Name = "buttonE";
            buttonE.Size = new Size(75, 661);
            buttonE.TabIndex = 2;
            buttonE.Text = "E4";
            buttonE.UseVisualStyleBackColor = true;
            buttonE.Click += Button_Click;
            buttonE.MouseDown += Button_MouseDown;
            buttonE.MouseUp += Button_MouseUp;
            // 
            // buttonF
            // 
            buttonF.Location = new Point(427, 43);
            buttonF.Margin = new Padding(3, 4, 3, 4);
            buttonF.Name = "buttonF";
            buttonF.Size = new Size(75, 661);
            buttonF.TabIndex = 3;
            buttonF.Text = "F4";
            buttonF.UseVisualStyleBackColor = true;
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
            listBox1.Items.AddRange(new object[] { "Game of Thrones", "Super Mario" });
            listBox1.Location = new Point(3, 8);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(156, 82);
            listBox1.TabIndex = 7;
            // 
            // playButton
            // 
            playButton.BackColor = SystemColors.ControlDarkDark;
            playButton.FlatAppearance.BorderSize = 0;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.ForeColor = SystemColors.Control;
            playButton.Location = new Point(73, 98);
            playButton.Margin = new Padding(3, 4, 3, 4);
            playButton.Name = "playButton";
            playButton.Size = new Size(86, 32);
            playButton.TabIndex = 8;
            playButton.Text = "Oynat";
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(61, 61, 61);
            leftPanel.Controls.Add(listBox1);
            leftPanel.Controls.Add(button2);
            leftPanel.Controls.Add(playButton);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 35);
            leftPanel.Margin = new Padding(3, 4, 3, 4);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(174, 677);
            leftPanel.TabIndex = 9;
            // 
            // buttonG
            // 
            buttonG.Location = new Point(510, 43);
            buttonG.Margin = new Padding(3, 4, 3, 4);
            buttonG.Name = "buttonG";
            buttonG.Size = new Size(75, 661);
            buttonG.TabIndex = 10;
            buttonG.Text = "G4";
            buttonG.UseVisualStyleBackColor = true;
            buttonG.Click += Button_Click;
            buttonG.MouseDown += Button_MouseDown;
            buttonG.MouseUp += Button_MouseUp;
            // 
            // connectionPanel
            // 
            connectionPanel.BackColor = Color.Maroon;
            connectionPanel.Controls.Add(isConnected);
            connectionPanel.Dock = DockStyle.Bottom;
            connectionPanel.Location = new Point(0, 712);
            connectionPanel.Margin = new Padding(3, 4, 3, 4);
            connectionPanel.Name = "connectionPanel";
            connectionPanel.Size = new Size(1163, 21);
            connectionPanel.TabIndex = 11;
            // 
            // isConnected
            // 
            isConnected.AutoSize = true;
            isConnected.Dock = DockStyle.Right;
            isConnected.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            isConnected.Location = new Point(1090, 0);
            isConnected.Name = "isConnected";
            isConnected.Size = new Size(73, 19);
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
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1163, 35);
            topPanel.TabIndex = 12;
            topPanel.MouseDown += DragForm;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 162);
            title.ForeColor = SystemColors.Control;
            title.Location = new Point(5, 4);
            title.Name = "title";
            title.Size = new Size(91, 25);
            title.TabIndex = 2;
            title.Text = "2B Piano";
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = SystemColors.Control;
            btnMinimize.Location = new Point(1103, 0);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 35);
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
            btnClose.Location = new Point(1133, 0);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 35);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // button1
            // 
            button1.Location = new Point(789, 94);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "baðla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDarkDark;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(0, 294);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 32);
            button2.TabIndex = 8;
            button2.Text = "Oynat";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 733);
            Controls.Add(button1);
            Controls.Add(buttonG);
            Controls.Add(leftPanel);
            Controls.Add(buttonC);
            Controls.Add(buttonD);
            Controls.Add(buttonE);
            Controls.Add(buttonF);
            Controls.Add(connectionPanel);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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
        private Button button1;
        private Button button2;
    }
}