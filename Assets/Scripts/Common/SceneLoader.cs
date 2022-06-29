using GhostHunter.Common;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}