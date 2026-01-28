using UnityEngine;

public class StepAtomicManager : MonoBehaviour
{
    [SerializeField] private Step_AgNo3_NaCl m_StepSolid;
    [SerializeField] private StepLiquid m_Liquid;
    [SerializeField] private StepGas m_StepGas;

    public void SetState(string state)
    {
        switch (state)
        {
            case Config.AgNO3_NaCl:
                m_StepSolid.StartStep();
                break;
        }
    }
}
