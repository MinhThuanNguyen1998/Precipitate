using System;
using UnityEngine;

public class Step_AgNo3_NaCl : StepBase
{
    private void OnEnable()
    {
        TotalSteps = 2;
        StartStep();
        Debug.Log("StepSolid");
    }   
    protected override void ExecuteCurrentStep()
    {
        //Debug.Log("Step step: " + CurretSteps);
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Solid step 0 : Use a dropper to take a small amount of the prepared");
                StepTutorialManager.Instance.GotoState(0);
                break;
            case 1:
                Debug.Log("Solid step 1: Review reaction ");
                StepTutorialManager.Instance.GotoState(1);
                break;
        }
    }
}
