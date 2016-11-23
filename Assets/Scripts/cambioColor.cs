using UnityEngine;
using System.Collections;

public class cambioColor : MonoBehaviour {

	public int velocidad = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		if(Input.GetKeyDown(KeyCode.G))
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.B))
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		}

		transform.Translate (new Vector3 (0, 0, Time.deltaTime * velocidad));
	
	}

	void OnCollisionEnter(){
		print ("Impacto!! AHHHHHHH");
	}
}
