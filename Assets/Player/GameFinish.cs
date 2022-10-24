using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
	[SerializeField] GameObject gameFinishCanvas;
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			gameFinishCanvas.SetActive(true);
			Time.timeScale = 0;
			FindObjectOfType<WeaponSwitcher>().enabled = false;
			
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
