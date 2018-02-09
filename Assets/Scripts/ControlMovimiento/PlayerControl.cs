using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	private float rot = 0.0f;
	public bool enabledx = true;
	public Animator anim;
	public bool walking = false;

	public KeyCode up = KeyCode.W;
	public KeyCode down = KeyCode.S;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;

	public string vertical_axis;
	public string horizontal_axis;
	//private bool[] dir;

	// Use this for initialization
	void Start () {
		//dir = new bool[4];
	}

	// Update is called once per frame
	void Update () {
		//rot += Time.deltaTime;

		bool w = false;
		bool s = false;
		bool a = false;
		bool d = false;

		if (Input.GetAxis (vertical_axis) > 0.01) {
			w = true;
		}
		if (Input.GetAxis (vertical_axis) < -0.01) {
			s = true;
		}

		if (Input.GetAxis (horizontal_axis) > 0.01) {
			d = true;
		}

		if (Input.GetAxis (horizontal_axis) < -0.01) {
			a = true;
		}

		walking = false;
		if ((Input.GetKey (up) || w)&& (Input.GetKey (left) || a) && enabledx) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 315, transform.eulerAngles.z);

			walking = true;
		}else 
			if ((Input.GetKey (up)|| w) && (Input.GetKey (right)|| d) && enabledx) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 45, transform.eulerAngles.z);

			walking = true;
		}else

				if ((Input.GetKey (down)|| s) && (Input.GetKey (right)|| d) && enabledx) {
				transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 135, transform.eulerAngles.z);

				walking = true;
		}else
					if ((Input.GetKey (down)|| s)  && (Input.GetKey (left)|| a) && enabledx) {
				transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 225, transform.eulerAngles.z);

				walking = true;
			}else
						if ((Input.GetKey (up)|| w) && enabledx) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 0, transform.eulerAngles.z);
	
			walking = true;
		}else
			if((Input.GetKey(down)|| s) && enabledx){
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x,180,transform.eulerAngles.z);
			walking = true;

		}else
			if((Input.GetKey(right) || d)&& enabledx){
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x,90,transform.eulerAngles.z);
			walking = true;

		}else

			if ((Input.GetKey (left)|| a) && enabledx) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 270, transform.eulerAngles.z);
	
			walking = true;
		}
		


		if (walking) {
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalking", true);
		} else {
			anim.SetBool ("IsIdle", true);
			anim.SetBool ("IsWalking", false);
		}
			

	}

	public void set_enabled(bool desire){
		enabledx = desire;
	}

	private void set_dir(){
		 
	}
}
