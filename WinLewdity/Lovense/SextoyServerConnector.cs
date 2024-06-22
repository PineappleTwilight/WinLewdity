using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using WinLewdity.Internal;
using WinLewdity_GUI.Lovense.Submodules;

namespace WinLewdity.Lovense
{
    public class SextoyServerConnector
    {
        /// <summary>
        /// Core buttplug.io API server
        /// </summary>
        public ButtplugClient Client { get; private set; } = new ButtplugClient(Globals.AppName + " Sex Toy Integration");

        /// <summary>
        /// Handles websocket connections
        /// </summary>
        public ButtplugWebsocketConnector Connector { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port"></param>
        public SextoyServerConnector(string ip = "127.0.0.1", int port = 12345, string suffix = "")
        {
            AppLogger.LogInfo(Globals.AppName + " Sex Toy Integration Service v" + Globals.AppVersion);
            try
            {
                AppLogger.LogInfo($"Attempting to connect to websocket server on {ip}:{port}...");
                Connector = new ButtplugWebsocketConnector(new Uri($"ws://{ip}:{port}/{suffix}"));
                var ConnectTask = Client.ConnectAsync(Connector);
                ConnectTask.Wait();
                AppLogger.LogInfo("Sex toy client connection ready for connections!");
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
        public List<LovenseDevice> GetConnectedDevices()
        {
            List<ButtplugClientDevice> rawClients = Client.Devices.ToList();
            List<LovenseDevice> devices = new List<LovenseDevice>();
            foreach (var client in rawClients)
            {
                devices.Add(new LovenseDevice(client));
            }
            return devices;
        }
    }
}