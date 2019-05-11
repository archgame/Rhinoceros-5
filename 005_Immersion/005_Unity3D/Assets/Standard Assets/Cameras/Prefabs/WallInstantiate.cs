using UnityEngine;
using System.Collections;

public class WallInstantiate : MonoBehaviour {

	public InputSet inputset;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (inputset.crossbutton) {

			GameObject wall;
			wall = Instantiate(prefab, transform.position+(transform.forward*5), transform.rotation) as GameObject;

		}
	
	}
}
