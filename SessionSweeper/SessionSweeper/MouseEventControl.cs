using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionSweeper
{
    //https://alala666888.wordpress.com/2010/09/17/simulate-mouse-event-using-sendinput-and-setcursorpos/
    public class MouseEventControl : IDisposable
    {
        private Timer _timer = new Timer();
        private int _mouseMove = _screenWidth / 4 * (65535 / _screenWidth);
        private bool _isMouseMove = false;
        private static int _screenWidth = GetSystemMetrics(SM_CXSCREEN) - 1;
        private static int _screenHeight = GetSystemMetrics(SM_CYSCREEN) - 1;
        private static int _halfScreenX = _screenWidth / 2 * (65535 / _screenWidth);
        private static int _halfScreenY = _screenHeight / 2 * (65535 / _screenHeight);

        public MouseEventControl()
        {
            _timer.Interval = 15000;
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (!_isMouseMove)
            {
                INPUT input = new INPUT();
                input.type = SendInputEventType.InputMouse;
                input.mkhi.mi.dwFlags = MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE;
                input.mkhi.mi.dx = _halfScreenX + _mouseMove;
                input.mkhi.mi.dy = _halfScreenY;
                uint i = SendInput(1, ref input, Marshal.SizeOf(new INPUT()));

                _isMouseMove = !_isMouseMove;
            }
            else
            {
                INPUT input = new INPUT();
                input.type = SendInputEventType.InputMouse;
                input.mkhi.mi.dwFlags = MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE;
                input.mkhi.mi.dx = _halfScreenX - _mouseMove;
                input.mkhi.mi.dy = _halfScreenY;
                uint i = SendInput(1, ref input, Marshal.SizeOf(new INPUT()));

                _isMouseMove = !_isMouseMove;
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            _timer.Tick -= OnTimerTick;
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);

        static int SM_CXSCREEN = 0;
        static int SM_CYSCREEN = 1;

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        /// <summary>
        /// The event type contained in the union field
        /// </summary>
        enum SendInputEventType : int
        {
            /// <summary>
            /// Contains Mouse event data
            /// </summary>
            InputMouse,
            /// <summary>
            /// Contains Keyboard event data
            /// </summary>
            InputKeyboard,
            /// <summary>
            /// Contains Hardware event data
            /// </summary>
            InputHardware
        }


        /// <summary>
        /// The mouse data structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct MouseInputData
        {
            /// <summary>
            /// The x value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
            /// otherwise it is a delta from the last position
            /// </summary>
            public int dx;
            /// <summary>
            /// The y value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
            /// otherwise it is a delta from the last position
            /// </summary>
            public int dy;
            /// <summary>
            /// Wheel event data, X buttons
            /// </summary>
            public uint mouseData;
            /// <summary>
            /// ORable field with the various flags about buttons and nature of event
            /// </summary>
            public MouseEventFlags dwFlags;
            /// <summary>
            /// The timestamp for the event, if zero then the system will provide
            /// </summary>
            public uint time;
            /// <summary>
            /// Additional data obtained by calling app via GetMessageExtraInfo
            /// </summary>
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        /// <summary>
        /// Captures the union of the three three structures.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        struct MouseKeybdhardwareInputUnion
        {
            /// <summary>
            /// The Mouse Input Data
            /// </summary>
            [FieldOffset(0)]
            public MouseInputData mi;

            /// <summary>
            /// The Keyboard input data
            /// </summary>
            [FieldOffset(0)]
            public KEYBDINPUT ki;

            /// <summary>
            /// The hardware input data
            /// </summary>
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        /// <summary>
        /// The Data passed to SendInput in an array.
        /// </summary>
        /// <remarks>Contains a union field type specifies what it contains </remarks>
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            /// <summary>
            /// The actual data type contained in the union Field
            /// </summary>
            public SendInputEventType type;
            public MouseKeybdhardwareInputUnion mkhi;
        }
    }

    /*public class MouseEventControl : IDisposable
    {
        private Timer _timer = new Timer();
        private int _mouseMax = 1000;
        private int _mouseMin = 0;
        private int _lastVal = 0;

        public MouseEventControl()
        {
            _timer.Interval = 1000;
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if(_lastVal==_mouseMin)
            {
                MousePoint mp = new MousePoint(_mouseMax, 0);
                MouseEvent(MouseEventFlags.Move, mp);
                _lastVal = _mouseMax;
            }
            else if (_lastVal == _mouseMin)
            {
                MousePoint mp = new MousePoint(_mouseMin, 0);
                MouseEvent(MouseEventFlags.Move, mp);
                _lastVal = _mouseMin;
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void MouseEvent(MouseEventFlags value, MousePoint position)
        {
            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        public void Dispose()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            _timer.Tick -= OnTimerTick;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }*/
}
