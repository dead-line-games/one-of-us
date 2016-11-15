using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Rigidbody2D physics;

	void Start () {
		physics = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");

		physics.velocity = new Vector2(move * maxSpeed, physics.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight)) {
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
