using System.Collections.Generic;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public abstract class BasePrecipitationReactionController : MonoBehaviour
{
    [Header("Liquid Volumes")]
    [SerializeField] protected LiquidVolume m_LiquidVolumeA;
    [SerializeField] protected LiquidVolume m_LiquidVolumeB;

    [Header("Target Liquid Types")]
    [SerializeField] protected LiquidType m_TargetLiquidVolumeA;
    [SerializeField] protected LiquidType m_TargetLiquidVolumeB;

    [Header("Visual Config")]
    [SerializeField] protected float m_Alpha = 1f;
    [SerializeField] protected float m_DefaultSparklingAmount = 0.3f;
    [SerializeField] protected float m_MaxValueSparklingAmount = 0.6f;
    [SerializeField] protected float m_PrecipitateDuration = 4f;
    protected bool m_HasPrecipitated = false;
    protected LiquidType? m_DropletLiquid = null;
    protected LiquidType? m_FilledLiquid = null;
    protected virtual void OnEnable()
    {
        DropletTrigger.OnLiquidDropletized += ReceiveDroplet;
        PipetStateController.OnLiquidFilled += ReceiveFilling;
    }
    protected virtual void OnDisable()
    {
        DropletTrigger.OnLiquidDropletized -= ReceiveDroplet;
        PipetStateController.OnLiquidFilled -= ReceiveFilling;
    }
    protected virtual void ReceiveDroplet(LiquidType liquidType)
    {
        m_DropletLiquid = liquidType;
        TryReact();
    }
    protected virtual void ReceiveFilling(LiquidType liquidType)
    {
        if (m_HasPrecipitated) return;
        m_FilledLiquid = liquidType;
    }
    protected void TryReact()
    {
        if (m_HasPrecipitated) return;
        if (!m_DropletLiquid.HasValue || !m_FilledLiquid.HasValue) return;
        if (IsValidReaction(m_DropletLiquid.Value, m_FilledLiquid.Value)) Precipitate(m_DropletLiquid.Value);
    }
    protected abstract bool IsValidReaction(LiquidType droplet, LiquidType filled);
    protected virtual void Precipitate(LiquidType liquidType)
    {
        LiquidVolume targetLiquid = GetTargetLiquid(liquidType);
        if (targetLiquid == null) return;
        Sequence seq = DOTween.Sequence();
        seq.Join(
            DOTween.To(
                () => targetLiquid.sparklingAmount,
                x => targetLiquid.sparklingAmount = x,
                m_MaxValueSparklingAmount,
                m_PrecipitateDuration
            )
        );
        seq.Join(
            DOTween.To(
                () => targetLiquid.liquidColor1.a,
                x =>
                {
                    Color c = targetLiquid.liquidColor1;
                    c.a = x;
                    targetLiquid.liquidColor1 = c;
                },
                Mathf.Clamp01(m_Alpha),
                m_PrecipitateDuration
            )
        );
        seq.OnComplete(OnPrecipitationComplete);
    }
    protected virtual void OnPrecipitationComplete()  => m_HasPrecipitated = true;
    protected LiquidVolume GetTargetLiquid(LiquidType liquidType)
    {
        if (liquidType == m_TargetLiquidVolumeA) return m_LiquidVolumeA;
        if (liquidType == m_TargetLiquidVolumeB) return m_LiquidVolumeB;
        return null;
    }
}
