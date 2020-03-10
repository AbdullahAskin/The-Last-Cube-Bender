using UnityEngine;
using UnityEngine.UI;

public class Turning_Gold_fog : MonoBehaviour {

	public float turningSpeed=7f;
	public PlayerMovement pm;

	public void FixedUpdate(){
		transform.Rotate (new Vector3 (0f, turningSpeed, 0f));
	}

	public void OnTriggerEnter(){
		pm.fog = true;
		gameObject.SetActive (false);
		pm.FogObject.SetActive (true);
		pm.textFog.SetActive (true);
		pm.fog_counter= 0;
		pm.fogBar.value = 0;
		RenderSettings.fog =true;
	}

}
