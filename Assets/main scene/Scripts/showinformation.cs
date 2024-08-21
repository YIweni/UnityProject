using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showinformation : MonoBehaviour
{
    public GameObject information;
    public float displayDuration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        information.SetActive(false);
        StartCoroutine(ShowPanelForSeconds(displayDuration));
    }

    // Update is called once per frame
    public void OnMouseEnterButton(string buttonText)
    {
        information.SetActive(true);
    }
    public void OnMouseExitButton()
    {
        information.SetActive(false);
    }
    private IEnumerator ShowPanelForSeconds(float seconds)
    {
        information.SetActive(true); 
        yield return new WaitForSeconds(seconds); 
        information.SetActive(false); 
    }
}
