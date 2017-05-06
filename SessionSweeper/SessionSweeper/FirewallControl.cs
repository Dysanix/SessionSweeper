using System;
using System.Runtime.InteropServices;
using System.Text;
using NetFwTypeLib;
using SessionSweeper;

namespace WinFirewall
{
    public class FWCtrl
    {
        const string guidFWPolicy2 = "{E2B3C97F-6AE1-41AC-817A-F6F92166D7DD}";
        const string guidRWRule = "{2C5BC43E-3369-4C33-AB0C-BE9469677AF4}";
        Type typeFWPolicy2 = Type.GetTypeFromCLSID(new Guid(guidFWPolicy2));
        Type typeFWRule = Type.GetTypeFromCLSID(new Guid(guidRWRule));

        public void LockLobby(bool playSound = false)
        {
            INetFwRule newRule = (INetFwRule)Activator.CreateInstance(typeFWRule);
            newRule.Name = "GTA V Session Lock";
            newRule.Description = "GTA V Session Lock";
            newRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            newRule.LocalPorts = "6672,61455,61457,61456,61458";
            newRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            newRule.Enabled = true;
            newRule.Grouping = "@firewallapi.dll,-23255";
            newRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
            fwPolicy2.Rules.Add(newRule);

            if(playSound)
                DataStorage.pLocked.Play();
        }

        public void UnlockLobby(bool playSound = false)
        {
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
            fwPolicy2.Rules.Remove("GTA V Session Lock");

            if (playSound)
                DataStorage.pUnlocked.Play();
        }
    }
}
