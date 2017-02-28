using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 1f;
	public GameObject targetObject;
	private Transform target;

	void Start () {
		target = targetObject.transform;
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}

	void LateUpdate () {
		Vector3 specificVector = new Vector3(target.position.x, target.position.y, transform.position.z);
   	transform.position = Vector3.Lerp(transform.position, specificVector, dampTime * Time.deltaTime);
	}

}
