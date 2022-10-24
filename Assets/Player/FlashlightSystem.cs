using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.05f;
    [SerializeField] float angleDecay = 0.5f;
    [SerializeField] float minAngle = 40f;

    Light flashLight;

    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle (float restoreAngle) {
        flashLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity (float intensityAmount) {
        flashLight.intensity += intensityAmount;
    }

    void DecreaseLightAngle() {
        if (flashLight.spotAngle >= minAngle) {
            flashLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    void DecreaseLightIntensity() {
        flashLight.intensity -= lightDecay * Time.deltaTime;
    }
}
