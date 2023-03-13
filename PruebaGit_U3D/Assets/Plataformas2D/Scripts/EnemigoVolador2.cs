using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 3f;
    public float limiteX = 10f;
    public GameObject proyectil;
    public float frecuenciaDisparo = 2f;
    public float cuentaatrasDisparo = 0;
    Vector3 movimientoOscilacion = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.PingPong(Time.time * velocidad, limiteX * 2) - limiteX;
        movimientoOscilacion.y = Mathf.Sin(Time.time * 2) * 0.01f;
        transform.position = new Vector3(x, transform.position.y, transform.position.z) + movimientoOscilacion;

        cuentaatrasDisparo -= Time.deltaTime;
        if (cuentaatrasDisparo <= 0f)
        {
            cuentaatrasDisparo = 1f / frecuenciaDisparo;
            LanzaProyectil();
        }
    }

    private void LanzaProyectil()
    {
        Vector3 posicionLanzamiento = transform.position + new Vector3(0, -1, 0);
        GameObject bomba = Instantiate(proyectil, posicionLanzamiento, Quaternion.identity);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * 50f);
    }
}
