using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prtTest
{    
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int FindWindow(string IpClassName, string IpWindowName);
        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
        [DllImport("user32")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        public int hw, hw1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hw = FindWindow("NotePad", null);
            if (hw != null) textBox1.Text += hw.ToString() + "\r\n";
            hw1 = FindWindowEx(hw, 0, "Edit", null);
            if (hw1 != null) textBox1.Text += hw1.ToString() + "\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            SetWindowPos(hw, -1, 0, 0, 400, 200, 0x10);
            // 주화면의 크기 정보 읽기
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            // 2nd screen = Screen.AllScreens[1]            

            string outputFilename = "test.bmp";

            // 픽셀 포맷 정보 얻기 (Optional)            
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;

            // 화면 크기만큼의 Bitmap 생성
            //Bitmap bmp = new Bitmap(rect.Width, rect.Height, pixelFormat);
            Bitmap bmp = new Bitmap(720, 450, pixelFormat);
            
            // Bitmap 이미지 변경을 위해 Graphics 객체 생성
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);                
            }

            // Bitmap 데이타를 파일로 저장            
            bmp.Save(outputFilename);
            bmp.Dispose();

            
            Bitmap bitmap4 = new Bitmap(outputFilename);
            var bitmap4bpp = bitmap4.Clone(new Rectangle(0, 0, bitmap4.Width, bitmap4.Height), PixelFormat.Format4bppIndexed);
            bitmap4bpp.Save("TMP.bmp");
        }
    }
}
