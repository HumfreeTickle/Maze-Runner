using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadOut : MonoBehaviour {

	private Text readOUt; //holds the UI text box
	private Vector3 whereTo; //where the player has selected
	private Vector3 distanceFrom; //distance between current location and whereTo
	public GameObject Player; //holds the player Gameobject

	void Start () {
		readOUt = GetComponent<Text>(); //assigns the text component
		distanceFrom = Player.transform.position; //sets distanceFrom to current player location
	}
	
	void Update () {
		ReadOUT(); //calls the ReadOUT function
	}

	void ReadOUT(){ //used to display infomation to the player
		whereTo = Player.GetComponent<clickToMove>().locationTo; //holds the set destination from the user
		float distance = Vector3.Distance(whereTo, distanceFrom); //returns the distance between where you are and where you are going
		readOUt.text = "Destination: " + whereTo.ToString("G4") + "\n" + 
			"Current Distance: " + distance.ToString(); // displays both Vector3s to the screen.
	}
}
