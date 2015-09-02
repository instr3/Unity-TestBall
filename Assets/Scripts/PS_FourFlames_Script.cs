using UnityEngine;
using System.Collections;

public class PS_FourFlames_Script : MonoBehaviour {
	Main main;
	public GameObject subFirePrefab;
	Transform[] subFire=new Transform[4];
	// Use this for initialization
	void Start () {
		main = GameObject.Find ("Level").GetComponent<Main> ();
		for(int i=0;i<=3;++i)
		{
			subFire[i] = ((GameObject)Instantiate (subFirePrefab)).transform;
			subFire[i].parent=transform;
			subFire[i].localPosition=new Vector3((i%2==1?-1:1)*6.1f,(i/2==1?-1:1)*7.4f,-1.9f);
		}
		Destroy (gameObject.GetComponent<MeshRenderer> ());
		Destroy (gameObject.GetComponent<MeshCollider> ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
