using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour {

	public GameObject[] portals;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ConnectPortals(GameObject connection1, GameObject connection2){
		connection1.GetComponent<PortalManager> ().ConnectedPortal = connection2;
	}
}
