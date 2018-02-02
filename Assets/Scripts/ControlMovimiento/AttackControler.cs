using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControler : MonoBehaviour {

	public GameObject apuntador;
	private Apuntador sc_apuntador;
	public PlayerControl playercontrol;
	public SphereControl spherecontrol;
	private bool shooting = false;
	public GameObject[] balas;
	private PlayerData.amunition actual_ammo;
	public Animator anim;
	public GameObject spawn;
	public GameObject vikingoCatapulta;

	private int contador = 0;
	float animTime = -0.1f;
	public float animDuration = 0.5f;
	bool atacking = false;
	GameObject actual_dummy;

	public KeyCode attack;
	public string attack_button;
	public int player = 0;
	//GameObject myThree = Instantiate (assets [three_number], (cordinate+random_cordinate()*children_distance).normalized*( distance) + this.transform.position, Quaternion.identity) as GameObject;


	// Use this for initialization
	void Start () {
		sc_apuntador = (Apuntador)apuntador.GetComponent<Apuntador> ();
		apuntador.GetComponentInChildren<Renderer> ().enabled = false;
		sc_apuntador.set_enabled(false);
		playercontrol.set_enabled (true);
		spherecontrol.set_enabled_x (true);
		actual_ammo = PlayerData.amunition.Vacio;
	}
	
	// Update is called once per frame
	void Update () { 
		
		if((Input.GetKeyDown (attack)|| Input.GetButtonDown(attack_button)) && shooting){
			animTime = animDuration;
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsShooting", true);
			atacking = true;
			enable_control ();
			actual_dummy = sc_apuntador.create_dummy ();
			actual_dummy.transform.SetParent (apuntador.GetComponent<RealTimeAutoRotator>().target); 

		}
		if (atacking) {
			if (animTime > 0) {
				animTime -= Time.deltaTime;
				vikingoCatapulta.GetComponent<Renderer> ().enabled = true;
				//Debug.Log (animTime);
			} else {
				atacking = false;
				shot (actual_dummy);
				vikingoCatapulta.GetComponent<Renderer> ().enabled = true;
				anim.SetBool ("IsIdle", true);
				anim.SetBool ("IsShooting", false);


			}
		}

		if ((Input.GetKeyDown (attack)|| Input.GetButtonDown(attack_button)) && !shooting && GameState.instance.get_cargo(player) != PlayerData.amunition.Vacio ) {
			start_Shooting ();
		} 

	}

	void start_Shooting(){
		shooting = true;
		playercontrol.set_enabled(false);
		sc_apuntador.set_enabled(true);
		spherecontrol.set_enabled_x(false);
		apuntador.GetComponentInChildren<Renderer> ().enabled = true;
		actual_ammo = GameState.instance.get_cargo(player);
		GameState.instance.set_cargo (player,PlayerData.amunition.Vacio);
	}

	void shot(GameObject bulletTarget){
		/*if (contador % 100 == 0) {
			Debug.Log(contador);
		}*/
		//Vector3 centro = apuntador.get

		contador++;
		sc_apuntador.set_enabled (false);
		playercontrol.set_enabled (true);
		apuntador.GetComponentInChildren<Renderer> ().enabled = false;
		shooting = false;

		spherecontrol.set_enabled_x (true);
		GameObject myBullet;
		if (actual_ammo == PlayerData.amunition.Roca) {
			myBullet = Instantiate (balas [0], spawn.transform.position, spawn.transform.rotation) as GameObject;
		}else if (actual_ammo == PlayerData.amunition.Escudo) {
			myBullet = Instantiate (balas [1],spawn.transform.position, spawn.transform.rotation) as GameObject;
		}else{
					myBullet = Instantiate (balas [2],spawn.transform.position, spawn.transform.rotation) as GameObject;
		}
		actual_ammo = PlayerData.amunition.Vacio;
		FollowTarget follower = (FollowTarget)myBullet.GetComponent<FollowTarget> ();
		follower.target = bulletTarget.transform;
		KeepAway away = (KeepAway)myBullet.GetComponent<KeepAway> ();
		away.target = apuntador.GetComponent<RealTimeAutoRotator> ().target;





	}

	void OnTriggerEnter( Collider collision)
	{
		Debug.Log ("Collision con catapulta");

	}

	/*void onCollisionEnter(Collision col){
		Debug.Log ("Col ctapulta");
	}*/

	void disable_control(){
		
	}

	void enable_control(){
		sc_apuntador.set_enabled (false);
		playercontrol.set_enabled (true);
		apuntador.GetComponentInChildren<Renderer> ().enabled = false;
		shooting = false;
		spherecontrol.set_enabled_x (true);

	}
}
