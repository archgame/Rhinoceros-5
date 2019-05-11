using UnityEngine;
using System.Collections;

public class ManipulateObject : MonoBehaviour {

	public InputSet inputset;
	private bool selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		float distanceToGround = 0;

		if (inputset.trianglebuttondown) {
			selected = true;
		}

		if (inputset.trianglebuttondown) {
			if (Physics.Raycast (transform.position+transform.up, transform.forward, out hit)) {
				Debug.Log("wall");
			}
		}
	
	}
}
