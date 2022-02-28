using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private GameObject m_Button;
    public static Action<int> TextCallback;
    public static Action<bool> ButtonCallback;
    
    private void OnEnable()
    {
        TextCallback += ShowText;
        ButtonCallback += ShowRestartButton;
    }
    private void ShowText(int text)
    {
        m_Text.text = (int.Parse(m_Text.text) + text).ToString();
    }

    private void ShowRestartButton(bool b)
    {
        m_Button.SetActive(b);
    }
    private void OnDisable()
    {
        TextCallback -= ShowText;
        ButtonCallback -= ShowRestartButton;
    }
}
