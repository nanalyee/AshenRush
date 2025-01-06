using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;
    
    [Header("References")]
    public Rigidbody2D PlayerRigidbody2D;
    public Animator PlayerAnimator;
    public BoxCollider2D PlayerCollider2D;

    [Header("Status")]
    public bool isGrounded = true;
    public bool isInvincible = false;
    private bool jumpRequest = false;

    void Start()
    {
        PlayerRigidbody2D = transform.GetComponent<Rigidbody2D>();
        PlayerAnimator = transform.GetComponent<Animator>();
        PlayerCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            PlayerRigidbody2D.linearVelocity = new Vector2(PlayerRigidbody2D.linearVelocity.x, 0);
            PlayerRigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);
            jumpRequest = false;  // Reset the jump request
        }
    }

    public void KillPlayer() 
    {
        //PlayerCollider2D.enabled = false;
        //PlayerAnimator.enabled = false;
        //PlayerRigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
        if (GameManager.Instance.Lives == 0)
        {
            KillPlayer();
        }
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives+1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        isInvincible = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            if (!isGrounded) {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    /*
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            if (isGrounded) {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = false;
        }
    }
    */
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            if(!isInvincible) {
                Destroy(collider.gameObject);
                Hit();
            }                
        }
        else if (collider.gameObject.tag == "Food") {
            Destroy(collider.gameObject);
            Heal();
        }
        else if (collider.gameObject.tag == "Golden") {
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}
