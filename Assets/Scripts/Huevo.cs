using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huevo : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject recogerP = null;
    int Contador = 0;
    [SerializeField] Button BtnContinuar;
    void Start()
    {
        BtnContinuar.interactable = false;
    }
    private void OnMouseDown()
    {
            Contador++;

            switch (Contador)
            {
                case 1:
                    animator.SetTrigger("isOpen1");
                    break;

                case 2:
                    animator.SetTrigger("isOpen2");
                    break;

                case 3:
                    animator.SetTrigger("isOpen3");
                    StartCoroutine(WaitThenLoad());
                    BtnContinuar.interactable = true;
                    break;
            }
    }
   
    private IEnumerator WaitThenLoad()
    {
        yield return new WaitForSecondsRealtime(2f);
        recogerP.SetActive(true);
    }
}
