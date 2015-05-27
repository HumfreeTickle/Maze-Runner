using UnityEngine;
using System.Collections;

public class playerHIt : MonoBehaviour
{

//USED ON THE SENSOR COLLIDER TO SEE IF THE PLAYER IS IN SIGHT OF THE ENEMY, TRYING TO COMBINE THIS WITH A RAY CAST TO SEE IF ANYTHING IS IN THE WAY

//	[System.NonSerialized]
	public bool hitPlayer;
//	[System.NonSerialized]
	public Transform target;
	

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			target = col.gameObject.transform; // the transform of the player so the enemy will look at him
			hitPlayer = true; // is the player in the collider
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Player") {
			target = col.gameObject.transform;// the transform of the player so the enemy will look at him
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			hitPlayer = false; 
		}
	}
}
