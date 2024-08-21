using UnityEngine;

public class GarbageCollision : MonoBehaviour
{
    private Garbage garbageScript;
    private bool hasCollided = false;
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            garbageScript = gameManager.GetComponent<Garbage>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !hasCollided)
        {
            if (garbageScript != null)
            {
                garbageScript.DecrementPoints();
            }
            hasCollided = true;
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hasCollided = false;
        }

    }
}