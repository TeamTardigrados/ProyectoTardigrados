using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interfaz_controller : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Fondo = null;
    [SerializeField] private Slider sliderTemperatura = null;
    public Text estadisticaTemperatura;
    public float temperaturaActual=0;

    private void Start()
    {
        temperaturaActual = sliderTemperatura.value;
        SliderTemp();
    }
    public void SliderTemp()
    {
        if (sliderTemperatura.value >= 0.5 )
        {
            //calor
            Fondo.color = Color.Lerp(Color.white, Color.red, sliderTemperatura.value - 0.5f);
        }
        else   
        {
            //frio
            Fondo.color = Color.Lerp(Color.cyan, Color.white, sliderTemperatura.value + 0.5f);
        }
        estadisticaTemperatura.text = ((int)(200f*sliderTemperatura.value) - 100f).ToString();

        temperaturaActual = sliderTemperatura.value; 
    }

}
