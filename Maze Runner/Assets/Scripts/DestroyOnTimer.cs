using UnityEngine;
using System.Collections;

public class DestroyOnTimer : MonoBehaviour
{
	//USED ON THE MARKER
	//CAUSES THE INTESITY OF THE LIGHT TO INCREASE THEN DECREASE TO 0 BEFORE BEING DESTROYED

	private Light flareUp; //Holds the light component
	private bool dim = false; //whether to lower the intesity of the light

	void Start ()
	{
		flareUp = GetComponent<Light> (); //gets the light component
	}

	void Update ()
	{
		jucingFeedback (); 
		destroyGameObject ();
	}

	void jucingFeedback () 
	{
		if (flareUp.intensity >= 0.9f)
			dim = true;
		if (dim)
			Dim ();
		else
			FlareUp ();
	}

	void FlareUp ()
	{
		flareUp.intensity = Mathf.Lerp (flareUp.intensity, 1f, Time.deltaTime* 2);
	}

	void Dim ()
	{
		flareUp.intensity = Mathf.Lerp (flareUp.intensity, 0, Time.deltaTime * 2);
	}

	void destroyGameObject ()
	{

		if (flareUp.intensity <= 0.1f) {
			Destroy (gameObject);
		}
	}
}
