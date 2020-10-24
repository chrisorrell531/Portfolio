/// Programmed By Christopher Orrell 18/05/2018.
/// This script controlls the player movement.

using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    //Creates variables for the players movement speed, the Horizontal Input, Vertical Input, the Controller to the move the player etc.
    public float speed = 1f;
    public float upwardForce = 4f;
    float hori_Input;
    float verti_Input;
    float upward_input;
    Vector3 moveDir;
    CharacterController controller;
    Vector3 forward;
    Vector3 right;
    Vector3 upward;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        hori_Input = Input.GetAxis("Horizontal") * speed;
        verti_Input = Input.GetAxis("Vertical") * speed;
        if (Input.GetButtonUp("Jump"))
        {
            upward_input = upwardForce;
        }
        upward = transform.up;
        forward = transform.forward;
        right = transform.right;
        upward_input -= 9.89f * Time.deltaTime;
    }

    //This is inline with the physics timestep, so anything physics based such as movement... collisions etc
    private void FixedUpdate()
    {
        //Moves the character controller component forward multipled by our vertical input from W or A or Up arrow or Down arrow added by our right direction multiplied by our horizontal input of A or D or Left arrow and Right Arrow keys.
        controller.SimpleMove(forward * verti_Input + right * hori_Input);
        //Moves the character upward as if the character has jumped.
        if (upward_input > 0)
        {
            controller.Move((upward * upwardForce) * Time.deltaTime);
        }
    }
}
