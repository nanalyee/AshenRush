using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;
    
    [Header("References")]
    public Rigidbody2D PlayerRigidbody2D;
    private bool isGrounded = true;

    void Start()
    {
        PlayerRigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            PlayerRigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            isGrounded = true;
        }
    }
}
