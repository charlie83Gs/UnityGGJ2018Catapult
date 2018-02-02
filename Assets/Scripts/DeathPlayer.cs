using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour {

	public int player_number = 0;
	public Transform other;
	public GameObject you_win;
	public GameObject you_lost;
	private float waitTime = 0.0f;
	private bool lost = false;

	// Use this for initialization


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "dangerous" && ! lost) {
			Debug.Log (player_number);
			//SceneManager.LoadScene ("Principal");
			you_lost.transform.position = new Vector3(this.transform.position.x+0.9f,you_lost.transform.position.y,this.transform.position.z-0.3f);
			you_lost.GetComponentInChildren<Renderer> ().enabled = true;
			you_win.transform.position = new Vector3(other.transform.position.x-0.9f,you_lost.transform.position.y,other.transform.position.z-0.3f);
			you_win.GetComponentInChildren<Renderer> ().enabled = true;
			lost = true;
		}


			
	}

	void Update(){
		if (lost)
			waitTime += Time.deltaTime;
		if (waitTime > 3.0f) {
			SceneManager.LoadScene ("Menu");
		}

	}
}
