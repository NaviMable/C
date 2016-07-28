using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FreshCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202,  //Left mousebutton up            
        }

        public static void NoxClick(IntPtr Id, int X, int Y)
        {
            PostMessage(Id, (int)WMessages.WM_LBUTTONDOWN, 1, new IntPtr(Y * 0x10000 + X));
            PostMessage(Id, (int)WMessages.WM_LBUTTONUP, 0, new IntPtr(Y * 0x10000 + X));
        }

        public static IntPtr NoxFind(string name)
        {
            IntPtr hw1 = FindWindow("Qt5QWindowIcon", name);
            IntPtr hw2 = FindWindowEx(hw1, IntPtr.Zero, null, "ScreenBoardClassWindow");
            IntPtr hw3 = FindWindowEx(hw2, IntPtr.Zero, null, "QWidgetClassWindow");
            return hw3;
        }

        public static void mBox(string msg)
        {
            MessageBox.Show(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hw = NoxFind(textBox1.Text);
            if((int)hw == 0)
            {
                mBox("Nox를 실행 / 창이름을 맞춰주세요");
                return;
            }
            //385 455(-30)
            NoxClick(hw, 585, 424);
            mBox("Nox에 설정화면이 열렸다면 작동가능");
        }
    }
}
