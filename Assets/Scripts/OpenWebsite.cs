using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebsite : MonoBehaviour {

	public bool mobile;
	public string iosLink;
	public string androidLink;

	public void OpenLink (){

		if (mobile) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				Application.OpenURL (iosLink);
			} else if (Application.platform == RuntimePlatform.Android) {
				Application.OpenURL (androidLink);
			}
		}
	}

}
