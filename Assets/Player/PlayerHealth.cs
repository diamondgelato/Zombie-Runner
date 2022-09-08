using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    DisplayDamage displayDamage;

    private void Start() {
        displayDamage = GameObject.Find("UI").GetComponentInChildren<DisplayDamage>();
    }

    public void TakeDamage(float damage) {
        hitPoints -= damage;
        displayDamage.DisplayDamageUI();

        if (hitPoints <= 0) {
            // Debug.Log("lmao ded");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
