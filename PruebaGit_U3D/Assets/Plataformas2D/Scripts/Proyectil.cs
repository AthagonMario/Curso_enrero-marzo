using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int danio = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaludPlayer saludPlayer = other.GetComponent<SaludPlayer>();
            if (saludPlayer != null)
            {
                saludPlayer.HazDanio(danio);
                Destroy(gameObject);
            }
        }
    }
}
