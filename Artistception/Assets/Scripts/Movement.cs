using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float velocidadX;
    float fuerzaSalto = 5f;
    Rigidbody2D rb;
    int saltosHechos;
    int limiteSaltos = 2;
    public bool saltar;
    public Transform refPie;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosHechos = 0;
    }

    // Update is called once per frame
    void Update(){
        saltar = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 8);
        GetComponent<Animator>().SetBool("saltar", saltar);
        velocidadX = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
            GetComponent<Animator>().SetBool("correr", true);
            velocidadX = 3f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
            GetComponent<Animator>().SetBool("correr", true);
            velocidadX = -3f;
        }

        transform.Translate(velocidadX * Time.deltaTime, 0f, 0f);

        if (velocidadX == 0f)
        {
            GetComponent<Animator>().SetBool("correr", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saltosHechos < limiteSaltos)
            {
                rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
                saltosHechos++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "suelo")
        {
            saltosHechos = 0;
        }
    }
}
