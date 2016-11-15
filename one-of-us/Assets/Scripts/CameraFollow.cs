using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float xMin, xMax, yMin, yMax;

	private Transform target;

	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void LateUpdate () {
		transform.position = new Vector3 (
			Mathf.Clamp (target.position.x, xMin, xMax),
			Mathf.Clamp (target.position.y, yMin, yMax),
			transform.position.z
		);
	}
}
