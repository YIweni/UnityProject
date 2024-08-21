using UnityEngine;
using System.Collections;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel; 
    public float displayDuration = 2f;
    public float fadeDuration = 1f;

    private CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            return;
        }
        Time.timeScale = 0f;
        StartCoroutine(ShowPanelForSeconds(displayDuration));
    }

    IEnumerator ShowPanelForSeconds(float seconds)
    {
        panel.SetActive(true); 
        yield return new WaitForSecondsRealtime(seconds);
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            canvasGroup.alpha = 1f - (elapsedTime / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0f;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}