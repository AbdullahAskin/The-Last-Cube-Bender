using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;


	public followPlayer fp;
	public float yRotateSpeed=0.5f;
	public float forwardForce = 2000f;
	public float sideForce =500f;
	public float jumpForce=1500f;
	public bool right=false,left=false,right_left=false,left_right=false;
	public float rotationAngle=0f;

	public bool untouchable = false;
	public float untouchable_counter = 0;
	public GameObject UntouchableObject;
	public GameObject textUntouchables;
	public Slider goldBar;

	public GameObject FogObject;
	public GameObject textFog;
	public bool fog = false;
	public float fog_counter = 0;
	public Slider fogBar;

	public GameObject SlowObject;
	public GameObject TextSlow;
	public bool slow=false;
	public float slow_counter=0;
	public Slider slowBar;


	 
	public void FixedUpdate () {
			if (right || left) {
				rb.AddForce (forwardForce * Time.deltaTime, 0, 0);
				if (Input.GetKey ("d")) {
					rb.AddForce (0, 0, sideForce * Time.deltaTime, ForceMode.VelocityChange);
				} else if (Input.GetKey ("a")) {
					rb.AddForce (0, 0, -sideForce * Time.deltaTime, ForceMode.VelocityChange);
				}
				
			} else {
				rb.AddForce (0, 0, forwardForce * Time.deltaTime);
				if (Input.GetKey ("d")) {
					rb.AddForce (sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				} else if (Input.GetKey ("a")) {
					rb.AddForce (-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				}
			}
		if (rb.position.y < -1f) {
			FindObjectOfType<GameManager> ().EndGame ();
		}
		if (untouchable) {
			Untouchable ();
		}
		if (fog) {
			FogEffect ();
		}
		if (slow) {
			SlowDown ();
		} else {
			Time.timeScale = 1f;
		}

		playerRotation ();

	}
	public void Untouchable(){
		if (untouchable_counter < 4) {
			untouchable_counter += Time.deltaTime;
			goldBar.value = (untouchable_counter * 25);
		} else {
			untouchable = false;
			UntouchableObject.SetActive (false);
			textUntouchables.SetActive (false);
		}
	}

	public void FogEffect(){
		if (fog_counter < 4) {
			fog_counter += Time.deltaTime;
			fogBar.value = (fog_counter * 25);
		} else {
			fog = false;
			FogObject.SetActive (false);
			textFog.SetActive (false);
			RenderSettings.fog = false;
		}
	}

	public void SlowDown(){
		if (slow_counter < 2) {
			slow_counter += Time.deltaTime;
			slowBar.value = (slow_counter* 50);
		} else {
			Time.timeScale = 1f;
			slow = false;
			SlowObject.SetActive (false);
			TextSlow.SetActive (false);
			forwardForce += 750;
		}
	}

	public void playerRotation(){
		if ((int)rotationAngle != (int)transform.eulerAngles.y) {
			if (right || left_right) {
				transform.Rotate (0, yRotateSpeed, 0);
			} else if(left || right_left){
				transform.Rotate (0,-yRotateSpeed, 0);
			}
		}
	}

	public void MovementRotation(bool isRight){
		if (right && !isRight) {
			right = false;
			right_left = true;
			sideForce = -sideForce;
			rotationAngle = transform.eulerAngles.y-90;
		} else if (left && isRight) {
			left = false;
			left_right = true;
			forwardForce = -forwardForce;
			if (transform.eulerAngles.y + 90 > 360) {
				rotationAngle = transform.eulerAngles.y - 360 + 90;
			} else {
				rotationAngle = transform.eulerAngles.y + 90;
			}
		}
		 else if (isRight) {
			right = true;
			right_left = false;
			left_right = false;
			sideForce = -sideForce;
			rotationAngle = transform.eulerAngles.y+90;
		} else {
			left = true;
			left_right = false;
			right_left = false;
			forwardForce = -forwardForce;
			//Açının -'lere inmesini engeller.
			if (transform.eulerAngles.y - 90 < 0) {
				rotationAngle = transform.eulerAngles.y + 360 - 90;
			} else {
				rotationAngle = transform.eulerAngles.y - 90; 
			}
		}
	} 

}