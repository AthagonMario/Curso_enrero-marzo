using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPlayer : MonoBehaviour
{
    public int saludMax = 3;
    private int saludActual;
    
    // Start is called before the first frame update
    void Start()
    {
        saludActual = saludMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HazDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;
        Debug.Log("SALUD: " + saludActual);
        if (saludActual <= 0)
        {
            PersonajeMuere();
        }
    }

    private void PersonajeMuere()
    {
        Debug.Log("Personaje muere...");
    }

}
