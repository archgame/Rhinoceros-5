using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

	public InputSet inputset;
	public GameObject architect;
	public GameObject orbitCam;

	public GameObject Teshima;
	public GameObject Koenji;
	public GameObject Shimokitazawa;

	public Transform TeshimaPivot;
	public Transform KoenjiPivot;
	public Transform ShimokitazawaPivot;

	public TextAsset sitetxt;

	private bool lastGround;

	// Use this for initialization
	void Start () {

		//SET SITE

		//TESHIMA
		if (sitetxt.text == "1") {
			Teshima.SetActive (true);
			Koenji.SetActive (false);
			Shimokitazawa.SetActive (false);
			orbitCam.transform.position = TeshimaPivot.position;
			lastGround = false;
			Write (1);
		}
		
		//KOENJI
		if (sitetxt.text == "2") {
			Teshima.SetActive (false);
			Koenji.SetActive (true);
			Shimokitazawa.SetActive (false);
			orbitCam.transform.position = KoenjiPivot.position;
			lastGround = false;
			Write (2);
		}
		
		//SHIMOKITAZAWA
		if (sitetxt.text == "3") {
			Teshima.SetActive (false);
			Koenji.SetActive (false);
			Shimokitazawa.SetActive (true);
			orbitCam.transform.position = ShimokitazawaPivot.position;
			lastGround = false;
			Write (3);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		//SWITCH SITE

		//TESHIMA
		if (inputset.squarebutton) {
			Teshima.SetActive (true);
			Koenji.SetActive (false);
			Shimokitazawa.SetActive (false);
			orbitCam.transform.position = TeshimaPivot.position;
			lastGround = false;
			Write (1);
		}

		//KOENJI
		if (inputset.crossbutton) {
			Teshima.SetActive (false);
			Koenji.SetActive (true);
			Shimokitazawa.SetActive (false);
			orbitCam.transform.position = KoenjiPivot.position;
			lastGround = false;
			Write (2);
		}

		//SHIMOKITAZAWA
		if (inputset.circlebutton) {
			Teshima.SetActive (false);
			Koenji.SetActive (false);
			Shimokitazawa.SetActive (true);
			orbitCam.transform.position = ShimokitazawaPivot.position;
			lastGround = false;
			Write (3);
		}

		//REGROUND
		if (lastGround == false) {
			//RaycastHit hit;

			RaycastHit[] hits;
			hits = Physics.RaycastAll(architect.transform.position + (Vector3.up * 100), -Vector3.up, 300);
			//if (Physics.RaycastAll(architect.transform.position + (Vector3.up * 1000), -Vector3.up, out hit)) { 
			for (int i = 0; i < hits.Length; i++) {
				
				//Debug.Log ("hit");
				
				if (hits[i].transform.tag == "Ground") { 
					
					//Debug.Log ("hit ground ="+hit.point + Vector3.up);
					
					architect.transform.position = hits[i].point + Vector3.up;
					
					lastGround = true;
					
				}
			}
		}

		//SWITCH CAMERA
		if (inputset.right1) {

			if(architect.activeSelf){
				architect.SetActive(false);
				orbitCam.SetActive(true);
			}
			else if(orbitCam.activeSelf){
				architect.SetActive(true);
				orbitCam.SetActive(false);
			}
		
		}
	}

	void Write (int site){
		Debug.Log (site);
		System.IO.File.WriteAllText("C:/Users/Matthew Conway/Desktop/20160406_walk/walk/Assets/Standard Assets/Scripts/site.txt", site.ToString ());
	}
}
