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
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines = null;
    private float typingTime = 0.02f;
    private bool didDialogueStart = false;

    public int LineTemp { get => lineTemp; set => lineTemp = value; }

    private void Start()
    {
        //dialogueButton.onClick.AddListener(HandleClick);
    }

    public void StartDialogue()
    {
        lineIndex = lineTemp;
        StartCoroutine(ShowLine());
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
        dialogueText.text = dialogueLines[lineIndex];
        dialogueButton.interactable = true;
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }
}
