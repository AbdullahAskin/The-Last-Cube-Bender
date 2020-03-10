using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	public Transform player;
	public Text scoreText;
	public PlayerMovement pm;
	public float sum=0;
	public float temp_x,temp_z;
	float startPosition;
	public int counter=0;
	void Start(){
		temp_z = player.position.z;
		temp_x = player.position.x;
	}
	void FixedUpdate () {
		if (pm.left) {
			sum -= player.position.x - temp_x;
			temp_x = player.position.x;
			scoreText.text = (sum).ToString ("0");
		} else if (pm.right) {
			sum += player.position.x - temp_x;
			temp_x = player.position.x;
			scoreText.text = (sum).ToString ("0");
		} else {
			sum += player.position.z - temp_z;
			temp_z = player.position.z;
			scoreText.text = (sum).ToString ("0");
		}

		if (counter > 100) {
			if (pm.forwardForce > 0) {
				pm.forwardForce += 250;
			} else {
				pm.forwardForce -= 250;
			}
			counter = 0;
		}
		counter++;
	}

}
