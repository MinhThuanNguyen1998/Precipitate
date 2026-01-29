using UnityEngine;

public class CuS04_NaOH_Precipitation : BasePrecipitationReactionController
{
    [SerializeField] private Step_CuSO4_NaOH m_Step_CuSO4_NaOH;
    protected override void ReceiveFilling(LiquidType liquidType)
    {
        base.ReceiveFilling(liquidType);
        m_Step_CuSO4_NaOH.GoToNextStep();
    }
    protected override bool IsValidReaction(LiquidType droplet, LiquidType filled)
    {
        return (droplet == LiquidType.CuSO4 && filled == LiquidType.NaOH) || (droplet == LiquidType.NaOH && filled == LiquidType.CuSO4);    
    }
}
