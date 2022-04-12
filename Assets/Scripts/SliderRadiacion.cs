using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRadiacion : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Fondo = null;
    [SerializeField] private Slider sliderRadiacion = null;
    [SerializeField] ParticleSystem radiacion;
    public GameObject SpaceBackground;
    public Text estadisticaRadiacion;
    private void Awake()
    {
        radiacion.GetComponent<ParticleSystem>();
    }
    public void SliderRadi()
    {
        if (sliderRadiacion.value >= 50)
        {
            Fondo.color = Color.Lerp(Color.white, Color.green, sliderRadiacion.value - 5f);
            radiacion.Play();
        }
        else if (sliderRadiacion.value <=0)
        {
            Fondo.color = Color.white;
            radiacion.Stop();
        }
        estadisticaRadiacion.text = sliderRadiacion.value.ToString("f0");
    }

}
