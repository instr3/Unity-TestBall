using UnityEngine;
using System.Collections;

public class Menu_Main : MonoBehaviour {
	int buttonWidth=120,buttonHeight=30;
	int labelWidth=400,labelHeight=200;
	int sliderWidth=200,sliderHeight=30;float sliderValue=2f;
	void Start(){
		
	}
	
	// Update is called once per frame
	void OnGUI(){
		GUI.Label(new Rect((Screen.width-labelWidth)/2,60,labelWidth,labelHeight),"操作说明：\n" +
		          "[电脑]用上下左右操作球的运动，Shift+左右键旋转摄像头。\n" +
		          "        空格键功能没做。用神秘按键做一些你懂得的事情。\n" +
		          "[手机]用重力感应操控球。用手在屏幕上滑动来旋转视角。\n        拖动下面的滑棒调整重力感应的灵敏度，左低右高。\n" +
		          "P.S.:\n" +
		          "这是一个测试Unity做滚球可行性和手感的测试品。全程低能。\n" +
		          "并且只完成了一小部分功能。\n" +
		          "请慎重选择是否开始。\n" +
		          "                                                                        From 2JJY");
		if(GUI.Button(new Rect((Screen.width-buttonWidth)/2,labelHeight+70,buttonWidth,buttonHeight),"开 始"))
		{
			DontDestroyOnLoad(gameObject);
			Application.LoadLevel("Level1");
		}
		if(Application.platform==RuntimePlatform.Android)
			sliderValue = GUI.HorizontalSlider (new Rect ((Screen.width-sliderWidth)/2, labelHeight+buttonHeight+80, sliderWidth, sliderHeight), sliderValue, 1f, 4f);
		
	}
	void OnLevelWasLoaded(int sceneID)
	{
		GameObject level = GameObject.Find ("Level");
		level.GetComponent<Game_Play> ().androidForce = sliderValue;
		Destroy (gameObject);
	}
}
