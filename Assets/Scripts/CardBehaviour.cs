using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CardBehaviour : MonoBehaviour {

	public GameObject card;
	public GameObject backgroundBack;
	public GameObject resolution;
	public GameObject author;
	public GameObject authorContent;
	public GameObject backgroundFront;
	public GameObject picture;
	public GameObject description;
	public GameObject title;

	private bool checkSwitch = true;

	IEnumerator SwitchCoroutine(){
		yield return new WaitForSeconds(0.3f);
		checkSwitch = true;
	}

	void Update () {


		float yRot = this.transform.rotation.y;

		if (Mathf.Abs(yRot) >= 0.7f && Mathf.Abs(yRot) <= 0.8f && checkSwitch) {
			
			checkSwitch = false;
				
			if (!backgroundFront.activeSelf && !picture.activeSelf && !description.activeSelf && !title.activeSelf) {
				backgroundFront.SetActive (true);
				picture.SetActive (true);
				description.SetActive (true);
				title.SetActive (true);
			} else {
				backgroundFront.SetActive (false);
				picture.SetActive (false);
				description.SetActive (false);
				title.SetActive (false);
			}
					
			StartCoroutine(SwitchCoroutine());

		}


	}
}
