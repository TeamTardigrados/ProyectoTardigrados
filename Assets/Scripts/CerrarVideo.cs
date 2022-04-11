using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;
    public int numeroEscena;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void CheckOver(VideoPlayer vp)
    { 

        //gameObject.SetActive(false);
        SceneManager.LoadScene(numeroEscena);
    }
}


