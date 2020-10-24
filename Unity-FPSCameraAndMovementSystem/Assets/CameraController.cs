/// Programmed by Christopher Philip Orrell 18/05/2018
/// This script controls the camera's movement, and makes as if its an FPS, Game.

using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Creates variables one is a constant atm becuase it doesnt change but it could  change... and the other saves the y rotation
    float y_Rotation;
    float turnSpeed = 3f;
    //Creates a variable for the player
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //This creates a variable called x rotation and sets it the the camera x rotation plus the input from the mouses x axis multipled by the turn speed. to give an integer answer.
        float x_Rotation = transform.eulerAngles.y + Input.GetAxis("Mouse X") * turnSpeed;
        //This adds y rotation the value given from the mouses y axis multiplied by the turn speed.
        y_Rotation += Input.GetAxis("Mouse Y") * turnSpeed;
        //Now we clamp this angle so the camera cant over turn.
        y_Rotation = Mathf.Clamp(y_Rotation, -60f, 60f);
        //Now we apply the y rotation to the camera like a head looking up and down, we rotate the whole body instead to look left and right.
        transform.localEulerAngles = new Vector3(-y_Rotation, 0, 0);
        player.transform.localEulerAngles = new Vector3(0, x_Rotation, 0);
    }
}
