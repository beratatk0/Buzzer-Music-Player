using System;
using System.Drawing;
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
        SerialPort serialPort = new SerialPort("COM11", 9600);
        Timer timer = new Timer();
        string note = "";
        string playingSong = "";


        private Timer gameTimer = new Timer();
        private int elapsedTime = 0;
        private int score = 0;
        private int nextExpectedOrder = 1; // Sýradaki doðru týklama sýrasý
        private List<Note> activeNotes = new List<Note>();
        private Note[] gameOfThronesNotes;
        private Note[] selectedSong;
        private Note[] twinkleTwinkleNotes;
        private Note[] harryPotterNotes;
        private Note[] merrychristmasNotes;
        private Note[] supermarioNotes;
        bool calmayaDevamEt=true;
        public Form1()
        {
			gameOfThronesNotes = new Note[]
{
	new Note { Freq = 392, Duration = 8,  Time = 0,    Position = 100, Order = 1 },
	new Note { Freq = 262, Duration = 8,  Time = 352,  Position = 300, Order = 2 },
	new Note { Freq = 311, Duration = 16, Time = 704,  Position = 500, Order = 3 },
	new Note { Freq = 349, Duration = 16, Time = 880,  Position = 700, Order = 4 },
	new Note { Freq = 392, Duration = 8,  Time = 1056, Position = 100, Order = 5 },
	new Note { Freq = 262, Duration = 8,  Time = 1408, Position = 300, Order = 6 },
	new Note { Freq = 311, Duration = 16, Time = 1760, Position = 500, Order = 7 },
	new Note { Freq = 349, Duration = 16, Time = 1936, Position = 700, Order = 8 },
	new Note { Freq = 392, Duration = 8,  Time = 2112, Position = 100, Order = 9 },
	new Note { Freq = 262, Duration = 8,  Time = 2464, Position = 300, Order = 10 },
	new Note { Freq = 311, Duration = 16, Time = 2816, Position = 500, Order = 11 },
	new Note { Freq = 349, Duration = 16, Time = 2992, Position = 700, Order = 12 },
	new Note { Freq = 392, Duration = 8,  Time = 3168, Position = 100, Order = 13 },
	new Note { Freq = 262, Duration = 8,  Time = 3520, Position = 300, Order = 14 },
	new Note { Freq = 330, Duration = 16, Time = 3872, Position = 500, Order = 15 },
	new Note { Freq = 349, Duration = 16, Time = 4048, Position = 700, Order = 16 },
	new Note { Freq = 392, Duration = 8,  Time = 4224, Position = 100, Order = 17 },
	new Note { Freq = 262, Duration = 8,  Time = 4576, Position = 300, Order = 18 },
	new Note { Freq = 330, Duration = 16, Time = 4928, Position = 500, Order = 19 },
	new Note { Freq = 349, Duration = 16, Time = 5104, Position = 700, Order = 20 },
	new Note { Freq = 392, Duration = -4, Time = 5280, Position = 100, Order = 21 },
	new Note { Freq = 262, Duration = -4, Time = 6337, Position = 300, Order = 22 },
	new Note { Freq = 311, Duration = 16, Time = 7394, Position = 500, Order = 23 },
	new Note { Freq = 349, Duration = 16, Time = 7570, Position = 700, Order = 24 },
	new Note { Freq = 392, Duration = 4,  Time = 7746, Position = 100, Order = 25 },
	new Note { Freq = 262, Duration = 4,  Time = 8451, Position = 300, Order = 26 },
	new Note { Freq = 311, Duration = 16, Time = 9156, Position = 500, Order = 27 },
	new Note { Freq = 349, Duration = 16, Time = 9332, Position = 700, Order = 28 },
	new Note { Freq = 294, Duration = -1, Time = 9508, Position = 100, Order = 29 },
	new Note { Freq = 349, Duration = -4, Time = 13742, Position = 300, Order = 30 },
	new Note { Freq = 233, Duration = -4, Time = 14799, Position = 500, Order = 31 },
	new Note { Freq = 311, Duration = 16, Time = 15856, Position = 700, Order = 32 },
	new Note { Freq = 294, Duration = 16, Time = 16032, Position = 100, Order = 33 },
	new Note { Freq = 349, Duration = 4,  Time = 16208, Position = 300, Order = 34 },
	new Note { Freq = 233, Duration = -4, Time = 16913, Position = 500, Order = 35 },
	new Note { Freq = 311, Duration = 16, Time = 17970, Position = 700, Order = 36 },
	new Note { Freq = 294, Duration = 16, Time = 18146, Position = 100, Order = 37 },
	new Note { Freq = 262, Duration = -1, Time = 18322, Position = 300, Order = 38 },
	new Note { Freq = 392, Duration = -4, Time = 22556, Position = 500, Order = 39 },
	new Note { Freq = 262, Duration = -4, Time = 23613, Position = 700, Order = 40 },
	new Note { Freq = 311, Duration = 16, Time = 24670, Position = 100, Order = 41 },
	new Note { Freq = 349, Duration = 16, Time = 24846, Position = 300, Order = 42 },
	new Note { Freq = 392, Duration = 8,  Time = 25022, Position = 500, Order = 43 },
	new Note { Freq = 262, Duration = 8,  Time = 25374, Position = 700, Order = 44 },
	new Note { Freq = 330, Duration = 16, Time = 25726, Position = 100, Order = 45 },
	new Note { Freq = 349, Duration = 16, Time = 25902, Position = 300, Order = 46 },
	new Note { Freq = 392, Duration = 8,  Time = 26078, Position = 500, Order = 47 },
	new Note { Freq = 262, Duration = 8,  Time = 26430, Position = 700, Order = 48 },
	new Note { Freq = 330, Duration = 16, Time = 26782, Position = 100, Order = 49 },
	new Note { Freq = 349, Duration = 16, Time = 26958, Position = 300, Order = 50 },
	new Note { Freq = 0,   Duration = 4,  Time = 27134, Position = 500, Order = 51 },
	new Note { Freq = 415, Duration = 16, Time = 27839, Position = 700, Order = 52 },
	new Note { Freq = 466, Duration = 16, Time = 28015, Position = 100, Order = 53 },
	new Note { Freq = 1047,Duration = 8,  Time = 28191, Position = 300, Order = 54 },
	new Note { Freq = 784, Duration = 8,  Time = 28543, Position = 500, Order = 55 },
	new Note { Freq = 831, Duration = 16, Time = 28895, Position = 700, Order = 56 },
	new Note { Freq = 932, Duration = 16, Time = 29071, Position = 100, Order = 57 },
	new Note { Freq = 1047,Duration = 8,  Time = 29247, Position = 300, Order = 58 },
	new Note { Freq = 784, Duration = 16, Time = 29599, Position = 500, Order = 59 },
	new Note { Freq = 831, Duration = 16, Time = 29775, Position = 700, Order = 60 },
	new Note { Freq = 932, Duration = 16, Time = 29951, Position = 100, Order = 61 },
	new Note { Freq = 1047,Duration = 8,  Time = 30127, Position = 300, Order = 62 },
	new Note { Freq = 784, Duration = 8,  Time = 30479, Position = 500, Order = 63 },
	new Note { Freq = 831, Duration = 16, Time = 30831, Position = 700, Order = 64 },
	new Note { Freq = 932, Duration = 16, Time = 31007, Position = 100, Order = 65 },
};

			harryPotterNotes = new Note[] {
	new Note { Freq = 0, Duration = 2, Time = 0, Position = 100, Order = 1 },
	new Note { Freq = 294, Duration = 4, Time = 833, Position = 300, Order = 2 },
	new Note { Freq = 392, Duration = -4, Time = 1249, Position = 500, Order = 3 },
	new Note { Freq = 466, Duration = 8, Time = 1873, Position = 700, Order = 4 },
	new Note { Freq = 440, Duration = 4, Time = 2081, Position = 100, Order = 5 },
	new Note { Freq = 392, Duration = 2, Time = 2497, Position = 300, Order = 6 },
	new Note { Freq = 587, Duration = 4, Time = 3330, Position = 500, Order = 7 },
	new Note { Freq = 523, Duration = -2, Time = 3746, Position = 700, Order = 8 },
	new Note { Freq = 440, Duration = -2, Time = 4995, Position = 100, Order = 9 },
	new Note { Freq = 392, Duration = -4, Time = 6244, Position = 300, Order = 10 },
	new Note { Freq = 466, Duration = 8, Time = 6868, Position = 500, Order = 11 },
	new Note { Freq = 440, Duration = 4, Time = 7076, Position = 700, Order = 12 },
	new Note { Freq = 349, Duration = 2, Time = 7492, Position = 100, Order = 13 },
	new Note { Freq = 415, Duration = 4, Time = 8325, Position = 300, Order = 14 },
	new Note { Freq = 294, Duration = -1, Time = 8741, Position = 500, Order = 15 },
	new Note { Freq = 294, Duration = 4, Time = 11240, Position = 700, Order = 16 },
	new Note { Freq = 392, Duration = -4, Time = 11656, Position = 100, Order = 17 },
	new Note { Freq = 466, Duration = 8, Time = 12280, Position = 300, Order = 18 },
	new Note { Freq = 440, Duration = 4, Time = 12488, Position = 500, Order = 19 },
	new Note { Freq = 392, Duration = 2, Time = 12904, Position = 700, Order = 20 },
	new Note { Freq = 587, Duration = 4, Time = 13737, Position = 100, Order = 21 },
	new Note { Freq = 698, Duration = 2, Time = 14153, Position = 300, Order = 22 },
	new Note { Freq = 659, Duration = 4, Time = 14986, Position = 500, Order = 23 },
	new Note { Freq = 622, Duration = 2, Time = 15402, Position = 700, Order = 24 },
	new Note { Freq = 494, Duration = 4, Time = 16235, Position = 100, Order = 25 },
	new Note { Freq = 622, Duration = -4, Time = 16651, Position = 300, Order = 26 },
	new Note { Freq = 587, Duration = 8, Time = 17275, Position = 500, Order = 27 },
	new Note { Freq = 554, Duration = 4, Time = 17483, Position = 700, Order = 28 },
	new Note { Freq = 277, Duration = 2, Time = 17899, Position = 100, Order = 29 },
	new Note { Freq = 494, Duration = 4, Time = 18732, Position = 300, Order = 30 },
	new Note { Freq = 392, Duration = -1, Time = 19148, Position = 500, Order = 31 },
	new Note { Freq = 466, Duration = 4, Time = 21647, Position = 700, Order = 32 },
	new Note { Freq = 587, Duration = 2, Time = 22063, Position = 100, Order = 33 },
	new Note { Freq = 466, Duration = 4, Time = 22896, Position = 300, Order = 34 },
	new Note { Freq = 587, Duration = 2, Time = 23312, Position = 500, Order = 35 },
	new Note { Freq = 466, Duration = 4, Time = 24145, Position = 700, Order = 36 },
	new Note { Freq = 622, Duration = 2, Time = 24561, Position = 100, Order = 37 },
	new Note { Freq = 587, Duration = 4, Time = 25394, Position = 300, Order = 38 },
	new Note { Freq = 554, Duration = 2, Time = 25810, Position = 500, Order = 39 },
	new Note { Freq = 440, Duration = 4, Time = 26643, Position = 700, Order = 40 },
	new Note { Freq = 466, Duration = -4, Time = 27059, Position = 100, Order = 41 },
	new Note { Freq = 587, Duration = 8, Time = 27683, Position = 300, Order = 42 },
	new Note { Freq = 554, Duration = 4, Time = 27891, Position = 500, Order = 43 },
	new Note { Freq = 277, Duration = 2, Time = 28307, Position = 700, Order = 44 },
	new Note { Freq = 294, Duration = 4, Time = 29140, Position = 100, Order = 45 },
	new Note { Freq = 587, Duration = -1, Time = 29556, Position = 300, Order = 46 },
	new Note { Freq = 0, Duration = 4, Time = 32055, Position = 500, Order = 47 },
	new Note { Freq = 466, Duration = 4, Time = 32471, Position = 700, Order = 48 },
	new Note { Freq = 587, Duration = 2, Time = 32887, Position = 100, Order = 49 },
	new Note { Freq = 466, Duration = 4, Time = 33720, Position = 300, Order = 50 },
	new Note { Freq = 698, Duration = 2, Time = 34136, Position = 500, Order = 51 },
	new Note { Freq = 659, Duration = 4, Time = 34969, Position = 700, Order = 52 },
	new Note { Freq = 622, Duration = 2, Time = 35385, Position = 100, Order = 53 },
	new Note { Freq = 494, Duration = 4, Time = 36218, Position = 300, Order = 54 },
	new Note { Freq = 622, Duration = -4, Time = 36634, Position = 500, Order = 55 },
	new Note { Freq = 587, Duration = 8, Time = 37258, Position = 700, Order = 56 },
	new Note { Freq = 554, Duration = 4, Time = 37466, Position = 100, Order = 57 },
	new Note { Freq = 277, Duration = 2, Time = 37882, Position = 300, Order = 58 },
	new Note { Freq = 466, Duration = 4, Time = 38715, Position = 500, Order = 59 },
	new Note { Freq = 392, Duration = -1, Time = 39131, Position = 700, Order = 60 },
};
			merrychristmasNotes = new Note[] {
	new Note { Freq = 523, Duration = 4, Time = 0,    Position = 100, Order = 1 },
	new Note { Freq = 698, Duration = 4, Time = 428,  Position = 300, Order = 2 },
	new Note { Freq = 698, Duration = 8, Time = 856,  Position = 500, Order = 3 },
	new Note { Freq = 784, Duration = 8, Time = 1070, Position = 700, Order = 4 },
	new Note { Freq = 698, Duration = 8, Time = 1284, Position = 100, Order = 5 },
	new Note { Freq = 659, Duration = 8, Time = 1498, Position = 300, Order = 6 },
	new Note { Freq = 587, Duration = 4, Time = 1712, Position = 500, Order = 7 },
	new Note { Freq = 587, Duration = 4, Time = 2140, Position = 700, Order = 8 },
	new Note { Freq = 587, Duration = 4, Time = 2568, Position = 100, Order = 9 },
	new Note { Freq = 784, Duration = 4, Time = 2996, Position = 300, Order = 10 },
	new Note { Freq = 784, Duration = 8, Time = 3424, Position = 500, Order = 11 },
	new Note { Freq = 880, Duration = 8, Time = 3638, Position = 700, Order = 12 },
	new Note { Freq = 784, Duration = 8, Time = 3852, Position = 100, Order = 13 },
	new Note { Freq = 698, Duration = 8, Time = 4066, Position = 300, Order = 14 },
	new Note { Freq = 659, Duration = 4, Time = 4280, Position = 500, Order = 15 },
	new Note { Freq = 523, Duration = 4, Time = 4708, Position = 700, Order = 16 },
	new Note { Freq = 523, Duration = 4, Time = 5136, Position = 100, Order = 17 },
	new Note { Freq = 880, Duration = 4, Time = 5564, Position = 300, Order = 18 },
	new Note { Freq = 880, Duration = 8, Time = 5992, Position = 500, Order = 19 },
	new Note { Freq = 932, Duration = 8, Time = 6206, Position = 700, Order = 20 },
	new Note { Freq = 880, Duration = 8, Time = 6420, Position = 100, Order = 21 },
	new Note { Freq = 784, Duration = 8, Time = 6634, Position = 300, Order = 22 },
	new Note { Freq = 698, Duration = 4, Time = 6848, Position = 500, Order = 23 },
	new Note { Freq = 587, Duration = 4, Time = 7276, Position = 700, Order = 24 },
	new Note { Freq = 523, Duration = 8, Time = 7704, Position = 100, Order = 25 },
	new Note { Freq = 523, Duration = 8, Time = 7918, Position = 300, Order = 26 },
	new Note { Freq = 587, Duration = 4, Time = 8132, Position = 500, Order = 27 },
	new Note { Freq = 784, Duration = 4, Time = 8560, Position = 700, Order = 28 },
	new Note { Freq = 659, Duration = 4, Time = 8988, Position = 100, Order = 29 },
	new Note { Freq = 698, Duration = 2, Time = 9416, Position = 300, Order = 30 },
	new Note { Freq = 523, Duration = 4, Time = 10273, Position = 500, Order = 31 },
	new Note { Freq = 698, Duration = 4, Time = 10701, Position = 700, Order = 32 },
	new Note { Freq = 698, Duration = 8, Time = 11129, Position = 100, Order = 33 },
	new Note { Freq = 784, Duration = 8, Time = 11343, Position = 300, Order = 34 },
	new Note { Freq = 698, Duration = 8, Time = 11557, Position = 500, Order = 35 },
	new Note { Freq = 659, Duration = 8, Time = 11771, Position = 700, Order = 36 },
	new Note { Freq = 587, Duration = 4, Time = 11985, Position = 100, Order = 37 },
	new Note { Freq = 587, Duration = 4, Time = 12413, Position = 300, Order = 38 },
	new Note { Freq = 587, Duration = 4, Time = 12841, Position = 500, Order = 39 },
	new Note { Freq = 784, Duration = 4, Time = 13269, Position = 700, Order = 40 },
	new Note { Freq = 784, Duration = 8, Time = 13697, Position = 100, Order = 41 },
	new Note { Freq = 880, Duration = 8, Time = 13911, Position = 300, Order = 42 },
	new Note { Freq = 784, Duration = 8, Time = 14125, Position = 500, Order = 43 },
	new Note { Freq = 698, Duration = 8, Time = 14339, Position = 700, Order = 44 },
	new Note { Freq = 659, Duration = 4, Time = 14553, Position = 100, Order = 45 },
	new Note { Freq = 523, Duration = 4, Time = 14981, Position = 300, Order = 46 },
	new Note { Freq = 523, Duration = 4, Time = 15409, Position = 500, Order = 47 },
	new Note { Freq = 880, Duration = 4, Time = 15837, Position = 700, Order = 48 },
	new Note { Freq = 880, Duration = 8, Time = 16265, Position = 100, Order = 49 },
	new Note { Freq = 932, Duration = 8, Time = 16479, Position = 300, Order = 50 },
	new Note { Freq = 880, Duration = 8, Time = 16693, Position = 500, Order = 51 },
	new Note { Freq = 784, Duration = 8, Time = 16907, Position = 700, Order = 52 },
	new Note { Freq = 698, Duration = 4, Time = 17121, Position = 100, Order = 53 },
	new Note { Freq = 587, Duration = 4, Time = 17549, Position = 300, Order = 54 },
	new Note { Freq = 523, Duration = 8, Time = 17977, Position = 500, Order = 55 },
	new Note { Freq = 523, Duration = 8, Time = 18191, Position = 700, Order = 56 },
	new Note { Freq = 587, Duration = 4, Time = 18405, Position = 100, Order = 57 },
	new Note { Freq = 784, Duration = 4, Time = 18833, Position = 300, Order = 58 },
	new Note { Freq = 659, Duration = 4, Time = 19261, Position = 500, Order = 59 },
	new Note { Freq = 698, Duration = 2, Time = 19689, Position = 700, Order = 60 },
	new Note { Freq = 523, Duration = 4, Time = 20546, Position = 100, Order = 61 },
	new Note { Freq = 698, Duration = 4, Time = 20974, Position = 300, Order = 62 },
	new Note { Freq = 698, Duration = 8, Time = 21402, Position = 500, Order = 63 },
	new Note { Freq = 784, Duration = 8, Time = 21616, Position = 700, Order = 64 },
	new Note { Freq = 698, Duration = 8, Time = 21830, Position = 100, Order = 65 },
	new Note { Freq = 659, Duration = 8, Time = 22044, Position = 300, Order = 66 },
	new Note { Freq = 587, Duration = 4, Time = 22258, Position = 500, Order = 67 },
	new Note { Freq = 587, Duration = 4, Time = 22686, Position = 700, Order = 68 },
	new Note { Freq = 587, Duration = 4, Time = 23114, Position = 100, Order = 69 },
	new Note { Freq = 784, Duration = 4, Time = 23542, Position = 300, Order = 70 },
	new Note { Freq = 784, Duration = 8, Time = 23970, Position = 500, Order = 71 },
	new Note { Freq = 880, Duration = 8, Time = 24184, Position = 700, Order = 72 },
	new Note { Freq = 784, Duration = 8, Time = 24398, Position = 100, Order = 73 },
	new Note { Freq = 698, Duration = 8, Time = 24612, Position = 300, Order = 74 },
	new Note { Freq = 659, Duration = 4, Time = 24826, Position = 500, Order = 75 },
	new Note { Freq = 523, Duration = 4, Time = 25254, Position = 700, Order = 76 },
	new Note { Freq = 523, Duration = 4, Time = 25682, Position = 100, Order = 77 },
	new Note { Freq = 880, Duration = 4, Time = 26110, Position = 300, Order = 78 },
	new Note { Freq = 880, Duration = 8, Time = 26538, Position = 500, Order = 79 },
	new Note { Freq = 932, Duration = 8, Time = 26752, Position = 700, Order = 80 },
	new Note { Freq = 880, Duration = 8, Time = 26966, Position = 100, Order = 81 },
	new Note { Freq = 784, Duration = 8, Time = 27180, Position = 300, Order = 82 },
	new Note { Freq = 698, Duration = 4, Time = 27394, Position = 500, Order = 83 },
	new Note { Freq = 587, Duration = 4, Time = 27822, Position = 700, Order = 84 },
	new Note { Freq = 523, Duration = 8, Time = 28250, Position = 100, Order = 85 },
	new Note { Freq = 523, Duration = 8, Time = 28464, Position = 300, Order = 86 },
	new Note { Freq = 587, Duration = 4, Time = 28678, Position = 500, Order = 87 },
	new Note { Freq = 784, Duration = 4, Time = 29106, Position = 700, Order = 88 },
	new Note { Freq = 659, Duration = 4, Time = 29534, Position = 100, Order = 89 },
	new Note { Freq = 698, Duration = 2, Time = 29962, Position = 300, Order = 90 },
	new Note { Freq = 523, Duration = 4, Time = 30819, Position = 500, Order = 91 },
};


			supermarioNotes = new Note[] {
	new Note { Freq = 659, Duration = 8, Time = 0,    Position = 100, Order = 1 },
	new Note { Freq = 659, Duration = 8, Time = 200,  Position = 300, Order = 2 },
	new Note { Freq = 0,   Duration = 8, Time = 400,  Position = 500, Order = 3 },
	new Note { Freq = 659, Duration = 8, Time = 600,  Position = 700, Order = 4 },
	new Note { Freq = 0,   Duration = 8, Time = 800,  Position = 100, Order = 5 },
	new Note { Freq = 523, Duration = 8, Time = 1000, Position = 300, Order = 6 },
	new Note { Freq = 659, Duration = 8, Time = 1200, Position = 500, Order = 7 },
	new Note { Freq = 784, Duration = 4, Time = 1400, Position = 700, Order = 8 },
	new Note { Freq = 0,   Duration = 4, Time = 1800, Position = 100, Order = 9 },
	new Note { Freq = 392, Duration = 8, Time = 2200, Position = 300, Order = 10 },
	new Note { Freq = 0,   Duration = 4, Time = 2400, Position = 500, Order = 11 },
	new Note { Freq = 523, Duration = -4, Time = 2800, Position = 700, Order = 12 },
	new Note { Freq = 392, Duration = 8, Time = 3400, Position = 100, Order = 13 },
	new Note { Freq = 0,   Duration = 4, Time = 3600, Position = 300, Order = 14 },
	new Note { Freq = 330, Duration = -4, Time = 4000, Position = 500, Order = 15 },
	new Note { Freq = 440, Duration = 4, Time = 4600,  Position = 700, Order = 16 },
	new Note { Freq = 494, Duration = 4, Time = 5000,  Position = 100, Order = 17 },
	new Note { Freq = 466, Duration = 8, Time = 5400,  Position = 300, Order = 18 },
	new Note { Freq = 440, Duration = 4, Time = 5600,  Position = 500, Order = 19 },
	new Note { Freq = 392, Duration = -8, Time = 6000, Position = 700, Order = 20 },
	new Note { Freq = 659, Duration = -8, Time = 6300, Position = 100, Order = 21 },
	new Note { Freq = 784, Duration = -8, Time = 6600, Position = 300, Order = 22 },
	new Note { Freq = 880, Duration = 4, Time = 6900,  Position = 500, Order = 23 },
	new Note { Freq = 698, Duration = 8, Time = 7300,  Position = 700, Order = 24 },
	new Note { Freq = 784, Duration = 8, Time = 7500,  Position = 100, Order = 25 },
	new Note { Freq = 0,   Duration = 8, Time = 7700,  Position = 300, Order = 26 },
	new Note { Freq = 659, Duration = 4, Time = 7900,  Position = 500, Order = 27 },
	new Note { Freq = 523, Duration = 8, Time = 8300,  Position = 700, Order = 28 },
	new Note { Freq = 587, Duration = 8, Time = 8500,  Position = 100, Order = 29 },
	new Note { Freq = 494, Duration = -4, Time = 8700, Position = 300, Order = 30 },
	new Note { Freq = 523, Duration = -4, Time = 9300, Position = 500, Order = 31 },
	new Note { Freq = 392, Duration = 8, Time = 9900,  Position = 700, Order = 32 },
	new Note { Freq = 0,   Duration = 4, Time = 10100, Position = 100, Order = 33 },
	new Note { Freq = 330, Duration = -4, Time = 10500,Position = 300, Order = 34 },
	new Note { Freq = 440, Duration = 4, Time = 11100, Position = 500, Order = 35 },
	new Note { Freq = 494, Duration = 4, Time = 11500, Position = 700, Order = 36 },
	new Note { Freq = 466, Duration = 8, Time = 11900, Position = 100, Order = 37 },
	new Note { Freq = 440, Duration = 4, Time = 12100, Position = 300, Order = 38 },
	new Note { Freq = 392, Duration = -8, Time = 12500,Position = 500, Order = 39 },
	new Note { Freq = 659, Duration = -8, Time = 12800,Position = 700, Order = 40 },
	new Note { Freq = 784, Duration = -8, Time = 13100,Position = 100, Order = 41 },
	new Note { Freq = 880, Duration = 4, Time = 13400, Position = 300, Order = 42 },
	new Note { Freq = 698, Duration = 8, Time = 13800, Position = 500, Order = 43 },
	new Note { Freq = 784, Duration = 8, Time = 14000, Position = 700, Order = 44 },
	new Note { Freq = 0,   Duration = 8, Time = 14200, Position = 100, Order = 45 },
	new Note { Freq = 659, Duration = 4, Time = 14400, Position = 300, Order = 46 },
	new Note { Freq = 523, Duration = 8, Time = 14800, Position = 500, Order = 47 },
	new Note { Freq = 587, Duration = 8, Time = 15000, Position = 700, Order = 48 },
	new Note { Freq = 494, Duration = -4, Time = 15200,Position = 100, Order = 49 },
	new Note { Freq = 523, Duration = -4, Time = 15800,Position = 300, Order = 50 },
	new Note { Freq = 784, Duration = 8, Time = 16400, Position = 500, Order = 51 },
	new Note { Freq = 740, Duration = 8, Time = 16600, Position = 700, Order = 52 },
	new Note { Freq = 698, Duration = 8, Time = 16800, Position = 100, Order = 53 },
	new Note { Freq = 622, Duration = 4, Time = 17000, Position = 300, Order = 54 },
	new Note { Freq = 659, Duration = 8, Time = 17400, Position = 500, Order = 55 },
	new Note { Freq = 0,   Duration = 8, Time = 17600, Position = 700, Order = 56 },
	new Note { Freq = 415, Duration = 8, Time = 17800, Position = 100, Order = 57 },
	new Note { Freq = 440, Duration = 8, Time = 18000, Position = 300, Order = 58 },
	new Note { Freq = 262, Duration = 8, Time = 18200, Position = 500, Order = 59 },
	new Note { Freq = 0,   Duration = 8, Time = 18400, Position = 700, Order = 60 },
	new Note { Freq = 440, Duration = 8, Time = 18600, Position = 100, Order = 61 },
	new Note { Freq = 523, Duration = 8, Time = 18800, Position = 300, Order = 62 },
	new Note { Freq = 587, Duration = 8, Time = 19000, Position = 500, Order = 63 },
	new Note { Freq = 0,   Duration = 4, Time = 19200, Position = 700, Order = 64 },
	new Note { Freq = 622, Duration = 4, Time = 19600, Position = 100, Order = 65 },
	new Note { Freq = 0,   Duration = 8, Time = 20000, Position = 300, Order = 66 },
	new Note { Freq = 587, Duration = -4,Time = 20200, Position = 500, Order = 67 },
	new Note { Freq = 523, Duration = 2, Time = 20800, Position = 700, Order = 68 },
	new Note { Freq = 0,   Duration = 2, Time = 21600, Position = 100, Order = 69 },
	new Note { Freq = 784, Duration = 8, Time = 22400, Position = 300, Order = 70 },
	new Note { Freq = 740, Duration = 8, Time = 22600, Position = 500, Order = 71 },
	new Note { Freq = 698, Duration = 8, Time = 22800, Position = 700, Order = 72 },
	new Note { Freq = 622, Duration = 4, Time = 23000, Position = 100, Order = 73 },
	new Note { Freq = 659, Duration = 8, Time = 23400, Position = 300, Order = 74 },
	new Note { Freq = 0,   Duration = 8, Time = 23600, Position = 500, Order = 75 },
	new Note { Freq = 415, Duration = 8, Time = 23800, Position = 700, Order = 76 },
	new Note { Freq = 440, Duration = 8, Time = 24000, Position = 100, Order = 77 },
	new Note { Freq = 262, Duration = 8, Time = 24200, Position = 300, Order = 78 },
	new Note { Freq = 0,   Duration = 8, Time = 24400, Position = 500, Order = 79 },
	new Note { Freq = 440, Duration = 8, Time = 24600, Position = 700, Order = 80 },
	new Note { Freq = 523, Duration = 8, Time = 24800, Position = 100, Order = 81 },
	new Note { Freq = 587, Duration = 8, Time = 25000, Position = 300, Order = 82 },
	new Note { Freq = 0,   Duration = 4, Time = 25200, Position = 500, Order = 83 },
	new Note { Freq = 622, Duration = 4, Time = 25600, Position = 700, Order = 84 },
	new Note { Freq = 0,   Duration = 8, Time = 26000, Position = 100, Order = 85 },
	new Note { Freq = 587, Duration = -4,Time = 26200, Position = 300, Order = 86 },
	new Note { Freq = 523, Duration = 2, Time = 26800, Position = 500, Order = 87 },
	new Note { Freq = 0,   Duration = 2, Time = 27600, Position = 700, Order = 88 },
};


			InitializeComponent();
            this.KeyPreview = true;
            timer.Interval = 500;
            timer.Tick += ConnectArduino;
            timer.Enabled = true;
            timer.Start();


        }
        #endregion

        #region Game
        
        private async Task Play(Note[] selectedSong ,int tempo, int lastNoteOrder)
        {

            int wholenote = (60000 * 4) / tempo;

            if (true)
            {
                for (int i = 0; i < lastNoteOrder; i++)
                {

                    int frequency = selectedSong[i].Freq;
                    int divider = selectedSong[i].Duration;

                    // Süreyi hesapla
                    int noteDuration;
                    if (divider > 0)
                    {
                        noteDuration = wholenote / divider;
                    }
                    else
                    {
                        noteDuration = (int)((wholenote / Math.Abs(divider)) * 1.5);
                    }


                    // CreateFallingButton(selectedSong[i].Position, selectedSong[i].Order);

                    if (noteDuration > 0)
                    {
                        await Task.Delay(noteDuration);
                    }
                    
                }
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime += gameTimer.Interval;

            foreach (Note note in selectedSong)
            {
                if (note.Time <= elapsedTime && !activeNotes.Contains(note))
                {
                    CreateFallingButton(note.Position, note.Order, note);
                    activeNotes.Add(note);
                }
            }

            foreach (var button in panel1.Controls.OfType<Button>().ToList())
            {
                button.Top += 4;

                if (button.Top > panel1.ClientSize.Height)
                {
                    panel1.Controls.Remove(button);
                    int missedOrder = (int)button.Tag; // Tag'den doðru sýrayý al
                    if (missedOrder == nextExpectedOrder)
                    {
                        GameOver(); // Sýradaki doðru nota kaçýrýldýysa oyun biter
                        return;
                    }
                }
            }
        }

        private void CreateFallingButton(int position, int order, Note note)
        {
            var button = new Button
            {
                Name = "C4",
                Size = new Size(50, 50),
                BackColor = Color.Black,
                Left = position,
                Top = 0,
                Tag = order // Doðru sýralama için kullanýlýr
            };

            button.Click += (sender, e) =>
            {
                int clickedOrder = (int)button.Tag; // Butonun sýrasý
                if (clickedOrder == nextExpectedOrder)
                {
                    if (playingSong == "got")
                    {
                        PlaySong(note, gameofthronesTempo, gameOfThronesNotes.Length);
                    }
                    else if(playingSong == "hp")
                    {
                        PlaySong(note, harrypotterTempo, harryPotterNotes.Length);

                    }
                    else if(playingSong == "mc")
                    {
                        PlaySong(note, merrychristmasTempo, harryPotterNotes.Length);

                    }
                    else if(playingSong == "sm")
                    {
						PlaySong(note, supermariotempo, supermarioNotes.Length);

                    }
                    //SendNoteToArduino(note);
                    nextExpectedOrder++; // Sýradaki nota doðruysa sýrayý ilerlet
                    score += 10;
                    panel1.Controls.Remove(button);

                }
                else
                {
                    playingSong = "";
                    GameOver(); // Yanlýþ sýrada butona týklandýysa oyun biter
                }
            };

            panel1.Controls.Add(button);
        }



        private enum GameState
        {
            NotStarted,
            Running,
            Finished
        }

        private GameState gameState = GameState.NotStarted;

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameState == GameState.Finished)
            {
                RestartGame();
            }
            else if (gameState == GameState.Running)
            {

                MessageBox.Show("Oyun yeniden baþlatýlýyor!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestartGame();
            }
            else if (gameState == GameState.NotStarted)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            gameState = GameState.Running;
            elapsedTime = 0;
            score = 0;
            nextExpectedOrder = 1;
            activeNotes.Clear();
            panel1.Controls.Clear();


            gameTimer.Interval = 10;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();


        }

        private void RestartGame()
        {
            gameState = GameState.Running;
            elapsedTime = 0;
            score = 0;
            nextExpectedOrder = 1;
            activeNotes.Clear();
            panel1.Controls.Clear();

            gameTimer.Start();

        }

        private void GameOver()
        {
            gameState = GameState.Finished;
            gameTimer.Stop();
            MessageBox.Show($"Oyun bitti! Skorunuz: {score}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion

        #region Songs
        int gameofthronesTempo = 85;
        //int[] gameofthrones = {
        //   392, 8, 262, 8, 311, 16, 349, 16, 392, 8, 262, 8, 311, 16, 349, 16,
        //    392, 8, 262, 8, 311, 16, 349, 16, 392, 8, 262, 8, 311, 16, 349, 16,
        //    392, 8, 262, 8, 330, 16, 349, 16, 392, 8, 262, 8, 330, 16, 349, 16,
        //    392, 8, 262, 8, 330, 16, 349, 16, 392, 8, 262, 8, 330, 16, 349, 16,
        //    392, -4, 262, -4, 311, 16, 349, 16, 392, 4, 262, 4, 311, 16, 349, 16,
        //    294, -1, 349, -4, 233, -4, 311, 16, 294, 16, 349, 4, 233, -4, 311, 16,
        //    294, 16, 262, -1, 392, -4, 262, -4, 311, 16, 349, 16, 392, 4, 262, 4,      
        //    311, 16, 349, 16, 294, -1, 349, -4, 233, -4, 311, 16, 294, 16, 349, 4,
        //    233, -4, 311, 16, 294, 16, 262, -1, 392, -4, 262, -4, 311, 16, 349, 16,
        //    392, 4, 262, 4, 311, 16, 349, 16, 294, -2, 349, -4, 233, -4, 294, -8,
        //    311, -8, 294, -8, 233, -8, 262, -1, 523, -2, 466, -2, 262, -2, 392, -2,
        //    311, -2, 311, -4, 349, -4, 392, -1, 523, -2, 466, -2, 262, -2, 392, -2,
        //    311, -2, 311, -4, 294, -4, 523, 8, 392, 8, 415, 16, 466, 16, 523, 8,
        //    392, 8, 415, 16, 466, 16, 523, 8, 392, 8, 415, 16, 466, 16, 523, 8,
        //    392, 8, 415, 16, 466, 16, 0, 4, 415, 16, 466, 16, 1047, 8, 784, 8,
        //    831, 16, 932, 16, 1047, 8, 784, 16, 831, 16, 932, 16, 1047, 8, 784, 8,
        //    831, 16, 932, 16
        //};

        int harrypotterTempo = 144;
        //int[] harrypotter = {
        //    0, 2, 294, 4, 392, -4, 466, 8, 440, 4,
        //    392, 2, 587, 4, 523, -2, 440, -2,
        //    392, -4, 466, 8, 440, 4, 349, 2,
        //    415, 4, 294, -1, 294, 4,

        //    392, -4, 466, 8, 440, 4, 392, 2,
        //    587, 4, 698, 2, 659, 4,
        //    622, 2, 494, 4, 622, -4, 587, 8, 554, 4,
        //    277, 2, 494, 4, 392, -1, 466, 4,

        //    587, 2, 466, 4, 587, 2, 466, 4,
        //    622, 2, 587, 4, 554, 2, 440, 4,
        //    466, -4, 587, 8, 554, 4, 277, 2,
        //    294, 4, 587, -1, 0, 4, 466, 4,

        //    587, 2, 466, 4, 587, 2, 466, 4,
        //    698, 2, 659, 4, 622, 2, 494, 4,
        //    622, -4, 587, 8, 554, 4, 277, 2,
        //    466, 4, 392, -1,
        //};

        int merrychristmasTempo = 140;
        //int[] merrychristmas = {
        //    523, 4,
        //    698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
        //    587, 4, 587, 4, 587, 4,
        //    784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
        //    659, 4, 523, 4, 523, 4,
        //    880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
        //    698, 4, 587, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,

        //    698, 2, 523, 4,
        //    698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
        //    587, 4, 587, 4, 587, 4,
        //    784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
        //    659, 4, 523, 4, 523, 4,
        //    880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
        //    698, 4, 587, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 523, 4,

        //    698, 4, 698, 4, 698, 4,
        //    659, 2, 659, 4,
        //    698, 4, 659, 4, 587, 4,
        //    523, 2, 880, 4,
        //    932, 4, 880, 4, 784, 4,
        //    1047, 4, 523, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 523, 4,
        //    698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
        //    587, 4, 587, 4, 587, 4,

        //    784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
        //    659, 4, 523, 4, 523, 4,
        //    880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
        //    698, 4, 587, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 523, 4,
        //    698, 4, 698, 4, 698, 4,
        //    659, 2, 659, 4,
        //    698, 4, 659, 4, 587, 4,

        //    523, 2, 880, 4,
        //    932, 4, 880, 4, 784, 4,
        //    1047, 4, 523, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 523, 4,
        //    698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
        //    587, 4, 587, 4, 587, 4,
        //    784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
        //    659, 4, 523, 4, 523, 4,

        //    880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
        //    698, 4, 587, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 523, 4,
        //    698, 4, 698, 8, 784, 8, 698, 8, 659, 8,
        //    587, 4, 587, 4, 587, 4,
        //    784, 4, 784, 8, 880, 8, 784, 8, 698, 8,
        //    659, 4, 523, 4, 523, 4,

        //    880, 4, 880, 8, 932, 8, 880, 8, 784, 8,
        //    698, 4, 587, 4, 523, 8, 523, 8,
        //    587, 4, 784, 4, 659, 4,
        //    698, 2, 0, 4
        //};

        int supermariotempo = 200;
        //int[] supermario = {
        //    659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 8,
        //    784, 4, 0, 4, 392, 8, 0, 4,
        //    523, -4, 392, 8, 0, 4, 330, -4,
        //    440, 4, 494, 4, 466, 8, 440, 4,
        //    392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
        //    0, 8, 659, 4, 523, 8, 587, 8, 494, -4,
        //    523, -4, 392, 8, 0, 4, 330, -4,
        //    440, 4, 494, 4, 466, 8, 440, 4,
        //    392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
        //    0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

        //    0, 4, 784, 8, 740, 8, 698, 8, 622, 4, 659, 8,
        //    0, 8, 415, 8, 440, 8, 262, 8, 0, 8, 440, 8, 523, 8, 587, 8,
        //    0, 4, 622, 4, 0, 8, 587, -4,
        //    523, 2, 0, 2,

        //    0, 4, 784, 8, 740, 8, 698, 8, 622, 4, 659, 8,
        //    0, 8, 415, 8, 440, 8, 262, 8, 0, 8, 440, 8, 523, 8, 587, 8,
        //    0, 4, 622, 4, 0, 8, 587, -4,
        //    523, 2, 0, 2,

        //    523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
        //    659, 8, 523, 4, 440, 8, 392, 2,

        //    523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 8, 659, 8,
        //    0, 1,
        //    523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
        //    659, 8, 523, 4, 440, 8, 392, 2,
        //    659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 4,
        //    784, 4, 0, 4, 392, 4, 0, 4,
        //    523, -4, 392, 8, 0, 4, 330, -4,
        //    440, 4, 494, 4, 466, 8, 440, 4,
        //    392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
        //    0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

        //    523, -4, 392, 8, 0, 4, 330, -4,
        //    440, 4, 494, 4, 466, 8, 440, 4,
        //    392, -8, 659, -8, 784, -8, 880, 4, 698, 8, 784, 8,
        //    0, 8, 659, 4, 523, 8, 587, 8, 494, -4,

        //    659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
        //    440, 8, 698, 4, 698, 8, 440, 2,
        //    587, -8, 880, -8, 880, -8, 880, -8, 784, -8, 698, -8,

        //    659, 8, 523, 4, 440, 8, 392, 2,
        //    659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
        //    440, 8, 698, 4, 698, 8, 440, 2,
        //    494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
        //    523, 8, 330, 4, 330, 8, 262, 2,

        //    659, 8, 523, 4, 440, 8, 392, 2,
        //    659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
        //    440, 8, 698, 4, 698, 8, 440, 2,
        //    494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
        //    523, 8, 330, 4, 330, 8, 262, 2,
        //    523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 8, 659, 8,
        //    0, 1,

        //    523, 8, 523, 4, 523, 8, 0, 8, 523, 8, 587, 4,
        //    659, 8, 523, 4, 440, 8, 392, 2,
        //    659, 8, 659, 8, 0, 8, 659, 8, 0, 8, 523, 8, 659, 4,
        //    784, 4, 0, 4, 392, 4, 0, 4,
        //    659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
        //    440, 8, 698, 4, 698, 8, 440, 2,
        //    587, -8, 880, -8, 880, -8, 880, -8, 784, -8, 698, -8,

        //    659, 8, 523, 4, 440, 8, 392, 2,
        //    659, 8, 523, 4, 392, 8, 0, 4, 415, 4,
        //    440, 8, 698, 4, 698, 8, 440, 2,
        //    494, 8, 698, 4, 698, 8, 698, -8, 659, -8, 587, -8,
        //    523, 8, 330, 4, 330, 8, 262, 2,

        //    523, -4, 392, -4, 330, 4,
        //    440, -8, 494, -8, 440, -8, 415, -8, 466, -8, 415, -8,
        //    392, 8, 294, 8, 330, -2
        //};


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
            else if (e.KeyCode == Keys.J)
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
        private void SendNoteToArduino(Note note)
        {
            string message = $"{note.Freq},{note.Duration}";

            serialPort.WriteLine(message);

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
            calmayaDevamEt = true;
            if (selected == null)
            {
                MessageBox.Show("Lütfen þarký seçin!");
                return;
            }
            if (selected.ToString() == "Game of Thrones")
            {
                PlaySong(gameOfThronesNotes, gameofthronesTempo, 65);
            }
            else if (selected.ToString() == "Harry Potter")
            {
                PlaySong(harryPotterNotes, harrypotterTempo, 60);
            }
            else if (selected.ToString() == "Merry Christmas")
            {
                PlaySong(merrychristmasNotes, merrychristmasTempo, 91);
            }
            else if (selected.ToString() == "Super Mario")
            {
                PlaySong(supermarioNotes, supermariotempo, 88);
            }

        }

        private async Task PlaySong(Note[] melody, int tempo, int lastNoteOrder)
        {

            int wholenote = (60000 * 4) / tempo;

            if (serialPort.IsOpen)
            {
                for (int i = 0; i < lastNoteOrder; i++)
                {
                    if (calmayaDevamEt)
                    {
                        int frequency = melody[i].Freq;
                        int divider = melody[i].Duration;

                        // Süreyi hesapla
                        int noteDuration;
                        if (divider > 0)
                        {
                            noteDuration = wholenote / divider;
                        }
                        else
                        {
                            noteDuration = (int)((wholenote / Math.Abs(divider)) * 1.5);
                        }


                        string message = $"{frequency},{noteDuration}";
                        serialPort.WriteLine(message);


                        await Task.Delay(noteDuration);
                    }
                    else
                    {
                        return;
                    }

                   
                }
            }
        }
        private async Task PlaySong(Note melody, int tempo, int lastNoteOrder)
        {

            int wholenote = (60000 * 4) / tempo;

            if (serialPort.IsOpen)
            {   
                    if (calmayaDevamEt)
                    {
                        int frequency = melody.Freq;
                        int divider = melody.Duration;

                        // Süreyi hesapla
                        int noteDuration;
                        if (divider > 0)
                        {
                            noteDuration = wholenote / divider;
                        }
                        else
                        {
                            noteDuration = (int)((wholenote / Math.Abs(divider)) * 1.5);
                        }


                        string message = $"{frequency},{noteDuration}";
                        serialPort.WriteLine(message);


                        await Task.Delay(noteDuration);
                    }
                    else
                    {
                        return;
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

        private void PianoButton_Click(object sender, EventArgs e)
        {
            if (PianoPanel.Visible)
            {
                PianoPanel.BringToFront();
            }
            else
            {
                PianoPanel.Visible = true;
                PianoPanel.BringToFront();
            }


        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            try
            {
				if (panel1.Visible)
				{
					panel1.BringToFront();


					var selected = listBox1.SelectedItem;

					if (selected.ToString() == "Game of Thrones")
					{
						playingSong = "got";
						selectedSong = gameOfThronesNotes;
					}
					else if (selected.ToString() == "Harry Potter")
					{
						playingSong = "hp";
						selectedSong = harryPotterNotes;
					}
					else if (selected.ToString() == "Merry Christmas")
					{
						playingSong = "mc";
						selectedSong = merrychristmasNotes;
					}
					else if (selected.ToString() == "Super Mario")
					{
						playingSong = "sm";
						selectedSong = supermarioNotes;
					}

					if (selectedSong == null)
					{
						playingSong = "";
						MessageBox.Show("Lütfen þarký seçin!");
						return;
					}
					if (gameState == GameState.Finished)
					{
						RestartGame();
					}
					else if (gameState == GameState.Running)
					{

						RestartGame();
					}
					else if (gameState == GameState.NotStarted)
					{
						StartGame();
					}
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen bir þarký seçin");
            }
            
        }

        private void StopSongButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                calmayaDevamEt = false;
            }
        }
       
    }
}
