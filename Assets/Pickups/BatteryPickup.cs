using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle;
    [SerializeField] float intensityAmount;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log(other.gameObject.name + " got battery");
            
            FlashlightSystem flashlightSystem = other.gameObject.GetComponentInChildren<FlashlightSystem>();
            flashlightSystem.RestoreLightAngle(restoreAngle);
            flashlightSystem.RestoreLightIntensity(intensityAmount);

            Destroy(gameObject);
        }
    }
}
