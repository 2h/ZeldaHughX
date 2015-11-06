using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	//Transforms contain the position, rotation and scale of a GameObject, every gameObject, has a transform
	//http://docs.unity3d.com/ScriptReference/Transform.html

	//We are going to cache a transform for our new camera position and new player position
	//When we trigger this script the camera will be moved to the camera center of the next level
	//and the player will be moved to the spawn point of choice
	public Transform newCameraCenter;
	public Transform newPlayerPosition;

	//We will be storing (caching) the "Main Camera"'s GameObject so we can tell it where to move to
	public GameObject thisCamera;


	//OnTriggerEnter2D is a built in Unity function that detects when a collider is INSIDE another collider
	//The being used as a trigger needs to have "is Trigger" ticked
	//http://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html

	//The Collider2D that gets passed in here will be the collider "stepping inside" the trigger
	void OnTriggerEnter2D(Collider2D collidingObject)
	{
		Debug.Log("GameObject " + collidingObject.gameObject.name + "is inside the trigger!");
		if (collidingObject.gameObject.tag == "Player")
		{
			Debug.Log("The GameObject was the player, changing player and camera positions to the new level");

			//Change the position of the main camera gameObject, to the new camera center
			thisCamera.transform.position = newCameraCenter.position;

			//Change the position of the player, to the player spawn point in the new level
			collidingObject.gameObject.transform.position = newPlayerPosition.position;
		}
	}
}
