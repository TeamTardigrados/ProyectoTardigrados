using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradoController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    [SerializeField]Interfaz_controller interfazController;
    [SerializeField] Humedad humedad;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        humedad.OnWaterEnd += Dried;
        humedad.OnGetWater += Hydrated;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Temperatura", interfazController.temperaturaActual);

    }

    void Dried()
    {
        anim.SetBool("isDried", true);
    }

    void Hydrated()
    {
        anim.SetBool("isDried", false);
    }

    private void OnDisable()
    {
        humedad.OnWaterEnd -= Dried;
        humedad.OnGetWater -= Hydrated;
    }
}
