using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {
	
	public float rotationspeed = 1.0f;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public InputSet inputset;
	private Vector3 moveDirection = Vector3.zero;
	private float control = 0.1f;
	private float pitch = 0;

	private int invertx = 1;
	private int inverty = 1;

	void Update() {

		//RELATIVE TO CAMERA FORWARD
		transform.forward = Camera.main.transform.forward;

		//MOVEMENT
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			if (inputset.leftanaloghorizontal > control || inputset.leftanalogvertical > control || inputset.leftanaloghorizontal < -control || inputset.leftanalogvertical < -control) {
				moveDirection = new Vector3 (inputset.leftanaloghorizontal, 0, inputset.leftanalogvertical);
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				//if (inputset.trianglebuttondown)
				//	moveDirection.y = jumpSpeed;


			} else {
				moveDirection.x *= 0.7f;
				moveDirection.z *= 0.7f;
			}
		} 


		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		//ROTATION
		if (inputset.rightanaloghorizontal > control) {
			transform.RotateAround (transform.position, transform.up, -rotationspeed*invertx);
		}

		if (inputset.rightanaloghorizontal < -control) {
			transform.RotateAround (transform.position, transform.up, rotationspeed*invertx);
		}


		//PITCH
		if (inputset.rightanalogvertical > control) {
			pitch = inputset.rightanalogvertical;
		} else if (inputset.rightanalogvertical < -control) {
			pitch = inputset.rightanalogvertical;
		} else {
			pitch = 0;
		}

		transform.RotateAround (Camera.main.transform.position, transform.right, pitch*inverty);

		//INVERT
		if(inputset.right3down){

			if(invertx == 1 && inverty == 1){
				inverty = -1;
			}
			else if(invertx == 1 && inverty == -1){
				invertx = -1;
			}
			else if(invertx == -1 && inverty == -1){
				inverty = 1;
			}
			else if(invertx == -1 && inverty == 1){
				invertx = 1;
			}
			
		}
	}


}