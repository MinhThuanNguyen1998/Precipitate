using System;
using UnityEngine;

public class Step_CuSO4_NaOH : StepBase
{
    private void OnEnable()
    {
        TotalSteps = 2;
        StartStep();
    }   
    protected override void ExecuteCurrentStep()
    {
        //Debug.Log("Step step: " + CurretSteps);
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("CuSO4_NaOH step 0 : Use a dropper to take a small amount of the prepared");
                StepTutorialManager.Instance.GotoState(6);
                break;
            case 1:
                Debug.Log("CuSO4_NaOH: Review reaction ");
                StepTutorialManager.Instance.GotoState(7);
                break;

        }
    }
}
