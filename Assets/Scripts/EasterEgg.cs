using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour {

	// Use this for initialization

	private int timer = 0;
	public GameObject[] addons;
	bool active = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 50 && !active) {
			//Debug.Log ("Has encendido la llama en mi!");
			activateEaster ();
			active = true;
		}
		//Debug.Log (timer);
	}

	void activateEaster(){

		//this.gameObject.GetComponent<Renderer> ().enabled = true;
		//this.gameObject.GetComponent<Collider> ().enabled = true;
		for(int i = 0; i <addons.Length; i++){
			addons[i].GetComponent<Renderer> ().enabled = true;
		}
	
	}

	void OnCollisionEnter(Collision colision){

		if(colision.gameObject.CompareTag("casa")){

			timer++;



		}

	}
}
