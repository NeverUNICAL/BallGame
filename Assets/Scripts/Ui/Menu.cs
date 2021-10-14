using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _selectLevelPanel;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectLevel()
    {
        _mainPanel.SetActive(false);
        _selectLevelPanel.SetActive(true);
    }

    public void GoBack()
    {
        _selectLevelPanel.SetActive(false);
        _mainPanel.SetActive(true);
    }

    public void ChooseLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
