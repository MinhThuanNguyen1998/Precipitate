using System;
using UnityEngine;

public class PipetStateController : MonoBehaviour
{
    public static event Action OnFilled;
    public static event Action OnEmptied;
    public static event Action OnDropletSpawned;
    public static event Action<LiquidType> OnLiquidFilled;
    [SerializeField] private PipetTrigger m_PipetTrigger;
    private PipetState m_CurrentState;

    private LiquidType m_FilledLiquid;

    private void Start()
    {
        SetState(PipetState.Empty);
    }
    public void CheckStateWhenPipetClickButton()
    {
        if (m_CurrentState == PipetState.Empty && m_PipetTrigger.IsInTube)
        {
            TryFill();
            return;
        }
        if (m_CurrentState == PipetState.Filled)
        {
            TryRelease();
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
                //Debug.Log("Empty");
                OnEmptied?.Invoke();
                break;
            case PipetState.Filled:
                //Debug.Log("Filled");
                OnFilled?.Invoke();
                break;
        }
    }
    private void TryFill()
    {
        if (!m_PipetTrigger.IsInTube) return;
        m_FilledLiquid = m_PipetTrigger.FilledLiquidType;
        OnLiquidFilled?.Invoke(m_PipetTrigger.FilledLiquidType);
        Debug.Log("Filled: " + m_FilledLiquid);
        SetState(PipetState.Filled);
    }
    private void TryRelease()
    {
        OnDropletSpawned?.Invoke();
        SetState(PipetState.Empty);
    }
}
