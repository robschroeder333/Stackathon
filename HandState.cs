using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState : MonoBehaviour {


	// void Awake () {
	// 	hand = GameObject.Find("HandController");
	// 	HC = handControllerObject.GetComponent<HandController>() as HandController;
	// }
	// Use this for initialization
	private HandModel HM;
	void Start () {
		HM = GetComponent<HandModel>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(HM.GetLeapHand().Fingers);
	}
}
