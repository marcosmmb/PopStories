using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CardHandler : MonoBehaviour {

	public GameObject card;

	public bool rotate = false;

	void Update () {

		if (rotate) {
			card.transform.Rotate(new Vector3 (0, 180, 0));
		} else {
			card.transform.Rotate(new Vector3 (0, 0, 0));
		}

	}
}