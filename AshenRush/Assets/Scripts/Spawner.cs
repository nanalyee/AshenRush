using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;

    [Header("References")]    
    public GameObject[] gameObjects;
    
    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void Spawn() {
        GameObject randomObejct = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObejct, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
