using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            var hw = NoxFind(textBox5.Text);
            if (textBox5.Text == null || (int)hw == 0)
                MSG("핸들을 찾을 수 없습니다");
            else if(textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
                MSG("모든 항목을 입력해 주세요");
            else // 빈 값이 없을 경우
            {
                // 필수값 셋팅
                int w = Convert.ToInt16(textBox1.Text);
                int h = Convert.ToInt16(textBox2.Text);
                int x = Convert.ToInt16(textBox3.Text);
                int y = Convert.ToInt16(textBox4.Text);

                //파일명 지정
                string Winner_tmp = @"\Screen_tmp.bmp";
                string Winner = @"\Screen.bmp";

                // 대상 창 리사이징 및 이동, 캡쳐
                // 듀얼일 경우 [0]주 / [1]부                
                SetWindowPos((int)hw, 0, 0, 0, 720, 490, 0x10);
                Rectangle rect = Screen.PrimaryScreen.Bounds;

                // bitmap 생성
                Bitmap bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.CopyFromScreen(x, y, 0, 0, rect.Size);
                }
                bmp.Save(Winner_tmp);
                bmp.Dispose();

                //bitmap 16비트로 변환
                Bitmap bmp4 = new Bitmap(Winner_tmp);
                var bitmap4 = bmp4.Clone(new Rectangle(0, 0, bmp4.Width, bmp4.Height), PixelFormat.Format4bppIndexed);
                bitmap4.Save(Winner);
                bitmap4.Dispose();
                bmp4.Dispose();
                MSG("완료");
            }
        }

        public static IntPtr NoxFind(string window)
        {
            IntPtr hw1 = FindWindow("Qt5QWindowIcon", window);
            IntPtr hw2 = FindWindowEx(hw1, IntPtr.Zero, null, "ScreenBoardClassWindow");
            IntPtr hw3 = FindWindowEx(hw2, IntPtr.Zero, null, "QWidgetClassWindow");
            return hw1;
        }

        public static void MSG(string message)
        {
            MessageBox.Show(message);
            return;
        }
    }
}
