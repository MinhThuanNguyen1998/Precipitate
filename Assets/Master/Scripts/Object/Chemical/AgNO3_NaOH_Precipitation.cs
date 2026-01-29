using UnityEngine;

public class AgNO3_NaOH_Precipitation : BasePrecipitationReactionController
{
    [SerializeField] private Step_AgNO3_NaOH m_Step_AgNO3_NaOH;
    protected override void ReceiveFilling(LiquidType liquidType)
    {
        base.ReceiveFilling(liquidType);
        m_Step_AgNO3_NaOH.GoToNextStep();
    }
    protected override bool IsValidReaction(LiquidType droplet, LiquidType filled)
    {
        return (droplet == LiquidType.AgNO3 && filled == LiquidType.NaOH) || (droplet == LiquidType.NaOH && filled == LiquidType.AgNO3);    
    }
}
