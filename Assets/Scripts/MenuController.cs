using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public bool freeVersion;
	public GameObject gameTitle;
	public GameObject freeTitle;
	public GameObject playButton;
	public GameObject rulesButton;
	public GameObject rulesText;
	public GameObject premiumButton;
	public GameObject backButton;

	private bool ruleActive = false;

	public void SwitchRule(){
	
		ruleActive = !ruleActive;
		
	}

	void Update() {

		if (ruleActive) {
			gameTitle.SetActive (false);
			if (freeVersion) {
				freeTitle.SetActive (false);
				premiumButton.SetActive (false);
			} else {
				freeTitle.SetActive (false);
				premiumButton.SetActive (false);
			}
			playButton.SetActive (false);
			rulesButton.SetActive (false);
			backButton.SetActive (true);
			rulesText.SetActive (true);
		} else {
			gameTitle.SetActive (true);
			if (freeVersion) {
				freeTitle.SetActive (true);
				premiumButton.SetActive (true);
			} else {
				freeTitle.SetActive (false);
				premiumButton.SetActive (false);
			}
			playButton.SetActive (true);
			rulesButton.SetActive (true);
			backButton.SetActive (false);
			rulesText.SetActive (false);
		}
	
	}
		
}
