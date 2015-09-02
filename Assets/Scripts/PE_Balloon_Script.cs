using UnityEngine;
using System.Collections;

public class PE_Balloon_Script : MonoBehaviour {
	Main main;GameObject level;
	Vector3 movespeed=Vector3.zero;
	bool activated;
	
	public GameObject testText;
	// Use this for initialization
	void Start () {
		level = GameObject.Find ("Level");
		main = level.GetComponent<Main> ();

	}
	IEnumerator PlayFinishAnimation()
	{
		yield return new WaitForSeconds (1);
		Destroy (testText);
		for(int i=1;i<=200;++i)
		{
			movespeed += new Vector3 (-.07f, 0, 0);
			transform.position += movespeed;
			yield return 1;
		}
		Transform camTrans=Camera.main.transform;
		Vector3 saveCamPos = camTrans.position;
		for(int i=50;i>=1;--i)
		{
			camTrans.position=saveCamPos+new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f))*i/10.0f;
			yield return 1;
		}
		camTrans.position = saveCamPos;
		level.SendMessage ("GameFinished");


	}
	public void Activate()
	{
		Debug.Log ("Activated");
		main.controlEnabled = false;
		Camera.main.transform.parent = null;
		main.ballMF.transform.parent = transform;
		activated = true;
		StartCoroutine (PlayFinishAnimation ());
	}
	// Update is called once per frame
	void Update () {
		if(activated)
		{
		}
	}
}
