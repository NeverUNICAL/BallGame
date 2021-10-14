using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
