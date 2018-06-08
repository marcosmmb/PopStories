using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public float cardSpeed;
	public float camSpeed;
	public Camera cam;
	public GameObject cardPackObject;
	public AudioSource flipCardAudio;
	public AudioSource wooshAudio;
	public GameObject leftButton;
	public GameObject rightButton;
	public bool debug = false;
	public GameObject debugPanel;
	public GameObject debugTurn;
	public GameObject debugFacing;
	public GameObject debugRightD;
	public GameObject debugLeftD;
	public GameObject debugLocked;
	public GameObject debugRotation;
	public int clickQuantity;

	private GameObject[] cardPack;
	private int packLength;
	private CardBehaviour cardBehaviour;
	private int leftCard;
	private static int currentCard;
	private int rightCard;
	private bool turn = false;
	private bool facing = true;
	private bool rightD = false;
	private bool leftD = false;
	private bool locked = false;
	private static bool checkFirst;
	private static int auxFirst;
	private static int currentFirst;
	private static bool checkShuffle;
	private static int[] auxArr;


	int RectifyIndex(int c) {
		if (c < 0) {
			c = (cardPack.Length + c);
		} else if (c == cardPack.Length) {
			c = 0;
		}

		return c;
	}

	public void MoveCard(string direction){

		if (!locked) {

			if (direction == "right" && currentCard != (cardPack.Length - 1)) {
				clickQuantity++;
				rightD = true;
				locked = true;
				float audioPitch = Random.Range (10, 15);
				audioPitch /= 10;
				wooshAudio.pitch = audioPitch;
				wooshAudio.Play ();
			}
			if (direction == "left" && currentCard != 0) {
				clickQuantity++;
				leftD = true;
				locked = true;
				float audioPitch = Random.Range (10, 15);
				audioPitch /= 10;
				wooshAudio.pitch = audioPitch;
				wooshAudio.Play ();
			}
			if (direction == "middle") {
				turn = true;
				locked = true;
				flipCardAudio.Play ();
			}
		}
	}

	void Awake() {

		clickQuantity = 1;

		int cardQuantity = cardPackObject.transform.childCount;
		cardPack = new GameObject[cardQuantity];

		if(!checkShuffle) { 

			auxArr = new int[cardQuantity];

			for (int i = 0; i < cardQuantity; i++) {
				auxArr [i] = i; 
			}

			for (int i = auxArr.Length - 1; i > 0; i--) {
				int r = Random.Range(0,i);
				int tmp = auxArr[i];
				auxArr[i] = auxArr[r];
				auxArr[r] = tmp;
			}
			checkShuffle = true;
		}

		for (int i = 0; i < cardQuantity; i++) {

			cardPack [i] = cardPackObject.transform.GetChild (auxArr[i]).gameObject;

		}

		for (int i = 0; i < cardPack.Length; i++) {
		
			Vector3 initialPosition = new Vector3 (i * 2000, 0, 0);
			cardPack[i].transform.position = initialPosition;
			cardPack[i].SetActive (true);
		}

	}

	void Start() {

		if (!checkFirst) {
			auxFirst = Random.Range (0, cardPack.Length - 1);
			currentCard = auxFirst;
			checkFirst = true;
		} else {
			currentCard = currentFirst;
		}
		leftCard = currentCard - 1;
		rightCard = currentCard + 1;
		cam.transform.position = cardPack [currentCard].transform.position + new Vector3(0, cam.transform.position.y, cam.transform.position.z);
	
	}



	void FixedUpdate() {

		if (clickQuantity % 6 == 0) {
			clickQuantity = 1;
		}

		leftCard = currentCard - 1;
		rightCard = currentCard + 1;

		currentCard = RectifyIndex (currentCard);
		leftCard = RectifyIndex (leftCard);
		rightCard = RectifyIndex (rightCard);

		float yRot = cardPack[currentCard].transform.rotation.y;

		if (yRot == Mathf.Abs(0f)) {
			facing = true;
		} else if (yRot == Mathf.Abs(1f)) {
			facing = false;
		}

	}

	void Update() {

		currentFirst = currentCard;

		if (currentCard == 0) {
			leftButton.GetComponent<Button> ().interactable = false;
		} else {
			leftButton.GetComponent<Button> ().interactable = true;
		}

		if (currentCard == (cardPack.Length - 1)) {
			rightButton.GetComponent<Button> ().interactable = false;
		} else {
			rightButton.GetComponent<Button> ().interactable = true;
		}

		if (rightD && !turn && currentCard != cardPack.Length - 1) {
			rightD = true;
			leftD = false;
		}

		if (cam.transform.position.x >= cardPack [rightCard].transform.position.x && rightD && currentCard != cardPack.Length - 1) {
			rightD = false;
			rightD = false;
			locked = false;
			cam.transform.position = cardPack [rightCard].transform.position + new Vector3(0, cam.transform.position.y, cam.transform.position.z);
			currentCard = rightCard;
		}

		if (rightD && currentCard != cardPack.Length - 1) {
			cam.transform.Translate (camSpeed * Time.deltaTime, 0, 0);
		}

		if (leftD && !turn && currentCard != 0) {
			leftD = true;
			rightD = false;
		}

		if (cam.transform.position.x <= cardPack [leftCard].transform.position.x && leftD && currentCard != 0){
			leftD = false;
			leftD = false;
			locked = false;
			cam.transform.position = cardPack [leftCard].transform.position + new Vector3(0, cam.transform.position.y, cam.transform.position.z);
			currentCard = leftCard;
		}

		if (leftD && currentCard != 0) {
			cam.transform.Translate (-camSpeed * Time.deltaTime, 0, 0);
		}

		if (facing) { 	
			if (turn && (cardPack[currentCard].transform.rotation.y) < Mathf.Abs (1f)) {
				if (cardPack[currentCard].transform.rotation.y < Mathf.Abs (0.998f)) {
					cardPack[currentCard].transform.Rotate (Vector3.up, cardSpeed * Time.deltaTime);
				} else {
					cardPack[currentCard].transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
					turn = false;
					facing = false;
					locked = false;
				}
			}
		} else if (!facing) {
			if (turn && (cardPack[currentCard].transform.rotation.y) <= Mathf.Abs (1f)) {
				if (cardPack[currentCard].transform.rotation.y <= Mathf.Abs (1.002f) && (cardPack[currentCard].transform.rotation.y) >= Mathf.Abs(0.1f)) {
					cardPack[currentCard].transform.Rotate (Vector3.up, cardSpeed * Time.deltaTime);
				} else {
					cardPack[currentCard].transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
					turn = false;
					facing = true;
					locked = false;
				}
			}
		}
			

		if (debug) {
			if (debugPanel.activeSelf == false) {
				debugPanel.SetActive (true);
			}
			debugTurn.GetComponent<Text> ().text = "Turn: " + turn.ToString ();
			debugFacing.GetComponent<Text> ().text = "Facing: " + facing.ToString ();
			debugRightD.GetComponent<Text> ().text = "RightD: " + rightD.ToString ();
			debugLeftD.GetComponent<Text> ().text = "LeftD: " + leftD.ToString ();
			debugLocked.GetComponent<Text> ().text = "Locked: " + locked.ToString ();
			debugRotation.GetComponent<Text> ().text = "Rot: " + cardPack[currentCard].transform.rotation.y.ToString ();

		} else {
			if (debugPanel.activeSelf) {
				debugPanel.SetActive (false);
			}
		}

	}

	public void DebugToggle() {
		debug = !debug;
	}

}
