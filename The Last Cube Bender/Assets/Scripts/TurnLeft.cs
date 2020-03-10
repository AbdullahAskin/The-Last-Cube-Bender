using UnityEngine;

public class TurnLeft : MonoBehaviour {

	public PlayerMovement pm;

	public void OnTriggerEnter(){
		pm.MovementRotation (false);
	}
}
