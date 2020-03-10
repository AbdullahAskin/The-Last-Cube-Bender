using UnityEngine;
using UnityEngine.UI;

public class TurningGold : MonoBehaviour {
		public float turningSpeed=6f;
		public PlayerMovement pm;

		public void FixedUpdate () {
		transform.Rotate (new Vector3 (turningSpeed, turningSpeed, turningSpeed));
		}

		public void OnTriggerEnter(){
			pm.untouchable = true;
			gameObject.SetActive (false);
			pm.UntouchableObject.SetActive (true);
			pm.textUntouchables.SetActive (true);
			pm.untouchable_counter = 0;
			pm.goldBar.value = 0;
		}
}
