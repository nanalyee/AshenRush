using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public CapsuleCollider2D WeaponCollider2D;
    public Player Player;

    private void OnEnable() {
        Player.StartInvincible();            
    }

    private void OnDisable() {
        Player.StopInvincible();            
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            collider.gameObject.SetActive(false);
        }
    }
}
