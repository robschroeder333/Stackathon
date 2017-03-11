using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandState : MonoBehaviour {

	private HandModel HM;
	public Hand hand;

	public bool IsFist () {
		int counter = 0;
		for (int f = 0; f < hand.Fingers.Count; f++) {
			Finger digit = hand.Fingers [f];
			if (!digit.IsExtended) {
					counter++;
			}
		}
		if (counter >= 4) {
			return true;
		}
		return false;
	}

	void Awake () {
		HM = this.gameObject.GetComponent<HandModel>();
	}

	void Update () {
		hand = HM.GetLeapHand();
	}
}
