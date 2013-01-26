using UnityEngine;
using System.Collections;

public class HeartAlertState : SKState<HeartModel>
{

    public override void begin()
    {
        // upon reaching this state your heart health decreases to 80
        _machine.context.HeartHealth = 80; 
    }

    public override void update(float deltaTime)
    {
        // something will trigger the transition of states 
        _machine.changeState<HeartAlertState>();

        // or back one state
        _machine.changeState<HeartCalmState>();
    }

    public override void end()
    {
        
    }
}
