using UnityEngine;

public class followPlayer : MonoBehaviour {

	public Transform player;
	public Vector3 offset;
	public float smoothSpeed=0.125f;
	public float yRotateSpeed=0.5f;
	public float forwardForce = 2000f;
	public bool offsetControl=false;
	public PlayerMovement pm;

	void FixedUpdate () {
		// Bu şekilde yazılan transform şuan üzerinde bulunduğumuz şeyin transformudur.Yani binevi this demektir.
			cameraRotation ();
		// transform.LookAt (player);
		}


	public void cameraRotation(){
		if ((int)player.eulerAngles.y != (int)transform.eulerAngles.y) {
			if (pm.right || pm.left_right) {
				transform.RotateAround (player.position, Vector3.up, yRotateSpeed);
				offsetControl = false;
			} else {
				transform.RotateAround (player.position, Vector3.down, yRotateSpeed);
				offsetControl = false;
			}
			if( !offsetControl ){
				if (pm.right) {
					offset.x = -15;
					offset.z = 0;
				} else if (pm.left) {
					offset.x = 15;
					offset.z = 0;
				} else if(pm.left_right || pm.right_left){
					offset.x = 0;
					offset.z = -15;
				}
				offsetControl = true;
			}
		} 
		else {
			Vector3 desiredPosition = player.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition,smoothSpeed);
			transform.position = smoothedPosition;
		}
	}


}
