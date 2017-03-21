using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		NpcController nc = other.gameObject.GetComponent<NpcController>();
		if (nc != null) {
			nc.FoundWaypoint();
		}
	}

}
