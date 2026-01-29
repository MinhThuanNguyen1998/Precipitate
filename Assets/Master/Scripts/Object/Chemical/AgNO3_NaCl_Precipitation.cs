using UnityEngine;

public class AgNO3_NaCl_Precipitation : BasePrecipitationReactionController
{
    [SerializeField] private Step_AgN03_NaCl m_Step_AgNo3_NaCl;
    protected override void ReceiveFilling(LiquidType liquidType)
    {
        base.ReceiveFilling(liquidType);
        m_Step_AgNo3_NaCl.GoToNextStep();
    }
    protected override bool IsValidReaction(LiquidType droplet, LiquidType filled)
    {
        return (droplet == LiquidType.AgNO3 && filled == LiquidType.NaCl) || (droplet == LiquidType.NaCl && filled == LiquidType.AgNO3);    
    }
}
