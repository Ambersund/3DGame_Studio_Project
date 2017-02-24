using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.Portal;

public class ConnectionManager : MonoBehaviour {

	public GameObject[] portals;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			portals [0].GetComponent<Portal> ().destination = portals [2].transform;
			portals [1].GetComponent<Portal> ().destination = portals [3].transform;

		}
	}

	public void ConnectPortals(GameObject connection1, GameObject connection2){
		
	}
}
