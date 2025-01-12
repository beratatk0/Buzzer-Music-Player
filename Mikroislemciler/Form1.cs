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
        SerialPort serialPort = new SerialPort("COM5", 9600);
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
            twinkleTwinkleNotes = new Note[]
           {
                new Note { Time = 0, Position = 100, Order = 1 },
                new Note { Time = 1000, Position = 300, Order = 2 },
                new Note { Time = 2000, Position = 500, Order = 3 },
                new Note { Time = 3000, Position = 100, Order = 4 },
                new Note { Time = 4000, Position = 300, Order = 5 },
                new Note { Time = 5000, Position = 500, Order = 6 },
                new Note { Time = 6000, Position = 100, Order = 7 }
           };


            gameOfThronesNotes = new Note[]
          {
            new Note { Freq = 392, Duration = 8, Time = 0,     Position =   100, Order = 1 },
            new Note { Freq = 262, Duration = 8, Time = 500,  Position =    300, Order = 2 },
            new Note { Freq = 311, Duration = 16, Time = 700, Position =  500, Order = 3 },
            new Note { Freq = 349, Duration = 16, Time = 900, Position =  700, Order = 4 },

            new Note { Freq = 392, Duration = 8, Time = 1100,   Position = 100 , Order = 5 },
            new Note { Freq = 262, Duration = 8, Time = 1600,   Position =  300  , Order = 6 },
            new Note { Freq = 311, Duration = 16, Time = 1800,   Position = 500, Order = 7 },
            new Note { Freq = 349, Duration = 16, Time = 2000,   Position = 700, Order = 8 },

            new Note { Freq = 392, Duration = 8, Time = 2500,   Position =  100, Order = 9 },
            new Note { Freq = 262, Duration = 8, Time = 7000,   Position =  300, Order = 10 },
            new Note { Freq = 311, Duration = 16, Time = 8000,   Position =  500, Order = 11 },
            new Note { Freq = 349, Duration = 16, Time = 9000,  Position =  700, Order = 12 },


            new Note { Freq = 392, Duration = 8, Time = 10000,   Position = 100, Order = 13 },
            new Note { Freq = 262, Duration = 8, Time = 10500,   Position = 300, Order = 14 },
            new Note { Freq = 330, Duration = 16, Time = 11000,   Position = 500, Order = 15 },
            new Note { Freq = 349, Duration = 16, Time = 12706,   Position = 700, Order = 16 },

            new Note { Freq = 392, Duration = 8, Time = 13920,   Position = 100, Order = 17 },
            new Note { Freq = 262, Duration = 8, Time = 17000,   Position = 300, Order = 18 },
            new Note { Freq = 330, Duration = 16, Time = 18080,   Position = 500, Order = 19 },
            new Note { Freq = 349, Duration = 16, Time = 19240,   Position = 700, Order = 20 },

            new Note { Freq = 392, Duration = -4, Time = 20400,   Position = 100, Order = 21 },
            new Note { Freq = 262, Duration = -4, Time = 21360,  Position = 300, Order = 22 },
            new Note { Freq = 311, Duration = 16, Time = 22560,  Position = 500, Order = 23 },
            new Note { Freq = 349, Duration = 16, Time = 23720,   Position = 700, Order = 24 },

            new Note { Freq = 392, Duration = 4, Time = 24880,   Position = 100, Order = 25 },
            new Note { Freq = 262, Duration = 4, Time = 25920  , Position = 300, Order = 26 },
            new Note { Freq = 311, Duration = 16, Time = 26960, Position = 500, Order = 27 },
            new Note { Freq = 349, Duration = 16, Time = 28120, Position = 700, Order = 28 },

            new Note { Freq = 294, Duration = -1, Time = 29280, Position = 100, Order = 29 },
            new Note { Freq = 349, Duration = -4, Time = 30270, Position = 300, Order = 30 },
            new Note { Freq = 233, Duration = -4, Time = 31230, Position = 500, Order = 31 },
            new Note { Freq = 311, Duration = 16, Time = 32440, Position = 700, Order = 32 },

            new Note { Freq = 294, Duration = 16, Time = 33600, Position = 100, Order = 33 },
            new Note { Freq = 349, Duration = 4, Time = 34760, Position = 300, Order = 34 },
            new Note { Freq = 233, Duration = -4, Time = 35720, Position = 500, Order = 35 },
            new Note { Freq = 311, Duration = 16, Time = 36920, Position = 700, Order = 36 },

            new Note { Freq = 294, Duration = 16, Time = 37080, Position = 100, Order = 37 },
            new Note { Freq = 262, Duration = -1, Time = 38240, Position = 300, Order = 38 },
            new Note { Freq = 392, Duration = -4, Time = 39200, Position = 500, Order = 39 },
            new Note { Freq = 262, Duration = -4, Time = 40160, Position = 700, Order = 40 },

            new Note { Freq = 311, Duration = 16, Time = 41320, Position = 100, Order = 41 },
            new Note { Freq = 349, Duration = 16, Time = 42480, Position = 300, Order = 42 },
            new Note { Freq = 392, Duration = 8, Time = 43640,   Position = 500, Order = 43 },
            new Note { Freq = 262, Duration = 8, Time = 44720,   Position = 700, Order = 44 },

            new Note { Freq = 330, Duration = 16, Time = 45800,   Position = 100, Order = 45 },
            new Note { Freq = 349, Duration = 16, Time = 46906,  Position = 300, Order = 46 },
            new Note { Freq = 392, Duration = 8, Time = 48012,   Position = 500, Order = 47 },
            new Note { Freq = 262, Duration = 8, Time = 49020,   Position = 700, Order = 48 },

            new Note { Freq = 330, Duration = 16, Time = 50208,  Position = 100, Order = 49 },
            new Note { Freq = 349, Duration = 16, Time = 51404,  Position = 300, Order = 50 },
            new Note { Freq = 0,   Duration = 4, Time = 52600,     Position = 500, Order = 51 },
            new Note { Freq = 415, Duration = 16, Time = 53064,  Position = 700, Order = 52 },

            new Note { Freq = 466, Duration = 16, Time = 54800,  Position = 100, Order = 53 },
            new Note { Freq = 1047, Duration = 8, Time = 55906,  Position = 300, Order = 54 },
            new Note { Freq = 784, Duration = 8, Time = 56004,   Position = 500, Order = 55 },
            new Note { Freq = 831, Duration = 16, Time = 57012,  Position = 700, Order = 56 },

            new Note { Freq = 932, Duration = 16, Time = 58028,  Position = 100, Order = 57 },
            new Note { Freq = 1047, Duration = 8, Time = 59404,  Position = 300, Order = 58 },
            new Note { Freq = 784, Duration = 16, Time = 60502,  Position = 500, Order = 59 },
            new Note { Freq = 831, Duration = 16, Time = 61608,  Position = 700, Order = 60 },

            new Note { Freq = 932, Duration = 16, Time = 62084,   Position = 100, Order = 61 },
            new Note { Freq = 1047, Duration = 8, Time = 63000,   Position = 300, Order = 62 },
            new Note { Freq = 784, Duration = 8, Time = 64008 , Position = 500, Order = 63 },
            new Note { Freq = 831, Duration = 16, Time = 65016, Position = 700, Order = 64 },

            new Note { Freq = 932, Duration = 16, Time = 66032, Position = 100, Order = 65 }
          };

            harryPotterNotes = new Note[]
        {
            new Note { Freq = 0, Duration = 2,  Time = 0,    Position = 100, Order = 1 },
            new Note { Freq = 294, Duration = 4, Time = 2,      Position = 300, Order = 2 },
            new Note { Freq = 392, Duration = -4, Time = 6,     Position = 500, Order = 3 },
            new Note { Freq = 466, Duration = 8, Time = 12,     Position = 700, Order = 4 },

            new Note { Freq = 440, Duration = 4, Time = 20,     Position = 100,  Order = 5 },
            new Note { Freq = 392, Duration = 2, Time = 24,     Position = 300,  Order = 6 },
            new Note { Freq = 587, Duration = 4, Time = 26,     Position = 500, Order = 7 },
            new Note { Freq = 523, Duration = -2, Time = 30,     Position = 700, Order = 8 },

            new Note { Freq = 440, Duration = -2, Time = 28,    Position = 100,  Order = 9 },
            new Note { Freq = 392, Duration = -4, Time = 24,    Position = 300,  Order = 10 },
            new Note { Freq = 466, Duration = 8, Time = 20,     Position = 500,Order = 11 },
            new Note { Freq = 440, Duration = 4, Time = 28,     Position = 700,Order = 12 },

            new Note { Freq = 349, Duration = 2, Time = 32,     Position = 100, Order = 13 },
            new Note { Freq = 415, Duration = 4, Time = 34,     Position = 300, Order = 14 },
            new Note { Freq = 294, Duration = -1, Time = 38,    Position = 500, Order = 15 },
            new Note { Freq = 294, Duration = 4, Time = 48,     Position = 700,Order = 16 },

            new Note { Freq = 392, Duration = -4, Time = 52,    Position = 100,  Order = 17 },
            new Note { Freq = 466, Duration = 8, Time = 56,     Position = 300, Order = 18 },
            new Note { Freq = 440, Duration = 4, Time = 64,      Position = 500,Order = 19 },
            new Note { Freq = 392, Duration = 2, Time = 68,      Position = 700,Order = 20 },

            new Note { Freq = 587, Duration = 4, Time = 70,  Position = 100,  Order = 21 },
            new Note { Freq = 698, Duration = 2, Time = 74,  Position = 300,  Order = 22 },
            new Note { Freq = 659, Duration = 4, Time = 76,   Position = 500, Order = 23 },
            new Note { Freq = 622, Duration = 2, Time = 80,   Position = 700, Order = 24 },

            new Note { Freq = 494, Duration = 4, Time = 82,  Position = 100,   Order = 25 },
            new Note { Freq = 622, Duration = -4, Time = 86, Position = 300,    Order = 26 },
            new Note { Freq = 587, Duration = 8, Time = 92,   Position = 500,  Order = 27 },
            new Note { Freq = 554, Duration = 4, Time = 100,  Position = 700,   Order = 28 },

            new Note { Freq = 277, Duration = 2, Time = 104,  Position = 100,   Order = 29 },
            new Note { Freq = 494, Duration = 4, Time = 106,  Position = 300,   Order = 30 },
            new Note { Freq = 392, Duration = -1, Time = 110, Position = 500,   Order = 31 },
            new Note { Freq = 466, Duration = 4, Time = 124,   Position = 700,  Order = 32 },

            new Note { Freq = 587, Duration = 2, Time = 128,    Position = 100, Order = 33 },
            new Note { Freq = 466, Duration = 4, Time = 130,    Position = 300, Order = 34 },
            new Note { Freq = 587, Duration = 2, Time = 134,    Position = 500,Order = 35 },
            new Note { Freq = 466, Duration = 4, Time = 136,    Position = 700,Order = 36 },

            new Note { Freq = 622, Duration = 2, Time = 140,    Position = 100, Order = 37 },
            new Note { Freq = 587, Duration = 4, Time = 142,    Position = 300, Order = 38 },
            new Note { Freq = 554, Duration = 2, Time = 146,    Position = 500,Order = 39 },
            new Note { Freq = 440, Duration = 4, Time = 148,    Position = 700,Order = 40 },

            new Note { Freq = 466, Duration = -4, Time = 152,   Position = 100,  Order = 41 },
            new Note { Freq = 587, Duration = 8, Time = 158,    Position = 300, Order = 42 },
            new Note { Freq = 554, Duration = 4, Time = 166,    Position = 500,Order = 43 },
            new Note { Freq = 277, Duration = 2, Time = 170,    Position = 700,Order = 44 },

            new Note { Freq = 294, Duration = 4, Time = 172,     Position = 100, Order = 45 },
            new Note { Freq = 587, Duration = -1, Time = 176,   Position = 300,  Order = 46 },
            new Note { Freq = 0,   Duration = 4, Time = 192,    Position = 500,  Order = 47 },
            new Note { Freq = 466, Duration = 4, Time = 196,     Position = 700,Order = 48 },

            new Note { Freq = 587, Duration = 2, Time = 200,     Position = 100, Order = 49 },
            new Note { Freq = 466, Duration = 4, Time = 202,    Position = 300, Order = 50 },
            new Note { Freq = 698, Duration = 2, Time = 206,      Position = 500,Order = 51 },
            new Note { Freq = 659, Duration = 4, Time = 208,     Position = 700,Order = 52 },

            new Note { Freq = 622, Duration = 2, Time = 212,     Position = 100, Order = 53 },
            new Note { Freq = 494, Duration = 4, Time = 214,    Position = 300, Order = 54 },
            new Note { Freq = 622, Duration = -4, Time = 218,     Position = 500, Order = 55 },
            new Note { Freq = 587, Duration = 8, Time = 224,    Position = 700,Order = 56 },

            new Note { Freq = 554, Duration = 4, Time = 232,     Position = 100, Order = 57 },
            new Note { Freq = 277, Duration = 2, Time = 236,    Position = 300, Order = 58 },
            new Note { Freq = 466, Duration = 4, Time = 238,    Position = 500,Order = 59 },
            new Note { Freq = 392, Duration = -1, Time = 242,   Position = 700, Order = 60 },
        };
            merrychristmasNotes = new Note[]
{
    new Note { Freq = 523, Duration = 4, Time = 0, Position = 1, Order = 1 },
    new Note { Freq = 698, Duration = 4, Time = 4, Position = 2, Order = 2 },
    new Note { Freq = 698, Duration = 8, Time = 8, Position = 3, Order = 3 },
    new Note { Freq = 784, Duration = 8, Time = 16, Position = 4, Order = 4 },
    new Note { Freq = 698, Duration = 8, Time = 24, Position = 5, Order = 5 },
    new Note { Freq = 659, Duration = 8, Time = 32, Position = 6, Order = 6 },
    new Note { Freq = 587, Duration = 4, Time = 40, Position = 7, Order = 7 },
    new Note { Freq = 587, Duration = 4, Time = 44, Position = 8, Order = 8 },
    new Note { Freq = 587, Duration = 4, Time = 48, Position = 9, Order = 9 },
    new Note { Freq = 784, Duration = 4, Time = 52, Position = 10, Order = 10 },
    new Note { Freq = 784, Duration = 8, Time = 56, Position = 11, Order = 11 },
    new Note { Freq = 880, Duration = 8, Time = 64, Position = 12, Order = 12 },
    new Note { Freq = 784, Duration = 8, Time = 72, Position = 13, Order = 13 },
    new Note { Freq = 698, Duration = 8, Time = 80, Position = 14, Order = 14 },
    new Note { Freq = 659, Duration = 4, Time = 88, Position = 15, Order = 15 },
    new Note { Freq = 523, Duration = 4, Time = 92, Position = 16, Order = 16 },
    new Note { Freq = 523, Duration = 4, Time = 96, Position = 17, Order = 17 },
    new Note { Freq = 880, Duration = 4, Time = 100, Position = 18, Order = 18 },
    new Note { Freq = 880, Duration = 8, Time = 104, Position = 19, Order = 19 },
    new Note { Freq = 932, Duration = 8, Time = 112, Position = 20, Order = 20 },
    new Note { Freq = 880, Duration = 8, Time = 120, Position = 21, Order = 21 },
    new Note { Freq = 784, Duration = 8, Time = 128, Position = 22, Order = 22 },
    new Note { Freq = 698, Duration = 4, Time = 136, Position = 23, Order = 23 },
    new Note { Freq = 587, Duration = 4, Time = 140, Position = 24, Order = 24 },
    new Note { Freq = 523, Duration = 8, Time = 144, Position = 25, Order = 25 },
    new Note { Freq = 523, Duration = 8, Time = 152, Position = 26, Order = 26 },
    new Note { Freq = 587, Duration = 4, Time = 160, Position = 27, Order = 27 },
    new Note { Freq = 784, Duration = 4, Time = 164, Position = 28, Order = 28 },
    new Note { Freq = 659, Duration = 4, Time = 168, Position = 29, Order = 29 },
    new Note { Freq = 698, Duration = 2, Time = 172, Position = 30, Order = 30 },
    new Note { Freq = 523, Duration = 4, Time = 174, Position = 31, Order = 31 },
    new Note { Freq = 698, Duration = 4, Time = 178, Position = 32, Order = 32 },
    new Note { Freq = 698, Duration = 8, Time = 182, Position = 33, Order = 33 },
    new Note { Freq = 784, Duration = 8, Time = 190, Position = 34, Order = 34 },
    new Note { Freq = 698, Duration = 8, Time = 198, Position = 35, Order = 35 },
    new Note { Freq = 659, Duration = 8, Time = 206, Position = 36, Order = 36 },
    new Note { Freq = 587, Duration = 4, Time = 214, Position = 37, Order = 37 },
    new Note { Freq = 587, Duration = 4, Time = 218, Position = 38, Order = 38 },
    new Note { Freq = 587, Duration = 4, Time = 222, Position = 39, Order = 39 },
    new Note { Freq = 784, Duration = 4, Time = 226, Position = 40, Order = 40 },
    new Note { Freq = 784, Duration = 8, Time = 230, Position = 41, Order = 41 },
    new Note { Freq = 880, Duration = 8, Time = 238, Position = 42, Order = 42 },
    new Note { Freq = 784, Duration = 8, Time = 246, Position = 43, Order = 43 },
    new Note { Freq = 698, Duration = 8, Time = 254, Position = 44, Order = 44 },
    new Note { Freq = 659, Duration = 4, Time = 262, Position = 45, Order = 45 },
    new Note { Freq = 523, Duration = 4, Time = 266, Position = 46, Order = 46 },
    new Note { Freq = 523, Duration = 4, Time = 270, Position = 47, Order = 47 },
    new Note { Freq = 880, Duration = 4, Time = 274, Position = 48, Order = 48 },
    new Note { Freq = 880, Duration = 8, Time = 278, Position = 49, Order = 49 },
    new Note { Freq = 932, Duration = 8, Time = 286, Position = 50, Order = 50 },
    new Note { Freq = 880, Duration = 8, Time = 294, Position = 51, Order = 51 },
    new Note { Freq = 784, Duration = 8, Time = 302, Position = 52, Order = 52 },
    new Note { Freq = 698, Duration = 4, Time = 310, Position = 53, Order = 53 },
    new Note { Freq = 587, Duration = 4, Time = 314, Position = 54, Order = 54 },
    new Note { Freq = 523, Duration = 8, Time = 318, Position = 55, Order = 55 },
    new Note { Freq = 523, Duration = 8, Time = 326, Position = 56, Order = 56 },
    new Note { Freq = 587, Duration = 4, Time = 334, Position = 57, Order = 57 },
    new Note { Freq = 784, Duration = 4, Time = 338, Position = 58, Order = 58 },
    new Note { Freq = 659, Duration = 4, Time = 342, Position = 59, Order = 59 },
    new Note { Freq = 698, Duration = 2, Time = 346, Position = 60, Order = 60 },
    new Note { Freq = 523, Duration = 4, Time = 348, Position = 61, Order = 61 },
    new Note { Freq = 698, Duration = 4, Time = 352, Position = 62, Order = 62 },
    new Note { Freq = 698, Duration = 8, Time = 360, Position = 63, Order = 63 },
    new Note { Freq = 784, Duration = 8, Time = 368, Position = 64, Order = 64 },
    new Note { Freq = 698, Duration = 8, Time = 376, Position = 65, Order = 65 },
    new Note { Freq = 659, Duration = 8, Time = 384, Position = 66, Order = 66 },
    new Note { Freq = 587, Duration = 4, Time = 392, Position = 67, Order = 67 },
    new Note { Freq = 587, Duration = 4, Time = 396, Position = 68, Order = 68 },
    new Note { Freq = 587, Duration = 4, Time = 400, Position = 69, Order = 69 },
    new Note { Freq = 784, Duration = 4, Time = 404, Position = 70, Order = 70 },
    new Note { Freq = 784, Duration = 8, Time = 408, Position = 71, Order = 71 },
    new Note { Freq = 880, Duration = 8, Time = 416, Position = 72, Order = 72 },
    new Note { Freq = 784, Duration = 8, Time = 424, Position = 73, Order = 73 },
    new Note { Freq = 698, Duration = 8, Time = 432, Position = 74, Order = 74 },
    new Note { Freq = 659, Duration = 4, Time = 440, Position = 75, Order = 75 },
    new Note { Freq = 523, Duration = 4, Time = 444, Position = 76, Order = 76 },
    new Note { Freq = 523, Duration = 4, Time = 448, Position = 77, Order = 77 },
    new Note { Freq = 880, Duration = 4, Time = 452, Position = 78, Order = 78 },
    new Note { Freq = 880, Duration = 8, Time = 456, Position = 79, Order = 79 },
    new Note { Freq = 932, Duration = 8, Time = 464, Position = 80, Order = 80 },
    new Note { Freq = 880, Duration = 8, Time = 472, Position = 81, Order = 81 },
    new Note { Freq = 784, Duration = 8, Time = 480, Position = 82, Order = 82 },
    new Note { Freq = 698, Duration = 4, Time = 488, Position = 83, Order = 83 },
    new Note { Freq = 587, Duration = 4, Time = 492, Position = 84, Order = 84 },
    new Note { Freq = 523, Duration = 8, Time = 496, Position = 85, Order = 85 },
    new Note { Freq = 523, Duration = 8, Time = 504, Position = 86, Order = 86 },
    new Note { Freq = 587, Duration = 4, Time = 512, Position = 87, Order = 87 },
    new Note { Freq = 784, Duration = 4, Time = 516, Position = 88, Order = 88 },
    new Note { Freq = 659, Duration = 4, Time = 520, Position = 89, Order = 89 },
    new Note { Freq = 698, Duration = 2, Time = 524, Position = 90, Order = 90 },
    new Note { Freq = 523, Duration = 4, Time = 526, Position = 91, Order = 91 }
};
            supermarioNotes = new Note[]{
    new Note { Freq = 659, Duration = 8, Time = 0, Position = 1, Order = 1 },
    new Note { Freq = 659, Duration = 8, Time = 8, Position = 2, Order = 2 },
    new Note { Freq = 0, Duration = 8, Time = 16, Position = 3, Order = 3 },
    new Note { Freq = 659, Duration = 8, Time = 24, Position = 4, Order = 4 },
    new Note { Freq = 0, Duration = 8, Time = 32, Position = 5, Order = 5 },
    new Note { Freq = 523, Duration = 8, Time = 40, Position = 6, Order = 6 },
    new Note { Freq = 659, Duration = 8, Time = 48, Position = 7, Order = 7 },
    new Note { Freq = 784, Duration = 4, Time = 56, Position = 8, Order = 8 },
    new Note { Freq = 0, Duration = 4, Time = 60, Position = 9, Order = 9 },
    new Note { Freq = 392, Duration = 8, Time = 64, Position = 10, Order = 10 },
    new Note { Freq = 0, Duration = 4, Time = 72, Position = 11, Order = 11 },
    new Note { Freq = 523, Duration = -4, Time = 76, Position = 12, Order = 12 },
    new Note { Freq = 392, Duration = 8, Time = 80, Position = 13, Order = 13 },
    new Note { Freq = 0, Duration = 4, Time = 88, Position = 14, Order = 14 },
    new Note { Freq = 330, Duration = -4, Time = 92, Position = 15, Order = 15 },
    new Note { Freq = 440, Duration = 4, Time = 96, Position = 16, Order = 16 },
    new Note { Freq = 494, Duration = 4, Time = 100, Position = 17, Order = 17 },
    new Note { Freq = 466, Duration = 8, Time = 104, Position = 18, Order = 18 },
    new Note { Freq = 440, Duration = 4, Time = 112, Position = 19, Order = 19 },
    new Note { Freq = 392, Duration = -8, Time = 116, Position = 20, Order = 20 },
    new Note { Freq = 659, Duration = -8, Time = 124, Position = 21, Order = 21 },
    new Note { Freq = 784, Duration = -8, Time = 132, Position = 22, Order = 22 },
    new Note { Freq = 880, Duration = 4, Time = 140, Position = 23, Order = 23 },
    new Note { Freq = 698, Duration = 8, Time = 148, Position = 24, Order = 24 },
    new Note { Freq = 784, Duration = 8, Time = 156, Position = 25, Order = 25 },
    new Note { Freq = 0, Duration = 8, Time = 164, Position = 26, Order = 26 },
    new Note { Freq = 659, Duration = 4, Time = 172, Position = 27, Order = 27 },
    new Note { Freq = 523, Duration = 8, Time = 176, Position = 28, Order = 28 },
    new Note { Freq = 587, Duration = 8, Time = 184, Position = 29, Order = 29 },
    new Note { Freq = 494, Duration = -4, Time = 192, Position = 30, Order = 30 },
    new Note { Freq = 523, Duration = -4, Time = 200, Position = 31, Order = 31 },
    new Note { Freq = 392, Duration = 8, Time = 208, Position = 32, Order = 32 },
    new Note { Freq = 0, Duration = 4, Time = 216, Position = 33, Order = 33 },
    new Note { Freq = 330, Duration = -4, Time = 220, Position = 34, Order = 34 },
    new Note { Freq = 440, Duration = 4, Time = 224, Position = 35, Order = 35 },
    new Note { Freq = 494, Duration = 4, Time = 228, Position = 36, Order = 36 },
    new Note { Freq = 466, Duration = 8, Time = 232, Position = 37, Order = 37 },
    new Note { Freq = 440, Duration = 4, Time = 240, Position = 38, Order = 38 },
    new Note { Freq = 392, Duration = -8, Time = 244, Position = 39, Order = 39 },
    new Note { Freq = 659, Duration = -8, Time = 252, Position = 40, Order = 40 },
    new Note { Freq = 784, Duration = -8, Time = 260, Position = 41, Order = 41 },
    new Note { Freq = 880, Duration = 4, Time = 268, Position = 42, Order = 42 },
    new Note { Freq = 698, Duration = 8, Time = 276, Position = 43, Order = 43 },
    new Note { Freq = 784, Duration = 8, Time = 284, Position = 44, Order = 44 },
    new Note { Freq = 0, Duration = 8, Time = 292, Position = 45, Order = 45 },
    new Note { Freq = 659, Duration = 4, Time = 300, Position = 46, Order = 46 },
    new Note { Freq = 523, Duration = 8, Time = 304, Position = 47, Order = 47 },
    new Note { Freq = 587, Duration = 8, Time = 312, Position = 48, Order = 48 },
    new Note { Freq = 494, Duration = -4, Time = 320, Position = 49, Order = 49 },
    new Note { Freq = 523, Duration = -4, Time = 328, Position = 50, Order = 50 },

    new Note { Freq = 784, Duration = 8, Time = 336, Position = 51, Order = 51 },
    new Note { Freq = 740, Duration = 8, Time = 344, Position = 52, Order = 52 },
    new Note { Freq = 698, Duration = 8, Time = 352, Position = 53, Order = 53 },
    new Note { Freq = 622, Duration = 4, Time = 360, Position = 54, Order = 54 },
    new Note { Freq = 659, Duration = 8, Time = 368, Position = 55, Order = 55 },
    new Note { Freq = 0, Duration = 8, Time = 376, Position = 56, Order = 56 },
    new Note { Freq = 415, Duration = 8, Time = 384, Position = 57, Order = 57 },
    new Note { Freq = 440, Duration = 8, Time = 392, Position = 58, Order = 58 },
    new Note { Freq = 262, Duration = 8, Time = 400, Position = 59, Order = 59 },
    new Note { Freq = 0, Duration = 8, Time = 408, Position = 60, Order = 60 },
    new Note { Freq = 440, Duration = 8, Time = 416, Position = 61, Order = 61 },
    new Note { Freq = 523, Duration = 8, Time = 424, Position = 62, Order = 62 },
    new Note { Freq = 587, Duration = 8, Time = 432, Position = 63, Order = 63 },
    new Note { Freq = 0, Duration = 4, Time = 440, Position = 64, Order = 64 },
    new Note { Freq = 622, Duration = 4, Time = 444, Position = 65, Order = 65 },
    new Note { Freq = 0, Duration = 8, Time = 452, Position = 66, Order = 66 },
    new Note { Freq = 587, Duration = -4, Time = 460, Position = 67, Order = 67 },
    new Note { Freq = 523, Duration = 2, Time = 468, Position = 68, Order = 68 },
    new Note { Freq = 0, Duration = 2, Time = 472, Position = 69, Order = 69 },

    new Note { Freq = 784, Duration = 8, Time = 476, Position = 70, Order = 70 },
    new Note { Freq = 740, Duration = 8, Time = 484, Position = 71, Order = 71 },
    new Note { Freq = 698, Duration = 8, Time = 492, Position = 72, Order = 72 },
    new Note { Freq = 622, Duration = 4, Time = 500, Position = 73, Order = 73 },
    new Note { Freq = 659, Duration = 8, Time = 508, Position = 74, Order = 74 },
    new Note { Freq = 0, Duration = 8, Time = 516, Position = 75, Order = 75 },
    new Note { Freq = 415, Duration = 8, Time = 524, Position = 76, Order = 76 },
    new Note { Freq = 440, Duration = 8, Time = 532, Position = 77, Order = 77 },
    new Note { Freq = 262, Duration = 8, Time = 540, Position = 78, Order = 78 },
    new Note { Freq = 0, Duration = 8, Time = 548, Position = 79, Order = 79 },
    new Note { Freq = 440, Duration = 8, Time = 556, Position = 80, Order = 80 },
    new Note { Freq = 523, Duration = 8, Time = 564, Position = 81, Order = 81 },
    new Note { Freq = 587, Duration = 8, Time = 572, Position = 82, Order = 82 },

    new Note { Freq = 0, Duration = 4, Time = 580, Position = 83, Order = 83 },
    new Note { Freq = 622, Duration = 4, Time = 584, Position = 84, Order = 84 },
    new Note { Freq = 0, Duration = 8, Time = 592, Position = 85, Order = 85 },
    new Note { Freq = 587, Duration = -4, Time = 600, Position = 86, Order = 86 },
    new Note { Freq = 523, Duration = 2, Time = 608, Position = 87, Order = 87 },
    new Note { Freq = 0, Duration = 2, Time = 612, Position = 88, Order = 88 }
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

        private void StopSongButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                calmayaDevamEt = false;
            }
        }
       
    }
}
