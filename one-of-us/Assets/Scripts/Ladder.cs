using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour, IUseable {

	private bool beingUsed = false;

	public void Use() {
		beingUsed = !beingUsed;
		PlayerController player = GameObject.Find ("Player").GetComponent<PlayerController>();
		player.ToggleClimbing();
		print("Being Used: " + beingUsed);
	}

	void Start () {

	}

	void Update () {

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player" && beingUsed) {
			PlayerController player = GameObject.Find ("Player").GetComponent<PlayerController>();
			player.ToggleClimbing();
			beingUsed = false;
		}
  }

}
