using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mision : MonoBehaviour
{
    bool estaAbierto=false;

    [SerializeField] Humedad Humedad;
    float criptobiosisTimer = 0;
    float criptobiosisTimerMax = 100f;
    float humedadCambiante = 0;
    float humedadAnterior = 0;
    float humedad=0;
    [SerializeField] int contadorHumedadAcabada = 0;

    [SerializeField] Interfaz_controller interfaz_Controller;
    float temperatura=0;
    float temperaturaAnterior =0;
    float temperaturaCambiante=0;

    [SerializeField] SliderRadiacion sliderRadiacion;
    float radiacion = 0;
    float radiacionAnterior=0;
    float radiacionCambiante = 0;

    [SerializeField] int contadorTemperaturaBaja=0; //variables para contar tiempo para la mision numero 1 (logica)
    float temperaturaBajaTimer =0; //variables para contar tiempo para la mision numero 1 (logica)
    float temperaturaBajaTimerMax = 0.5f; //variables para contar tiempo para la mision numero 1 (logica)

    [SerializeField] int contadorTemperaturaSube= 0; 
    float temperaturaSubeTimer = 0; 
    float temperaturaSubeTimerMax = 0.5f;

    //Timers
    float bajarTemperaturaTimer = 0;
    float subirRadiacionTimer = 0;
    float subirTemperaturaTimer = 0;

    //Misiones cumplidas gameobjects
    [SerializeField] GameObject mision1Cumplida;
    [SerializeField] GameObject mision2Cumplida;
    [SerializeField] GameObject mision3Cumplida;
    [SerializeField] GameObject mision4Cumplida;
    [SerializeField] GameObject mision5Cumplida;
    [SerializeField] GameObject mision6Cumplida;
    [SerializeField] GameObject mision7Cumplida;
    [SerializeField] GameObject mision8Cumplida;
    [SerializeField] GameObject mision9Cumplida;
    
    public int contadorHidratacion = 0;

    [SerializeField] Button BtnContinuar;
    
    void Start()
    {
        BtnContinuar.interactable = false;
    }
    void AbrirCuadroMisiones()
    {
        estaAbierto = true;
    }
    void Update()
    {
        AbrirCuadroMisiones();
        if (estaAbierto == true)
        {
            ActualizarHumedad();
            ActualizarTemperatura();
            HumedadCambiante();
            TemperaturaCambiante();
            CriptobiosisDosVeces();
            BajaTempertauraTresVeces();
            CriptobiosisTresVeces();

            ActualizarRadicion();
            RadiacionCambiante();
            
            BajarLaTemperatura();
            AumentaRadiacionyTemperatura();
            DisminuyeRadiacionyTemperatura();
            PasoDeEvento();
        }
        else
        {
            estaAbierto = false;
        }
        Hidratar5Veces();
    }
    
    void ActualizarTemperatura()
    {
        temperatura = float.Parse(interfaz_Controller.estadisticaTemperatura.text);
        //Debug.Log("temperatura normal  " + temperatura);
    }
    void ActualizarHumedad()
    {
        humedad = float.Parse(Humedad.estaditicaHumedad.text);
        //Debug.Log("humedad normal  " + humedad);
    }
    void ActualizarRadicion()
    {
        radiacion = float.Parse(sliderRadiacion.estadisticaRadiacion.text);
        //Debug.Log("Radiacion normal  " + radiacion);
    }


    //Misiones Evento 2

    // 1. Tardi el Heladero
    void BajaTempertauraTresVeces() 
    {
        temperaturaBajaTimer += Time.deltaTime;
        if (temperatura <= -80 && temperaturaBajaTimer > temperaturaBajaTimerMax)
        {
            if (temperaturaCambiante != 0)
            {
                contadorTemperaturaBaja++;
                temperaturaBajaTimer = 0;
            }
        }
        if (contadorTemperaturaBaja == 3) mision1Cumplida.SetActive(true);
    }
    void TemperaturaCambiante()
    {
        temperaturaCambiante = temperatura - temperaturaAnterior;
        temperaturaAnterior = temperatura;
        //Debug.Log("cambio de temperatura " + temperaturaCambiante);
    }

    // 2. Lluvia
    void Hidratar5Veces() 
    {
        if (contadorHidratacion >= 5)
        {
            mision2Cumplida.SetActive(true);
        }
    }
    public void AgregarUnoContadorHidratar()
    {
        if (contadorHidratacion < 5)
        {
            contadorHidratacion++;
        }
    }

    // 3. Estado crítico
    void CriptobiosisDosVeces()  
    {
        criptobiosisTimer += Time.deltaTime;
        if (Humedad.humedad <= 1 && criptobiosisTimer > 0.5f)
        {
            if (humedadCambiante != 0)
            {
                contadorHumedadAcabada++;
                criptobiosisTimer = 0;
            }
        }
        if (contadorHumedadAcabada == 2) mision3Cumplida.SetActive(true);      
    }
    void HumedadCambiante()
    {
        humedadCambiante = humedad - humedadAnterior;
        humedadAnterior = humedad;
        //Debug.Log("cambio de temperatura " + temperaturaCambiante);
    }


    //Misiones evento 3

    // 4. Tropi-Tardigrado
    void CriptobiosisTresVeces()
    {
        criptobiosisTimer += Time.deltaTime;
        if (Humedad.humedad <= 1 && criptobiosisTimer > 0.5f)
        {
            if (humedadCambiante != 0)
            {
                contadorHumedadAcabada++;
                criptobiosisTimer = 0;
            }
        }
        if (contadorHumedadAcabada == 3) mision3Cumplida.SetActive(true);
    }

    // 5. Hidratación Controlada
    public void DetectarHidratacion40a50()
    {
        Debug.Log("se invoco funcion detectarHidartacion40a50");
        if(Humedad.humedad >= 40f && Humedad.humedad <= 50f) 
        {
            mision5Cumplida.SetActive(true);
        }   
    }

    // 6. ¿Frío? ¿En el Serengueti?
    void BajarLaTemperatura()
    {
        if (temperatura <= -80 && !mision6Cumplida.activeSelf)
        {
            bajarTemperaturaTimer += 1f*Time.deltaTime;
            if (bajarTemperaturaTimer > 3f)
            {
                mision6Cumplida.SetActive(true);
            }
        } 
    }


    //Misiones evento 4

    // 7. Experto en los elementos
    void RadiacionCambiante()
    {
        radiacionCambiante = radiacion - radiacionAnterior;
        radiacionAnterior = radiacion;
        Debug.Log("cambio de radiación " + radiacionCambiante);
    }
    void AumentaRadiacionyTemperatura()
    {
        if (radiacion >= 70 && temperatura >=99)
        {
            subirTemperaturaTimer += 1f * Time.deltaTime;
            subirRadiacionTimer += 1f * Time.deltaTime;
            if (subirTemperaturaTimer > 2f && subirRadiacionTimer> 2f)
            {
                mision7Cumplida.SetActive(true);
            }
        }
    }

    // 8. ¡Emergencia!
    public void RehidratarTradigrado()
    {
        if (Humedad.humedad <= 20f)
        {
            mision8Cumplida.SetActive(true);
        }
    }

    // 9. Invierno nuclear
    void DisminuyeRadiacionyTemperatura()
    {
        if (radiacion >= 99 && temperatura <= -80)
        {
            bajarTemperaturaTimer += 1f * Time.deltaTime;
            subirRadiacionTimer += 1f * Time.deltaTime;
            if (bajarTemperaturaTimer > 2f && subirRadiacionTimer > 2f)
            {
                mision9Cumplida.SetActive(true);
            }
        }
    }


    //Desbloqueo de botón de paso de escena cuando se completan las misiones
    void PasoDeEvento()
    {  //Evento 2
        if (mision1Cumplida.activeSelf==true && mision2Cumplida.activeSelf==true && mision3Cumplida.activeSelf == true)
        {
            BtnContinuar.interactable = true;
        }
        else
        {
            BtnContinuar.interactable = false;
        }
        //Evento 3
        if (mision3Cumplida.activeSelf == true && mision4Cumplida.activeSelf == true && mision5Cumplida.activeSelf == true)
        {
            BtnContinuar.interactable = true;
        }
        else
        {
            BtnContinuar.interactable = false;
        }
        //Evento 4
        if (mision6Cumplida.activeSelf == true && mision7Cumplida.activeSelf == true && mision8Cumplida.activeSelf == true)
        {
            BtnContinuar.interactable = true;
        }
        else
        {
            BtnContinuar.interactable = false;
        }
    }
  
}
