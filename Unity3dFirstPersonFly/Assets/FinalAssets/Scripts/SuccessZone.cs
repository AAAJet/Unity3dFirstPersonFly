using UnityEngine;
using System.Collections;

public class SuccessZone : MonoBehaviour 
{
	void OnTriggerEnter()
	{

		HungryBirdController.NotifySuccess();
	}
}
