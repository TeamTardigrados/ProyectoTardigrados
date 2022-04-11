using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarMisiones : MonoBehaviour
{
    [SerializeField] GameObject CuadroMisiones;
    [SerializeField] GameObject MissionHolder;
    bool activarCuadroMisiones = false;
    bool activarMissionHolder = false;


    public void AbrirOCerrarMisionest()
    {
        activarCuadroMisiones = !activarCuadroMisiones;
        CuadroMisiones.SetActive(activarCuadroMisiones);

        activarMissionHolder = !activarMissionHolder;
        MissionHolder.SetActive(activarMissionHolder);

    }
  
}
