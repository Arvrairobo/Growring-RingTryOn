﻿using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour {

	public GameObject objectToActivate;

	private void Start()
	{
		StartCoroutine(ActivationRoutine());
	}

	private IEnumerator ActivationRoutine()
	{        
		//Wait for 14 secs.
		yield return new WaitForSeconds(10);

		//Turn My game object that is set to false(off) to True(on).
		objectToActivate.SetActive(false);

		//Turn the Game Oject back off after 1 sec.
		//yield return new WaitForSeconds(1);

		//Game object will turn off
		//objectToActivate.SetActive(false);
	}
}
