using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

	private bool hasPickup = false;

	public Transform holdPoint;
	public GameObject heldObject;

	public Transform keyPoint;
	public GameObject keyObject;

	public Camera cam;

	public float pickupDistance;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		//DEBUG RAYCAST
		Ray pickupRay = new Ray(transform.position, cam.transform.forward);
		RaycastHit pickupHit;

		if (Physics.Raycast (pickupRay, out pickupHit, pickupDistance)) {
			if (Input.GetMouseButton (0)) {
				if (pickupHit.transform.gameObject.tag == "Pickup" && !hasPickup) {
					//pick up object
					Pickup(pickupHit.transform.gameObject);
				}
				if (hasPickup) {
					//drop object
					Drop(pickupHit.transform.gameObject);
				}
			}
		}
	}

	void Pickup(GameObject _pickup){
		Debug.Log ("PICKUP");
	}
	void Drop(GameObject _pickup){
		Debug.Log ("DROP");
	}
	void Place(GameObject _pickup){
		Debug.Log ("PLACE");
	}
}
