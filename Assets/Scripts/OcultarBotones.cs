using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcultarBotones : MonoBehaviour
{

    [SerializeField] private Button eventoBTN1;
    [SerializeField] private Button eventoBTN2;
    [SerializeField] private Button eventoBTN3;
    [SerializeField] private Button eventoBTN4;
    [SerializeField] private Button GoteroBTN;
    [SerializeField] private Slider sliderTemp;
    [SerializeField] private Slider sliderRadi;

    void Start()
    {
        eventoBTN1.enabled = false;
        eventoBTN2.enabled = false;
        eventoBTN3.enabled = false;
        eventoBTN4.enabled = false;
        GoteroBTN.enabled = false;
        sliderTemp.enabled= false;
        sliderRadi.enabled = false;
    }
}
