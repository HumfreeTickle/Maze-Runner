using UnityEngine;
using System.Collections;

// Require these components when using this script
// Means that I can aplly this to another character and still have the required components
[RequireComponent(typeof(CapsuleCollider))] 
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class clickToMove : MonoBehaviour
{ 
	[System.NonSerialized]
	public  NavMeshAgent playerNavAgent;

	public GameObject marker;
	[System.NonSerialized] //So it can be accessed form another script but can't be changed within the inspector
	public Vector3 locationTo; // where the raycast has hit

	[System.NonSerialized]
	public RaycastHit hit; //where the raycast has hit

	void Start ()
	{
		playerNavAgent = GetComponent<NavMeshAgent> ();
		locationTo = transform.position;
	}
	
	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //creates a ray from where ever the mouse was clicked to the gamefield  

		
			Physics.Raycast (ray, out hit); // did it actually hit anything
			print (hit.point);
			locationTo = hit.point;		
			if (Physics.Raycast (ray, out hit, 300)) { //If the raycast hit the ground, then create a marker and send the player there
				playerNavAgent.SetDestination (hit.point);
				Instantiate (marker, new Vector3 (hit.point.x, 0, hit.point.z), Quaternion.identity); //Creates a waypoint so the user knows where they've sent the player character
			}
		}
	}
}


