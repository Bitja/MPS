using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject;
	public static GameObject infoButton,infoImage1,infoImage2,infoImage3,infoImage4,infoImage5, path4;
	public static Image infoPanel;
	public static Text infoText;
    private static bool skrap= false;



	void Start () {
		infoButton = GameObject.Find ("InfoButton");
		infoText = infoTextObject.GetComponent<Text>();
		infoPanel = infoPanelObject.GetComponent<Image>();

		infoImage1 = GameObject.Find ("InfoImage1");
		infoImage2 = GameObject.Find ("InfoImage2");
		infoImage3 = GameObject.Find ("InfoImage3");
		infoImage4 = GameObject.Find ("InfoImage4");
		infoImage5 = GameObject.Find ("InfoImage5");

		infoImage1.SetActive (false);
		infoImage2.SetActive (false);
		infoImage3.SetActive (false);
		infoImage4.SetActive (false);
		infoImage5.SetActive (false);

		infoButton.SetActive(false);
		infoText.enabled = false;
		infoPanel.enabled = false;
	
	}

	public static void showInfoButton(){
		infoButton.SetActive (true);
	}

	public void showInfo(){
		infoButton.SetActive (false);
		infoText.enabled = true;
		infoPanel.enabled = true;
		
		if (PathTracer.currentLevel == 0) {
			infoText.text = "Hello world";
		}
		else if (PathTracer.currentLevel == 1) {
			infoText.text = "Grap your widget and get ready for the first level!";
			infoImage1.SetActive (true);
		}
		else if (PathTracer.currentLevel == 2) {
			infoText.text = "Grap your widget and get ready for the next level!";
			infoImage1.SetActive (true);
		}
		else if (PathTracer.currentLevel == 3) {
            infoText.text = "Grap your widget and get ready for the last level!";
            infoImage1.SetActive (true);
		}		
		else if (PathTracer.currentLevel == 4) {
            if (skrap == false) {
                infoText.text = "Part A has now ended. Continue to Part B.";
                skrap = true;
            }
            else if (skrap == true){
                infoText.text = "You have now completed the game.";
            }
        }

		else if (PathTracer.currentLevel == 5) {
			infoText.text = "For your next task, use the solid widget and the light following it.";
			infoImage5.SetActive (true);
		}
		else if (PathTracer.currentLevel == 6) {
			infoText.text = "That was it for the test. Thank you for your participation.";
		}

	}
}
