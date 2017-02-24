using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	public Camera cam;
	Rigidbody rb;

	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Vector3 tetherPoint;

	Vector3 gravityDirection = Vector3.up;
	Vector3 targetGravity = Vector3.up;

	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float playerSpeed;
	public float gravity = -9.8f;
	public float shiftSpeed = 0;

	public LayerMask groundedMask;

	float verticalLookRotation;

	public bool grounded;
	public bool isTethered = false;
	public bool gravityOverride = false;
	public bool onStairs = false;

	void Awake(){

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		rb = this.gameObject.GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (cam.transform.position != this.gameObject.transform.position) {
			cam.transform.position = this.gameObject.transform.position;
		}

		// Look rotation for mouse
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation,-85,85);
		cam.transform.localEulerAngles = Vector3.left * verticalLookRotation;

		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * playerSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);

		//GROUNDED CHECK
		Ray groundRay = new Ray(transform.position, -transform.up);
		RaycastHit groundHit;

		if (Physics.Raycast (groundRay, out groundHit, 1, groundedMask)) {
			grounded = true;
			if (gravityOverride == false) {
				if (groundHit.transform.gameObject.tag == "Stairs") {
					targetGravity = groundHit.transform.gameObject.GetComponent<StairGravity> ().stairGravity;
				} else {
					targetGravity = groundHit.normal;
				}
			}

		}else{
			grounded = false;
		}

		//DEBUG RAYCAST
		Ray debugRay = new Ray(transform.position, cam.transform.forward);
		RaycastHit debugHit;

		if (Physics.Raycast (debugRay, out debugHit, 100)) {
			if (Input.GetMouseButton (0)) {
				//Debug.Log (debugHit.normal);
			}
		}
	}

	void FixedUpdate(){

		//Gravity
		ExertGravity(targetGravity);

		//Movement
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + localMove);
	}

	//USED FOR PORTALS
	public void ChangeGravity(Vector3 changeNormal){
		gravityDirection = changeNormal;
	}

	void ExertGravity(Vector3 _targetGravity){
		Vector3 localUp = rb.transform.up;

		//if we are tethered to a sphere
		if (isTethered) {
			//sphere gravity
			gravityDirection = (rb.position - tetherPoint).normalized;
		}
		if (gravityDirection != _targetGravity) {
			gravityDirection  = Vector3.Lerp (gravityDirection, _targetGravity, shiftSpeed); 

			Debug.Log ("TARGET: " + _targetGravity + ", CURRENT: " + gravityDirection);
				
		}

		rb.AddForce (gravityDirection * gravity);
		rb.rotation = Quaternion.FromToRotation (localUp, gravityDirection) * rb.rotation;
	}
}
