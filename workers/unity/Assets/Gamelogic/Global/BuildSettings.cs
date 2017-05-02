
namespace Assets.Gamelogic.Global
{
    public static class BuildSettings
    {
        public static readonly string UnityClientScene = "UnityClient";
        public static readonly string UnityWorkerScene = "UnityWorker";
        public static readonly string[] ClientScenes = { UnityClientScene };
        public static readonly string[] WorkerScenes = { UnityWorkerScene };
        public static readonly string ClientDefaultActiveScene = UnityClientScene;
        public static readonly string WorkerDefaultActiveScene = UnityWorkerScene;
        public const string SceneDirectory = "Assets";
    }
}
