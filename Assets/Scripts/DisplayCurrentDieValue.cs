using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCurrentDieValue : MonoBehaviour {

    public LayerMask dieValueColliderLayer = -1;
    public int currentValue = 1;
    private bool rollComplete = false;
    // Update is called once per frame
    void Update() {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) {
            currentValue = hit.collider.GetComponent<DieValue>().value;
        }

        if (GetComponent<Rigidbody>().IsSleeping() && !rollComplete) {
            rollComplete = true;
            Debug.Log("Die roll complete, die is at rest");
        } else if (!GetComponent<Rigidbody>().IsSleeping()) {
            rollComplete = false;
        }
    }

    void OnGUI() {
        GUILayout.Label(currentValue.ToString());
    }
}
