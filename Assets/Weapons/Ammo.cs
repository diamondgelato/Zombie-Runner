using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // [SerializeField] int ammoAmount = 10;

    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // private void Start() {
    // }

    public int GetCurrentAmmo (AmmoType ammoType) {
        // return ammoAmount;
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo (AmmoType ammoType) {
        GetAmmoSlot(ammoType).ammoAmount--;
        // UpdateAmmoUI(GetAmmoSlot(ammoType).ammoAmount);
    }

    public void IncreaseCurrentAmmo (AmmoType ammoType, int amount) {
        GetAmmoSlot(ammoType).ammoAmount += amount;
        // UpdateAmmoUI(GetAmmoSlot(ammoType).ammoAmount);
    }

    // public void UpdateAmmoUI (int amount) {
    //     AmmoText.text = amount.ToString();
    // }

    private AmmoSlot GetAmmoSlot (AmmoType ammoType) {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType) {
                return slot;
            }
        }

        return null;
    }
}
