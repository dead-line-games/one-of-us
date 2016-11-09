using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator animator;
	Rigidbody2D physics;

	void Start () {
		animator = GetComponent<Animator> ();
		physics = GetComponent<Rigidbody2D>();
	}
		
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");

		animator.SetFloat ("speed", Mathf.Abs (move));

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
