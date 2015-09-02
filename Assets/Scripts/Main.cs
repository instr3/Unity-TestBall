using UnityEngine;
using System.Collections;
public class Main : MonoBehaviour {
	public GUIText debugText;
	public GameObject ballMF;
	public GameObject ballPos;
	public GameObject level_1;
	[HideInInspector]
	public Vector3 spawnPos,spawnRot;
	
	[HideInInspector]
	public bool controlEnabled;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
}
