using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

	private bool hasPickup = false;
	public Transform holdPoint;
	public GameObject heldObject;

	public Transform keyPoint;
	public GameObject keyObject;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (heldObject != null) {
			heldObject.transform.position = holdPoint.position;
		}

		if (Input.GetMouseButton (1) && heldObject != null) {
			//Drop ();
		}
	}
	void OnTriggerStay(Collider other){
		if (Input.GetMouseButton(0) && other.tag == "Pick-up" && hasPickup == false) {
			heldObject = other.gameObject;
			Pickup ();
		}
		if (Input.GetMouseButton (1) && other.tag == "Key" && hasPickup == true && heldObject != null) {
			keyObject = other.gameObject;
			PlaceObject ();
		}
	}

	void Pickup(){
		Debug.Log ("PICKUP");
		heldObject.GetComponent<Rigidbody> ().isKinematic = true;
		heldObject.transform.parent = this.gameObject.transform;
		hasPickup = true;
	}
	void Drop(){
		hasPickup = false;
		heldObject.transform.parent = null;
		heldObject.GetComponent<Rigidbody> ().isKinematic = false;
		heldObject = null;
	}
	void PlaceObject(){
		Drop ();
		keyObject.GetComponent<KeyCheck> ().DisableGate ();
	}
}
