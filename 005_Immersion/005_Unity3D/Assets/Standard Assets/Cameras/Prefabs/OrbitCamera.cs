using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

	//GAMEOBJECTS
	public InputSet inputset;
	public GameObject objectCamera;

	//PIVOT
	private float pivot;

	//PITCH
	private float pitchmin = -89;
	private float pitchmax = 89;
	private float pitch;

	//ZOOM
	private float zoffsetmin = 50;
	private float zoffsetmax = 100;
	private float zoffset;

	private Vector3 tempvec;


	// Use this for initialization
	void Start () {

		zoffset = zoffsetmax;
	
	}
	
	// Update is called once per frame
	void Update () {

		//PIVOT
		pivot += inputset.rightanaloghorizontal;
		tempvec = transform.rotation.eulerAngles;
		tempvec.y = pivot;
		//Debug.Log (inputset.rightanaloghorizontal);

		//PITCH
		pitch += inputset.rightanalogvertical;
		pitch = Mathf.Clamp(pitch, pitchmin, pitchmax);
		tempvec.x = pitch;
		transform.rotation = Quaternion.Euler(tempvec);

		//ZOOM
		zoffset -= inputset.leftanalogvertical;
		zoffset = Mathf.Clamp(zoffset, zoffsetmin, zoffsetmax);
		tempvec = objectCamera.transform.localPosition;
		tempvec.z = -zoffset;
		objectCamera.transform.localPosition = tempvec;
	
	}
}
