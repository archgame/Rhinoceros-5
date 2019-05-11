using UnityEngine;
using System;
using System.Collections;

public class InputSet : MonoBehaviour {

	//VARIABLES
	[HideInInspector]
	public bool joystick;
	private float sensitivity = 0.5f;
	//private int power = 3;

	//AXIS
	public float leftanalogvertical;
	public float leftanaloghorizontal;
	public float rightanalogvertical;
	public float rightanaloghorizontal;
	public float leftanalogverticaltemp;
	public float leftanaloghorizontaltemp;
	public float rightanalogverticaltemp;
	public float rightanaloghorizontaltemp;
	[HideInInspector]
	public Vector3 leftanalog;
	[HideInInspector]
	public Vector3 rightanalog;

	//BUTTON
	[HideInInspector]
	public bool trianglebuttondown;
	[HideInInspector]
	public bool trianglebuttonup;
	[HideInInspector]
	public bool crossbutton;
	[HideInInspector]
	public bool circlebutton;
	[HideInInspector]
	public bool squarebutton;

	//JOYSTICK BUTTON
	[HideInInspector]
	public bool right3down;
	[HideInInspector]
	public bool right3up;
	private float scroll;

	//TRIGGER
	[HideInInspector]
	public float trigger;
	[HideInInspector]
	public bool right1;
	public bool left1;

	//MENU
	[HideInInspector]
	public bool options;
	[HideInInspector]
	public bool share;

	//INVERT VARIABLE
	[HideInInspector]
	public int invertx = -1;
	[HideInInspector]
	public int inverty = 1;

	//public CameraScript camscript;

	void Start(){

		joystick = false;

		if (Input.GetJoystickNames().Length != 0) 
		{
			joystick = true;
		}

		leftanalogvertical = 0;
		leftanaloghorizontal = 0;
		rightanalogvertical = 0;
		rightanaloghorizontal = 0;

	}

	void Update()
	{

		//GAMEPAD
		if (joystick == true) 
		{
			//INDEPENDENT AXIS
			leftanalogverticaltemp = Input.GetAxisRaw ("LeftAnalogVertical");
			leftanaloghorizontaltemp = Input.GetAxisRaw ("LeftAnalogHorizontal");
			rightanalogverticaltemp = Input.GetAxisRaw ("RightAnalogVertical");
			rightanaloghorizontaltemp = Input.GetAxisRaw ("RightAnalogHorizontal");

			//SMOOTH "S" CURVE
			//leftanalogverticaltemp = ((Mathf.Cos(((leftanalogverticaltemp-1)*Mathf.PI))+1)/2) * Mathf.Sign(leftanalogverticaltemp);
			//leftanaloghorizontaltemp = ((Mathf.Cos(((leftanaloghorizontaltemp-1)*Mathf.PI))+1)/2) * Mathf.Sign(leftanaloghorizontaltemp);
			//rightanalogverticaltemp = ((Mathf.Cos(((rightanalogverticaltemp-1)*Mathf.PI))+1)/2) * Mathf.Sign(rightanalogverticaltemp);
			//rightanaloghorizontaltemp = ((Mathf.Cos(((rightanaloghorizontaltemp-1)*Mathf.PI))+1)/2) * Mathf.Sign(rightanalogverticaltemp);

			//POWER
			//leftanalogverticaltemp = Mathf.Pow(leftanalogverticaltemp,power);
			//leftanaloghorizontaltemp = Mathf.Pow(leftanaloghorizontaltemp,power);
			//rightanalogverticaltemp = Mathf.Pow(rightanalogverticaltemp,power);
			//rightanaloghorizontaltemp = Mathf.Pow(rightanaloghorizontaltemp,power);

			//INVERT SET
			rightanalogverticaltemp = rightanalogverticaltemp * inverty;
			rightanaloghorizontaltemp = rightanaloghorizontaltemp * invertx;

			//ANALOG SENSITIVITY
			leftanalogvertical = Mathf.Lerp(leftanalogvertical,leftanalogverticaltemp,sensitivity);
			leftanaloghorizontal = Mathf.Lerp(leftanaloghorizontal,leftanaloghorizontaltemp,sensitivity);
			rightanalogvertical = Mathf.Lerp(rightanalogvertical,rightanalogverticaltemp,sensitivity);
			rightanaloghorizontal = Mathf.Lerp(rightanaloghorizontal,rightanaloghorizontaltemp,sensitivity);

			//VECTOR3 COMPILE
			leftanalog = new Vector3 (leftanaloghorizontal, 0, leftanalogvertical);
			rightanalog = new Vector3 (rightanaloghorizontal, 0, rightanalogvertical);

			//Debug.Log (leftanalog);

			//BUTTON
			trianglebuttondown = Input.GetButtonDown ("TriangleButton");
			trianglebuttonup = Input.GetButtonUp ("TriangleButton");
			crossbutton = Input.GetButtonDown ("CrossButton");
			circlebutton = Input.GetButtonDown("CircleButton");
			squarebutton = Input.GetButtonDown("SquareButton");


			right3down = Input.GetButtonDown ("Right3");
			right3up = Input.GetButtonUp ("Right3");

			//TRIGGER L2 = -1 R2 = 1
			trigger = Input.GetAxis("Trigger");
			right1 = Input.GetButtonUp("Right1");
			left1 = Input.GetButtonUp("Left1");

			//MENU
			options = Input.GetButtonDown("Options");
			share = Input.GetButtonDown("Share");
		}

		//KEYBOARD
		if (joystick != true) 
		{
			//AXIS
			if(Input.GetKey("w")){
				leftanalogvertical = 1;
			}
			else if(Input.GetKey ("s")){
				leftanalogvertical = -1;
			}
			else{
				leftanalogvertical = 0;
			}

			if(Input.GetKey("d")){
				leftanaloghorizontal = 1;
			}
			else if(Input.GetKey ("a")){
				leftanaloghorizontal = -1;
			}
			else{
				leftanaloghorizontal = 0;
			}

			//CAMERA
			rightanalogvertical = 0;
			rightanaloghorizontal = 0;
			//rightanalog = Vector3.zero;

			if (Input.GetMouseButton(0)){
				rightanalogvertical = Input.GetAxis ("RightAnalogVerticalKey");
				rightanaloghorizontal = Input.GetAxis ("RightAnalogHorizontalKey");

			}

			leftanalog = new Vector3 (leftanaloghorizontal,0,leftanalogvertical);
			rightanalog = new Vector3 (leftanaloghorizontal, 0, leftanalogvertical);

			//Debug.Log (rightanalog);
			
			//BUTTON
			trianglebuttondown = Input.GetButtonDown ("TriangleButtonKey");
			trianglebuttonup = Input.GetButtonUp ("TriangleButtonKey");
			crossbutton = Input.GetButtonDown ("CrossButtonKey");
			circlebutton = Input.GetKeyDown(KeyCode.LeftShift);
			squarebutton = Input.GetKeyDown(KeyCode.LeftControl);

			//ZOOM
			right3down = false;
			right3up = false;
			if(Input.GetAxis("Right3Key") > 0){
				//camscript.zoom = false;
				//Debug.Log("forward");
			}
			else if(Input.GetAxis("Right3Key") < 0){
				//camscript.zoom = true;
				//Debug.Log("back");
			}
			//Debug.Log (Input.GetAxis ("Right3Key"));

			//TRIGGER L2 = -1 R2 = 1

			//FOLLOW
			trigger = 0;
			if (Input.GetMouseButtonDown(2)){
				trigger = -1;
			}

			//TOGGLE PERSPECTIVE
			if (Input.GetMouseButtonDown(1)){
				trigger = 1;
			}
			if (Input.GetButtonUp("Right2Key")){
				trigger = 1;
			}

			right1 = Input.GetButtonUp("Right1Key");
			
			//MENU
			options = Input.GetButtonDown("OptionsKey");
			share = Input.GetButtonDown("ShareKey");
		}

	}
}
