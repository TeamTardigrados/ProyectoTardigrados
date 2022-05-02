using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Humedad : MonoBehaviour
{
    public Slider barraHumedad;
    [SerializeField] public float humedad;
    [SerializeField] float maxHumedad = 100f;
    public Text estaditicaHumedad;
    [SerializeField] Interfaz_controller sliderTemperatura;
    public Action OnWaterEnd;
    public Action OnGetWater;
    //Referencias
    [SerializeField] Mision mision1;
    [SerializeField] Mision mision2;

    void Start()
    {
        humedad = maxHumedad;
    }
    void Update()
    {
        barraHumedad.value = humedad;
        humedad -= 1f * Time.deltaTime;
        if (humedad <= 0f)
        {
            humedad = 0f;
        }
        if (sliderTemperatura.temperaturaActual >= 0.8f || sliderTemperatura.temperaturaActual <= 0.2f)
        {
            humedad -= 7f * Time.deltaTime;
            if (humedad <= 0 )
            {
                OnWaterEnd?.Invoke();
            }
        }
      
        estaditicaHumedad.text = ((int)humedad).ToString();
    }
    
    public void AumentoHumedad()
    {
        OnGetWater?.Invoke();
        mision1.DetectarHidratacion40a50();
        mision2.RehidratarTradigrado();
        humedad = maxHumedad;
        //humedad = maxHumedad;
    }

}
