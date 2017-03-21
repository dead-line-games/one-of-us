using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

	public GameObject[] waypoints;
	public float maxSpeed = 5;
	private Queue waypointQueue;
	private GameObject currentWaypoint;
	private Animator animator;
	private Rigidbody2D physics;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		waypointQueue = new Queue();
		foreach(GameObject go in waypoints) {
			waypointQueue.Enqueue(go);
		}
		currentWaypoint = (GameObject) waypointQueue.Dequeue();
		physics = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		int horizontal = 0;
		Debug.Log(currentWaypoint);
		if (currentWaypoint != null) {
			// Debug.Log("I have a waypoint!");
			if (currentWaypoint.transform.position.x < transform.position.x) {
				horizontal = -1;
			} else {
				horizontal = 1;
			}
		}

		Debug.Log("Horiz:\t" + horizontal);
		physics.velocity = new Vector2(horizontal * maxSpeed, physics.velocity.y);
		if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
			Flip ();
		}
		animator.SetFloat("speed", Mathf.Abs(horizontal));
	}

	public void FoundWaypoint() {
    Debug.Log("Hey! I Found it!");
		if (waypointQueue.Count > 0) {
			currentWaypoint = (GameObject) waypointQueue.Dequeue();
		} else {
			currentWaypoint = null;
		}
  }

	void Flip () {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}
