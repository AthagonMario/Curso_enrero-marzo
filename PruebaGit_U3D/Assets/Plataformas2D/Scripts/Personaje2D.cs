using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje2D : MonoBehaviour
{
    CharacterController characterController;
    AudioSource audioSource;
    Vector3 movimiento = Vector3.zero;
    Animator anim;
    [SerializeField] float direccionHorizontal;
    [SerializeField] float velocidad = 3f;
    [SerializeField] float gravedad = 9f;
    [SerializeField] float salto = 2f;
    float fuerzaGravedad = 0f;
    float duracionSalto = 0f;

    void Start()
    {
        // Esta es una manera de evitar el [SerializeField].
        // OJO: Que sólo se debe hacer en Start
        characterController = gameObject.GetComponent<CharacterController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponentInChildren<Animator>(); // El Animator está en el hijo
    }

    void Update()
    {

        duracionSalto = duracionSalto + Time.deltaTime;
        
        // MOVIMIENTO
        //Mover en direccion horizontal (eje x) con flechas o letras A y D
        direccionHorizontal = Input.GetAxis("Horizontal");
        
        if (direccionHorizontal > 0f)
        {
            anim.transform.rotation = Quaternion.AngleAxis(90, Vector3.up); //Cuando va a la derecha rota 90
        }
        if (direccionHorizontal < 0f)
        {
            anim.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up); //Cuando va a la izquierda rota -90
        }
        anim.SetFloat("Blend", Mathf.Abs(direccionHorizontal));


        // SALTO
        //Si estoy posado en el suelo
        if (characterController.isGrounded) 
        {
            anim.SetBool("Suelo", true);
            fuerzaGravedad = 1f; 
            
            if (Input.GetButtonDown("Jump"))
            {
                Salto();
            }
            else
            {
                anim.SetBool("Suelo", false);
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

        anim.SetTrigger("Salto");

        fuerzaGravedad = -salto;
        duracionSalto = 0;
        ReproducirSonido();
        
    }

    public void animacionSuelo()
    {
        anim.SetBool("Suelo", true);
        fuerzaGravedad = 1f;
    }

    private void ReproducirSonido()
    {
        audioSource.Play();
    }
}
