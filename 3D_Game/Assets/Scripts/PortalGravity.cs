using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGravity : MonoBehaviour {

	public Vector3 portalGravity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.transform.gameObject.GetComponent<PlayerController> ().gravityOverride = true;
		}
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			other.transform.gameObject.GetComponent<PlayerController> ().ChangeGravity(portalGravity);
			Debug.Log ("Gravity Changed to: " + portalGravity);
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			other.transform.gameObject.GetComponent<PlayerController> ().gravityOverride = false;
		}
	}
}
