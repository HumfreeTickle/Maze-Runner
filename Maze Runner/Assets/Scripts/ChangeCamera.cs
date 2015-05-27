using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{

	public Transform CameraPositionOne; //First position
	public Transform CameraPositionTwo; //Second position
	public Transform CameraPositionThree; //Third position
	public Transform CameraPositionFour; //Fourth position
	public Transform CameraPositionFive; //Fifth position

	public Image numberOne;
	public Image numberTwo;
	public Image numberThree;
	public Image numberFour;
	public Image numberFive;
	private Color cameraON = new Vector4 (0, 1, 0, 1);
	private Color cameraOFF = new Vector4 (0, 1, 0, 0.25f);
	private Camera mainCamera;
	private int changeCamera = 1;
	
	void Start ()
	{
		mainCamera = GetComponent<Camera> ();
		cameraPosition1 ();
	}

	void Update ()
	{
		changesCamera ();
	}

	void changesCamera ()
	{ // switch statement using an enum to change the camera position based on what key is pressed


		if (Input.GetKeyDown (KeyCode.Z)) {
			changeCamera = 1;
		} else if (Input.GetKeyDown (KeyCode.X)) {
			changeCamera = 2;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			changeCamera = 3;
		} else if (Input.GetKeyDown (KeyCode.V)) {
			changeCamera = 4;
		} else if (Input.GetKeyDown (KeyCode.B)) {
			changeCamera = 5;
		}


		switch (changeCamera) {
		case 1:
			cameraPosition1 ();
			break;
		case 2:
			cameraPosition2 ();
			break;
		case 3:
			cameraPosition3 ();
			break;
		case 4:
			cameraPosition4 ();
			break;
		case 5:
			cameraPosition5 ();
			break;
		default:
			throw new ArgumentOutOfRangeException (); //default case that throws the user an error if any of the cases aren't met
		}
	}

	void cameraPosition1 ()
	{
		transform.position = CameraPositionOne.position;
		transform.rotation = CameraPositionOne.rotation;
		mainCamera.fieldOfView = 60;
		numberOne.color = cameraON;
		numberTwo.color = cameraOFF;
		numberThree.color = cameraOFF;
		numberFour.color = cameraOFF;
		numberFive.color = cameraOFF;
	}

	void cameraPosition2 ()
	{
		transform.position = CameraPositionTwo.position;
		transform.rotation = CameraPositionTwo.rotation;
		mainCamera.fieldOfView = 75;
		numberOne.color = cameraOFF;
		numberTwo.color = cameraON;
		numberThree.color = cameraOFF;
		numberFour.color = cameraOFF;
		numberFive.color = cameraOFF;
	}

	void cameraPosition3 ()
	{
		transform.position = CameraPositionThree.position;
		transform.rotation = CameraPositionThree.rotation;
		mainCamera.fieldOfView = 60;
		numberOne.color = cameraOFF;
		numberTwo.color = cameraOFF;
		numberThree.color = cameraON;
		numberFour.color = cameraOFF;
		numberFive.color = cameraOFF;
	}

	void cameraPosition4 ()
	{
		transform.position = CameraPositionFour.position;
		transform.rotation = CameraPositionFour.rotation;
		mainCamera.fieldOfView = 75;
		numberOne.color = cameraOFF;
		numberTwo.color = cameraOFF;
		numberThree.color = cameraOFF;
		numberFour.color = cameraON;
		numberFive.color = cameraOFF;
	}

	void cameraPosition5 ()
	{
		transform.position = CameraPositionFive.position;
		transform.rotation = CameraPositionFive.rotation;
		mainCamera.fieldOfView = 60;
		numberOne.color = cameraOFF;
		numberTwo.color = cameraOFF;
		numberThree.color = cameraOFF;
		numberFour.color = cameraOFF;
		numberFive.color = cameraON;
	}
}
