using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TMP_Text playerHealthText;
    DisplayDamage displayDamage;

    private void Start() {
        displayDamage = GameObject.Find("UI").GetComponentInChildren<DisplayDamage>();
    }

    public void TakeDamage(float damage) {
        hitPoints -= damage;
        displayDamage.DisplayDamageUI();
        playerHealthText.text = hitPoints.ToString();

        if (hitPoints <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
