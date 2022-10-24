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

        if (hitPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        StartCoroutine(RemoveEnemy());
    }

    private IEnumerator RemoveEnemy() {
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
    }
}
