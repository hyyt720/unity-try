using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialoguebox : MonoBehaviour
{
    public GameObject dialogueBox; //对话框
    public Text dialoguetext; // 对话文本
    public string text; //说话内容

    private bool display; // 是否显示

    void Start()
    {
        dialogueBox.SetActive(false);
        display = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            display = true;
        }
        if (display)
        {
            dialoguetext.text = text;
            dialogueBox.SetActive(true);
        }
    }
}
