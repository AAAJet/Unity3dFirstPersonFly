using UnityEngine;
using System.Collections;

public class ScoreZonePointsAdder : MonoBehaviour 
{
	public int pointsAmount;

	void OnTriggerEnter()
	{
		HungryBirdController.AddPoints(pointsAmount);
	}
}
