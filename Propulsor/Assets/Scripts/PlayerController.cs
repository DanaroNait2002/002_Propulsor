using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 50f;

    [SerializeField]
    TextMeshProUGUI labelFuel;

    [SerializeField]
    GameObject prefabsParticles;


    //Variable tipo float de FUEL actual
    float fuel = 100f;


    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        //Fuerza inicial de BODY hacia la derecha
        //body.AddForce(transform.right, ForceMode2D.Impulse);
    }

    
    void Update()
    {
        //Obtengo datos de movimiento en el mando/teclado
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        //El valor de FUEL disminuye con el tiempo
        fuel = fuel - 1 * Time.deltaTime;
        labelFuel.text = fuel.ToString("00") + "%";
    }

    //Recarga de combustible
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel")
        {
            //Aumenta en 10 el FUEL
            fuel += 10f;
            
            //Limitamos que el total sobrepase el 100%
            if (fuel > 100f)
            {
                fuel = 100;
            }

            //Crear particulas de EXPLOSION
            Instantiate(prefabsParticles, collision.transform.position, collision.transform.rotation);

            //Se destruye el objeto
            Destroy(collision.gameObject);
        }
    }


    private void FixedUpdate()
    {
        //Empujo hacia donde se mueve
        body.AddForce(direction, ForceMode2D.Impulse);
    }
}
