using System.Collections;
using LiquidVolumeFX;
using UnityEngine;

public class LiquidPipetVolumeController : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_LiquidVolume;
    private bool m_IsProcessing = false;
    private float m_DurationTime = 4f;
    private float m_MinLevelVolume = 0f;
    private float m_MaxLevelVolume = 0.5f;

    private void OnEnable()
    {
        PipetStateController.OnFilled += FillLiquid;
        PipetStateController.OnEmptied += DrainLiquid;
    }
    private void OnDisable()
    {
        PipetStateController.OnFilled -= FillLiquid;
        PipetStateController.OnEmptied -= DrainLiquid;
    }
    private void FillLiquid()
    {
        StartCoroutine(ChangeLiquidLevel(m_LiquidVolume, m_MaxLevelVolume, m_DurationTime));
    }
    private void DrainLiquid()
    {
        StartCoroutine(ChangeLiquidLevel(m_LiquidVolume, m_MinLevelVolume, m_DurationTime));
    }

    IEnumerator ChangeLiquidLevel(LiquidVolume liquid, float targetLevel, float duration)
    {
        m_IsProcessing = true;
        AudioMainManager.Instance.PlayOnShot(SoundType.Liquid);
        float start = liquid.level;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            liquid.level = Mathf.Lerp(start, targetLevel, t / duration);
            yield return null;
        }
        liquid.level = targetLevel;
        m_IsProcessing = false;
    }
}
