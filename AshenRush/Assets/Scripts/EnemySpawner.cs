using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    public int minSpawnCnt;
    public int maxSpawnCnt;
    public float probability;

    [Header("References")]    
    public GameObject[] gameObjects;

    void OnEnable()
    {
        SpawnMultiple();
    }

    void SpawnMultiple()
    {
        if (gameObjects.Length == 0) return;

        for (int i = 0; i < maxSpawnCnt; i++)
        {
            if (Random.value < probability)  // UnityEngine.Random.value는 0.0과 1.0 사이의 값을 반환
            {
                GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
                Instantiate(randomObject, transform.GetChild(i).position, Quaternion.identity, transform);
            }
        }
    }
}
