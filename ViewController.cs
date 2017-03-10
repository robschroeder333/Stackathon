using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class ViewController : MonoBehaviour {

// script imports
// private HandController HandControllerScript;
// private SkeletalHand SkeletalHandScript1;
private HandState handScriptL;
private HandState handScriptR;

// var declaration
// private GameObject handController;
private GameObject handL;
private GameObject handR;
private Vector3 leftPos;
private Vector3 rightPos;

/*TODO:
	get magnitude between the two hands

	relate magnitude to scale of cube


*/


float roundToDecimalPlace(float num, float decimalPlace) {
  float processor = Mathf.Pow(10, decimalPlace);
  num = (num * processor);
  return Mathf.Round(num) / processor;
}

	void Awake () {
		// handController = GameObject.Find("HandController");
		// HandControllerScript = handController.GetComponent<HandController>() as HandController;
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

			handL = GameObject.Find("GlowRobotLeftHand(Clone)");
			handR = GameObject.Find("GlowRobotRightHand(Clone)");

		if (handL) {
			handScriptL = handL.GetComponent<HandState>() as HandState;
		}
		if (handR) {
			handScriptR = handR.GetComponent<HandState>() as HandState;
		}

		if (handL && handR) {
			if (handScriptL.IsFist() && handScriptR.IsFist()) {
				leftPos = new Vector3(
					roundToDecimalPlace(handScriptL.hand.PalmPosition.x, 2),
					roundToDecimalPlace(handScriptL.hand.PalmPosition.y, 2),
					roundToDecimalPlace(handScriptL.hand.PalmPosition.z, 2));
				rightPos = new Vector3(
					roundToDecimalPlace(handScriptR.hand.PalmPosition.x, 2),
					roundToDecimalPlace(handScriptR.hand.PalmPosition.y, 2),
					roundToDecimalPlace(handScriptR.hand.PalmPosition.z, 2));

				Debug.Log(leftPos);
				Debug.Log(rightPos);
			}
		}


	}
}
