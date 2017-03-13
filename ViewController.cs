using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;

public class ViewController : MonoBehaviour {

// script imports
private HandState handScriptL;
private HandState handScriptR;

// var declaration
private GameObject handL;
private GameObject handR;
private Vector3 leftPos;
private Vector3 rightPos;
private bool isStartDist;
private float startDist;
private float currentDist;
private GameObject gameCube;
private bool shouldUpdateGameCubeScale;
public float scaleRate = 50f;
private bool isStartRot;
private Vector3 startRot;
private Vector3 currentRot;
private bool shouldUpdateGameCubeRot;
private bool isStartPos;
private Vector3 startPos;
private Vector3 currentPos;
private bool shouldUpdateGameCubePos;
public float posRate = 50f;

/*TODO:
	-rotate cube
		y is good -z is good but combined is acting strange

	-create better model for cube


*/

	void Start () {
		gameCube = GameObject.Find("GameSpace");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey("escape")) {
			Application.Quit();
		}
		if (Input.GetKey("space")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

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
				isStartPos = true;

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

				HandleScaling();
				HandleRotation();

			} else if (handScriptL.IsFist()) {
				leftPos = new Vector3(
					handScriptL.hand.PalmPosition.x,
					handScriptL.hand.PalmPosition.y,
					handScriptL.hand.PalmPosition.z
				);
				HandleShifting(leftPos);
			} else if (handScriptR.IsFist()) {
				rightPos = new Vector3(
					handScriptR.hand.PalmPosition.x,
					handScriptR.hand.PalmPosition.y,
					handScriptR.hand.PalmPosition.z
				);
				HandleShifting(rightPos);
			} else {
				isStartPos = true;
				isStartDist = true;
				isStartRot = true;
			}
		} else if (handL && handScriptL.IsFist()) {
				leftPos = new Vector3(
					handScriptL.hand.PalmPosition.x,
					handScriptL.hand.PalmPosition.y,
					handScriptL.hand.PalmPosition.z
				);
				HandleShifting(leftPos);
		} else if (handR && handScriptR.IsFist()) {
				rightPos = new Vector3(
					handScriptR.hand.PalmPosition.x,
					handScriptR.hand.PalmPosition.y,
					handScriptR.hand.PalmPosition.z
				);
				HandleShifting(rightPos);
		} else {
			isStartPos = true;
		}


	}

	float roundToDecimalPlace (float num, float decimalPlace) {
		float processor = Mathf.Pow(10, decimalPlace);
		num = (num * processor);
		return Mathf.Round(num) / processor;
	}

	void HandleScaling () {
		if (isStartDist) {
			startDist = Vector3.Distance(leftPos, rightPos);
			isStartDist = false;
			shouldUpdateGameCubeScale = true;
		} else {
			currentDist = Vector3.Distance(leftPos, rightPos);
			float cubeScale = (currentDist - startDist) / scaleRate;
			startDist = currentDist;
			gameCube.transform.localScale += new Vector3(cubeScale,cubeScale,cubeScale);
		}
	}

	void HandleRotation () {
		if (isStartRot) {
			startRot = rightPos - leftPos;
			isStartRot = false;
			shouldUpdateGameCubeRot = true;
		} else {
			currentRot = rightPos - leftPos;
			Vector3 cubeRot = (currentRot - startRot);
			startRot = currentRot;
			// gameCube.transform.Rotate(0f, cubeRot.z, cubeRot.y); acting strange
			gameCube.transform.Rotate(0, cubeRot.z, 0);
		}
	}

	void HandleShifting (Vector3 handPos) {
		if (isStartPos) {
			startPos = handPos;
			isStartPos = false;
			shouldUpdateGameCubePos = true;
		} else {
			currentPos = handPos;
			Vector3 cubeShift = (currentPos - startPos) / posRate;
			startPos = currentPos;
			gameCube.transform.position += new Vector3(cubeShift.x, cubeShift.y, -cubeShift.z);
		}
	}

}
