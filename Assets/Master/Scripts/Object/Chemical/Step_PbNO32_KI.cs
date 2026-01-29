using UnityEngine;

public class Step_PbNO32_KI : StepBase
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
                Debug.Log("Pb(NO3)2_KI step 0 : Use a dropper to take a small amount of the prepared");
                StepTutorialManager.Instance.GotoState(2);
                break;
            case 1:
                Debug.Log("Pb(NO3)2_KI: Review reaction ");
                StepTutorialManager.Instance.GotoState(3);
                break;

        }
    }
}
