using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent () {
        if (target == null) { return; }

        // Debug.Log("bang bang you hit");
        target.TakeDamage(damage);
    }

    public void OnDamageTaken() {
        // Debug.Log("EnemyAttack: I got hit");
    }
}
