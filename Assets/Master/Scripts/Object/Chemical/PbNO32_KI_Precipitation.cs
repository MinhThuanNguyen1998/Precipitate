using UnityEngine;

public class PbNO32_KI_Precipitation : BasePrecipitationReactionController
{
    [SerializeField] private Step_PbNO32_KI m_Step_PbNO32_KI;
    protected override void ReceiveFilling(LiquidType liquidType)
    {
        base.ReceiveFilling(liquidType);
        m_Step_PbNO32_KI.GoToNextStep();
    }
    protected override bool IsValidReaction(LiquidType droplet, LiquidType filled)
    {
        return (droplet == LiquidType.PbNO32 && filled == LiquidType.KI) || (droplet == LiquidType.KI && filled == LiquidType.PbNO32);    
    }
}
