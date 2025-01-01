using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
        SerialPort serialPort = new SerialPort("COM2", 9600);
        Timer timer = new Timer();

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

        public Form1()
        {
            InitializeComponent();


        }
        private void StopNoteOnArduino()
        {
            // Sesi durdurmak i�in bo� bir de�er g�nder
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("");
            }
        }
        private void DragForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        /////////////////////////////////////////////////////////////////////
       
        // HERHANG� B�R BUTONA CL�CK VEYA MOUSEDOWN �ZELL��� ATANACAKSA BUNLAR ATANACAK
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
                string buttonName = clickedButton.Text;
                SendNoteToArduino("NOTE_" + buttonName);

            }


        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            StopNoteOnArduino();
        }


        ///////////////////////////////////////////////////////////////////////////



        private void SendNoteToArduino(string note)
        {

            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(note);
            }
            else
            {
                MessageBox.Show("Seri port a��k de�il veya ge�erli de�il!");
            }
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            var selected = listBox1.SelectedItem;
            if (selected != null)
            {
                if (selected.ToString() == "Game of Thrones")
                {
                    var gotArray = string.Join(',', gameofthrones);
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        serialPort.WriteLine("got");
                    }
                    else
                    {
                        MessageBox.Show("Seri port a��k de�il veya ge�erli de�il!");
                    }
                }
                return;
            }

            MessageBox.Show("L�tfen �ark� se�in");

        }

        private void ConnectArduino()
        {
            if (serialPort.IsOpen)
            {
                return;
            }
            try
            {
                serialPort.Open();
                isConnected.Text = "Ba�l�";
                connectionPanel.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                isConnected.Text = "Ba�l� De�il " + ex.Message;
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



        private void button1_Click(object sender, EventArgs e)
        {
            ConnectArduino();
        }

       
    }
}
