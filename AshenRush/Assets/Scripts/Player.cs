using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;
    
    [Header("References")]
    public Rigidbody2D PlayerRigidbody2D;
    public Animator PlayerAnimator;

    private bool isGrounded = true;

    void Start()
    {
        PlayerRigidbody2D = transform.GetComponent<Rigidbody2D>();
        PlayerAnimator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            PlayerRigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            if (!isGrounded) {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }
}
