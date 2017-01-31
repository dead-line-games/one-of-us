using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 7f;
	public float climbSpeed = 8f;
	public int jumpHeight = 10;

	public bool hidden = false;

	private bool jumping = false;
	private bool climbing = false;
	private bool facingRight = true;

	private IUseable useable;

	Rigidbody2D physics;
	Animator animator;

	void Start () {
		physics = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		if (Input.GetKeyUp (KeyCode.E)) {
			Use();
		}

		if (!hidden) {
			if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
				physics.velocity = new Vector2 (0, jumpHeight);
				jumping = true;
			}

			physics.velocity = new Vector2(horizontal * maxSpeed, physics.velocity.y);
			if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
				Flip ();
			}
		}

		animator.SetBool("isHidden", hidden);
		animator.SetBool("isJumping", jumping);
		animator.SetFloat("speed", Mathf.Abs(horizontal));
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
				animator.SetBool("isJumping", false);
				jumping = false;
				break;
		}
  }

	void OnTriggerEnter2D (Collider2D other) {
		switch (other.gameObject.tag) {
			case "Useable":
				useable = other.gameObject.GetComponent<IUseable> ();
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
