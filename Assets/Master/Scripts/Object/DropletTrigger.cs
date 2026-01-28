using System;
using UnityEngine;

public class DropletTrigger : BaseTrigger
{
    public static event Action<LiquidType> OnLiquidDropletized;
    public LiquidType CurrentLiquid { get; private set; }
    protected override void OnEnter(Collider other)
    {
        if (IsOtherCollider(other))
        {
            var tubeLiquid = other.GetComponent<TubeLiquid>();
            CurrentLiquid = tubeLiquid != null ? tubeLiquid.LiquidType : LiquidType.None;
            Debug.Log("Pipet get current liquid is:" + CurrentLiquid);
            OnLiquidDropletized?.Invoke(CurrentLiquid);
        }
    }
    private bool IsOtherCollider(Collider other)
    {
        return other.gameObject.tag == "Tube";
    }
}
