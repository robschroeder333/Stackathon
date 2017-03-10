using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

private HandController HC;
private GameObject handControllerObject;



//set script on the hand prefabs to return boolean true if
//no fingers are extended.

//object find them here in update (like in other script)

//get component of each to access the function

//if both return true then get the values of positions
//and continue working

	void Awake () {
		// handControllerObject = GameObject.Find("HandController");

		HC = this.gameObject.GetComponent<HandController>() as HandController;
	}
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		// Debug.Log(HC.GetAllGraphicsHands());
	}
}
