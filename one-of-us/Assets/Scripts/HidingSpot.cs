using UnityEngine;
using System.Collections;

public class HidingSpot : MonoBehaviour, IUseable {

	private bool beingUsed = false;
	Animator animator;

	public void Use() {
		beingUsed = !beingUsed;
		if (beingUsed) {
			print ("Door is closed!");
			GameObject.Find ("Player").GetComponent<PlayerController> ().hidden = true;
		} else {
			print ("Door is open");
			GameObject.Find ("Player").GetComponent<PlayerController> ().hidden = false;
		}
		animator.SetBool("beingUsed", beingUsed);
	}

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {

	}

}
