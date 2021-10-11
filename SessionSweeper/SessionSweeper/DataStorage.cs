using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SessionSweeper
{
    class DataStorage
    {
        public static Process pRDR2;
        public static bool LobbyLocked = false;
        public static bool AntiIdlingActive = false;

        public static WinFirewall.FWCtrl FirewallControl = new WinFirewall.FWCtrl();
        public static MouseEventControl MouseEventControl = new MouseEventControl();

        public static System.Media.SoundPlayer pSweeped = new System.Media.SoundPlayer(Properties.Resources.sweeped);
        public static System.Media.SoundPlayer pPending = new System.Media.SoundPlayer(Properties.Resources.pending);
        public static System.Media.SoundPlayer pUnlocked = new System.Media.SoundPlayer(Properties.Resources.unlocked);
        public static System.Media.SoundPlayer pLocked = new System.Media.SoundPlayer(Properties.Resources.locked);

        public static bool HasAdministrativeRight = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}
