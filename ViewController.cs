using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class ViewController : MonoBehaviour {

// script imports
private HandController HandControllerScript;
private HandState HandStateScript1;
private HandState HandStateScript2;

// var declaration
private GameObject handController;
private HandModel hand1;
private HandModel hand2;


/*TODO:
	get component of each to access the function (nest within function and only
	 call if they exist)

	if both return true then get the values of positions
	and continue working
*/


	void Awake () {
		handController = GameObject.Find("HandController");
		HandControllerScript = handController.GetComponent<HandController>() as HandController;
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// hand1 = HandControllerScript.GetAllGraphicsHands()[0];
		// hand2 = HandControllerScript.GetAllGraphicsHands()[1];
		HandStateScript1 = hand1.GetComponent<HandState>() as HandState;
		HandStateScript2 = hand2.GetComponent<HandState>() as HandState;


		// Debug.Log(hand2.transform.position);

	}
}
