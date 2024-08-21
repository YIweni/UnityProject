using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{

    public GameObject Talkfox;

    // Start is called before the first frame update
    void Start()
    {
        Talkfox.SetActive(false);
    }

    // Update is called once per frame
    public void reachScore()
    {
        StartCoroutine(ShowTalkfoxForSeconds(3f)); 
    }

    private IEnumerator ShowTalkfoxForSeconds(float seconds)
    {
        Talkfox.SetActive(true); 
        yield return new WaitForSeconds(seconds);
        Talkfox.SetActive(false);
    }
}