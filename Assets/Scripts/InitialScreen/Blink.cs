using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public GameObject target;
	public AudioSource audioFile;
	public float minWaitTime;
	public float maxWaitTime;
	public float blinkTime;

	void Start () {
		StartCoroutine (BlinkTarget ());
	}

	IEnumerator BlinkTarget(){
		while (true) {
			float waitTime = Random.Range (minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			target.SetActive (false);
			audioFile.Play ();
			yield return new WaitForSeconds (blinkTime);
			target.SetActive (true);
			yield return new WaitForSeconds (blinkTime * 5);
			target.SetActive (false);
			yield return new WaitForSeconds (blinkTime * 2);
			target.SetActive (true);
			yield return new WaitForSeconds (blinkTime * 15);
			target.SetActive (false);
			yield return new WaitForSeconds (blinkTime * 3);
			target.SetActive (true);
			yield return new WaitForSeconds (blinkTime * 10);
			target.SetActive (false);
			yield return new WaitForSeconds (blinkTime * 3);
			target.SetActive (true);
		}
	}
}
