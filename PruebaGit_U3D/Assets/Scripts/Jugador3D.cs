using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador3D : MonoBehaviour
{
    CharacterController characterController;

    float fuerzaGravedad = 0f;
    [SerializeField] float fuerzaSalto = 20f; // 20 Con este valor funciona
    [SerializeField] float gravedad = 45f;  // 45 Con este valor funciona

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    Vector3 desplazamiento = Vector3.zero;
    [SerializeField] float velocidad = 3;
    [SerializeField] float velocidadGiro = 45;

    void Update()
    {
        // DESPLAZAMIENTO Y SALTO --------------------------------------------------------------------------------
        // Hay que ponerle gravedad porque sino flotaría
        desplazamiento = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        if (characterController.isGrounded)
        {
            fuerzaGravedad = gravedad;
            if (Input.GetButtonDown("Jump"))
            {
                fuerzaGravedad = -fuerzaSalto;
            }
        } else
        {
            fuerzaGravedad = fuerzaGravedad + gravedad * Time.deltaTime;
        }
        desplazamiento.y = -fuerzaGravedad * Time.deltaTime;
        // El movimiento tambien se puede hacer a traves de transform.position. pero es mas optimo con Move
        characterController.Move(desplazamiento);
        
        // ROTACION --------------------------------------------------------------------------------------
        // A la hora de rotar, al incrementar el Quaternion no se suma, se multiplica
        // Vector3.up indica el eje sobre el que va a rotar en este caso Vector3.up es (0,1,0)... Eje de las Y
        float angulo = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadGiro;
        transform.rotation = transform.rotation * Quaternion.AngleAxis(angulo, Vector3.up);
    }
}