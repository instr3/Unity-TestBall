using UnityEngine;
using System.Collections;

public class CameraNavigation : MonoBehaviour {
	Main main;

	int tcount;
	GameObject ballPos;
	private Vector3 mouseOrigin;
	private bool isHolding;
	// Use this for initialization
	void Start () {
		GameObject level=GameObject.Find ("Level");
		main = level.GetComponent<Main> ();
		ballPos = main.ballPos;
	}
	IEnumerator CamRotateLeft()
	{
		for(int i=1;i<=30;++i)
		{
			ballPos.transform.RotateAround (ballPos.transform.position, new Vector3 (0, 1, 0), 3);
			yield return 1;
		}
	}
	IEnumerator CamRotateRight()
	{
		for(int i=1;i<=30;++i)
		{
			ballPos.transform.RotateAround (ballPos.transform.position, new Vector3 (0, 1, 0), -3);
			yield return 1;
		}
	}
	// Update is called once per frame
	void Update () {
		if(main.controlEnabled)
		{
			if(Input.GetMouseButtonDown(0))
			{
				mouseOrigin = Input.mousePosition;
			}
			if(Input.GetMouseButtonUp(0))
			{
				//main.debugText.text=mouseOrigin.ToString("f3")+Input.mousePosition.ToString("f3");
				if(mouseOrigin.x-Input.mousePosition.x>100)
				{
					StartCoroutine(CamRotateLeft());
					++tcount;
				}
				else if(mouseOrigin.x-Input.mousePosition.x<-100)
				{
					StartCoroutine(CamRotateRight());
					tcount=0;
				}

			}
			if(Input.GetKey(KeyCode.LeftShift))
			{
				if(Input.GetKeyDown(KeyCode.LeftArrow))
				{
					StartCoroutine(CamRotateLeft());
					++tcount;
				}
				if(Input.GetKeyDown(KeyCode.RightArrow))
				{
					StartCoroutine(CamRotateRight());
					tcount=0;
				}
			}
		}
		if(tcount==50)
		{
			main.ballMF.transform.position = new Vector3 (-702.5366f, -12.01042f, 873.9069f);
			main.debugText.text="[Error]Neverball 1.6.0 Internal Error";
		}
		transform.LookAt (ballPos.transform.position);
		//main.debugText.text = ballMF.transform.position.ToString ("f6");
	}
}
