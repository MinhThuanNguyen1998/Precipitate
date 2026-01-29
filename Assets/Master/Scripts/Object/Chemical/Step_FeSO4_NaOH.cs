using System;
using UnityEngine;

public class Step_FeSO4_NaOH : StepBase
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
                Debug.Log("FeSO4_NaOH step 0 : Use a dropper to take a small amount of the prepared");
                StepTutorialManager.Instance.GotoState(8);
                break;
            case 1:
                Debug.Log("FeSO4_NaOH: Review reaction ");
                StepTutorialManager.Instance.GotoState(9);
                break;

        }
    }
}
