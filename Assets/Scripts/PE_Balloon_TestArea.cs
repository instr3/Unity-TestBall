using UnityEngine;
using System.Collections;

public class PE_Balloon_TestArea : MonoBehaviour {
	Main main;
	// Use this for initialization
	void Start () {
		main = GameObject.Find ("Level").GetComponent<Main> ();
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other==main.ballMF.GetComponent<Collider>())
		{
			transform.parent.SendMessage("Activate");
		}
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
