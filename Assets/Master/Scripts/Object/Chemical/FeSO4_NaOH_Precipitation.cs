using UnityEngine;

public class FeS04_NaOH_Precipitation : BasePrecipitationReactionController
{
    [SerializeField] private Step_FeSO4_NaOH m_Step_FeSO4_NaOH;
    protected override void ReceiveFilling(LiquidType liquidType)
    {
        base.ReceiveFilling(liquidType);
        m_Step_FeSO4_NaOH.GoToNextStep();
    }
    protected override bool IsValidReaction(LiquidType droplet, LiquidType filled)
    {
        return (droplet == LiquidType.FeSO4 && filled == LiquidType.NaOH) || (droplet == LiquidType.NaOH && filled == LiquidType.FeSO4);    
    }
}
