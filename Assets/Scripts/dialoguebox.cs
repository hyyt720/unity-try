using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialoguebox : MonoBehaviour
{
    public GameObject dialoguebox; //对话框
    public Text dialoguetext; // 对话文本
    public string text; //说话内容

    private bool display = false; // 是否显示

    void Start()
    {
        display = false;
        dialoguebox.SetActive(display);
    }

    void Update()
    {
        // 检查是否按下了F键，并且对话框当前不显示
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (display)
            {
                display = false;
            }
            else
            {
                dialoguetext.text = text;
                display = true; // 设置display为true，准备显示对话框
            }
        }
        dialoguebox.SetActive(display);
    }
}