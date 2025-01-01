using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public int minSpawnDelay;
    public int maxSpawnDelay;

    [Header("References")]    
    public GameObject[] gameObjects;
    
    void OnEnable()
    {
        Spawn();
        Invoke("RepeatSpawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
    
    void OnDisable() 
    {
        CancelInvoke();
    }
    
    void Spawn()
    {
        GameObject randomObejct = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObejct, transform.position, Quaternion.identity, gameObject.transform);
    }

    void RepeatSpawn() 
    {
        Spawn();
        Invoke("RepeatSpawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
