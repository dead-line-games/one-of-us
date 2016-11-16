using UnityEngine;
using System.Collections;

public class playerJump : MonoBehaviour {

	public int jumpHeight;
	public int maxJump;
	private int jumpNum;

	// Use this for initialization
	void Start () {
		jumpNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && (jumpNum<maxJump)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			jumpNum++;
		}
	}
	void OnCollisionEnter2D (Collision2D call){
		if (call.gameObject.CompareTag("Ground")){
			jumpNum = 0;
		}
			}
}