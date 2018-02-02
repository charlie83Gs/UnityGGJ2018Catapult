using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour {

	[Range(0.01f, 100.0f)] 
	public float speed = 0.1f;
	// Use this for initialization
	private float timer = 0.0f;
	private float time = 0.8f;
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (timer < time) {
			transform.Translate (-this.transform.up* (speed) * Time.deltaTime*(time-timer));
		}

		timer += Time.deltaTime;
	}
}
