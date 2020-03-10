using UnityEngine;

public class TurnRight : MonoBehaviour {

	public PlayerMovement pm;

	public void OnTriggerEnter(){
		pm.MovementRotation (true);
	}

}
