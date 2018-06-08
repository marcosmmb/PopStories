using UnityEngine;
using System.Collections;

public class ForAndBackTranslate : MonoBehaviour {

	public GameObject target;
	public int initialPosition;
	public int endPosition;
	public float speed;

	private bool direction;

	void Update () {
		if (target.transform.position.x > endPosition) {
			direction = false;
		} else if (target.transform.position.x < initialPosition) {
			direction = true;
		}
		if (direction) {
			target.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}else {
			target.transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}
	}
}
