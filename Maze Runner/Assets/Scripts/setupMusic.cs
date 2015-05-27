using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class setupMusic : MonoBehaviour {

	public AudioMixerSnapshot main;
	// Use this for initialization
	void Awake() {
		main.TransitionTo(1);
	}

}
