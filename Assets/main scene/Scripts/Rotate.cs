using UnityEngine;

public class Rotate : MonoBehaviour
{   
    public float moveSpeed = 1f;
    void Start()
    {

        float randomAngleZ = Random.Range(0f, 90f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngleZ);
    }
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}