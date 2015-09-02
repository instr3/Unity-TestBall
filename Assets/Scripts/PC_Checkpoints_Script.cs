using UnityEngine;
using System.Collections;

public class PC_Checkpoints_Script : MonoBehaviour {
	Main main;GameObject level;
	[HideInInspector]
	public int sector;
	public GameObject mainFire;
	public Transform subFire1,subFire2;
	public GameObject subFirePrefab;
	// Use this for initialization
	void Start () {
		level=GameObject.Find ("Level");
		main = level.GetComponent<Main> ();
	
	}
	public void Init(int nowSector)
	{
		sector = nowSector;
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log ("in");
		if(other==main.ballMF.GetComponent<Collider>())
		{
			level.SendMessage("ActivateSector",sector+1);
			Destroy(mainFire);
			((GameObject)Instantiate(subFirePrefab,subFire1.position,subFire1.rotation)).transform.parent=subFire1;
			((GameObject)Instantiate(subFirePrefab,subFire2.position,subFire2.rotation)).transform.parent=subFire2;
			Destroy(GetComponent<Collider>());
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
