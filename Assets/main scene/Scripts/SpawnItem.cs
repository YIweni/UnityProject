using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public float initialSpawnTime = 2.5f;
    public GameObject[] Items;
    public GameTimer gameTimer; 
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = initialSpawnTime;
        InvokeRepeating("SpawnItems",spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        AdjustSpawnTime();
    }
    void SpawnItems() {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        int ItemIndex = Random.Range(0, Items.Length);
        Instantiate(Items[ItemIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);

    }
    void AdjustSpawnTime()
    {
        float remainingTime = gameTimer.GetRemainingTime();

        if (remainingTime <= 150f)
        {
            if (spawnTime != 1f)
            {
                CancelInvoke("SpawnItems");
                spawnTime = 1f;
                InvokeRepeating("SpawnItems", spawnTime, spawnTime);
            }
        }
        else
        {
            if (spawnTime != initialSpawnTime)
            {
                CancelInvoke("SpawnItems");
                spawnTime = initialSpawnTime;
                InvokeRepeating("SpawnItems", spawnTime, spawnTime);
            }
        }
    }
}
