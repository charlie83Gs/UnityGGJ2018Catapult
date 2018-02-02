using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsset : MonoBehaviour {

	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Obstacle") {
			Destroy (col.gameObject);
			//Debug.Log ("Destruido");
		}
		//Debug.Log ("colision detectada en casa");
	}
}
