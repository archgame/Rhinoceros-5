using UnityEngine;
using System.Collections;
using System.Collections.Generic; //use for arrays
using UnityEngine.UI; // required when using UI elements in scripts

public class Track_test : MonoBehaviour {

	//UI ELEMENTS
	public Button[] enable;
	public Button[] cui;
	public Slider[] slider;

	//COLOR
	public Color[] colors;
	// 0 = Normal Color
	// 1 = Highlighted Color
	// 2 = On Color
	// 3 = Off Color
	// 4 = Press Color
	// 5 = Half Highlighted Color

	//VARIABLES
	private int activeClip;
	private int activeCUI;
	private float slideValue;

	void Start () {

		//SET ALL COLORS
		for (int i = 0; i < 8; i++) {

			//ENABLE BUTTON COLORS
			ColorBlock cbEnable = enable[i].colors;
			cbEnable.normalColor = colors[5];
			cbEnable.highlightedColor = colors[1];
			cbEnable.pressedColor = colors[2];
			cbEnable.disabledColor = colors[3];
			enable[i].colors = cbEnable;

			//CUI BUTTON COLORS
			ColorBlock cbCui = cui[i].colors;
			cbCui.normalColor = colors[2];
			cbCui.highlightedColor = colors[1];
			cbCui.pressedColor = colors[4];
			cbCui.disabledColor = colors[3];
			cui[i].colors = cbCui;

			//SLIDER COLORS
			ColorBlock cbSlider = slider[i].colors;
			cbSlider.normalColor = colors[2];
			cbSlider.highlightedColor = colors[1];
			cbSlider.pressedColor = colors[4];
			cbSlider.disabledColor = colors[3];
			slider[i].colors = cbSlider;
			
		}

		//DISABLE ALL BUTTONS AND SLIDERS ON INITIALIZE
		for (int i = 1; i < 8; i++) {

			cui[i].interactable = false;
			slider[i].interactable = false;

		}

		//ENABLE BUTTON COLORS
		ColorBlock cbStart = enable[0].colors;
		cbStart.normalColor = colors[2];
		cbStart.highlightedColor = colors[2];
		cbStart.pressedColor = colors[4];
		cbStart.disabledColor = colors[3];
		enable[0].colors = cbStart;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Disable(){

		//Debug.Log ("CLIP = " + activeClip);

		//ENABLE SELECTED BUTTON
		for (int i = 0; i < 8; i++) {
			
			cui[i].interactable = false;
			slider[i].interactable = false;

			//ENABLE BUTTON COLORS [DISABLED]
			ColorBlock cbDisable = enable[i].colors;
			cbDisable.normalColor = colors[5];
			cbDisable.highlightedColor = colors[1];
			//cbDisable.pressedColor = colors[4];
			//cbDisable.disabledColor = colors[3];
			enable[i].colors = cbDisable;

			if(i == (activeClip-1)){

				cui[(i)].interactable = true;
				slider[(i)].interactable = true;

				//ENABLE BUTTON COLORS [ENABLE]
				ColorBlock cbEnable = enable[i].colors;
				cbEnable.normalColor = colors[2];
				cbEnable.highlightedColor = colors[2];
				//cbEnable.pressedColor = colors[4];
				//cbEnable.disabledColor = colors[3];
				enable[i].colors = cbEnable;
			}
			
		}

	}

	public void Enable (int clip) {

		activeClip = clip;
		Disable ();
		
	}

	public void CustomUI (int clip) {

		activeCUI = clip;
		
	}

	public void Sliding (int value) {

		slideValue = slider [(value - 1)].value;
		
	}
}
