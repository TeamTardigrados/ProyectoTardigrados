using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueoBotones : MonoBehaviour
{
    [SerializeField] private Button eventoBTN1;
    [SerializeField] private Button eventoBTN2;
    [SerializeField] private Button eventoBTN3;
    [SerializeField] private Button eventoBTN4;
    [SerializeField] private Button GoteroBTN;
    [SerializeField] private Slider sliderTemp;
    [SerializeField] private Slider sliderRadi;
   // [SerializeField] public Button SiguienteEventoBTN;
    void Start()
    {
        eventoBTN1.interactable = false;
        eventoBTN2.interactable = false;
        eventoBTN3.interactable = false;
        eventoBTN4.interactable = false;
        GoteroBTN.interactable = false;
        sliderTemp.interactable = false;
        sliderRadi.interactable = false;
        //SiguienteEventoBTN.interactable = false;
    }
}
