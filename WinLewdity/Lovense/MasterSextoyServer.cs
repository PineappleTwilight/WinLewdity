using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using WinLewdity.Internal;

namespace WinLewdity.Lovense
{
    public class MasterSextoyServer
    {
        /// <summary>
        /// Core buttplug.io API server
        /// </summary>
        public ButtplugClient Client { get; private set; } = new ButtplugClient("DDOLP Sex Toy Integration");

        /// <summary>
        /// Handles websocket connections
        /// </summary>
        public ButtplugWebsocketConnector Connector { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port"></param>
        public MasterSextoyServer(string ip = "127.0.0.1", int port = 12345, string suffix = "")
        {
            AppLogger.LogInfo("DOLP Sex Toy Integration Service v1.0.0");
            try
            {
                AppLogger.LogInfo($"Attempting to connect to websocket server on {ip}:{port}...");
                Connector = new ButtplugWebsocketConnector(new Uri($"ws://{ip}:{port}/{suffix}"));
                var ConnectTask = Client.ConnectAsync(Connector);
                ConnectTask.Wait();
                AppLogger.LogInfo("Sex toy master server ready for connections!");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Sex toy integration error! Exception: " + ex.InnerException?.InnerException?.Message);
                AppLogger.LogWarning("Sex toy integration will be disabled for this run!");
            }
        }

        /// <summary>
        /// Shuts down the Lovense listener daemon
        /// </summary>
        public async void DisconnectClient()
        {
            await Client.DisconnectAsync();
        }

        /// <summary>
        /// Tells the websocket to scan for any device connection attempts.
        /// </summary>
        public async void StartScanningForDevices()
        {
            await Client.StartScanningAsync();
        }

        /// <summary>
        /// Tells the websocket to stop scanning for device connection attempts.
        /// </summary>
        public async void StopScanningForDevices()
        {
            await Client.StopScanningAsync();
        }

        /// <summary>
        /// Fetches a list of all currently connected devices
        /// </summary>
        /// <returns></returns>
        public List<ButtplugClientDevice> GetConnectedDevices()
        {
            return Client.Devices.ToList();
        }

        /// <summary>
        /// Determines if the specified device supports vibrations.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckVibrationSupport(ButtplugClientDevice device)
        {
            return device.VibrateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports oscillations.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckOscillateSupport(ButtplugClientDevice device)
        {
            return device.OscillateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports rotational force.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckRotationSupport(ButtplugClientDevice device)
        {
            return device.RotateAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device supports linear force.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckLinearSupport(ButtplugClientDevice device)
        {
            return device.LinearAttributes.Count > 0;
        }

        /// <summary>
        /// Determines if the specified device has a battery or if it requires a direct wall socket connection.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool IsPortableDevice(ButtplugClientDevice device)
        {
            return device.HasBattery;
        }

        /// <summary>
        /// Fetches the device's internal name.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public string GetDeviceName(ButtplugClientDevice device)
        {
            return device.Name;
        }

        /// <summary>
        /// Fetches the device's user-chosen display name.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public string GetDeviceDisplayName(ButtplugClientDevice device)
        {
            return device.DisplayName;
        }

        /// <summary>
        /// Fetches the amount of battery a device has left. For non-portable devices, this will always return 100%.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public async Task<double> GetDeviceBattery(ButtplugClientDevice device)
        {
            if (IsPortableDevice(device))
            {
                double batteryLeft = await device.BatteryAsync();
                return batteryLeft;
            }
            else
            {
                return (double)100;
            }
        }
    }
}