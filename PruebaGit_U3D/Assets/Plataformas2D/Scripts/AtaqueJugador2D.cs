using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueJugador2D : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arma2DProyecto")
        {
            Debug.Log("Tocado");
        }
    }

    void Update()
    {
      
    }
}
