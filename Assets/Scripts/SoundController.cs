using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundController : MonoBehaviour {

	public enum soundsGame{
		explosion,
		explosionFuerte,
		fuegoPasa,
		fuerzaVikingo,
		iniciaBatalla,
		lanzaCatapulta,
		ping,
		sustovikingo,
		swoosh,
		musica
	}

	public AudioClip explosionV;
	public AudioClip explosionFuerteV;
	public AudioClip fuegoPasaV;
	public AudioClip fuerzaVikingoV;
	public AudioClip iniciaBatallaV;
	public AudioClip lanzaCatapultaV;
	public AudioClip pingV;
	public AudioClip sustovikingoV;
	public AudioClip swooshV;
	public AudioClip musicaV;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();

	}

	//audioSource.PlayOneShot(impact, 0.7F);



	public void PlaySound(soundsGame currentSound){
		switch(currentSound){

		case soundsGame.explosion:{
			audioSource.PlayOneShot(explosionV,0.7f);
			}
			break;
		case soundsGame.explosionFuerte:{
				audioSource.PlayOneShot(explosionFuerteV,0.7f);
			}
			break;
		case soundsGame.fuegoPasa:{
				audioSource.PlayOneShot(fuegoPasaV,0.7f);
			}
			break;
		case soundsGame.fuerzaVikingo:{
				audioSource.PlayOneShot(fuerzaVikingoV,0.7f);
			}
			break;
		case soundsGame.iniciaBatalla:{
				audioSource.PlayOneShot(iniciaBatallaV,0.7f);
			}
			break;
		case soundsGame.lanzaCatapulta:{
				audioSource.PlayOneShot(lanzaCatapultaV,0.7f);
			}
			break;
		case soundsGame.ping:{
				audioSource.PlayOneShot(pingV,0.7f);
			}
			break;
		case soundsGame.sustovikingo:{
				audioSource.PlayOneShot(sustovikingoV,0.7f);
			}
			break;
		case soundsGame.swoosh:{
				audioSource.PlayOneShot(swooshV,0.7f);
			}
			break;
		case soundsGame.musica:{
				audioSource.PlayOneShot(musicaV,0.7f);
			}
			break;

		}
	}
}