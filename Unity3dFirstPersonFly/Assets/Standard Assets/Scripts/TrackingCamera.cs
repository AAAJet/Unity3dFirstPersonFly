using UnityEngine;
using System.Collections;

public class TrackingCamera : MonoBehaviour 
{
	public GameObject objectToTrack;

	public float trackingOffsetZ;
	
	// Update is called once per frame
	void Update () 
	{
		if (objectToTrack != null)
		{
			Vector3 currentPosition = transform.position;
			float x = currentPosition.x;
			float y = currentPosition.y;
			float z = objectToTrack.transform.position.z + trackingOffsetZ;

			transform.position = new Vector3(x, y, z);
		}
	}
}
