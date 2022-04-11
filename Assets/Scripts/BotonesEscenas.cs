using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesEscenas : MonoBehaviour
{
    //BOTONES-SLIDERS
    [SerializeField] private Button eventoBTN1;
    [SerializeField] private Button eventoBTN2;
    [SerializeField] private Button eventoBTN3;
    [SerializeField] private Button eventoBTN4;
    [SerializeField] private Slider sliderTemp;
    [SerializeField] private Slider sliderRadi;

    //FONDOS
    //public SpriteRenderer FondoActual;
    //public Sprite FondoEvento1;
    //public Sprite FondoEvento2;
    //public Sprite FondoEvento3;
    //public Sprite FondoEvento4;
    //public Sprite FondoEvento5;

    public SpriteRenderer FondoActual;
    public void Start()
    {
        FondoActual = GameObject.Find("Fondo").GetComponent<SpriteRenderer>();       

    }
    public void ColdChange()
    {
        //Cambio de fondo
        //FondoActual.sprite = FondoEvento2;
        FondoActual.sprite = Resources.Load<Sprite>("Fondos/FondoEvento2");
        //Bloqueo de botones-slider
        sliderTemp.interactable = true;
        sliderRadi.interactable = false;

    }
    public void WarmChange()
    {
        //Cambio de fondo
        //FondoActual.sprite = FondoEvento2;
        FondoActual.sprite = Resources.Load<Sprite>("Fondos/FondoEvento3");

        //Bloqueo de botones-slider
        sliderRadi.interactable = false;
        sliderTemp.interactable = true;
    }
    public void RadioChange()
    {
        //Cambio de fondo
        //FondoActual.sprite = FondoEvento2;
        FondoActual.sprite = Resources.Load<Sprite>("Fondos/FondoEvento4");

        //Bloqueo de botones-slider
        sliderTemp.interactable = false;
        sliderRadi.interactable = true;
    }
    public void SpaceChange()
    {
        //Cambio de fondo
        //FondoActual.sprite = FondoEvento2;
        FondoActual.sprite = Resources.Load<Sprite>("Fondos/FondoEvento5");

        //Bloqueo de botones-slider
        sliderRadi.interactable = false;
        sliderTemp.interactable = false;
    }

}
