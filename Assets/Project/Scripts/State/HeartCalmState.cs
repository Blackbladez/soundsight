using Assets.Scripts.Singleton;
using UnityEngine;
using System.Collections;

public class HeartCalmState : SKState<HeartModel>
{
    public override void begin()
    {
        // when you're in this state set your heart health to 
        // 100
        Player.Instance.HeartHealth = 10;
    }

    public override void update(float deltaTime)
    {
        // something will trigger the transition of states 
        _machine.changeState<HeartAlertState>();
    }

    public override void end()
    {
        
    }
}
