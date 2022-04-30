using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    [SerializeField] private Button dialogueButton = null;
    [SerializeField] private GameObject dialoguePanel = null;
    [SerializeField] private TMP_Text dialogueText = null;
    [SerializeField] private int lineIndex = 0;
    [SerializeField] private int lineTemp = 0;
    [SerializeField] private int charsToPlays = 0;
    [SerializeField] private float typingTime = 0f;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines = null;
    
    private bool didDialogueStart = false;
    private SoundManager soundManager;

    public int LineTemp { get => lineTemp; set => lineTemp = value; }

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void StartDialogue()
    {
        lineIndex = lineTemp;
        StartCoroutine(ShowLine());
        soundManager.SeleccionAudio(5, 0.5f);
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
    }

    public void HandleClick(bool isNext)
    {
        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == dialogueLines[lineIndex])
        {
            if (isNext) { NextDialogueLine(); }
            else { BackDialogueLine(); }
        }
        else
        {
            CloseDialogue();
        }
    }

    public void NextDialogueLine()
    {
        lineIndex++;
        soundManager.SeleccionAudio(5, 0.5f);
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            lineIndex = 0;
            StartCoroutine(ShowLine());
        }
    }
    
    public void BackDialogueLine()
    {
        lineIndex--;
        soundManager.SeleccionAudio(5, 0.5f);
        if (lineIndex >= 0)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            lineIndex = dialogueLines.Length-1 ;
            StartCoroutine(ShowLine());
        }
    }

    public void CloseDialogue()
    {
        lineTemp = lineIndex;
        StopAllCoroutines();
        soundManager.SeleccionAudio(5, 0.5f);
        dialogueText.text = dialogueLines[lineIndex];
        dialogueButton.interactable = true;
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        int charIndex = 0;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            if(charIndex % charsToPlays == 0)
            {
                soundManager.SeleccionAudio(6, 0.05f);
            }
            
            charIndex++;
            yield return new WaitForSeconds(typingTime);
        }
    }
}
