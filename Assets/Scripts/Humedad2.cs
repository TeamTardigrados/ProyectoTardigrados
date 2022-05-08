using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Humedad2 : MonoBehaviour
{
    public Slider barraHumedad;
    [SerializeField] public float humedad;
    [SerializeField] float maxHumedad = 100f;
    public Text estaditicaHumedad;
    [SerializeField] Interfaz_controller sliderTemperatura;

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
        if (sliderTemperatura.temperaturaActual >= 0.8f || sliderTemperatura.temperaturaActual<= 0.2f)
        {
            humedad -= 4f * Time.deltaTime;

        }

        estaditicaHumedad.text = ((int)humedad).ToString();
    }

    public void AumentoHumedad()
    {
        humedad = maxHumedad;
    }
}
