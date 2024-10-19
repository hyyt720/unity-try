using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialoguebox : MonoBehaviour
{
    public GameObject dialoguebox; //�Ի���
    public Text dialoguetext; // �Ի��ı�
    public string text; //˵������

    private bool display = false; // �Ƿ���ʾ

    void Start()
    {
        display = false;
        dialoguebox.SetActive(display);
    }

    void Update()
    {
        // ����Ƿ�����F�������ҶԻ���ǰ����ʾ
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (display)
            {
                display = false;
            }
            else
            {
                dialoguetext.text = text;
                display = true; // ����displayΪtrue��׼����ʾ�Ի���
            }
        }
        dialoguebox.SetActive(display);
    }
}