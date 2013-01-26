using UnityEngine;
using System.Collections;

public class HeartDangerState : SKState<HeartModel>
{

    public override void begin()
    {
        // upon reaching this state your heart health decreases to 60
        _machine.context.HeartHealth = 60; 
    }

    public override void update(float deltaTime)
    {
        // something will trigger the transition of states 
        _machine.changeState<HeartPanicState>();

        // or back one state
        _machine.changeState<HeartAlertState>();
    }

    public override void end()
    {
        
    }
}
