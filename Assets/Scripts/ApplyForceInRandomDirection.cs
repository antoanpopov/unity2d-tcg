using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceInRandomDirection : MonoBehaviour {

    [SerializeField] public string buttonName = "Fire1";
    [SerializeField] public float forceAmount = 10.0f;
    [SerializeField] public float angularForce = 10.0f;
    [SerializeField] public ForceMode forceMode;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(buttonName)) {
            GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
            GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * angularForce,forceMode);
        }
	}
}
