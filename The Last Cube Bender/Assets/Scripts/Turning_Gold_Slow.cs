using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning_Gold_Slow : MonoBehaviour {

	public float turningSpeed=4f;
	public PlayerMovement pm;

	public void FixedUpdate () {
		transform.Rotate (new Vector3 (0f, turningSpeed, 0f));
	}

	public void OnTriggerEnter(){
		pm.slow = true;
		Time.timeScale = 0.5f;
		gameObject.SetActive (false);
		pm.SlowObject.SetActive (true);
		pm.TextSlow.SetActive (true);
		pm.slow_counter= 0;
		pm.slowBar.value = 0;
		}

}
