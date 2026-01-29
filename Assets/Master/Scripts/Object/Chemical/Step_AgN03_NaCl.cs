using System;
using UnityEngine;

public class Step_AgN03_NaCl : StepBase
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
                Debug.Log("AgNO3_NaCl step 0 : Use a dropper to take a small amount of the prepared");
                StepTutorialManager.Instance.GotoState(0);
                break;
            case 1:
                Debug.Log("AgNO3_NaCl: Review reaction ");
                StepTutorialManager.Instance.GotoState(1);
                break;

        }
    }
}
