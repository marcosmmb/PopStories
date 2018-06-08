using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;

public class CardCreator : EditorWindow {

	private GameObject card;
	private GameObject cardPack;
	private GameObject titleObject;
	private GameObject pictureObject;
	private GameObject descriptionObject;
	private GameObject resolutionObject;
	private GameObject authorObject;
	private GameObject authorTextObject;
	private Object instCard;
	private Vector3 spawnPoint = new Vector3 (0, 0, 0);
	private string cardTitle;
	private Sprite cardPicture;
	private string cardDescription;
	private string cardResolution;
	private bool checkAuthor = false;
	private string cardAuthor;

	[MenuItem ("PopStories/Card Creator Tool")]
	public static void ShowWindow () {
		EditorWindow.GetWindow (typeof(CardCreator));
	}
		
	void Update() {
		cardPack = GameObject.FindGameObjectWithTag ("CardPack");
		card = GameObject.FindGameObjectWithTag ("Card");

		titleObject = card.GetComponent<CardBehaviour> ().title;
		pictureObject = card.GetComponent<CardBehaviour> ().picture;
		descriptionObject = card.GetComponent<CardBehaviour> ().description;
		resolutionObject = card.GetComponent<CardBehaviour> ().resolution;
		authorObject = card.GetComponent<CardBehaviour> ().author;
		authorTextObject = card.GetComponent<CardBehaviour> ().authorContent;
	}

	void OnGUI () {

		GUILayout.Label ("Criador de Cartas", EditorStyles.boldLabel);

		/*
		cardPack = EditorGUILayout.ObjectField ("Card Pack", cardPack, typeof(GameObject), true) as GameObject;
		card = EditorGUILayout.ObjectField ("Card", card, typeof(GameObject), false) as GameObject;
		titleObject = EditorGUILayout.ObjectField ("Title", titleObject, typeof(GameObject), false) as GameObject;
		descriptionObject = EditorGUILayout.ObjectField ("Description", descriptionObject, typeof(GameObject), false) as GameObject;
		resolutionObject = EditorGUILayout.ObjectField ("Resolution", resolutionObject, typeof(GameObject), false) as GameObject;
		authorObject = EditorGUILayout.ObjectField ("Author Object", authorObject, typeof(GameObject), false) as GameObject;
		authorTextObject = EditorGUILayout.ObjectField ("Author", authorTextObject, typeof(GameObject), false) as GameObject;
		*/

		cardTitle = EditorGUILayout.TextField ("Título", cardTitle);
		EditorGUILayout.Separator ();
		cardPicture = EditorGUILayout.ObjectField ("Ilustração", cardPicture, typeof(Sprite), true) as Sprite;
		EditorGUILayout.Separator ();
		cardDescription = EditorGUILayout.TextField ("Enigma", cardDescription, GUILayout.Height(Screen.height / 10));
		cardResolution = EditorGUILayout.TextField ("História", cardResolution, GUILayout.Height (Screen.height / 6));

		checkAuthor = EditorGUILayout.BeginToggleGroup ("Inserir autor?", checkAuthor);
			cardAuthor = EditorGUILayout.TextField ("Nome do autor", cardAuthor);
		EditorGUILayout.EndToggleGroup ();

		if (GUILayout.Button("Criar")) {
			
			titleObject.GetComponent<Text> ().text = cardTitle;
			pictureObject.GetComponent<Image> ().sprite = cardPicture;
			descriptionObject.GetComponent<Text> ().text = cardDescription;
			resolutionObject.GetComponent<Text> ().text = cardResolution;

			if (checkAuthor) {
				authorObject.SetActive (true);
				authorTextObject.SetActive (true);
				authorTextObject.GetComponent<Text> ().text = cardAuthor;
			} else {
				authorObject.SetActive (false);
				authorTextObject.SetActive (false);
			}

			instCard = Instantiate (card, spawnPoint, Quaternion.identity, cardPack.transform);
			if (cardTitle != "") {
				instCard.name = cardTitle;
			}

		}

		if (GUILayout.Button ("Limpar")) {
			cardTitle = null;
			cardPicture = null;
			cardDescription = null;
			cardResolution = null;
			checkAuthor = false;
			cardAuthor = null;
		}

	}
}
