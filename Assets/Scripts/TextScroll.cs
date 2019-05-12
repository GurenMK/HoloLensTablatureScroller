using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour {


	public GUIStyle potionStyle;

	int GUIDepthInt = -1;

	Vector3 matrixVector;

	float native_width = 1280;
	float native_height = 720;

	float rx;
	float ry;

	int textUpCounter;

	void Start()
	{
		//scale for your matrix
		//this is where things get messy at different aspect ratios for your scale
		//if you always use a specific native width and height like 1280, 720
		rx = Screen.width/native_width;
		ry = Screen.height/native_height;

		matrixVector = new Vector3 (rx, ry, 1);

		potionStyle.normal.textColor = Color.red;

		textUpCounter = 0;
	}

	void OnGUI()
	{


			GUI.depth = GUIDepthInt;

			GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, matrixVector); 

			++textUpCounter;

			//this will center your text if you use the GUIStyle with "Upper Center" allignment
			//with the 1280, 720 formatting matrix
			GUI.Label (new Rect (640, 140 - textUpCounter, 0, 0), "+1 Health Potions!", potionStyle);


	}
}
