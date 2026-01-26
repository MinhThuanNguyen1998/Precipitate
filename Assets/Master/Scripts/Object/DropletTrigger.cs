using System;
using UnityEngine;

public class DropletTrigger : BaseTrigger
{
    public static event Action<LiquidType> OnLiquidReacted;
    public LiquidType CurrentLiquid { get; private set; }
    protected override void OnEnter(Collider other)
    {
        if (IsOtherCollider(other))
        {
            var tubeLiquid = other.GetComponent<TubeLiquid>();
            CurrentLiquid = tubeLiquid != null ? tubeLiquid.LiquidType : LiquidType.None;
            Debug.Log("Pipet get current liquid is:" + CurrentLiquid);
            if(FilledLiquidType.Liquid != CurrentLiquid)
            {
                OnLiquidReacted?.Invoke(CurrentLiquid);
            }
        }
    }
    private bool IsOtherCollider(Collider other)
    {
        return other.gameObject.tag == "Tube";
    }
}
