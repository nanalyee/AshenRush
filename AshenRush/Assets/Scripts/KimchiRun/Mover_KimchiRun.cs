using UnityEngine;

public class Mover_KimchiRun : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 1f;
    
    //[Header("References")]


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
    }
}
