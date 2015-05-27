using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class startGame : MonoBehaviour
{
	public AudioMixerSnapshot start; // holds the start audio snapshot
	public Image staticImage; // holds the static screen UI image
	public AudioClip staticsound; // holds the static audio clip
	private bool nextLevel; // has the transtion to Level-1 been activated

	void Update ()
	{
		if (nextLevel) {
			staticImage.enabled = true; // the image had to be turned off to allow the player to push the stat button
			staticImage.color = Color.Lerp (staticImage.color, Color.white, Time.deltaTime); // to fade in the "screen static" image 
		}
	}

	public void LoadLevel ()
	{ //USed by the buttons onCLick function to change the level
		if (!nextLevel) { //To stop you calling the function multiple times
			Invoke ("whichLevel", 5.0f); //delays the loading of Level-1
			GetComponent<AudioSource> ().PlayOneShot (staticsound); // plays the staticsound once
			start.TransitionTo (2);  // transitions the current audio snapshot to the start audio snapshot
			nextLevel = true;
		}

	}

	void whichLevel ()
	{
		Application.LoadLevel (1); //Changes to the next scene
	}
}
