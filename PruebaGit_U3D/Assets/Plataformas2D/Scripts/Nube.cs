using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{

    Vector3 posInicial = Vector3.zero;
    Vector3 movimientoOscilacion = Vector3.zero;

    Quaternion rotInicial = Quaternion.identity;

    void Start()
    {
        posInicial = transform.position;
        rotInicial = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        movimientoOscilacion.y = Mathf.Sin(Time.time * 2) * 0.3f;
        transform.position = posInicial + movimientoOscilacion;

        transform.rotation = Quaternion.AngleAxis(Time.time * 45, Vector3.up) * rotInicial;
    }

   
}
