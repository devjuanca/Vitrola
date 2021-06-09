using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.NetworkInformation;

/// <summary>
/// Summary description for NetworkUtil
/// </summary>
public static class NativeMethods
{
    // http://www.codeproject.com/KB/IP/host_info_within_network.aspx
    [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
    static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

    /// <summary>
    /// Gets the MAC address (<see cref="PhysicalAddress"/>) associated with the specified IP.
    /// </summary>
    /// <param name="ipAddress">The remote IP address.</param>
    /// <returns>The remote machine's MAC address.</returns>
    public static PhysicalAddress GetMacAddress(IPAddress ipAddress)
    {
        const int MacAddressLength = 6;
        int length = MacAddressLength;
        var macBytes = new byte[MacAddressLength];
        SendARP(BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0), 0, macBytes, ref length);
        return new PhysicalAddress(macBytes);
    }
}