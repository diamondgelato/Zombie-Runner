using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    Camera MainCamera;
    RigidbodyFirstPersonController player;
    [SerializeField] int normalFOV = 60;
    [SerializeField] int zoomedFOV = 20;
    [SerializeField] float normalSens = 2f;
    [SerializeField] float zoomedSens = 1.33f;

    bool isZoomed = false;
    public bool IsZoomed   // property
    {
        get { return isZoomed; }   // get method
        set { isZoomed = value; }  // set method
    }

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        player = GetComponentInParent<RigidbodyFirstPersonController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            ToggleZoom(!isZoomed);
        }
    }
    
    public void ToggleZoom (bool zoom) {
        if (zoom) {
            MainCamera.fieldOfView = zoomedFOV;
            player.mouseLook.XSensitivity = zoomedSens;
            player.mouseLook.YSensitivity = zoomedSens;
        } else {
            MainCamera.fieldOfView = normalFOV;
            player.mouseLook.XSensitivity = normalSens;
            player.mouseLook.YSensitivity = normalSens;
        }

        isZoomed = zoom;
    }
}
