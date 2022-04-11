using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonIluminado : MonoBehaviour
{
    private Image imagen;
    private float contador = 255;
    private int maximo = 250; //se pone 250 para evitar bugs con el color en byte.
    private int minimo = 150;
    private bool abajo = true;
    public float MultiplicadoDeVelocidad;

    
    void Start()
    {
        imagen = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (abajo && contador >= minimo)
        {
            contador -= Time.deltaTime * MultiplicadoDeVelocidad;
        }
        else
        {
            abajo = false;
        }
        if (contador <= maximo && !abajo)
        {
            contador += Time.deltaTime * MultiplicadoDeVelocidad;
        }
        else
        {
            abajo = true;
        }

        imagen.color = new Color32((byte)contador, (byte)contador, (byte)contador, 255);
    }
}
