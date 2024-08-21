using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 200f; 
    private float elapsedTime = 0f; 

    public Text timeText;
    public Text speedUpText; 
    private bool speedUpAt100Triggered = false;
    private bool speedUpAt5Triggered = false;
    private  Rotate rotateComponent;
    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("TimeText is not assigned in the inspector.");
        }

        speedUpText.gameObject.SetActive(false); 
    }

    void Update()
    {
        
        elapsedTime += Time.deltaTime;

   
        float remainingTime = totalTime - elapsedTime;

        if (timeText != null)
        {
            int seconds = Mathf.CeilToInt(remainingTime);
            timeText.text = "Time:" + seconds.ToString();
        }

        if (remainingTime <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (remainingTime <= 150f && !speedUpAt100Triggered)
        {
            SpeedUpObject(3.5f);
            ShowSpeedUpText("Speed up!");
            speedUpAt100Triggered = true;
        }

        if (remainingTime <= 70f && !speedUpAt5Triggered)
        {
            SpeedUpObject(5f);
            ShowSpeedUpText("Speed up!");
            speedUpAt5Triggered = true;
        }
    }
    public void DeductTime(float seconds) { 
    totalTime -= seconds;
        if (totalTime<0f)totalTime = 0f;
        HighlightTimeText();
    }
    private void HighlightTimeText()
    {
        StartCoroutine(FlashTimeText());
    }

    private IEnumerator FlashTimeText()
    {
        Color originalColor = timeText.color;
        timeText.color = Color.red;
        timeText.fontStyle = FontStyle.Bold;
        yield return new WaitForSeconds(1f);
        timeText.color = originalColor;
        timeText.fontStyle = FontStyle.Bold;
    }
    private void SpeedUpObject(float newSpeed)
    {
        if (rotateComponent != null)
        {
            rotateComponent.SetSpeed(newSpeed);
        }
    }

    private void ShowSpeedUpText(string message)
    {
        StartCoroutine(DisplaySpeedUpText(message));
    }

    private IEnumerator DisplaySpeedUpText(string message)
    {
        speedUpText.text = message;
        speedUpText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        speedUpText.gameObject.SetActive(false);
    }
    public float GetRemainingTime()
    {
        return totalTime - elapsedTime;
    }

}