using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	public GameObject pause;
	public GameObject EventSystem;

	   
    void Awake ()
    {
	 pause.GetComponent<Canvas>().enabled=false;
		EventSystem.SetActive(false); 
		}
    
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartJ1") || Input.GetButtonDown("StartJ2"))
        {
            Pause();
			 
		}
		if (pause.GetComponent<Canvas>().enabled==false)
		{
			PausedTime ();		
		}
else
		{
			EventSystem.SetActive(true); 
			Time.timeScale = Time.timeScale == 0 ?0 : 0;
		}

    }
    
    public void Pause()
    {
		pause.GetComponent<Canvas>().enabled = !pause.GetComponent<Canvas>().enabled;

       
    }
	public void PausedTime()
	{		
		EventSystem.SetActive(false); 		
		Time.timeScale = 1;

	}
    
    public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}