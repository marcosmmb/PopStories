using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public bool activateFade;
	public Texture2D fadeInTexture;
	public float fadeSpeed;  

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI () {

		if (activateFade) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);

			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeInTexture);
		}
	}

	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}

	public void GoToScene(string name){

		if (activateFade) {
			StartCoroutine (Fade (name));
		} else {
			SceneManager.LoadScene (name);
		}
	}

	IEnumerator Fade (string name) {
		BeginFade (1);
		yield return new WaitForSeconds (fadeSpeed);
		SceneManager.LoadScene (name);
	}

}
