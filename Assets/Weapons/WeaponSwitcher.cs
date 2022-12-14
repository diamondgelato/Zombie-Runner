using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSwitcher : MonoBehaviour
{
	[SerializeField] TMP_Text activeWeaponName;
    [SerializeField] int currentWeapon = 0;
	
	string[] gunNames = new string[4]{
	    "Machine Gun",
		"Shotgun",
		"Rifle",
		"Knife"
	};

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon) {
            RemoveZoom(previousWeapon);
            SetWeaponActive();
			activeWeaponName.text = gunNames[currentWeapon];
        }
    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentWeapon = 2;
        } 
    }

    private void ProcessScrollWheel() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (currentWeapon >= transform.childCount - 1) {
                currentWeapon = 0;
            } else {
                currentWeapon++;
            }
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            if (currentWeapon <= 0) {
                currentWeapon = transform.childCount - 1;
            } else {
                currentWeapon--;
            }
        }
    }

    private void SetWeaponActive() {
        
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon) {
                weapon.gameObject.SetActive(true);
            } else {                
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    private void RemoveZoom(int weaponIndex) {
        Transform weapon = transform.GetChild(weaponIndex);

        WeaponZoom weaponZoom = weapon.gameObject.GetComponent<WeaponZoom>();
        if (weaponZoom) {
            weaponZoom.ToggleZoom(false);
        }
    }

}
