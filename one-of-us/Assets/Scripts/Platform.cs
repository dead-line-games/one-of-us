using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public BoxCollider2D platformCollider;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), platformCollider);
	}

	void OnTriggerExit2D (Collider2D other) {
		Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), platformCollider, false);
	}

}
