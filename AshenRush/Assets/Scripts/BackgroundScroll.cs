using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = transform.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime, 0);
    }
}
