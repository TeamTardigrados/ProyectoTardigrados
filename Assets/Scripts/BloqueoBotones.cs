using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueoBotones : MonoBehaviour
{

    [SerializeField] private Button GoteroBTN;
    [SerializeField] private Slider sliderTemp;
    [SerializeField] private Slider sliderRadi;
    [SerializeField] public Button SiguienteEventoBTN;
    void Start()
    {
        GoteroBTN.interactable = false;
        sliderTemp.interactable = false;
        sliderRadi.interactable = false;
        SiguienteEventoBTN.interactable = false;
    }
}
