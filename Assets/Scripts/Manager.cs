using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager: MonoBehaviour
{
    public Button quitGame;
    void Start()
    {
        Button btn = quitGame.GetComponent<Button>();
        btn.onClick.AddListener(Exit);
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    private void Exit()
    {
        Application.Quit();
    }



}
