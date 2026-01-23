using System;
using UnityEngine;

public class PipetController : MonoBehaviour
{
    public static event Action OnFilled;
    public static event Action OnEmptied;
    [SerializeField] private PipetTrigger m_PipetTrigger;
    public PipetState PipetState;
    private PipetState m_CurrentState;
    
    private void Start()
    {
        SetState(PipetState.Empty);
    }

    public void CheckStateWhenPipetClickButton()
    {
        if (m_CurrentState == PipetState.Empty && m_PipetTrigger.IsInTube)
        {
            Debug.Log(m_PipetTrigger.CurrentLiquid);
            SetState(PipetState.Filled);
            return;
        }
        if (m_CurrentState == PipetState.Filled)
        {
            SetState(PipetState.Empty);
            return;
        }
    }
    public void SetState(PipetState newState)
    {
        if (m_CurrentState == newState) return;
        m_CurrentState = newState;
        switch (m_CurrentState)
        {
            case PipetState.Empty:
                Debug.Log("Empty");
                OnEmptied?.Invoke();
                break;
            case PipetState.Filled:
                Debug.Log("Filled");
                OnFilled?.Invoke();
                break;
        }
    }
}
