using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Eavesdrop : MonoBehaviour {
  public float detectionTime = 5.0f;
  private float timeLeft;
  private bool detected = false;


	// Use this for initialization
	void Start () {
      timeLeft = detectionTime;
  }

	// Update is called once per frame
	void Update () {
    if (detected) {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
	}

  void OnTriggerEnter2D (Collider2D other) {
    if (other.gameObject.tag == "Player") {
      detected = true;
    }
  }

  void OnTriggerExit2D (Collider2D other) {
    if (other.gameObject.tag == "Player") {
      detected = false;
      timeLeft = detectionTime;
    }
  }

}
