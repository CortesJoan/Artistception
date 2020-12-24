using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed = 3;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    //Put non physics based movement in here
    void Update()
    {
        Move();

    }

    //Put physica based movement in here
    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            rb2d.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
        }
        else if (buttonPressed == LEFT)
        {
            rb2d.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {
        
        }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;


        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;


        }
        else
        {
            buttonPressed = null;
        }
    }
}
