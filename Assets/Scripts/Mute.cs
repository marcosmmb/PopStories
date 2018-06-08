using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

	public GameObject muteOn;
	public GameObject muteOff;

	private static bool isMuted = false;

	public void MuteSwitch () {
		isMuted = !isMuted;
	}

	void Update () {

		if (isMuted) {
			muteOn.SetActive (true);
			muteOff.SetActive (false);
			AudioListener.volume = 0;
		}else {
			muteOn.SetActive (false);
			muteOff.SetActive (true);
			AudioListener.volume = 1;
		}

	}
}
