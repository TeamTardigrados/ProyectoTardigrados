using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huevo : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject collectPiece = null;
    [SerializeField] private Texto dialoguePanel = null;
    [SerializeField] private Button btnContinue = null;
    [SerializeField] private float waitTimeBrokenEgg = 10f;

    private int counter = 0;

    void Start()
    {
        btnContinue.interactable = false;
    }
    private void OnMouseDown()
    {
            counter++;

            switch (counter)
            {
                case 1:
                    animator.SetTrigger("isOpen1");
                    dialoguePanel.CloseDialogue();
                    break;

                case 2:
                    animator.SetTrigger("isOpen2");
                    break;

                case 3:
                    animator.SetTrigger("isOpen3");
                    StartCoroutine(WaitThenLoad());
                    btnContinue.interactable = true;
                    break;
            }
    }
   
    private IEnumerator WaitThenLoad()
    {
        yield return new WaitForSecondsRealtime(waitTimeBrokenEgg);
        collectPiece.SetActive(true);
        dialoguePanel.LineTemp = 2;
        dialoguePanel.StartDialogue();
    }
}
