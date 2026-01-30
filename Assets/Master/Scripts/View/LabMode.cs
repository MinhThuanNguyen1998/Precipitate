using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class LabMode : MonoBehaviour
{
    public static event Action<int> OnGotoState;
    [SerializeField] private TMP_Dropdown m_DropDownStateOfMatter;
    [SerializeField] private ModelLoader m_ModelLoader;
    [SerializeField] private DocUI m_DocUI;
    private void OnEnable() 
    {
        m_DropDownStateOfMatter.onValueChanged.AddListener(OnStateChanged);  
    }
    private void OnDisable() 
    {
        m_DropDownStateOfMatter.onValueChanged.RemoveListener(OnStateChanged);
    } 
    private void OnStateChanged(int index)
    {
        string selectedState = m_DropDownStateOfMatter.options[index].text;
        Debug.Log($"[LabMode] Selected index: {index}");
        m_ModelLoader.LoadStateModel((LabState)index);
        m_DocUI.UpdateVoicePack(index);
        m_DocUI.UpdateDocument(index);
    }

}
