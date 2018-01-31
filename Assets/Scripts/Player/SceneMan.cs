using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

	bool gameHasEnded = false;

	public void EndGame()
	{
		if (gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log ("GAME OVER");
			Restart ();
		}
	}
	void Restart()
	{
		SceneManager.LoadScene (0);
	}
}
