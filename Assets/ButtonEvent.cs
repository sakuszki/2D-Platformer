using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadSpecificLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}