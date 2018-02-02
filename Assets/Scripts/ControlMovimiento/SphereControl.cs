using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour {

	[Range (0, 500)]
	public float speed = 150;
	public enum direction{adelante,atras,derecha,izquierda};

	private float anglex = 0.0f;
	private float angley = 0.0f;
	private bool[] allowed;
	private bool enabledx;

	public KeyCode up= KeyCode.W;
	public KeyCode down = KeyCode.S;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;
	public string vertical_axis = "VerticalJ1";
	public string horizontal_axis = "HorizontalJ1";
	// Use this for initialization
	void Start () {
		allowed = new bool[4];
		for (int i = 0; i < 4; i++) {
			allowed [i] = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(up) && allowed[0] && enabledx) {
			transform.Rotate(-speed*Time.deltaTime,0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(down) && allowed[1]  && enabledx) {
			transform.Rotate(speed*Time.deltaTime,0.0f, 0.0f, Space.World);
		}
		if (Input.GetKey(left) && allowed[2]  && enabledx) {
			transform.Rotate(0.0f,0.0f, -speed*Time.deltaTime, Space.World);
		}
		if (Input.GetKey(right) && allowed[3]  && enabledx) {
			transform.Rotate(0.0f,0.0f, speed*Time.deltaTime, Space.World);
		}

		if (enabledx) {
			float x = Input.GetAxis (horizontal_axis);
			//Debug.Log (x);
			transform.Rotate (0.0f, 0.0f, speed * Time.deltaTime * x, Space.World);
			float y = Input.GetAxis (vertical_axis);
			transform.Rotate(-speed*Time.deltaTime*y,0.0f, 0.0f, Space.World);
		}
	}


	public void lock_unlock_direction(direction dir, bool new_avaibility){
		float repeal_force = 1f;
		if (dir == direction.adelante) {
			allowed [0] = new_avaibility;
			transform.Rotate(repeal_force,0.0f, 0.0f, Space.World);
		}else if (dir == direction.atras) {
			allowed [1] = new_avaibility;
			transform.Rotate(-repeal_force,0.0f, 0.0f, Space.World);
		}else if (dir == direction.derecha) {
			allowed [3] = new_avaibility;
			transform.Rotate(repeal_force,0.0f, 0.1f, Space.World);
		}else if (dir == direction.izquierda) {
			allowed [2] = new_avaibility;
			transform.Rotate(repeal_force,0.0f, -0.1f, Space.World);
		}
	}


	public void free_movement(){
		allowed [0] = true;
		allowed [1] = true;
		allowed [2] = true;
		allowed [3] = true;
	}

	public void set_enabled_x(bool par){
		enabledx = par;
	}

}
