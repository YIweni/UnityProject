using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 public   void PauseGame() {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    
    }

 public   void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void GoToMainMenu() {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);


    }
    public void QuitGame()
    {

        Application.Quit();

    }

}
