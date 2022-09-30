using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;

    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        //Fuerza BODY a la derecha
        body.AddForce(transform.right, ForceMode2D.Impulse);
    }

    
    void Update()
    {
        //Obtengo datos de movimiento en el mando/teclado
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        
    }


    private void FixedUpdate()
    {
        //Empujo hacia donde se mueve
        body.AddForce(direction, ForceMode2D.Impulse); 
    }
}
