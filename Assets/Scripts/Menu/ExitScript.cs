using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	public void Exit()
	{
		SceneManager.LoadScene(0);
		Debug.Log("Click!");
	}

}
