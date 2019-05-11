using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic; //use for arrays
using UnityEngine.UI; // required when using UI elements in scripts

public class Track : MonoBehaviour {

	//TITLE
	public Text dataText;
	public Text clipnameText;
	public Text slidernameText;

	//UI ELEMENTS
	public Button[] clips;
	public Slider[] sliders;
	public Button[] tool;

	//COLOR
	public Color[] colors;
	// 0 = Normal Color
	// 1 = Highlighted Color
	// 2 = On Color
	// 3 = Off Color
	// 4 = Press Color

	//PRIVATE VARIABLES
	private int activeClip = 0;
	private int activeSlide = 1;
	private bool activeTool = false;
	private int lastClip = 0;
	private int lastSlide = 0;

	//TEXT IMPORTER
	public string filepath;
	public TextAsset textFile;
	private Text textHold;
	[HideInInspector]
	public string[] textLines;
	private int[] cliptext = new int[4];
	private int[] clip1text = new int[] {5,7,9,11};
	private int[] clip2text = new int[] {14,16,18,20};
	private int[] clip3text = new int[] {23,25,27,29};
	private int[] clip4text = new int[] {32,34,36,38};

	//IMPORT VARIABLES
	private string[] clipnames = new string[5];
	private string[] slidernames = new string[4];
	[HideInInspector]
	public float[] sliderdata = new float[4];
	private bool toolAvailable = false;


	void Start () {

		//SET ALL COLORS
		for (int i = 0; i < 4; i++) {

			//CLIP BUTTON COLORS
			ColorBlock cbEnable = clips[i].colors;
			cbEnable.normalColor = colors[2];
			cbEnable.highlightedColor = colors[1];
			cbEnable.pressedColor = colors[2];
			cbEnable.disabledColor = colors[3];
			clips[i].colors = cbEnable;

			//SLIDER COLORS
			ColorBlock cbSlider = sliders[i].colors;
			cbSlider.normalColor = colors[2];
			cbSlider.highlightedColor = colors[1];
			cbSlider.pressedColor = colors[4];
			cbSlider.disabledColor = colors[3];
			sliders[i].colors = cbSlider;
			
		}

		//TOOL BUTTON COLORS
		ColorBlock cbCui = tool[0].colors;
		cbCui.normalColor = colors[2];
		cbCui.highlightedColor = colors[1];
		cbCui.pressedColor = colors[4];
		cbCui.disabledColor = colors[3];
		tool[0].colors = cbCui;

		//TEXT IMPORT SPLIT
		//textFile =  (TextAsset)AssetDatabase.LoadAssetAtPath(filepath, typeof(TextAsset));

		if (textFile != null) 
		{
			textLines = (textFile.text.Split('\n'));
		}

		//CLIP INITIALIZE
		activeClip = int.Parse(textLines [0]);
		clipnames[0] = "default";
		clipnames[1] = textLines [1];
		clipnames[2] = textLines [2];
		clipnames[3] = textLines [3];
		clipnames[4] = textLines [4];
		for (int i = 0; i < 5; i++) {
			if(clipnames[i].Contains("9")){
				clips[i-1].interactable = false;
			}
		}
	}

	void Update () {

		//ACTIVE CLIP UPDATE
		if (activeClip != lastClip) {

			if(activeClip == 1){
				cliptext = clip1text;
				textLines[0] = 1.ToString();
			}
			else if(activeClip == 2){
				cliptext = clip2text;
				textLines[0] = 2.ToString();
			}
			else if(activeClip == 3){
				cliptext = clip3text;
				textLines[0] = 3.ToString();
			}
			else if(activeClip == 4){
				cliptext = clip4text;
				textLines[0] = 4.ToString();
			}

			//COLORS
			for (int i = 0; i < 4; i++) {

				//CLIP DATA
				if(int.Parse (textLines[cliptext[i]+1]) == 999){
					sliders[i].interactable = false;
				}
				else {
					//Debug.Log(textLines[cliptext[i]+1]);
					sliders[i].interactable = true;
					slidernames[i] = textLines[cliptext[i]];
					sliderdata[i] = int.Parse(textLines[cliptext[i]+1]);
					sliders[i].value = sliderdata[i];
				}

				//CLIP BUTTON COLORS
				ColorBlock cbEnable = clips[i].colors;
				cbEnable.normalColor = colors[2];
				clips[i].colors = cbEnable;

				if(i == activeClip - 1){	
					cbEnable = sliders[i].colors;
					cbEnable.normalColor = colors[4];
					clips[i].colors = cbEnable;	
				}
			}
			lastClip = activeClip;
		}

		//ACTIVE SLIDER UPDATE
		if (activeSlide != lastSlide) {

			//COLOR
			for (int i = 0; i < 4; i++) {
				//SLIDER COLORS
				ColorBlock cbSlider = sliders[i].colors;
				cbSlider.normalColor = colors[2];
				sliders[i].colors = cbSlider;

				if(i == activeSlide - 1){
					cbSlider = sliders[i].colors;
					cbSlider.normalColor = colors[4];
					sliders[i].colors = cbSlider;
				}
			}
			lastSlide = activeSlide;
		}

		//TITLE UPDATE
		clipnameText.text = clipnames [activeClip];
		slidernameText.text = slidernames [activeSlide-1];
		dataText.text = sliders [activeSlide-1].value.ToString ();
		//SLIDER DATA UPDATE
		sliderdata [activeSlide-1] = sliders [activeSlide - 1].value;
	}

	//FUNCTIONS

	void Tool(){

		if (activeTool)
		{
			activeTool = false;
		} else {
			activeTool = true;
		}

	}

	public void Clip (int clip) {

		activeClip = clip;

	}

	public void Sliding (int value) {

		activeSlide = value;
		
	}

	public void ToolUI (bool clip) {

		Tool ();
		
	}
}
