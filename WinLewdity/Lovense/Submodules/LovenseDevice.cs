using Buttplug.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Lovense.Submodules
{
    /// <summary>
    /// Fake extension class for ButtplugClientDevice.
    /// </summary>
    public class LovenseDevice
    {
        /// <summary>
        /// Raw ButtplugClientDevice object that this class attaches to.
        /// </summary>
        public ButtplugClientDevice RawDeviceSocket;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="device"></param>
        public LovenseDevice(ButtplugClientDevice device)
        {
            RawDeviceSocket = device;
        }

        /// <summary>
        /// Determines if the specified device supports vibrations.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool SupportsVibrations()
        {
            return RawDeviceSocket.VibrateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports oscillations.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool SupportsOscillations()
        {
            return RawDeviceSocket.OscillateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports rotational force.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool SupportsRotationalForce()
        {
            return RawDeviceSocket.RotateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports linear force. These devices are commonly called "strokers".
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool SupportsLinearForce()
        {
            return RawDeviceSocket.LinearAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device has a battery or if it requires a direct wall socket connection.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool IsPortableDevice()
        {
            return RawDeviceSocket.HasBattery;
        }

        /// <summary>
        /// Fetches the device's internal name.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public string GetDeviceName()
        {
            return RawDeviceSocket.Name;
        }

        /// <summary>
        /// Fetches the device's user-chosen display name.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public string GetDeviceDisplayName()
        {
            return RawDeviceSocket.DisplayName;
        }

        /// <summary>
        /// Fetches the amount of battery a device has left. For non-portable devices, this will always return 100%.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public async Task<double> GetDeviceBattery()
        {
            if (IsPortableDevice())
            {
                double batteryLeft = await RawDeviceSocket.BatteryAsync();
                return batteryLeft;
            }
            else
            {
                return (double)100;
            }
        }
    }
}