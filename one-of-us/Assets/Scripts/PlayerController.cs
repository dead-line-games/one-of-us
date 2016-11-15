using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 5f;
	public float climbSpeed = 8f;
	public bool onLadder = true;

	bool facingRight = true;

	Rigidbody2D physics;

	void Start () {
		physics = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		if (onLadder) {
			physics.velocity = new Vector2(physics.velocity.x, vertical * climbSpeed);
		} else {
			physics.velocity = new Vector2(horizontal * walkSpeed, physics.velocity.y);
		}

		if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
			Flip ();
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
}
