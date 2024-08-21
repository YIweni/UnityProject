using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RESULTMENU : MonoBehaviour
{
    public GameObject resultmenu;
    public GameObject Talkfox;
    public Garbage garbage;
    public GameTimer gametimer;
    [SerializeField] private Text resultText;
    [SerializeField] private Text talk;
    void Start()
    {
        if (resultmenu != null)
        {
            resultmenu.SetActive(false);
        }

        if (resultText != null)
        {
            resultText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        WINTHEGAME();

    }
    public void WINTHEGAME()
    {
        if (garbage.Getpoints() >= 50 && gametimer.GetRemainingTime() >= 0)
        {       resultmenu.SetActive(true);
                Talkfox .SetActive(true);
               resultText.text = "You win the game!";
                resultText.gameObject.SetActive(true);
            talk.text = "thank you!";
           talk.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (gametimer.GetRemainingTime()<=0&&garbage.Getpoints() <= 50)
        {   resultmenu.SetActive(true);
            resultText.text = "You lose the game!";
            resultText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void RESTART()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }


}
