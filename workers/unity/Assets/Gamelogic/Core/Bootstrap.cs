using Improbable.Unity;
using Improbable.Unity.Configuration;
using Improbable.Unity.Core;
using UnityEngine;

// Placed on a GameObject in a Unity scene to execute SpatialOS connection logic on startup.
namespace Assets.Gamelogic.Core
{
    public class Bootstrap : MonoBehaviour
    {
        public WorkerConfigurationData Configuration = new WorkerConfigurationData();

        private void Start()
        {
            SpatialOS.ApplyConfiguration(Configuration);

            Time.fixedDeltaTime = 1.0f / SimulationSettings.FixedFramerate;

            // Distinguishes between when the Unity is running as a client or a server.
            switch (SpatialOS.Configuration.WorkerPlatform)
            {
                case WorkerPlatform.UnityWorker:
                    Application.targetFrameRate = SimulationSettings.TargetServerFramerate;
                    SpatialOS.OnDisconnected += reason => Application.Quit();
                    break;
                case WorkerPlatform.UnityClient:
                    Application.targetFrameRate = SimulationSettings.TargetClientFramerate;
                    SpatialOS.OnConnected += OnSpatialOsConnection;
                    break;
            }

            SpatialOS.Connect(gameObject);
        }

        private static void OnSpatialOsConnection()
        {
            // Add code to handle SpatialOS connection
        }
    }
}
