using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSpalda : MonoBehaviour {

	public PlayerData.amunition ammo_type; // tipo de anmo
	public bool active = false;
	public int player; // jugador que los tiene
	public Transform father;
	private bool enabledx = false;
	void Start(){

		//this.gameObject.GetComponent<Renderer> ().enabled = false;
		//this.gameObject.GetComponent<Collider> ().enabled = false;

		Renderer[] children = GetComponentsInChildren<Renderer> ();
		foreach(Renderer child in children){

			child.enabled = false;
		}
		this.transform.SetParent (father);
		/*if(){

			this.gameObject.GetComponent<Renderer> ().enabled = true;
			this.gameObject.GetComponent<Collider> ().enabled = true;
		}*/

	}
	void Update(){
		if (GameState.instance.get_cargo (player) != PlayerData.amunition.Vacio) {

			if (GameState.instance.get_cargo (player) == ammo_type && !enabledx) {

				//this.gameObject.GetComponent<Renderer> ().enabled = true;
				//this.gameObject.GetComponent<Collider> ().enabled = true;

				Renderer[] children = GetComponentsInChildren<Renderer> ();
				foreach (Renderer child in children) {

					child.enabled = true;
				}

				enabledx = true;
			}

		} else if(enabledx){
		
			Renderer[] children = GetComponentsInChildren<Renderer> ();
			foreach (Renderer child in children) {

				child.enabled = false;
				enabledx = false;
			}
		
		}
}

}
