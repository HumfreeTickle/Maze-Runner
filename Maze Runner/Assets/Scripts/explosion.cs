using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour
{
	public float force; // allows me to change the amount of force produced through the inspector
	public float radius; // allows me to change the radius of the blast through the inspector
	private RaycastHit hit; //why is this needed again
	public AudioSource bigBoom; // holds the audio source for the explosion. 
	private Vector3 startingPosition = new Vector3 (-6, 0, 0);
	private Vector3 startingrotation = new Vector3 (0, 270, 0);
	

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.GetComponent<Rigidbody> () != null) { // if the gameobject the bullet has collided with has a rigidbody apply an explosive force to it
			col.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (force, transform.position, radius, 0, ForceMode.Impulse);
		}
		if (col.gameObject.tag == "Player") { // if the collision is the player teleport back to the start
			col.transform.position = startingPosition;
//			col.transform.eulerAngles = startingrotation;
		}
		Destroy (this.gameObject); // destroy the gameobject once all the code has been executed
	}
}
