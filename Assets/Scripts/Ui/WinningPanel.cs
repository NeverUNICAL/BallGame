using UnityEngine;

public class WinningPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
