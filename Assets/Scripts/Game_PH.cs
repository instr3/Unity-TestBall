using UnityEngine;
using System.Collections;
public class Game_PH : MonoBehaviour {
	Main main;
	public GameObject[] PHPrefab;
	public string[] PHPrefabName;
	public class PHObject
	{
		
		public string name;
		public int sector;
		public Vector3 pos,rot;
		public string type;
		public PHObject(string iname,int isector,float px,float py,float pz,float rx,float ry,float rz,string group)
		{
			name=iname;sector=isector;
			pos=new Vector3(-px,py,-pz);
			rot=new Vector3(rx,ry,rz)*Mathf.Rad2Deg;

			type=group;
		}
	};
	[HideInInspector]
	public int PHCount;
	[HideInInspector]
	public int currentSector;
	public PHObject[] PHCurrent=new PHObject[1001];
	
	
	// Use this for initialization
	void Start () {
		GameObject level=GameObject.Find ("Level");
		main = level.GetComponent<Main> ();
		PHObject[] PHLv1= {
			new PHObject ("P_Ball_Paper_01", 1, -148.327f, 19.3652f, -362.153f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_02", 1, -151.636f, 19.3652f, -358.844f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_03", 1, -157.914f, 19.3652f, -358.844f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_04", 1, -153.223f, 19.3652f, -367.049f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_05", 4, 491.864f, 76.8535f, -912.667f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_06", 4, 525.565f, 55.3038f, -875.904f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_07", 4, 630.457f, -4.10724f, -913.622f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Paper_08", 3, 181.818f, 5.85561f, -799.609f, 0f, 0f, 0f, "P_Ball_Paper"),
			new PHObject ("P_Ball_Stone_01", 3, 181.818f, 5.85543f, -795.002f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_02", 4, 525.535f, 67.1459f, -911.892f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_03", 4, 563.747f, 32.5094f, -914.148f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_06", 3, 181.818f, 5.85561f, -786.095f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_07", 3, 181.818f, 5.85561f, -804.288f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_08", 3, 181.818f, 5.85561f, -781.645f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Stone_09", 3, 181.818f, 5.85543f, -790.437f, 0f, 0f, 0f, "P_Ball_Stone"),
			new PHObject ("P_Ball_Wood_01", 4, 488.318f, 78.4752f, -915.069f, 0f, 0f, 0f, "P_Ball_Wood"),
			new PHObject ("P_Ball_Wood_02", 4, 562.625f, 43.5815f, -874.362f, 0f, 0f, 0f, "P_Ball_Wood"),
			new PHObject ("P_Ball_Wood_03", 1, -62.3069f, 21.6523f, -363.744f, 0f, 0f, 0f, "P_Ball_Wood"),
			new PHObject ("P_Ball_Wood_04", 2, -52.0458f, 12.4523f, -363.612f, 0f, 0f, 0f, "P_Ball_Wood"),
			new PHObject ("P_Box_01", 1, -145.363f, 20.1096f, -150.178f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Box_02", 1, -145.363f, 20.1096f, -155.385f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Box_03", 1, -156.088f, 20.1096f, -138.505f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Box_04", 2, 167.066f, -0.84446f, -567.469f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Box_05", 2, 167.066f, -6.0603f, -567.469f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Box_06", 2, 147.167f, 17.2373f, -650.806f, 0f, 0f, 0f, "P_Box"),
			new PHObject ("P_Dome_01", 2, 74.7851f, 5.17669f, -507.788f, 0f, 0f, 0f, "P_Dome"),
			new PHObject ("P_Extra_Life_04", 1, -170.978f, 19.9759f, -137.735f, 0f, -1.5708f, 0f, "P_Extra_Life"),
			new PHObject ("P_Extra_Life_01", 2, 147.232f, -1.57607f, -568.227f, -1e-006f, 1.5708f, 0f, "P_Extra_Life"),
			new PHObject ("P_Extra_Life_02", 3, 267.12f, -2.11739f, -792.714f, 0f, 0f, 0f, "P_Extra_Life"),
			new PHObject ("P_Extra_Life_03", 4, 439.121f, 64.2442f, -913.909f, 0f, 0f, 0f, "P_Extra_Life"),
			new PHObject ("P_Extra_Point_01", 1, -177.653f, 18.6937f, -377.888f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_06", 1, -85.2313f, 22.2826f, -363.769f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_07", 1, -78.0443f, 22.2826f, -363.769f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_08", 1, -70.7101f, 22.2826f, -363.769f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_02", 2, 167.066f, -6.64029f, -567.469f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_03", 3, 274.131f, 5.44485f, -771.975f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_04", 4, 426.885f, 15.2356f, -889.438f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_05", 4, 467.474f, 37.259f, -854.968f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_09", 2, 74.6317f, 3.6766f, -460.07f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_10", 3, 187.371f, 5.61786f, -782.948f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Extra_Point_11", 2, 127.309f, -1.63843f, -562.788f, 0f, 0f, 0f, "P_Extra_Point"),
			new PHObject ("P_Modul_01_01", 3, 262.77f, -4.67975f, -795.214f, 0f, -1.5708f, 0f, "P_Modul_01"),
			new PHObject ("P_Modul_01_02", 3, 272.77f, -4.67975f, -795.214f, 0f, -1.5708f, 0f, "P_Modul_01"),
			new PHObject ("P_Modul_34_01", 2, 147.232f, -4.13842f, -555.327f, 0f, -1.5708f, 0f, "P_Modul_34"),
			new PHObject ("P_Trafo_Stone_01", 2, 147.232f, -4.04348f, -533.231f, 0f, 0f, 0f, "P_Trafo_Stone"),
			new PHObject ("P_Trafo_Stone_02", 1, -191.52f, 12.8849f, -224.55f, 0f, 0f, 0f, "P_Trafo_Stone"),
			new PHObject ("P_Trafo_Wood_05", 1, -153.793f, 16.5896f, -272.917f, 0f, 0f, 0f, "P_Trafo_Wood"),
			new PHObject ("P_Trafo_Wood_01", 3, 302.035f, -9.7479f, -830.547f, 0f, 0f, 0f, "P_Trafo_Wood"),
			new PHObject ("P_Trafo_Wood_02", 4, 302.035f, -9.7479f, -830.547f, 0f, 0f, 0f, "P_Trafo_Wood"),
			new PHObject ("PR_Resetpoint_01", 1, 54.0956f, 17.6565f, -153.072f, 3.14159f, 8.74228e-008f, -3.14159f, "PR_Resetpoints"),
			new PHObject ("PR_Resetpoint_02", 2, -18.6501f, 14.959f, -379.104f, 3.14159f, -8.74228e-008f, 3.14159f, "PR_Resetpoints"),
			new PHObject ("PR_Resetpoint_03", 3, 147.433f, 1.68852f, -710.489f, 0f, -1.5708f, 0f, "PR_Resetpoints"),
			new PHObject ("PR_Resetpoint_04", 4, 341.96f, -4.07268f, -830.591f, 3.14159f, -8.74228e-008f, 3.14159f, "PR_Resetpoints"),
			new PHObject ("PC_TwoFlames_01", 1, -18.6501f, 11.6332f, -379.104f, 3.14159f, 0f, 3.14159f, "PC_Checkpoints"),
			new PHObject ("PC_TwoFlames_02", 2, 147.433f, -1.63728f, -710.489f, 0f, -1.5708f, 0f, "PC_Checkpoints"),
			new PHObject ("PC_TwoFlames_03", 3, 341.96f, -7.39847f, -830.591f, 0f, 0f, 0f, "PC_Checkpoints")};
		PHCount = PHLv1.GetUpperBound(0)+1;
		for(int i=1;i<=PHCount;++i)
		{
			PHCurrent[i]=PHLv1[i-1];
		}
	}
	public void ActivateSector(int index)
	{
		currentSector = index;
		for(int i=1;i<=PHCount;++i)
		{
			if(PHCurrent[i].sector==index)
			{
				if(PHCurrent[i].type=="PR_Resetpoints")
				{
					main.spawnPos=PHCurrent[i].pos;
					main.spawnRot=new Vector3(PHCurrent[i].rot.x,PHCurrent[i].rot.y+90,PHCurrent[i].rot.z);
				}
				else InstantiatePH(i);
			}
		}
	}
	bool InstantiatePH(int index)
	{
		for(int i=0;i<=PHPrefabName.GetUpperBound(0);++i)
		{
			if(PHCurrent [index].type==PHPrefabName[i])
			{
				GameObject newPH = (GameObject)Instantiate (PHPrefab[i]);
				newPH.transform.position = PHCurrent [index].pos;
				newPH.transform.eulerAngles = PHCurrent [index].rot;
				newPH.name = PHCurrent [index].name;
				newPH.SendMessage("Init",currentSector,SendMessageOptions.DontRequireReceiver);
				return true;
			}
		}
		return false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
