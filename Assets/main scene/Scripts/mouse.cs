using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    private bool isDragging = false;
    private bool wasDragging = false;
    private Vector3 offset;
    private Plane dragPlane;
    private GameObject flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Sphere");
        if (flag != null)
        {
            this.transform.LookAt(flag.transform.position);
        }
        else
        {
            Debug.LogError("Sphere object not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wasDragging && flag != null)
        {
            Vector3 p1 = this.transform.position;
            Vector3 p2 = flag.transform.position;
            Vector3 p = p2 - p1;
            float distance = p.magnitude;

            if (distance <= 0.1f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("1");
        isDragging = true;
        wasDragging = true; 

        dragPlane = new Plane(Camera.main.transform.forward, this.transform.position);

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float planeDist;
        if (dragPlane.Raycast(camRay, out planeDist))
        {
            offset = this.transform.position - camRay.GetPoint(planeDist);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnMouseDrag()
    {
        Debug.Log("3");
        if (isDragging)
        {
            Debug.Log("2");
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float planeDist;
            if (dragPlane.Raycast(camRay, out planeDist))
            {
                this.transform.position = camRay.GetPoint(planeDist) + offset;
            }
        }
    }
}