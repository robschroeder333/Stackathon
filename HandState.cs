using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandState : MonoBehaviour {

	private HandModel HM;
	private Hand hand;

	public bool IsFist (Hand hand) {
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

	void FixedUpdate () {
		hand = HM.GetLeapHand();
	}
}
