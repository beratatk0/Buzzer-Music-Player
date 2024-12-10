using System.IO.Ports;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;
namespace Mikroislemciler
{

	public partial class Form1 : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();
		SerialPort serialPort = new SerialPort("COM10", 9600);
		Timer timer = new Timer();

		public Form1()
		{
			InitializeComponent();
			timer.Interval = 500;
			timer.Tick += ConnectArduino;
			timer.Start();
		}
		private void DragForm(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void ButtonC_Click(object sender, EventArgs e)
		{
			SendNoteToArduino("NOTE_C4");
		}

		private void ButtonD_Click(object sender, EventArgs e)
		{
			SendNoteToArduino("NOTE_D4");

		}

		private void ButtonE_Click(object sender, EventArgs e)
		{
			SendNoteToArduino("NOTE_E4");

		}

		private void ButtonF_Click(object sender, EventArgs e)
		{
			SendNoteToArduino("NOTE_F4");

		}

		private void ButtonG_Click(object sender, EventArgs e)
		{
			SendNoteToArduino("NOTE_G4");
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
			if (selected != null)
			{
				if (selected.ToString() == "Game of Thrones")
				{
					SendNoteToArduino("got");
				}
			}

			MessageBox.Show("Lütfen þarký seçin");

		}

		private void ConnectArduino(object? sender, EventArgs e)
		{
			if (serialPort.IsOpen)
			{
				if (timer.Interval < 3000)
				{
					timer.Stop();
					timer.Interval = 3000;
					timer.Start();
				}
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
	}
}
