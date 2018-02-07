using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public GameObject DialoguePanel;
    public Button ContinueButton;
    public Text DialogueText;
    public Text NameText;

    private string _npcName;
    private List<string> _dialogueLines = new List<string>();
    private int _dialogueIndex;

    private void Awake()
    {
        ContinueButton = DialoguePanel.transform.Find("Continue").GetComponent<Button>();
        DialogueText = DialoguePanel.transform.Find("Text").GetComponent<Text>();
        NameText = DialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        DialoguePanel.SetActive(false);
        ContinueButton.onClick.AddListener(ContinueDialogue);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        _dialogueIndex = 0;
        _dialogueLines = new List<string>();

        foreach (var line in lines)
        {
            _dialogueLines.Add(line);
        }

        _npcName = npcName;

        Debug.Log(_dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        DialogueText.text = _dialogueLines[_dialogueIndex];
        NameText.text = _npcName;

        DialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (_dialogueIndex < _dialogueLines.Count - 1)
        {
            _dialogueIndex++;

            DialogueText.text = _dialogueLines[_dialogueIndex];
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
    }
}