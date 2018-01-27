using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour {

	public string menu;

	public void RestartGame(){
		
	}

	public void QuitTomenu(){
		SceneManager.LoadScene(menu);
	}
}
