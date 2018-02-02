using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour {

	public GameObject[] assets;

	[Range(0.1f,20.0f)]
	public float distance;
	[Range(1,30)]
	public int total = 5;
	[Range(0,30)]
	public int min_children = 3;
	[Range(0,30)]
	public int max_children = 5;
	[Range(0.01f,3.0f)]
	public float children_distance = 0.1f;
	[Range(0.01f,2.0f)]
	public float random_size = 0.3f;

	public float prefab_scale = 0.2f;
	// Use this for initialization
	void Start () {

		int three_number;
		for (int i = 0; i < total; i++) {
			
			Vector3 cordinate = random_cordinate ();
			int total_children = (int)Mathf.Floor(Random.Range ((float)min_children,(float)max_children));
			//Debug.Log (total_children);
			for (int j = 0; j < total_children; j++) {
				float random_scale = Random.Range (-random_size/2, random_size/2);
				three_number = (int)Mathf.Floor(Random.Range (0.0f,assets.Length -0.01f));
				GameObject myThree = Instantiate (assets [three_number], (cordinate+random_cordinate()*children_distance).normalized*( distance) + this.transform.position, Quaternion.identity) as GameObject;
				myThree.transform.parent = this.transform;
				AutoRotator rotator = (AutoRotator)myThree.GetComponent (typeof(AutoRotator));
				rotator.target = this.gameObject.transform;
				rotator.manual_reset_rotation ();

				myThree.transform.localScale +=new Vector3(random_scale,random_scale,random_scale);
			}

			//myThree.transform.Rotate (new Vector3(0.0f,0.0f,90.0f));
		}

	}
	
	// Update is called once per frame
	void Update () {
		
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
