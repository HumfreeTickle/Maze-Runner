using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

//	public Transform enemy;	//Used to enter the crouch state //If I get time to do this					

	private Animator anim;	// a reference to the animator on the character
	private Vector3 target;
//	private Rigidbody Player;

	void Start ()
	{
		anim = GetComponent<Animator>();
//		Player = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate ()
	{
		target = transform.parent.GetComponent<clickToMove>().locationTo;
		float animationParam = Vector3.Distance(transform.parent.position, target);	
		anim.SetFloat("Distance", animationParam);	// set our animator's float parameter 'Distance' equal to the distance from target				
		//If the distance is greater than a set amount, use the run animation.
	}
}
