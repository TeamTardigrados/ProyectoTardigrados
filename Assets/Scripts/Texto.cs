using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    [SerializeField] private Button dialogueButton = null;
    [SerializeField] private GameObject dialoguePanel = null;
    [SerializeField] private TMP_Text dialogueText = null;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines = null;
    private float typingTime = 0.04f;
    private bool didDialogueStart = false;
    private int lineIndex = 0 ;

    private void Start()
    {
        dialogueButton.onClick.AddListener(HandleClick);
    }

    private void StartDialogue()
    {
        lineIndex = 0;
        StartCoroutine(ShowLine());
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
    }

    private void HandleClick()
    {
        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == dialogueLines[lineIndex])
        {
            NextDialogueLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
        }
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
