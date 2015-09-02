using UnityEngine;
using System.Collections;

public class Game_Play : MonoBehaviour {
	Main main;
	public float inputForce;
	[HideInInspector]
	public float androidForce;
	public GUIText timerText;
	public GUITexture whitePanel;
	float timeBegin;
	GameObject ballMF,ballPos;
	public GUITexture blackBackGroundPrefab;
	public GUIText extraLifeLabelPrefab,timeSpentLabelPrefab,totLabelPrefab,thankyouPrefab;
	public Material skyLayerMat;
	// Use this for initialization
	void Start () {
		GameObject level=GameObject.Find ("Level");
		main = level.GetComponent<Main> ();
		level.SendMessage ("ActivateSector", 1);
		//GameObject levelStart = GameObject.FindGameObjectWithTag ("LevelStart");
		ballMF = main.ballMF;
		ballPos = main.ballPos;
		ballMF.transform.position = main.spawnPos;
		ballPos.transform.eulerAngles = main.spawnRot;
		main.controlEnabled = true;
		timeBegin = Time.time;
		
	}
	void SpawnBall()
	{
		ballMF.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		ballMF.GetComponent<Rigidbody>().velocity = Vector3.zero;
		ballMF.transform.position = main.spawnPos;
		ballPos.transform.eulerAngles = main.spawnRot;
	}
	
	IEnumerator DeathPanelShow()
	{
		for(int i=1;i<=30;++i)
		{
			whitePanel.color=new Color(whitePanel.color.r,whitePanel.color.g,whitePanel.color.b,whitePanel.color.a+.05f);
			yield return 10;
		}
		SpawnBall();
		for(int i=1;i<=30;++i)
		{
			whitePanel.color=new Color(whitePanel.color.r,whitePanel.color.g,whitePanel.color.b,whitePanel.color.a-.05f);
			yield return 10;
		}

	}
	IEnumerator FinishPanelShow()
	{
		yield return new WaitForSeconds (5);
		Instantiate (blackBackGroundPrefab);
		yield return new WaitForSeconds (3);
		GUIText timeCounter=((GUIText)Instantiate(timeSpentLabelPrefab)).transform.GetChild(0).GetComponent<GUIText>();
		int timeUsed=int.Parse(timerText.text), timeCounted = 0;
		yield return new WaitForSeconds (1.5f);
		while(timeUsed>0)
		{
			timerText.text=(--timeUsed).ToString();
			timeCounter.text=(++timeCounted).ToString();
			yield return 1;
		}
		yield return new WaitForSeconds (3);
		Instantiate (extraLifeLabelPrefab);
		yield return new WaitForSeconds (3);
		Instantiate (totLabelPrefab);
		yield return new WaitForSeconds (6);
		Instantiate (thankyouPrefab);



	}
	public void GameFinished()
	{
		StartCoroutine (FinishPanelShow ());
	}
	public void FallOut()
	{
		StartCoroutine (DeathPanelShow());
	}
	// Update is called once per frame
	void Update () {

		skyLayerMat.mainTextureOffset = skyLayerMat.mainTextureOffset + new Vector2 (.01f, .02f)*Time.deltaTime;
		ballPos.transform.position = ballMF.transform.position;
		if(main.controlEnabled)
		{
			if(Input.GetKey(KeyCode.LeftShift)==false)
			{
				if(Application.platform==RuntimePlatform.Android)
				{
					Vector3 tVForce = new Vector3 (Input.acceleration.x, 0, Input.acceleration.y)*androidForce ;
					//main.debugText.text=tVForce.ToString("f6")+androidForce;
					if(tVForce.z>1)tVForce/=tVForce.z;
					if(tVForce.x>1)tVForce/=tVForce.x;
					tVForce=tVForce * inputForce*Time.deltaTime;
					tVForce = ballPos.transform.TransformDirection (tVForce);
					ballMF.GetComponent<Rigidbody>().AddForce (tVForce);
				}
				else
				{
					Vector3 tVForce = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetKey(KeyCode.F1)?4:0, Input.GetAxis ("Vertical")) * inputForce*Time.deltaTime;
					tVForce = ballPos.transform.TransformDirection (tVForce);
					ballMF.GetComponent<Rigidbody>().AddForce (tVForce);
				}
			}
			timerText.text=((int)(Time.time-timeBegin)).ToString();
		}
	}
}
