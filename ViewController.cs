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
private bool isStartDist;
public float startDist;
public float currentDist;
private GameObject gameCube;
private bool shouldUpdateGameCube;

/*TODO:
	rotate cube

	shift cube

	create better model for cube


*/


float roundToDecimalPlace(float num, float decimalPlace) {
  float processor = Mathf.Pow(10, decimalPlace);
  num = (num * processor);
  return Mathf.Round(num) / processor;
}

	// void Awake () {
	// 	// handController = GameObject.Find("HandController");
	// 	// HandControllerScript = handController.GetComponent<HandController>() as HandController;
	// }
	void Start () {
		gameCube = GameObject.Find("GameSpace");
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
					handScriptL.hand.PalmPosition.x,
					handScriptL.hand.PalmPosition.y,
					handScriptL.hand.PalmPosition.z
				);
				rightPos = new Vector3(
					handScriptR.hand.PalmPosition.x,
					handScriptR.hand.PalmPosition.y,
					handScriptR.hand.PalmPosition.z
				);
				if (isStartDist) {
					startDist = Vector3.Distance(leftPos, rightPos);
					isStartDist = false;
					shouldUpdateGameCube = true;
				} else {
					currentDist = Vector3.Distance(leftPos, rightPos);
					float cubeScale = (currentDist-startDist)/100f;
					startDist = currentDist;
					gameCube.transform.localScale += new Vector3(cubeScale,cubeScale,cubeScale);
				}
			} else {
				isStartDist = true;
			}
		}


	}
}
