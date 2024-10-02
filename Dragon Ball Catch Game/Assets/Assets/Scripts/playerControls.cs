using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {

    public Camera cam;
    public float speed = 10.0f;

    private Rigidbody2D rigidBody2D;
    private float maxWidth;

    public static bool movementEnabled;

	// Use this for initialization
	void Start () {
	    if(cam == null)
        {
            cam = Camera.main;
        }

        movementEnabled = false;
        rigidBody2D = GetComponent<Rigidbody2D>();

        Vector3 targetWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        maxWidth = targetWidth.x;
	}

    public void SetMovementEnabled(bool bEnable)
    {
        movementEnabled = bEnable;
    }
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.x = speed;
            GetComponent<Rigidbody2D>().velocity = vel;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.x = -1 * speed;
            GetComponent<Rigidbody2D>().velocity = vel; ;
        }
        else if (!Input.anyKey)
        {
            var vel = GetComponent<Rigidbody2D>().velocity;
            vel.y = 0.0f;
            GetComponent<Rigidbody2D>().velocity = vel;
        }




        if(movementEnabled)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, transform.position.y, 0.0f);

            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition.x = targetWidth;

            rigidBody2D.MovePosition(targetPosition);
        }
	}
}
