using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public CapsuleCollider2D WeaponCollider2D;
    public Player Player;
    public Animator WeaponAnimator;

    void Start()
    {
        WeaponAnimator = transform.GetComponent<Animator>();
    }

    private void OnEnable() {
        WeaponAnimator.SetInteger("state", 1);
        Player.StartInvincible();            
    }

    private void OnDisable() {
        WeaponAnimator.SetInteger("state", 0);
        Player.StopInvincible();            
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            collider.gameObject.SetActive(false);
        }
    }
}
