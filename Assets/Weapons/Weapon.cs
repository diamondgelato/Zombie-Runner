using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject HitEffectVFX;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float damage = 30f;
    [SerializeField] float range = 50f;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] TMP_Text AmmoText;

    bool canShoot = true;

    private void OnEnable() {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (ammoType == AmmoType.None || (AmmoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot))) {
            StartCoroutine(Shoot());
        }

        DisplayAmmo();
    }

    private void DisplayAmmo() {
        AmmoText.text = AmmoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    private IEnumerator Shoot () {
        canShoot = false;
		
        PlayMuzzleFlash();
        ProcessRaycast();
        AmmoSlot.ReduceCurrentAmmo(ammoType);

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash() {
		if (MuzzleFlash == null) return;
        MuzzleFlash.Play();
    }

    private void ProcessRaycast () {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            // add hit effect
            CreateHitImpact(hit);

            // decrease enemyHealth if hit enemy
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) { return; }
            target.TakeDamage(damage);

        } else {
            // ignore null pointer exceptions
            return;
        }
    }

    private void CreateHitImpact (RaycastHit hit) {
		// return if no hit effect assigned
		if (HitEffectVFX == null) return;
		
        // Instantiate effect where raycast collides
        GameObject impact = Instantiate(HitEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));

        // destroy effect after sometime
        Destroy(impact, 0.1f);
    }
}
