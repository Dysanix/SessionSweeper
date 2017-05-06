using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SessionSweeper
{
    public partial class fMain : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public fMain()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, 0, 0, Keys.Pause.GetHashCode());
            RegisterHotKey(this.Handle, 1, 0, Keys.Scroll.GetHashCode());
            DataStorage.FirewallControl.UnlockLobby();
            FormClosing += fMain_Closing;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                if (isGTAVRunning())
                {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    int id = m.WParam.ToInt32();

                    if (key == Keys.Pause)
                    {
                        SweepSession();
                    }
                    else if (key == Keys.Scroll)
                    {
                        ToggleLockSession();
                    }
                }
                else
                {
                    Activate();
                    MessageBox.Show("GTA V was not detected!", "SessionSweeper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool isGTAVRunning()
        {
            bool isRunning = false;
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Equals("GTA5"))
                {
                    isRunning = true;
                    DataStorage.pGTAV = process;
                    break;
                }
            }
            return isRunning;
        }

        private void SweepSession()
        {
            if (isGTAVRunning())
            {
                if (!tmrResume.Enabled)
                {
                    DataStorage.pPending.Play();
                    Toolkit.SuspendProcess(DataStorage.pGTAV.Id);
                    tmrResume.Start();
                }
            }
            else
            {
                Activate();
                MessageBox.Show("GTA V was not detected!", "SessionSweeper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleLockSession()
        {
            if (!DataStorage.HasAdministrativeRight) { return; }
            if (isGTAVRunning())
            {
                if (DataStorage.LobbyLocked)
                {
                    DataStorage.FirewallControl.UnlockLobby(true);
                    lblSessionStatus.BackColor = Color.Green;
                    lblSessionStatus.Text = "Session is unlocked!";
                }
                else
                {
                    DataStorage.FirewallControl.LockLobby(true);
                    lblSessionStatus.BackColor = Color.Red;
                    lblSessionStatus.Text = "Session is locked!";
                }
                DataStorage.LobbyLocked = !DataStorage.LobbyLocked;
            }
            else
            {
                Activate();
                MessageBox.Show("GTA V was not detected!", "SessionSweeper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrResume_Tick(object sender, EventArgs e)
        {
            Toolkit.ResumeProcess(DataStorage.pGTAV.Id);
            DataStorage.pSweeped.Play();
            tmrResume.Stop();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            if (!DataStorage.HasAdministrativeRight)
            {
                lblSessionStatus.Text = "Run as admin to lock sessions!";
                lblSessionStatus.BackColor = Color.Red;
                lblLockSessionInfo.Font = new Font(lblLockSessionInfo.Font, FontStyle.Strikeout);
                btnScrollLock.Enabled = false;
            }
        }

        private void fMain_Closing(object sender, CancelEventArgs e)
        {
            DataStorage.FirewallControl.UnlockLobby();
            UnregisterHotKey(this.Handle, 0);
            UnregisterHotKey(this.Handle, 1);
        }

        private void btnPauseBreak_Click(object sender, EventArgs e)
        {
            SweepSession();
        }

        private void btnScrollLock_Click(object sender, EventArgs e)
        {
            ToggleLockSession();
        }
    }
}
