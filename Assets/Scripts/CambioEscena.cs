using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    //public int numeroEscena;
    private Animator transitionAnimator;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {

    }
    public void Iniciar()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
        //SceneManager.LoadScene(numeroEscena);
    }
    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
