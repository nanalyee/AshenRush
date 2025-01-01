using UnityEngine;

public class Heart : MonoBehaviour
{
    [Header("References")]
    public Sprite OnHeart;
    public Sprite OffHeart;
    public SpriteRenderer SpriteRenderer;

    [Header("Status")]
    public int LiveNumber;


    void Start()
    {
        SpriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.Instance.Lives >= LiveNumber)
        {
            SpriteRenderer.sprite = OnHeart;
        }
        else
        {
            SpriteRenderer.sprite = OffHeart;
        }
    }
}
