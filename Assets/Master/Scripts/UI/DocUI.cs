using System;
using System.Collections.Generic;
using Michsky.MUIP;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DocUI : MonoBehaviour
{
    [SerializeField] private Image m_DefaultSoundImage;
    [SerializeField] private Image m_PauseImage;
    [SerializeField] private Button m_SoundDocButton;
    [SerializeField] private AudioSource m_AudioSource;
     
    [SerializeField] private CustomDropdown m_DropDownVoice;
    [SerializeField] private ScrollRect m_ScrollRect;

    [SerializeField] private List<VoicePack> m_ListVoicePacks;
    [SerializeField] private List<GameObject> m_ListObjectDocuments; 
    private List<AudioClip> m_ListAudioClips = new();
    private bool isSoundOn = true;
    private void OnEnable() => ResetButtonDocState();
    private void Start()
    {
        m_SoundDocButton.onClick.AddListener(ToggleSoundIcon);
        if (m_DropDownVoice != null)m_DropDownVoice.onValueChanged.AddListener(OnChangeVoice);
        ResetButtonDocState();
        SyncUIDropDownList();
        UpdateVoicePack(0);
        UpdateDocument(0);
    }
    private void OnChangeVoice(int index) => VoiceDropDownList.CurrentVoiceIndex = index;
    private void SyncUIDropDownList()
    {
        m_DropDownVoice.selectedItemIndex = VoiceDropDownList.CurrentVoiceIndex;
        //m_DropDownVoice.SetupDropdown();
        m_DropDownVoice.SetDropdownIndex(m_DropDownVoice.selectedItemIndex);  
    }
    private void ToggleSoundIcon()
    {
        isSoundOn = !isSoundOn;
        if (!isSoundOn)
        {
            m_AudioSource.clip = m_ListAudioClips[VoiceDropDownList.CurrentVoiceIndex];
            m_AudioSource.Play();
        }
        else m_AudioSource.Pause();
        UpdateUI();
    }
    public void UpdateVoicePack(int index)
    {
        if (index < 0 || index >= m_ListVoicePacks.Count) return;
        var pack = m_ListVoicePacks[index];
        if (pack == null || pack.audioClips == null) return;
        m_ListAudioClips.Clear();
        m_ListAudioClips.AddRange(pack.audioClips);
    }
    public void UpdateDocument(int index)
    {
        if (index < 0 || index >= m_ListObjectDocuments.Count) return;
        for (int i = 0; i < m_ListObjectDocuments.Count; i++)
        {
            m_ListObjectDocuments[i].SetActive(i == index);
        }
    }
    private void UpdateUI()
    {
        m_DefaultSoundImage.gameObject.SetActive(isSoundOn);
        m_PauseImage.gameObject.SetActive(!isSoundOn);
    }
    private void ResetButtonDocState()
    {
        isSoundOn = true;
        UpdateUI();
        m_ScrollRect.verticalNormalizedPosition = 1f;
    }
}
