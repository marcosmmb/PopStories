using UnityEngine;
using System.Collections;

public class LoopTranslate : MonoBehaviour {

	public GameObject target;
	public int initialPosition;
	public int endPosition;
	public float speed;

	void Start () {
		target.transform.position = new Vector3 (initialPosition, target.transform.position.y, target.transform.position.z);
	}

	void Update () {
		if (target.transform.position.x < endPosition) {
			target.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		} else {
			target.transform.position = new Vector3 (initialPosition, target.transform.position.y, target.transform.position.z);
		}
	}
}
