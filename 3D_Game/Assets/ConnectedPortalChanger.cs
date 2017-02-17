using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedPortalChanger : MonoBehaviour {

	public GameObject[] portals;

	public int portalPointer;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<PortalManager> ().ConnectedPortal = portals [portalPointer];

	}
}
