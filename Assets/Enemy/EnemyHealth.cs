using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    public bool IsDead { get { return isDead; } }

    public void TakeDamage (float damage) {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        // Debug.Log(gameObject.name + " health: " + hitPoints);

        if (hitPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        // Destroy(gameObject);
    }
}
