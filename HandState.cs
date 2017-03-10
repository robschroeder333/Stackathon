using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandState : MonoBehaviour {

	private HandModel HM;
	public Hand hand;

	public bool IsFist () {
		for (int f = 0; f < hand.Fingers.Count; f++) {
			Finger digit = hand.Fingers [f];
			if (digit.IsExtended) {
					return false;
			}
		}
		return true;
	}

	void Awake () {
		HM = this.gameObject.GetComponent<HandModel>();
	}

	void Update () {
		hand = HM.GetLeapHand();
	}
}
