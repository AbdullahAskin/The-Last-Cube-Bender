using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement pm;

	void OnCollisionEnter(Collision CollisionInfo){
		if (CollisionInfo.collider.tag == "Obstacle" && !pm.untouchable) {
			pm.enabled = false;
			FindObjectOfType<GameManager> ().EndGame ();
		} else if(CollisionInfo.collider.tag == "Obstacle" && pm.untouchable){
			// Kutuları fırlatma ekle.
		}
	}
}
