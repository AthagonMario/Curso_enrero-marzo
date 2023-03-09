using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador3D : MonoBehaviour
{
    CharacterController characterController;
    Vector3 desplazamiento = Vector3.zero;
    float fuerzaGravedad = 0f;
    [SerializeField] float gravedad = 45f;
    [SerializeField] float FuerzaSalto = 4f;
    [SerializeField] float velocidad = 45f;
    [SerializeField] float Giro = 45f;
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }



    void Update()
    {
        // ejemplo 1 // desplazamiento.z = 1 * Time.deltaTime; //Incremento la dirección en 1 metro * cada "tiempo",  en la dirección "Z"
        desplazamiento = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        if (characterController.isGrounded) //si nuestro personaje esta tocando el suelo
        {
            fuerzaGravedad = gravedad;
            if (Input.GetButtonDown("Jump"))
            {
                fuerzaGravedad = -FuerzaSalto;
            }
        }
        else { fuerzaGravedad = fuerzaGravedad + gravedad * Time.deltaTime; }
        

        desplazamiento.y = -fuerzaGravedad * Time.deltaTime;

        //desplazamiento.y = 1 * Time.deltaTime; //Prueba en dirección "Y"
        // transform.position = transform.position + desplazamiento; // suma coordenadas del objeto con las coordenadas entregadas desde el joystick
        characterController.Move(desplazamiento); //Lo aplico
        //transform.rotation = transform.rotation * Quaternion.AngleAxis(45 * Time.deltaTime,Vector3.up);
        transform.rotation = transform.rotation * Quaternion.AngleAxis(Giro * Input.GetAxis("Horizontal") * Time.deltaTime, Vector3.up);

    }
}
