using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float displaySeconds = 0.5f;
    Canvas canvas;

    private void Start() {
        // gameObject.SetActive(false);
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void DisplayDamageUI() {
        StartCoroutine(ShowSplatter());
    }

    private IEnumerator ShowSplatter() {
        // gameObject.SetActive(true);
        canvas.enabled = true;
        yield return new WaitForSeconds(displaySeconds);
        // gameObject.SetActive(false);
        canvas.enabled = false;
    }
}
