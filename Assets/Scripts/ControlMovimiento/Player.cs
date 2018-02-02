using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject home_world;
	private SphereControl worldControl;
	[Range (0f ,1f)]
	public float repeal_force = 0.01f;

	// Use this for initialization
	void Start () {
		worldControl = (SphereControl)home_world.GetComponent (typeof(SphereControl));
	}
	


	void OnCollisionExit(Collision col){

		worldControl.free_movement ();
		//Debug.Log ("free movement");

	
	
	}
	void OnCollisionStay(Collision collision){
		
		//Debug.Log ("Collision detected");


			Vector3 dir = collision.contacts [0].point - transform.position;
			dir = dir.normalized;
			if (dir.x > 0) {
				//Debug.Log ("Collision derecha");
				worldControl.lock_unlock_direction (SphereControl.direction.derecha, false);
			} else if (dir.x < 0) {
				//Debug.Log ("Collision izquierda");
				worldControl.lock_unlock_direction (SphereControl.direction.izquierda, false);
			}
			if (dir.z > 0) {
				//Debug.Log ("Collision frente");
				worldControl.lock_unlock_direction (SphereControl.direction.adelante, false);
			} else if (dir.z < 0) {
				//Debug.Log ("Collision detras");
				worldControl.lock_unlock_direction (SphereControl.direction.atras, false);
			}

	
	}
		

}
