using UnityEngine;
using System.Collections;

public class DeathTestGroup : MonoBehaviour {
	Main main;GameObject level;

	// Use this for initialization
	void Start () {
		level=GameObject.Find ("Level");
		main = level.GetComponent<Main> ();
		Destroy (gameObject.GetComponent<MeshRenderer> ());
	}
	
	void OnTriggerEnter(Collider other) {
		if(other==main.ballMF.GetComponent<Collider>())
		{
			level.SendMessage("FallOut");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
