using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace Mikroislemciler
{

	public partial class Form1 : Form
	{
		#region definitions
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();
		SerialPort serialPort = new SerialPort("COM12", 9600);
		Timer timer = new Timer();
		string note = "";

		public Form1()
		{
			InitializeComponent();
			this.KeyPreview = true;
			timer.Interval = 500;
			timer.Tick += ConnectArduino;
			timer.Enabled = true;
			timer.Start();


		}
		#endregion

		#region Songs
		int gameofthronesTempo = 85;
		int[] gameofthrones = {
			392, 8, 262, 8, 311, 16, 349, 16, 392, 8, 262, 8, 311, 16, 349, 16,
			392, 8, 262, 8, 311, 16, 349, 16, 392, 8, 262, 8, 311, 16, 349, 16,
			392, 8, 262, 8, 330, 16, 349, 16, 392, 8, 262, 8, 330, 16, 349, 16,
			392, 8, 262, 8, 330, 16, 349, 16, 392, 8, 262, 8, 330, 16, 349, 16,
			392, -4, 262, -4, 311, 16, 349, 16, 392, 4, 262, 4, 311, 16, 349, 16,
			294, -1, 349, -4, 233, -4, 311, 16, 294, 16, 349, 4, 233, -4, 311, 16,
			294, 16, 262, -1, 392, -4, 262, -4, 311, 16, 349, 16, 392, 4, 262, 4,
			311, 16, 349, 16, 294, -1, 349, -4, 233, -4, 311, 16, 294, 16, 349, 4,
			233, -4, 311, 16, 294, 16, 262, -1, 392, -4, 262, -4, 311, 16, 349, 16,
			392, 4, 262, 4, 311, 16, 349, 16, 294, -2, 349, -4, 233, -4, 294, -8,
			311, -8, 294, -8, 233, -8, 262, -1, 523, -2, 466, -2, 262, -2, 392, -2,
			311, -2, 311, -4, 349, -4, 392, -1, 523, -2, 466, -2, 262, -2, 392, -2,
			311, -2, 311, -4, 294, -4, 523, 8, 392, 8, 415, 16, 466, 16, 523, 8,
			392, 8, 415, 16, 466, 16, 523, 8, 392, 8, 415, 16, 466, 16, 523, 8,
			392, 8, 415, 16, 466, 16, 0, 4, 415, 16, 466, 16, 1047, 8, 784, 8,
			831, 16, 932, 16, 1047, 8, 784, 16, 831, 16, 932, 16, 1047, 8, 784, 8,
			831, 16, 932, 16
		};

		int harrypotterTempo = 144;
		int[] harrypotter = {
			0, 2, 294, 4, 392, -4, 466, 8, 440, 4,
			392, 2, 587, 4, 523, -2, 440, -2,
			392, -4, 466, 8, 440, 4, 349, 2,
			415, 4, 294, -1, 294, 4,

			392, -4, 466, 8, 440, 4, 392, 2,
			587, 4, 698, 2, 659, 4,
			622, 2, 494, 4, 622, -4, 587, 8, 554, 4,
			277, 2, 494, 4, 392, -1, 466, 4,

			587, 2, 466, 4, 587, 2, 466, 4,
			622, 2, 587, 4, 554, 2, 440, 4,
			466, -4, 587, 8, 554, 4, 277, 2,
			294, 4, 587, -1, 0, 4, 466, 4,

			587, 2, 466, 4, 587, 2, 466, 4,
			698, 2, 659, 4, 622, 2, 494, 4,
			622, -4, 587, 8, 554, 4, 277, 2,
			466, 4, 392, -1,
		};

		int merrychristmasTempo = 140;
		int[] merrychristmas = {
			523, 4,
			698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
			587, 4, 587, 4, 587, 4,
			784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
			659, 4, 523, 4, 523, 4,
			880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
			698, 4, 587, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,

			698, 2, 523, 4,
			698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
			587, 4, 587, 4, 587, 4,
			784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
			659, 4, 523, 4, 523, 4,
			880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
			698, 4, 587, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 523, 4,

			698, 4, 698, 4, 698, 4,
			659, 2, 659, 4,
			698, 4, 659, 4, 587, 4,
			523, 2, 880, 4,
			932, 4, 880, 4, 784, 4,
			1047, 4, 523, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 523, 4,
			698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
			587, 4, 587, 4, 587, 4,

			784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
			659, 4, 523, 4, 523, 4,
			880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
			698, 4, 587, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 523, 4,
			698, 4, 698, 4, 698, 4,
			659, 2, 659, 4,
			698, 4, 659, 4, 587, 4,

			523, 2, 880, 4,
			932, 4, 880, 4, 784, 4,
			1047, 4, 523, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 523, 4,
			698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
			587, 4, 587, 4, 587, 4,
			784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
			659, 4, 523, 4, 523, 4,

			880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
			698, 4, 587, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 523, 4,
			698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
			587, 4, 587, 4, 587, 4,
			784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
			659, 4, 523, 4, 523, 4,

			880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
			698, 4, 587, 4, 523, 8, 523, 8,
			587, 4, 784, 4, 659, 4,
			698, 2, 0, 4
		};

		int supermariotempo = 200;
		int[] supermario = {
			659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 8,
			784, 4, 0, 4, 392, 8, 0, 4,
			523, -4, 392, 8, 0, 4, 330, -4,
			440, 4, 494, 4, 466, 8, 440, 4,
			392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
			0, 8, 659, 4, 523, 8, 587, 8, 494, -4,
			523, -4, 392, 8, 0, 4, 330, -4,
			440, 4, 494, 4, 466, 8, 440, 4,
			392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
			0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

			0, 4, 784, 8, 740, 8, 698, 8, 622, 4, 659, 8,
			0, 8, 415, 8, 440, 8, 262, 8, 0, 8, 440, 8, 523, 8, 587, 8,
			0, 4, 622, 4, 0, 8, 587, -4,
			523, 2, 0, 2,

			0, 4, 784, 8, 740, 8, 698, 8, 622, 4, 659, 8,
			0, 8, 415, 8, 440, 8, 262, 8, 0, 8, 440, 8, 523, 8, 587, 8,
			0, 4, 622, 4, 0, 8, 587, -4,
			523, 2, 0, 2,

			523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
			659, 8, 523, 4, 440, 8, 392, 2,

			523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 8, 659, 8,
			0, 1,
			523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
			659, 8, 523, 4, 440, 8, 392, 2,
			659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 4,
			784, 4, 0, 4, 392, 4, 0, 4,
			523, -4, 392, 8, 0, 4, 330, -4,
			440, 4, 494, 4, 466, 8, 440, 4,
			392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
			0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

			523, -4, 392, 8, 0, 4, 330, -4,
			440, 4, 494, 4, 466, 8, 440, 4,
			392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
			0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

			659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
			440, 8, 698, 4, 698, 8, 440, 2,
			587, -8, 880, -8, 880, -8, 880, -8, 784, -8, 698, -8,

			659, 8, 523, 4, 440, 8, 392, 2,
			659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
			440, 8, 698, 4, 698, 8, 440, 2,
			494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
			523, 8, 330, 4, 330, 8, 262, 2,

			659, 8, 523, 4, 440, 8, 392, 2,
			659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
			440, 8, 698, 4, 698, 8, 440, 2,
			494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
			523, 8, 330, 4, 330, 8, 262, 2,
			523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 8, 659, 8,
			0, 1,

			523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
			659, 8, 523, 4, 440, 8, 392, 2,
			659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 4,
			784, 4, 0, 4, 392, 4, 0, 4,
			659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
			440, 8, 698, 4, 698, 8, 440, 2,
			587, -8, 880, -8, 880, -8, 880, -8, 784, -8, 698, -8,

			659, 8, 523, 4, 440, 8, 392, 2,
			659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
			440, 8, 698, 4, 698, 8, 440, 2,
			494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
			523, 8, 330, 4, 330, 8, 262, 2,

			523, -4, 392, -4, 330, 4,
			440, -8, 494, -8, 440, -8, 415, -8, 466, -8, 415, -8,
			392, 8, 294, 8, 330, -2
		};


		#endregion

		#region ButtonClicks for piano

		private void DragForm(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void Button_Click(object sender, EventArgs e)
		{
			if (sender is Button clickedButton)
			{
				string buttonName = clickedButton.Text;
				SendNoteToArduino("NOTE_" + buttonName);
			}
		}
		private void Button_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is Button clickedButton)
			{
				note = clickedButton.Text;
				if (clickedButton.BackColor != Color.Black)
				{
					clickedButton.BackColor = Color.Aqua;
				}
				string buttonName = clickedButton.Text;
				SendNoteToArduino("NOTE_" + note);

			}


		}

		private void Button_MouseUp(object sender, MouseEventArgs e)
		{
			if (sender is Button clickedButton)
			{
				if (clickedButton.BackColor != Color.Black)
				{
					clickedButton.BackColor = Color.White;
				}
			}
			StopNoteOnArduino();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A)
			{
				SendNoteToArduino("NOTE_C4");
			}
			else if (e.KeyCode == Keys.Q)
			{
				SendNoteToArduino("NOTE_CS4");
			}
			else if (e.KeyCode == Keys.S)
			{
				SendNoteToArduino("NOTE_D4");
			}
			else if (e.KeyCode == Keys.W)
			{
				SendNoteToArduino("NOTE_DS4");
			}
			else if (e.KeyCode == Keys.D)
			{
				SendNoteToArduino("NOTE_E4");
			}
			else if (e.KeyCode == Keys.F)
			{
				SendNoteToArduino("NOTE_F4");
			}
			else if (e.KeyCode == Keys.R)
			{
				SendNoteToArduino("NOTE_FS4");
			}
			else if (e.KeyCode == Keys.G)
			{
				SendNoteToArduino("NOTE_G4");
			}
			else if (e.KeyCode == Keys.T)
			{
				SendNoteToArduino("NOTE_GS4");
			}
			else if (e.KeyCode == Keys.H)
			{
				SendNoteToArduino("NOTE_A4");
			}
			else if (e.KeyCode == Keys.Y)
			{
				SendNoteToArduino("NOTE_AS4");
			}
			else if(e.KeyCode == Keys.J)
			{
				SendNoteToArduino("NOTE_B4");
			}
			else if (e.KeyCode == Keys.K)
			{
				SendNoteToArduino("NOTE_C5");
			}
			else if (e.KeyCode == Keys.I)
			{
				SendNoteToArduino("NOTE_CS5");
			}
			else if (e.KeyCode == Keys.L)
			{
				SendNoteToArduino("NOTE_D5");
			}
			else if (e.KeyCode == Keys.O)
			{
				SendNoteToArduino("NOTE_DS5");
			}
			else if (e.KeyCode == Keys.OemSemicolon)
			{
				SendNoteToArduino("NOTE_E5");
			}
			else if (e.KeyCode == Keys.Oem7)
			{
				SendNoteToArduino("NOTE_F5");
			}
			else if (e.KeyCode == Keys.Oem4)
			{
				SendNoteToArduino("NOTE_F5");
			}
			else if (e.KeyCode == Keys.Oemcomma)
			{
				SendNoteToArduino("NOTE_G5");
			}


		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			StopNoteOnArduino();
		}
		#endregion

		#region Send Note to Arduino and Play Song

		private void StopNoteOnArduino()
		{
			// Sesi durdurmak için boþ bir deðer gönder
			if (serialPort.IsOpen)
			{
				serialPort.WriteLine("");
			}
		}
		private void SendNoteToArduino(string note)
		{

			if (serialPort != null && serialPort.IsOpen)
			{
				serialPort.WriteLine(note);
			}
			else
			{
				MessageBox.Show("Seri port açýk deðil veya geçerli deðil!");
			}
		}
		private void playButton_Click(object sender, EventArgs e)
		{
			var selected = listBox1.SelectedItem;
			if (selected == null)
			{
				MessageBox.Show("Lütfen þarký seçin!");
			}
			if (selected.ToString() == "Game of Thrones")
			{
				PlaySong(gameofthrones, gameofthronesTempo);
			}
			else if (selected.ToString() == "Harry Potter")
			{
				PlaySong(harrypotter, harrypotterTempo);
			}
			else if (selected.ToString() == "Merry Christmas")
			{
				PlaySong(merrychristmas, merrychristmasTempo);
			}
			else if (selected.ToString() == "Super Mario")
			{
				PlaySong(supermario, supermariotempo);
			}


		}

		private async Task PlaySong(int[] melody, int tempo)
		{
			int wholenote = (60000 * 4) / tempo;
			if (serialPort.IsOpen)
			{
				for (int i = 0; i < melody.Length; i += 2)
				{
					int frequency = melody[i];
					int divider = melody[i + 1];
					int noteDuration;

					if (divider > 0)
					{
						noteDuration = wholenote / divider; // Normal süre
					}
					else
					{
						noteDuration = (int)((wholenote / Math.Abs(divider)) * 1.5); // Noktalý nota
					}

					// Frekans ve süreyi Arduino'ya gönder
					string message = $"{frequency},{noteDuration}";
					serialPort.WriteLine(message);

					// Çalma süresine kýsa bir ara ekle
					System.Threading.Thread.Sleep(noteDuration);
				}
			}
		}
		#endregion

		#region connection control and form events
		private void ConnectArduino(object sender, EventArgs e)
		{
			if (serialPort.IsOpen)
			{
				return;
			}
			try
			{
				serialPort.Open();
				isConnected.Text = "Baðlý";
				connectionPanel.BackColor = Color.Green;
			}
			catch (Exception ex)
			{
				isConnected.Text = "Baðlý Deðil " + ex.Message;
				connectionPanel.BackColor = Color.Maroon;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		#endregion

		private void connectionPanel_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
