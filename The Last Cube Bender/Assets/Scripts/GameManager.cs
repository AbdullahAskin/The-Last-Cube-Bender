using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;
	float restartDelay= 1f;
	public GameObject completeLevelUI;


	public void EndGame()
	{	
		if (!gameHasEnded) {
			gameHasEnded = true;
			Invoke ("Restart", restartDelay);		
		}
	}

	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void CompleteLevel(){
		 completeLevelUI.SetActive (true);
	}
		
}
