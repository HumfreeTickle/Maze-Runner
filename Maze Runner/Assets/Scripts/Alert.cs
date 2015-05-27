using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
	private Color alert;
	public Transform player;
	public Transform enemy;
	private float distanceBetween;
	public float alertValue;
	private Vector3 startValue; 
	// Use this for initialization
	void Start ()
	{
		alert = Color.green;
		startValue= transform.localScale/2;
		transform.localScale = startValue;
	}
	
	// Update is called once per frame
	void Update ()
	{
		alertStatus();
		GetComponent<Image> ().color = alert;
	}

	void alertStatus(){
		distanceBetween = Vector3.Distance(player.position, enemy.position);
		if(distanceBetween < alertValue){ //when close to an enemy the sensor slowly changes to red and grows.
			alertValue = distanceBetween;
			alert = Color.Lerp (alert, Color.red, Time.deltaTime/10);
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (2f, 2f ,2f), Time.deltaTime/10);
		}
		else if(distanceBetween > alertValue){ //as you move away from the enemy the sensor returns to its origial size and colour
			alert = Color.Lerp (alert, Color.green, Time.deltaTime/10);
			transform.localScale = Vector3.Lerp(transform.localScale, startValue, Time.deltaTime/10);
			if(distanceBetween >= 40){ //resets the alert distance
				alertValue = 40;
			}
		}
	}
	                
}
