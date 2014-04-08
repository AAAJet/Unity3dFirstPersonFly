using UnityEngine;
using System.Collections;

public class MENU : MonoBehaviour {
	public GUISkin Gui;
	public string GameScene;

	int buttonWidth = 200;
	int buttonHeight = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = Gui;
		DrawStart ();
		DrawEnd ();

	}

	void DrawStart ()
	{
		int X = (int)(Screen.width*0.5);
		int Y = (int)(Screen.height*0.5);
		int positionX = (int)(X - buttonWidth * 0.5f);
		int positionY = (int)(Y + buttonHeight * 0.5f);
		Rect buttonRect = new Rect(positionX, positionY, buttonWidth, buttonHeight);
		if (GUI.Button(buttonRect, "NEW GAME"))
		{
			Application.LoadLevel(GameScene);
		}

	}

	void DrawEnd ()
	{
		int X = (int)(Screen.width*0.5);
		int Y = (int)(Screen.height*0.5);
		int positionX = (int)(X - buttonWidth * 0.5f);
		int positionY = (int)(Y - buttonHeight * 0.5f);
		Rect buttonRect = new Rect(positionX, positionY, buttonWidth, buttonHeight);
		if (GUI.Button(buttonRect, "END GAME"))
		{
			Application.Quit();
		}	
	}
}
