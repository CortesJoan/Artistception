using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed = 3;
    public bool isUsingThisMovement = true;
    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string JUMP = "space";
    public KeyCode jump;
    string buttonPressed;
    private float acceleration = 9.8f;
    public bool isJumping = false;
    private bool canJump = false;
    public LayerMask groundMask;
    public int DeploymentHeight = 3;
    public List<String> inputList;
    public GameObject hitEffect;
    public float jumpForce;
    private GameManager gameManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    // Los inputs se manejan en el Update
    void Update()
    {
        if (isUsingThisMovement)
        {
            InputHandler();
        }
    }
    bool pressedJumping;


    // Y en el FixedUpdate se hace el movimiento
    private void FixedUpdate()
    {
        if (isUsingThisMovement)
        {
            PerformInputs();
        }
    }
    /// <summary>
    /// Metodo que tira entre 1 a 3 raycast para comprobar si se esta tocando el suelo o no  el primero hacia abajo y los otros 2 en diagonal para assegurarse de poder saltar en bordes
    /// </summary>
    void CheckGroundStatus()
    {

        if (DrawRay(Vector2.down, Color.red) || DrawRay(Quaternion.Euler(-0.2f, 0, -45) * Vector3.down, Color.black) || DrawRay(new Vector3(0.2f, -1, 0), Color.green))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, moveSpeed * jumpForce - rb2d.velocity.x * this.acceleration), ForceMode2D.Impulse);

            canJump = true;
            Debug.Log(canJump);
        }
        else
        {
            canJump = false;
            Debug.Log(canJump);
        }


    }
    /// <summary>
    /// Metodo que tira un raycast con una direction para ver si choca con algo 
    /// </summary>
    /// <param name="direction"> la direction hacia donde ira el rayo en vector2</param>
    /// <param name="color"> el color del rayo</param>
    /// <returns> un booleano para saber si ha collisionado o no</returns>
    private bool DrawRay(Vector2 direction, Color color)
    {
        Debug.DrawRay(transform.position, Vector3.down, color);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, DeploymentHeight, groundMask);
        // Debug.DrawRay(hit);
        if (hit.collider == null)
        {
            return false;
        }
        else
        {

            return true;
        }
    }
    /// <summary>
    /// Metodo para mirar si un input ha sido introducido
    /// </summary>
    /// <param name="input"> el nombre del input a mirar</param>
    /// <returns> si esta o no </returns>
    public bool IsInputInList(String input)
    {

        return inputList.Contains(input);
    }
    /// <summary>
    /// Metodo para añadir inputs a una arraylist  
    /// </summary>
    public void InputHandler()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputList.Add(RIGHT);


        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputList.Add(LEFT);



        }
        else if (Input.GetKey(jump))
        {
            inputList.Add(JUMP);


        }
        else
        {
            buttonPressed = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Dead"))
        {
             
            GameObject blood = Instantiate(hitEffect);
            blood.transform.parent = this.transform;
            blood.transform.localPosition = new Vector3(0, 2, 0);
            blood.GetComponent<ParticleSystem>().Play();
            //  this.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("muerto");
            StartCoroutine("WaitForDeath");
            ///todo death sound




        }
    }
    public IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2);

        gameManager.KillPlayer();
        Destroy(this.gameObject);
        

    }
    public void PerformInputs()
    {

        if (IsInputInList(RIGHT))
        {
            if (!canJump)
            {

                rb2d.AddForce(new Vector2(moveSpeed / 2, 0), ForceMode2D.Impulse);

            }
            else
            {
                rb2d.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
            }
        }
        if (IsInputInList(LEFT))
        {

            if (!canJump)
            {
                rb2d.AddForce(new Vector2(-moveSpeed / 2, 0), ForceMode2D.Impulse);

            }
            else
            {
                rb2d.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);

            }
        }
        if (IsInputInList(JUMP))
        {
            CheckGroundStatus();
            Debug.Log("aaaaaaaaaa");
        }
        inputList.Clear();
    }
}
