using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Keyboard keyboard;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyboard = Keyboard.current;
    }



    // Update is called once per frame
    void Update()
    {
        if (keyboard != null)
        {
            Vector3 movement = Vector3.zero;

            if (keyboard.wKey.isPressed)
            {
                movement += Vector3.forward;
            }
            if (keyboard.sKey.isPressed)
            {
                movement += Vector3.back;
            }
            if (keyboard.aKey.isPressed)
            {
                movement += Vector3.left;
            }
            if (keyboard.dKey.isPressed)
            {
                movement += Vector3.right;
            }

            //transform.Translate(movement * Time.deltaTime * speed);
            if (this.GetComponent<Rigidbody>().linearVelocity.magnitude < speed)
            {
                this.GetComponent<Rigidbody>().AddForce(
                    movement * Time.deltaTime * speed, ForceMode.VelocityChange
                );
            }

        }
    }
}
