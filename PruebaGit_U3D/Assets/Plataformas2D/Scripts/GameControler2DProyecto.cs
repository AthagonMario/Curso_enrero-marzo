using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler2DProyecto : MonoBehaviour
{
    [SerializeField] Transform inicioJugador;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PersonajeMuerto(GameObject jugador)
    {
        if (jugador.CompareTag("Player"))
        {
            jugador.GetComponent<CharacterController>().enabled = false;
            jugador.transform.position = inicioJugador.position;
            jugador.GetComponent<CharacterController>().enabled = true;
        }
    }
}
