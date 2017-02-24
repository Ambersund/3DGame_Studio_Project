using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObejctScript : MonoBehaviour {

	Transform targetPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
	}

	public void Follow(Transform _targetPoint){
		targetPoint = _targetPoint; 
	}
	public void UnFollow(){
		
	}
}
