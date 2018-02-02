using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : MonoBehaviour {
	public GameObject crater;
	public bool crear = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter( Collision collision)
	{
		if (collision.gameObject.tag == "misil" && !crear) {
			GameObject g = Instantiate (crater, this.transform.position, this.transform.rotation) as GameObject;
			g.transform.Rotate (new Vector3(-90.0f,0.0f,0.0f));
			g.transform.Translate (new Vector3(0.0f,-0.2f,0.0f));
			g.transform.SetParent (this.transform.parent);
			Destroy (collision.gameObject);
			crear = true;
			//Destroy (this.gameObject);
		}


	}

}
