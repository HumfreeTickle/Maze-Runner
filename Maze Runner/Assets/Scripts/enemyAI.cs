using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour
{

	private NavMeshAgent enemyNavAgent; // a reference to the enemy gameobject's NavMeshAgent
	public Transform wayPoint1; // First waypoint location
	public Transform wayPoint2; // Second waypoint loacation
	public Transform wayPoint3; // Third waypoint location
	public Transform wayPoint4; // Fourth waypoint location
	private Vector3 wayPoint; // a variable to hold which waypoint the emeny will move to
	public float _timer; // a standard timer variable used to activate certain parts of the code
	private bool hitPlayer = false; // a reference to the whether the player can be seen by the enemy
	private Light sensor; // used to change the colour of the droid's sensor light to let the player know when they have entered the sensor collider
	public GameObject plasmaBullet; // holds the plasmabullet gameobject
	public float force; // the amount of the plasmabullet is fired with
	public Transform target; // to allow the enemy to lokk at the player once they have entered the sensor
	private GameObject sensorCollider; // holds a reference to the sensor collider gameobjecet
	private RaycastHit hit; // used with the raycast
	public AudioSource laserSFX; // holds the audio source for the laser sound effects
	public AudioClip laserSound; // laser sound effect clip

	void Start ()
	{
		enemyNavAgent = GetComponent<NavMeshAgent> (); //assigns the navmeshagent
		wayPoint = wayPoint1.position; // sets current waypoint destination to the first waypoint
		sensor = transform.GetChild (1).GetComponent<Light> ();  // assign the sensor light to the spotlight child gameobject
		sensorCollider = GameObject.Find ("SensorCollider"); // assigns the sensor collider to the sensor lights cone collider child
	}

	void Update ()
	{
		target = sensorCollider.GetComponent<playerHIt> ().target; // assigns a reference to the playerHits target variable
		hitPlayer = sensorCollider.GetComponent<playerHIt> ().hitPlayer; //assigns a reference to the playerHits hitplayer variable
		Searching (); // calls the searching funciton
		if (target != null) { // if there is a target
			transform.LookAt (target, Vector3.up); //look at the target.
		}
	}

	void Searching () //if the player enters the sensorCollider the enemy stops its Patrol and enters Attack
	{
		if (hitPlayer) { // if the player is in the enemy's sights, unobstructed 
			enemyNavAgent.Stop (); // stop the droids movements
			_timer += Time.deltaTime; // start the timer
			Attack (); // calls the attack function
		} else if (!hitPlayer) { // if player is behind something or is outside the sensor collider
			enemyNavAgent.Resume (); // resume the droids movements
			target = null; // target is set to null so the droid doesn't look at the player anymore
			_timer = 0; // reset the timer
			Patrol (); // call the patrol function
		}
	}

	void Patrol () //moves the droid use a navmesh randomly between 4 different waypoints
	{
		if (Vector3.Distance (transform.position, wayPoint) < 10) { // if the distance between currrent position and the waypoint is less than 10, change waypoint
			int r = Mathf.RoundToInt (Random.Range (1, 5)); // creates a random integer between 1 and 5
			switch (r) { // switch statement used to decide which waypoint to go to
			case 1:
				wayPoint = wayPoint1.position;
				break;
			case 2:
				wayPoint = wayPoint2.position;
				break;
			case 3:
				wayPoint = wayPoint3.position;
				break;
			case 4:
				wayPoint = wayPoint4.position;
				break;
			default:
				wayPoint = transform.position;
				break;
			}
		}
		enemyNavAgent.SetDestination (wayPoint); // moves the droid using the navmesh
		sensor.color = Color.Lerp (sensor.color, Color.yellow, Time.deltaTime);
	}

	void Attack () // change the light colour and calls the fire function after a certain amount of time
	{
		Vector3 forward = transform.TransformDirection (Vector3.forward); // directly ahead of the bullet
		if (Physics.Raycast (transform.position, forward, out hit, 100)) {
			Debug.DrawLine (transform.position, hit.point, Color.blue);
		}

		if (_timer > 0.1f && hit.collider.tag == "Player") {
			sensor.color = Color.Lerp (Color.red, Color.yellow, Time.deltaTime);
			if (_timer >= 0.5f) {
				Fire ();
			}
		}
	}

	void Fire ()
	{ // instatiates a bullet and fires it using physics towards the player. Plays the laser audio clip everytime a bullet is fired
		GameObject shotsFired = Instantiate (plasmaBullet, transform.localPosition, transform.rotation) as GameObject;
		Physics.IgnoreCollision (shotsFired.GetComponent<SphereCollider> (), this.GetComponent<CapsuleCollider> ());
		shotsFired.GetComponent<Rigidbody> ().AddForce (transform.TransformDirection (Vector3.forward) * force);
		laserSFX.PlayOneShot (laserSound);
		_timer = 0.1f; // rests the timer to 0.1 to create a delay in between each shot
	}
}
