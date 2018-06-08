using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject menuButton;
	public GameObject leftButton;
	public GameObject middleButton;
	public GameObject rightButton;
	public GameObject panelBack;
	public GameObject panelFront;
	public GameObject rateButton;
	public GameObject initialScreenButton;
	public GameObject backButton;

	private bool check = false;
	private bool recent = false;

	public void ActiveMenu() {

		check = !check;

	}

	void FixedUpdate(){
		if(recent && !check){
			StartCoroutine (Wait (0.5f));
		}
	}

	void Update() {

		if (check) {
			menuButton.SetActive (false);
			leftButton.SetActive (false);
			middleButton.SetActive (false);
			rightButton.SetActive (false);
			panelFront.SetActive (true);
			panelBack.SetActive (true);
			rateButton.SetActive (true);
			initialScreenButton.SetActive (true);
			backButton.SetActive (true);
			recent = true;
		} else {
			menuButton.SetActive (true);
			leftButton.SetActive (true);
			rightButton.SetActive (true);
			if (!recent) {
				middleButton.SetActive (true);
			}
			panelFront.SetActive (false);
			panelBack.SetActive (false);
			rateButton.SetActive (false);
			initialScreenButton.SetActive (false);
			backButton.SetActive (false);
		}

	
	}

	IEnumerator Wait(float s) {
		yield return new WaitForSeconds (s);
		recent = false;
	}

}
