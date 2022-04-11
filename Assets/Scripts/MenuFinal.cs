using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFinal : MonoBehaviour
{
    //Por ahora lo mandare a la escena 1 , ya que no sé en dónde ponerlo D:
    public void BotonReinicio ()
    {
        SceneManager.LoadScene(1);
    }

    public void BotonMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void BotonCreditos()
    {
        SceneManager.LoadScene(12);
    }

    public void BotonCreditosArte()
    {
        SceneManager.LoadScene(13);
    }
    public void BotonCreditosProg()
    {
        SceneManager.LoadScene(14);
    }

    public void BotonMenuFin()
    {
        SceneManager.LoadScene(11);
    }
}
