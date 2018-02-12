using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public int SCNumber;
	void Start ()
	{
		Time.timeScale = 1;
	}
 public void Executor ()
	{
		SceneManager.LoadScene (SCNumber);

	}
}


