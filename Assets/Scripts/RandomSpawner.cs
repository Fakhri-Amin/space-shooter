using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] things;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float minThingSpeed = 3f;
    [SerializeField] float maxThingSpeed = 7f;
    [SerializeField] float minSpawnNextTime = 3f;
    [SerializeField] float maxSpawnNextTime = 9f;
    [SerializeField] float minStartSpawnTime = 5f;
    [SerializeField] float maxStartSpawnTime = 9f;

    private int randomPoint, randomThing;
    private float randomSpawnTime, randomThingSpeed, randomStartSpawnTime;

    private void Start()
    {
        randomSpawnTime = Random.Range(minSpawnNextTime, maxSpawnNextTime);
        randomStartSpawnTime = Random.Range(minStartSpawnTime, maxStartSpawnTime);
        InvokeRepeating("SpawnRandomThing", randomStartSpawnTime, randomSpawnTime);
    }

    private void SpawnRandomThing()
    {
        randomThing = Random.Range(0, things.Length);
        randomPoint = Random.Range(0, spawnPoints.Length);
        randomThingSpeed = Random.Range(minThingSpeed, maxThingSpeed);

        GameObject Thing = Instantiate(things[randomThing], spawnPoints[randomPoint].transform.position, Quaternion.identity);
        Rigidbody2D rb = Thing.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -randomThingSpeed);
    }
}
