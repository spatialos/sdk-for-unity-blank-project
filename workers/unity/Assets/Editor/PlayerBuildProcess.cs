using System;
using System.IO;
using System.Linq;
using Assets.Gamelogic.Global;
using Improbable.Unity;
using UnityEditor;
using Improbable.Unity.EditorTools.Build;

namespace Assets.Editor
{
    [InitializeOnLoad]
    public class PlayerBuildProcess : IPlayerBuildEvents
    {
        #region Implement IPlayerBuildEvents

        public string[] GetScenes(WorkerPlatform workerType)
        {
            switch (workerType)
            {
                case WorkerPlatform.UnityClient:
                    return FormatSceneList(BuildSettings.ClientScenes, BuildSettings.ClientDefaultActiveScene);
                case WorkerPlatform.UnityWorker:
                    return FormatSceneList(BuildSettings.WorkerScenes, BuildSettings.WorkerDefaultActiveScene);
                default:
                    throw new Exception("Attempting to get scenes for unrecognised worker platform");
            }
        }

        private string[] FormatSceneList(string[] sceneList, string defaultActiveScene)
        {
            return sceneList.OrderBy(scene => scene != defaultActiveScene).Select(FormatSceneName).ToArray();
        }

        private string FormatSceneName(string sceneName)
        {
            return Path.Combine(BuildSettings.SceneDirectory, sceneName) + ".unity";
        }

        public void BeginBuild() { }

        public void EndBuild() { }

        public void BeginPackage(WorkerPlatform workerType, BuildTarget target, Config config, string packagePath) { }

        #endregion

        static PlayerBuildProcess()
        {
            SimpleBuildSystem.CreatePlayerBuildEventsAction = () => new PlayerBuildProcess();
        }
    }
}
