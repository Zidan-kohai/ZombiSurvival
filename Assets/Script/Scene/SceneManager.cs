using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void switchingScene(int indexOfScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(indexOfScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
