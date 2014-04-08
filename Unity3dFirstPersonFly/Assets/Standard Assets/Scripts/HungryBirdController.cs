using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HungryBirdController : MonoBehaviour 
{
	static int points;

	public string sceneName;
	public float convectionForceAmount = 9.0f;
	public GUISkin playerGUISkin;
	private Rect imageRectangle;


	private static bool succeded;
	private bool failed;

	// Use this for initialization
	void Start()
	{
     	// reset game state
		Time.timeScale = 1.0f;
		succeded = false;
		failed = false;

	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Jump") || (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began))
		{
			rigidbody.AddForce(new Vector3(0, convectionForceAmount, 0));
		}
	}

	void OnCollisionEnter()
	{
		Time.timeScale = 0.00000001f;
		failed = true;
	}

	#region HUD display

	/// <summary>
	/// Draw HUD with points
	/// </summary>
	void OnGUI()
	{
		GUI.skin = playerGUISkin;
		Rect textRectangle = new Rect(20, 20, 100, 40);
		GUI.Label(textRectangle, "Score: " + points);

		if (succeded)
		{
			DrawSuccess();
		}
		else if (failed)
		{
			DrawFailure();
		}
	}

	void DrawSuccess()
	{
		int X = (int)(Screen.width*0.5);
		int Y = (int)(Screen.height*0.5);
		GUI.Label (new Rect (X - 100, Y - 20, 200, 40), "Jesteś Zwycięzcą");
        GUI.Label(new Rect(X - 100, Y + 20, 200, 40), "Wynik: " + points);
		int buttonWidth = 128;
		int buttonHeight = 60;
		int positionX = (int)(X - buttonWidth * 0.5f);
		int positionY = (int)(Y - buttonHeight * 0.5f);
		Rect buttonRect = new Rect(positionX, positionY, buttonWidth, buttonHeight);
		if (GUI.Button(buttonRect, "Try again!"))
		{
			Application.LoadLevel(sceneName);
		}
	}

	void DrawFailure()
	{
		int X = (int)(Screen.width*0.5);
		int Y = (int)(Screen.height*0.5);
        GUI.Label(new Rect(X - 100, Y - 60, 200, 40), "LOOOOOOSER");
        GUI.Label(new Rect(X - 100, Y + 60, 200, 40), "Wynik: " + points);

		int buttonWidth = 128;
		int buttonHeight = 60;
		int positionX = (int)(X - buttonWidth*0.5f);
		int positionY = (int)(Y - buttonHeight * 0.5f);
		Rect buttonRect = new Rect(positionX, positionY, buttonWidth, buttonHeight);
		if (GUI.Button(buttonRect, "Try again!"))
		{
			Application.LoadLevel(sceneName);
			points=0;
		}
	}

	#endregion

	#region Game state management

	public static void NotifySuccess()
	{
		Time.timeScale = 0.00000001f;
		succeded = true;
	}

	public static void AddPoints(int amount)
	{
		points += amount;
	}

	#endregion
}
