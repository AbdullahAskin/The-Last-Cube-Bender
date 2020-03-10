using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

	public PlayerMovement pm;
	public Text speed;

	void FixedUpdate () {
		if (pm.forwardForce < 0) {
			speed.text = ((-pm.forwardForce)/100).ToString ("0");
		} else {
			speed.text = (pm.forwardForce / 100).ToString ("0");
		}
	}
}
