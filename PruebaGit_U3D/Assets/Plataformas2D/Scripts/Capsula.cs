using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsula : MonoBehaviour
{
    CharacterController characterController;
    Vector3 movimiento = Vector3.zero;
    [SerializeField] float direccionHorizontal;
    [SerializeField] float velocidad = 3f;
    [SerializeField] float gravedad = 9f;
    [SerializeField] float salto = 2f;
    float fuerzaGravedad = 0f;
    float duracionSalto = 0f;
    
    

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        
    }

    void Update()
    {

        duracionSalto = duracionSalto + Time.deltaTime;

        // MOVIMIENTO. Mover en direccion horizontal (eje x) con flechas o letras A y D
        direccionHorizontal = Input.GetAxis("Horizontal");

        // SALTO. Si estoy posado en el suelo
        if (characterController.isGrounded)
        {
            fuerzaGravedad = 1f;
            if (Input.GetButtonDown("Jump"))
            {
                Salto();
            }
            
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (duracionSalto < 0.2f)
            {
                fuerzaGravedad = fuerzaGravedad / 2;
            }
        }
        fuerzaGravedad = fuerzaGravedad + gravedad * Time.deltaTime;
        movimiento.y = -fuerzaGravedad;
        movimiento.x = direccionHorizontal * Time.deltaTime * velocidad;
        characterController.Move(movimiento);
    }

    public void Salto()
    {
        //Intensidad de salto. Esta es la fuerza de gravedad que va a mostrar en el salto.
        //A valores mas pequeños (p.e. -4) el salto es mayor
        fuerzaGravedad = -salto;
        duracionSalto = 0;
        
    }

    
}
