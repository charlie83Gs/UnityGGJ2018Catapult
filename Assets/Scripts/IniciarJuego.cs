using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IniciarJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame(){

		SceneManager.LoadScene ("Principal");

	}

	public void endGame(){
		Application.Quit ();
	}
}
