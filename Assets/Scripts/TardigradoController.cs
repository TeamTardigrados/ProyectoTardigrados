using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradoController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    [SerializeField]
    Interfaz_controller interfazController;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Temperatura", interfazController.temperaturaActual);
    }
}
