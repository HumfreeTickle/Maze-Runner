using UnityEngine;
using System.Collections;

public class endPoint : MonoBehaviour
{
	public AudioClip gameOver;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().PlayOneShot (gameOver); //plays gameover audioclip once
			Invoke ("GameOver", 4.5f); // delays the return to the start scene by 4.5 seconds
		}
	}

	void GameOver ()
	{
		Application.LoadLevel (0); // load the start scene
	}
}
