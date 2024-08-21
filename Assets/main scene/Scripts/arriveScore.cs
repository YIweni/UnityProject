using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arriveScore : MonoBehaviour
{
    public Garbage garbage;
    public Animator foxAnimator;
    private bool hasCelebrated = false;

    void Start()
    {
        if (garbage == null)
        {
            Debug.LogError("Garbage reference is not set.");
        }
        if (foxAnimator == null)
        {
            Debug.LogError("Animator reference is not set.");
        }
    }

    void Update()
    {
        if (garbage.Getpoints() >= 10 && !hasCelebrated)
        {
            StartCoroutine(HandleAnimationAndStopGame());
            hasCelebrated = true;
        }
    }

    IEnumerator HandleAnimationAndStopGame()
    {
        foxAnimator.SetTrigger("Celebrate");
        yield return new WaitForSeconds(5f);
        StopGame();
    }

    void StopGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}