using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedChange : MonoBehaviour {
	private float timer = 0.0f;
	public float waitTime = 50.0f;
	public string scene_name = "Menu";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > waitTime) {
			SceneManager.LoadScene (scene_name);
		}
		timer += Time.deltaTime;

			if(Input.anyKeyDown){
			SceneManager.LoadScene (scene_name);
			}
	}
}
