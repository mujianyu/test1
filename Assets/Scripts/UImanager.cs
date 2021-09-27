using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
                
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject dialogueBox;

    public Text characterNameText;
    public Text dialogueLineText;
    public GameObject spacebar;

    public void ToggleDialogueBox(bool isActive)
    {
        dialogueBox.gameObject.SetActive(isActive);
    }
    public void ToggleSpaceBar(bool isActive)
    {
        spacebar.gameObject.SetActive(isActive);
    }
    public void SetUpDialogue(string _name,string line,int _size)
    {
        characterNameText.text = _name;
        dialogueLineText.text = line;
        dialogueLineText.fontSize = _size;

        ToggleDialogueBox(true);
    }

}
