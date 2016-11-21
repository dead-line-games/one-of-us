using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 5f;
	public float climbSpeed = 8f;
	public int jumpHeight = 6;

	private bool jumping = false;
	private bool climbing = false;

	private bool facingRight = true;

	private IUseable useable;

	Rigidbody2D physics;

	void Start () {
		physics = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			Use();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			physics.velocity = new Vector2 (0, jumpHeight);
			jumping = true;
		}

		if (climbing) {
			physics.gravityScale = 0;
			physics.velocity = new Vector2(physics.velocity.x, vertical * climbSpeed);
		} else {
			physics.gravityScale = 1;
			physics.velocity = new Vector2(horizontal * walkSpeed, physics.velocity.y);
			if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
				Flip ();
			}
		}
	}

	public void ToggleClimbing() {
		climbing = !climbing;
	}

	void Use() {
		if (useable != null) {
			useable.Use();
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

  void OnCollisionEnter2D (Collision2D other) {
		switch (other.gameObject.tag) {
			case "Ground":
				jumping = false;
				break;
		}
  }

	void OnTriggerEnter2D (Collider2D other) {
		switch (other.gameObject.tag) {
			case "Useable":
				useable = other.gameObject.GetComponent<IUseable>();
				break;
		}
  }

	void OnTriggerExit2D (Collider2D other) {
		switch (other.gameObject.tag) {
			case "Useable":
				useable = null;
				break;
		}
  }

}
