using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickeable : MonoBehaviour {
	[Range(0.1f,10.0f)]
	public float min_respawn_time;

	[Range(0.1f,40.0f)]
	public float max_respawn_time;
	public GameObject home_world;
	public PlayerData.amunition ammo_type = PlayerData.amunition.Roca;

	private float respawn_time = 0.0f;
	public bool active = true;
	public int player = 0;
	[Range (0.1f,20.0f)]
	public float distance = 1.95f;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		if (!active) {
			respawn_time -= Time.deltaTime;
			if (respawn_time < 0) {
				this.transform.position = random_cordinate() * distance + home_world.transform.position;
				this.gameObject.GetComponent<Renderer> ().enabled = true;
				this.gameObject.GetComponent<Collider> ().enabled = true;
				active = true;
			}
		}
		//Debug.Log (respawn_time);
	


	}

	void OnTriggerEnter( Collider collision)
    {

		if (GameState.instance.get_cargo (player) == PlayerData.amunition.Vacio) {
			//desactivar render y colision
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			this.gameObject.GetComponent<Collider> ().enabled = false;

			//asignamos muchila de vikingo
			GameState.instance.set_cargo (player, ammo_type);
			active = false;
			//Debug.Log (ammo_type);
			respawn_time = Random.Range (min_respawn_time,max_respawn_time);
			int random_pickup = (int)Mathf.Floor (Random.Range (0f, 2.99f));
			if (random_pickup == 0) {
				ammo_type = PlayerData.amunition.Escudo;
			}
			if (random_pickup == 1) {
				ammo_type = PlayerData.amunition.Roca;
			}
			if (random_pickup == 2) {
				ammo_type = PlayerData.amunition.Tronco;
			} else {
				active = false;
			}


		}
		//Debug.Log ("Exitooo!!!");

		// triggered = true; //If you want to have this only trigger once

	}

	Vector3 random_cordinate(){
		double x0 = Random.Range(-1.0f,1.0f);
		double x1 = Random.Range(-1.0f,1.0f);
		double x2 = Random.Range(-1.0f,1.0f);
		double x3 = Random.Range(-1.0f,1.0f);
		while (x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3 >= 1) {
			x0 = Random.Range(-1.0f,1.0f);
			x1 = Random.Range(-1.0f,1.0f);
			x2 = Random.Range(-1.0f,1.0f);
			x3 = Random.Range(-1.0f,1.0f);
		}
		double a = x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3;
		double x = 2 * (x1 * x3 + x0 * x2) / a;
		double y = 2 * (x2 * x3 - x0 * x1) / a;
		double z = (x0 * x0 + x3 * x3 - x1 * x1 - x2 * x2) / a;
		return new Vector3 ((float)x, (float)y,(float)z);

	}


}
