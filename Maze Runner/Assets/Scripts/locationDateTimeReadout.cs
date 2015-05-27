using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class locationDateTimeReadout : MonoBehaviour {

	private Text readOUt; //holds the UI text box
	
	void Start () {
		readOUt = GetComponent<Text>(); //assigns the text component
	}
	
	void Update () {
		ReadOUT(); //calls the ReadOUT function
	}
	
	void ReadOUT(){ //used to display infomation to the player
	
		readOUt.text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
	}
}
