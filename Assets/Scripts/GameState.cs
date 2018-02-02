using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public PlayerData[] jugadores = new PlayerData[4];
	public ConfigData matchData;
	[Range (1,100)]
	public int vidaDefault  = 10;

	public static GameState instance;



	void Awake(){



		if (instance == null) {
			instance = this;
			matchData = new ConfigData ();
			matchData.VidaMaxima = vidaDefault;
			matchData.TotalJugadores = 2;


			for (int i = 0; i < 4; i++) {
				jugadores[i] = new PlayerData();
				jugadores [i].carga = PlayerData.amunition.Vacio;
				jugadores [i].vida = 10;
				jugadores [i].vidaTotal = 10;
			}
			DontDestroyOnLoad (this);
			//Application.targetFrameRate = 120;
		} else if (instance != this) {
			Destroy (this);
		}
	}


	public SoundController getSoundController(){
	
		return this.GetComponent<SoundController>();

	}



		// GameState.instance.getSoundController ().PlaySound ( getSoundController().soundsGame.musica );
	

	// Use this for initialization
	void Start () {
		
	}

	public void resetPlayerData(){
		for(int i = 0; i < matchData.TotalJugadores; i++){
			jugadores[i].vida = matchData.VidaMaxima;
			jugadores[i].vidaTotal = matchData.VidaMaxima;
			jugadores[i].carga = PlayerData.amunition.Vacio;
		}
	}

	public void damagePlayer(int player_numer,int damage){
		jugadores [player_numer].vida -= damage;
	}

	public void  set_total_players(int amount){
		matchData.TotalJugadores = amount;
	}

	public PlayerData.amunition get_cargo(int index){
		return jugadores[index].carga;
	}

	public void set_cargo(int player_index, PlayerData.amunition tipo){
		jugadores [player_index].carga = tipo;
	}
	// Update is called once per frame
	/*void Update () {
		
	}*/

	public void gameOver(int ganador){


	}
}
