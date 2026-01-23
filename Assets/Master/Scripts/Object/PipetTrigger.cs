using UnityEngine;

public class PipetTrigger : BaseTrigger
{
    public bool IsInTube { get; private set; }
    public LiquidType CurrentLiquid { get; private set; }
    protected override void OnEnter(Collider other)
    {
        if (IsOtherCollider(other))
        {
            //Debug.Log("TriggerEnter");
            IsInTube = true;
            var tubeLiquid = other.GetComponent<TubeLiquid>();
            CurrentLiquid = tubeLiquid != null? tubeLiquid.LiquidType: LiquidType.None;
            
        }
    }
    protected override void OnExit(Collider other)
    {
        if (IsOtherCollider(other))
        {
            //Debug.Log("TriggerExit");
            IsInTube = false;
        }
    }
    private bool IsOtherCollider(Collider other)
    {
        return other.gameObject.tag == "Tube";
    }
}
