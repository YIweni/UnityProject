using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Garbage : MonoBehaviour
{
    private GameObject selectedobj;
        int x = 0;
    [SerializeField] private Text PointText;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private Talk talk;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("trashbinBlue") || hitObject.CompareTag("trashbinRed") || hitObject.CompareTag("trashbinGreen") || hitObject.CompareTag("recyclable trash") || hitObject.CompareTag("Perishable waste") || hitObject.CompareTag("Hazardous waste"))
                {
                    if (selectedobj == null)
                    {
                        if (hitObject.CompareTag("recyclable trash") || hitObject.CompareTag("Perishable waste") || hitObject.CompareTag("Hazardous waste"))
                        {
                            selectedobj = hitObject;
                            Outline outline = selectedobj.GetComponent<Outline>();
                            if (outline != null)
                            {
                                outline.enabled = true;
                            }
                            else
                            {
                                Debug.LogWarning("Outline component missing on the selected trash.");
                            }
                        }
                    }
                    else
                    {
                        if (hitObject.CompareTag("trashbinBlue"))
                        {
                            if (selectedobj.CompareTag("recyclable trash"))
                            {
                                Destroy(selectedobj);
                                selectedobj = null;
                                UpdatePointText();
                            }
                            else {

                                DeductTime(5f);
                            }
                        }
                        if (hitObject.CompareTag("trashbinRed"))
                        {
                            if (selectedobj.CompareTag("Hazardous waste"))
                            {
                                Destroy(selectedobj);
                                selectedobj = null;
                                UpdatePointText();
                            }
                     else
                                {

                                DeductTime(5f);
                                }
                       
                        }
                        if (hitObject.CompareTag("trashbinGreen"))
                        {
                            if (selectedobj.CompareTag("Perishable waste"))
                            {
                                Destroy(selectedobj);
                                selectedobj = null;
                                UpdatePointText();
                            }
                            else
                            {

                                DeductTime(5f);
                            }
                        }
                        else
                        {
                            Outline outline = selectedobj.GetComponent<Outline>();
                            if (outline != null)
                            {
                                outline.enabled = false;
                            }
                            selectedobj = null;
                        }
                    }
                }
                else
                {

                    if (selectedobj != null)
                    {
                        Outline outline = selectedobj.GetComponent<Outline>();
                        if (outline != null)
                        {
                            outline.enabled = false;
                        }
                        selectedobj = null;
                    }
                }
            }
        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 far = Camera.main.ScreenToWorldPoint(screenFar);
        Vector3 near = Camera.main.ScreenToWorldPoint(screenNear);

        RaycastHit hit;
        Physics.Raycast(near, far - near, out hit);
        return hit;
    }
    private void UpdatePointText()
    {  
        if (PointText != null)
        {
            x++;
            PointText.text = "Points: " + x;
        }
        if (x >= 50) {

            talk.reachScore();

        }
    }
    public int Getpoints() {

        return x;
    }
    public void DecrementPoints()
    {
        if (PointText != null)
        {
            x--;
            PointText.text = "Points: " + x;
            StartCoroutine(FlashPointText());
            UpdatePointText(); 
        }
    }
    private void DeductTime(float seconds)
    {
        if (gameTimer != null)
        {
            gameTimer.DeductTime(seconds);
        }
        else
        {
            Debug.LogWarning("GameTimer reference is not set.");
        }
    }
    private IEnumerator FlashPointText()
    {
        Color originalColor = PointText.color; 
        PointText.color = Color.red;
        PointText.fontStyle = FontStyle.Bold;
        yield return new WaitForSeconds(3f); 
        PointText.color = originalColor;
        PointText.fontStyle = FontStyle.Bold;

    }
}