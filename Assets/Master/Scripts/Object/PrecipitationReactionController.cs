using System.Collections.Generic;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public class PrecipitationReactionController : MonoBehaviour
{
    [SerializeField] LiquidVolume m_LiquidVolumeAgNo3;
    [SerializeField] LiquidVolume m_LiquidVolumeNaCl;
    [SerializeField] Step_AgNo3_NaCl m_Step_AgNo3_NaCl;
    private float m_DefaultSparklingAmount = 0.3f;
    private float m_MaxValueSparklingAmount = 0.6f;
    private float m_PrecipitateDuration = 4f;
    private bool m_HasPrecipitated = false;
    private LiquidType? m_DropletLiquid = null;
    private LiquidType? m_FilledLiquid = null;
    private void OnEnable() 
    {
        DropletTrigger.OnLiquidDropletized += ReceiveDroplet;
        PipetStateController.OnLiquidFilled += ReceiveFilling;
    }
    private void OnDisable() 
    {
        DropletTrigger.OnLiquidDropletized -= ReceiveDroplet;
        PipetStateController.OnLiquidFilled -= ReceiveFilling;
    }
    private void ReceiveDroplet(LiquidType liquidType)
    {
        m_DropletLiquid = liquidType;
        TryReact();
    }
    private void ReceiveFilling(LiquidType liquidType)
    {
        if (m_HasPrecipitated) return;
        m_FilledLiquid = liquidType;
        m_Step_AgNo3_NaCl.GoToNextStep();
    }
    private void TryReact()
    {
        if (m_HasPrecipitated) return;
        if (m_DropletLiquid.Value != m_FilledLiquid.Value) Precipitate(m_DropletLiquid.Value);
    }
    private void Precipitate(LiquidType liquidType)
    {
        LiquidVolume targetLiquid =
            liquidType == LiquidType.AgNO3 ? m_LiquidVolumeAgNo3 :
            liquidType == LiquidType.NaCl ? m_LiquidVolumeNaCl :
            null;
        if (targetLiquid == null) return;
        DOTween.To(
            () => targetLiquid.sparklingAmount,
            x => targetLiquid.sparklingAmount = x,
            m_MaxValueSparklingAmount,
            m_PrecipitateDuration
        )
        .OnComplete(() =>
        {
            m_HasPrecipitated = true;
        });
    }
}
