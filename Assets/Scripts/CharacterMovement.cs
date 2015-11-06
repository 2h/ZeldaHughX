using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	//We use floats for numbers that can contain decimal points
	public float currentSpeed = 0f;
	public float walkSpeed = 1.5f;
	public float runSpeed = 3f;

	// Use this for initialization
	void Start () {
		//When the game loads we'll make the current speed Link can reach the same as the walk speed
		currentSpeed = walkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//Inputs: http://docs.unity3d.com/Manual/ConventionalGameInput.html
		//Input scripting reference: http://docs.unity3d.com/ScriptReference/Input.html

		//GetButtonDown checks if the button has been depressed, only once per press
		if (Input.GetButtonDown("Jump"))
		{
			//Log something to the console so we know it's working
			Debug.Log("Pressed the Jump Button!");
			//Change the currentSpeed link can reach to the run speed
			currentSpeed = runSpeed;
		}

		//GetButtonUp checks if a pressed button has been released, only once per press
		if (Input.GetButtonUp("Jump"))
		{
			Debug.Log("Let go of the Jump Button!");
			//Change the currentSpeed of link can reach to the walking speed
			currentSpeed = walkSpeed;
		}

		//You can also us "GetButton" which checks if a button is pressed every single frame and executes the code inside every single frame also


		//GetAxis checks the named axis for presses, by default Unity binds the let and right arrows to a single axis.
		// Without pressing either arrow, "Horizontal" is equal to "0", pressing left "Horizontal" is equal to "-1", pressing right "Horizontal" is equal to "1"
		
		//We check if our right key is being pressed by checking if the Horizontal Axis value is greater than 0.1f
		if (Input.GetAxis("Horizontal") > 0.1f)
		{
			Debug.Log("Presing the Right Arrow!");

			//Call our custom function we made below and give it a Vector2 (x, y values) to work with.
			//http://docs.unity3d.com/ScriptReference/Vector2.html
			//In this Vector2 we set the x value to the value of our Inputted axis, since we dont want link to move up or down we set the y value to 0
			MoveCharacter(new Vector2(Input.GetAxis("Horizontal"), 0));
		}

		//We check if our left key is being pressed by checking if the Horizontal Axis value is less than -0.1f
		if (Input.GetAxis("Horizontal") < -0.1f)
		{
			Debug.Log("Presing the Left Arrow!");
			//In this Vector2 we set the x value to the value of our Inputted axis, since we dont want link to move up or down we set the y value to 0
			MoveCharacter(new Vector2(Input.GetAxis("Horizontal"), 0));
		}

		//Check if the up arrow is pressed
		if (Input.GetAxis("Vertical") > 0.1f)
		{
			Debug.Log("Presing the Up Arrow!");
			//In this Vector2 we set the y value to the value of our Inputted axis, since we dont want link to move left or right we set the x value to 0
			MoveCharacter(new Vector2(0, Input.GetAxis("Vertical")));
		}

		if (Input.GetAxis("Vertical") < -0.1f)
		{
			Debug.Log("Presing the Down Arrow!");
			//In this Vector2 we set the y value to the value of our Inputted axis, since we dont want link to move left or right we set the x value to 0
			MoveCharacter(new Vector2(0, Input.GetAxis("Vertical")));
		}
	}

	//We have declared our own custom function, note that it is outside the curly brackets of any other function, but inside the curly brackets of our Class
	//In the brackets beside the name we state that this function needs to be supplied with a Vector2
	void MoveCharacter(Vector2 axis)
	{
		//http://docs.unity3d.com/ScriptReference/Transform.Translate.html

		//To translate something means to cause it to move within the game world

		//We supply three values to translate by
		//The Axis tells us which direction we move as it's a Vector2
		//We multiply that by the speed we wish to move at
		//Then we multiply that my Time.deltaTime, which smoothes out our movement speed based on the framerate of our game
		//Deltatime will give us consistant movement speed regardless of the game's performance 
		//http://docs.unity3d.com/ScriptReference/Time-deltaTime.html
		transform.Translate(axis * currentSpeed * Time.deltaTime);
	}
}
