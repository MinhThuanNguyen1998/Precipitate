using System.Collections.Generic;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public class Precipitation : MonoBehaviour
{
    [SerializeField] LiquidVolume m_LiquidVolumeAgNo3;
    [SerializeField] LiquidVolume m_LiquidVolumeNaCl;

    private float m_DefaultSparklingAmount = 0.3f;
    private float m_MaxValueSparklingAmount = 0.6f;
    private float m_PrecipitateDuration = 4f;

    private bool m_HasPrecipitated = false;
    private void OnEnable() => DropletTrigger.OnLiquidReacted += Precipitate;
    private void OnDisable() => DropletTrigger.OnLiquidReacted -= Precipitate;

    private void Precipitate(LiquidType liquidType)
    {
        if (m_HasPrecipitated) return;
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
