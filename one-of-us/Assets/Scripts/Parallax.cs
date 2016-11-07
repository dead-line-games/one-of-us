using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	public float smoothing;

	private float[] parallaxScales;
	private Vector3 previousCameraPosition;

	void Start () {
		previousCameraPosition = transform.position;
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < parallaxScales.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}

	}

	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i++) {
			Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);
			backgrounds [i].position = new Vector3 (
				backgrounds [i].position.x + parallax.x,
				backgrounds [i].position.y + parallax.y,
				backgrounds [i].position.z
			);
		}
		previousCameraPosition = transform.position;
	}
}
