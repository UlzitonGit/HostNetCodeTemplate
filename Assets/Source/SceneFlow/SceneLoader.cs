using Unity.Netcode;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        Lobby,
        TestGameLevel,
    }

    private static Scene _targetScene;
    
    public static void LoadNetwork(Scene scene)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }
    
}
