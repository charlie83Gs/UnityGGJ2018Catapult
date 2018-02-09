using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntador : MonoBehaviour {

	[Range(0.01f,2.0f)]
	float speed = 0.1f;

	public GameObject xdummy;
	public bool enabledx = true;
	public KeyCode up = KeyCode.W;
	public KeyCode down = KeyCode.S;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;

	public string vertical_axis;
	public string horizontal_axis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (up) && enabledx ){
			this.transform.Translate (new Vector3(0.0f,0.0f,speed), Space.World);
		}
		if(Input.GetKey (down) && enabledx) {
			this.transform.Translate (new Vector3(0.0f,0.0f,-speed), Space.World);
		}
		if (Input.GetKey (right) && enabledx) {
			this.transform.Translate (new Vector3(speed,0.0f,0.0f), Space.World);
		}
		if (Input.GetKey (left) && enabledx) {
			this.transform.Translate (new Vector3(-speed,0.0f,0.0f), Space.World);
		}

		if (enabledx) {
			float x = Input.GetAxis (horizontal_axis);

			float y = Input.GetAxis (vertical_axis);
			this.transform.Translate (new Vector3(speed*x,0.0f,0.0f), Space.World);
			this.transform.Translate (new Vector3(0.0f,0.0f,speed*y), Space.World);
		}

	}

	public void set_enabled(bool state){
		enabledx = state;
	}

	public GameObject create_dummy(){
		GameObject dummy =  Instantiate (xdummy,this.transform.position, Quaternion.identity) as GameObject;
		dummy.transform.position = transform.position;
		dummy.transform.eulerAngles = transform.eulerAngles;
		return dummy;
	}
		
}
