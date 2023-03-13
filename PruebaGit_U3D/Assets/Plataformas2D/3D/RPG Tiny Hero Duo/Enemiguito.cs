using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemiguito : MonoBehaviour
{
    NavMeshAgent agente;
    Transform jugador;
    int estado = 0;
    [SerializeField] float cronometro = 0;
    float distanciaJugador;
    bool inicioEstado = true;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (estado)
        {
            case 0:
                Patrulla();
                break;
            case 1:
                PerserguirPlayer();
                break;
            case 2:
                AtaquePlayer();
                break;
        }
    }

    void Patrulla()
    {
        // inicio fotograma del estado.

        if (inicioEstado)
        {

            float randonX = Random.Range(-10.0f, 10.0f);
            float randonZ = Random.Range(-10.0f, 10.0f);

            Debug.Log(randonX);

            agente.destination = new Vector3(randonX, 0, randonZ) + transform.position;

            inicioEstado = false; // necesario para que funcione el estado inicial
        }

        // atualización del estado.

        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        // cambios del estado.

        if (cronometro > 10)
        {
            CambiarEstado(0);
        }
        if (distanciaJugador < 5)
        {
            CambiarEstado(1);
        }
    }

    void PerserguirPlayer()
    {
        // inicio fotograma del estado.

        if (inicioEstado)
        {

            Debug.Log("persigue");
            inicioEstado = false; // necesario para que funcione el estado inicial
        }

        // atualización del estado.

        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        agente.destination = jugador.position;

        // cambios del estado.

        if (distanciaJugador > 5 && cronometro > 5)
        {
            CambiarEstado(0);
        }
        if (distanciaJugador < 2.5f)
        {
            CambiarEstado(2);
        }
    }

    void AtaquePlayer()
    {
        if (inicioEstado)
        { // inicio fotograma del estado.

            Debug.Log("ataque");

            agente.destination = transform.position;

            inicioEstado = false; // necesario para que funcione el estado inicial
        }

        // atualización del estado.

        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        // cambios del estado.

        if (distanciaJugador > 1.5f)
        {
            CambiarEstado(1);
        }
    }

    void CambiarEstado(int e) // Funcion para cambiar estados.
    {
        estado = e;
        cronometro = 0;
        inicioEstado = true;
    }
}