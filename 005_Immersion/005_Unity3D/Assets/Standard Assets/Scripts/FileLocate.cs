using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Text;

public class FileLocate : MonoBehaviour {

	private string url = "http://makuro.org:9090/data/test.txt";
	private string filepath;
	private TextAsset textFile;
	private string[] textLines;
	private string textcheck;

	public Track masTrack;
	public Track orgTrack;
	public Track plnTrack;
	public Track secTrack;
	public Track cirTrack;
	public Track geoTrack;
	public Track strTrack;
	public Track srfTrack;

	private string[] outputdata = new string[40];
	private string outputdataList = "start";
	private string blankList = "";
	private string outputdataLast = "def";

	public void Start()
	{
		//StartCoroutine(Check());
	}
	
	IEnumerator Check () {

		WWW www = new WWW(url);
		yield return www;
		textcheck = www.text;
		//Debug.Log (textcheck);
		//textFile =  (TextAsset)AssetDatabase.LoadAssetAtPath(www.text, typeof(TextAsset));
		//textLines = (textFile.text.Split('\n'));

		//POSTFORM
		WWWForm postForm = new WWWForm();
		//EXAMPLE
		//postForm.AddBinaryData("webupload", Encoding.UTF8.GetBytes("10\n20\n30"), "test.txt", "text/plain");
		//TEST
		postForm.AddBinaryData("webupload", Encoding.UTF8.GetBytes(outputdataList), "test.txt", "text/plain");
		WWW upload = new WWW("http://makuro.org:9090/upload",postForm);        
		yield return upload;

		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);

		/* example code to separate all that text in to lines:
         longStringFromFile = w.text
         List<string> lines = new List<string>(
             longStringFromFile
             .Split(new string[] { "\r","\n" },
             StringSplitOptions.RemoveEmptyEntries) );
         // remove comment lines...
         lines = lines
             .Where(line => !(line.StartsWith("//")
                             || line.StartsWith("#")))
             .ToList();
         */

	}

	void Update () {

		//UPDATE STRING
		//MASSING
		outputdata [0] = masTrack.textLines [0].ToString();
		outputdata [1] = masTrack.sliderdata [0].ToString();
		outputdata [2] = masTrack.sliderdata [1].ToString();
		outputdata [3] = masTrack.sliderdata [2].ToString();
		outputdata [4] = masTrack.sliderdata [3].ToString();
		//ORGANIZATION
		outputdata [5] = orgTrack.textLines [0].ToString();
		outputdata [6] = orgTrack.sliderdata [0].ToString();
		outputdata [7] = orgTrack.sliderdata [1].ToString();
		outputdata [8] = orgTrack.sliderdata [2].ToString();
		outputdata [9] = orgTrack.sliderdata [3].ToString();
		//PLAN
		outputdata [10] = plnTrack.textLines [0].ToString();
		outputdata [11] = plnTrack.sliderdata [0].ToString();
		outputdata [12] = plnTrack.sliderdata [1].ToString();
		outputdata [13] = plnTrack.sliderdata [2].ToString();
		outputdata [14] = plnTrack.sliderdata [3].ToString();
		//SECTION
		outputdata [15] = secTrack.textLines [0].ToString();
		outputdata [16] = secTrack.sliderdata [0].ToString();
		outputdata [17] = secTrack.sliderdata [1].ToString();
		outputdata [18] = secTrack.sliderdata [2].ToString();
		outputdata [19] = secTrack.sliderdata [3].ToString();
		//CIRCULATION
		outputdata [20] = cirTrack.textLines [0].ToString();
		outputdata [21] = cirTrack.sliderdata [0].ToString();
		outputdata [22] = cirTrack.sliderdata [1].ToString();
		outputdata [23] = cirTrack.sliderdata [2].ToString();
		outputdata [24] = cirTrack.sliderdata [3].ToString();
		//GEOMETRY
		outputdata [25] = geoTrack.textLines [0].ToString();
		outputdata [26] = geoTrack.sliderdata [0].ToString();
		outputdata [27] = geoTrack.sliderdata [1].ToString();
		outputdata [28] = geoTrack.sliderdata [2].ToString();
		outputdata [29] = geoTrack.sliderdata [3].ToString();
		//STRUCTURE
		outputdata [30] = strTrack.textLines [0].ToString();
		outputdata [31] = strTrack.sliderdata [0].ToString();
		outputdata [32] = strTrack.sliderdata [1].ToString();
		outputdata [33] = strTrack.sliderdata [2].ToString();
		outputdata [34] = strTrack.sliderdata [3].ToString();
		//SURFACE
		outputdata [35] = srfTrack.textLines [0].ToString();
		outputdata [36] = srfTrack.sliderdata [0].ToString();
		outputdata [37] = srfTrack.sliderdata [1].ToString();
		outputdata [38] = srfTrack.sliderdata [2].ToString();
		outputdata [39] = srfTrack.sliderdata [3].ToString();

		//TRANSLATE DATA
		outputdataList = outputdataList.Replace(outputdataList,blankList);

		for (int i = 0; i < outputdata.Length; i++) {
			outputdataList += outputdata [i] + "\n";
		}

		//UPLOAD
		if (outputdataList != outputdataLast) {
			outputdataLast = outputdataList;
			StartCoroutine (Check ());
		}
	
	}
}
