using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void switchingScene(int indexOfScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(indexOfScene);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != indexOfScene)
        {
            DataController.Instanse.SaveData();
        }
        else
        {
            DataController.Instanse.LoadData();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
