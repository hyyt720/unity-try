using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialoguebox : MonoBehaviour
{
    public GameObject dialogueBox; //�Ի���
    public Text dialoguetext; // �Ի��ı�
    public string text; //˵������

    private bool display; // �Ƿ���ʾ

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
