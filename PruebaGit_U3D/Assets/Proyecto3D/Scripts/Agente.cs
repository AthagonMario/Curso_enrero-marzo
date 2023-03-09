using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Agente : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agente;
    Transform jugador;
 
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        agente.destination = jugador.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (intervalo)
        //{
        //    agente.destination = jugador.position;
        //}

    }
}
