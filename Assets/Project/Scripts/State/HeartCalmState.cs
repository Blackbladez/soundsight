using Assets.Project.Scripts.Model;
using Assets.Scripts.Singleton;

namespace Assets.Project.Scripts.State
{
    public class HeartCalmState : SKState<HeartModel>
    {
        public override void begin()
        {
            // when you're in this state set your heart health to 
            // 100
            Player.Instance.HeartHealth = 10;
            Player.Instance.Sensitivity = 3;
            Player.Instance.Rate = 1.0f;
        }

        public override void update(float deltaTime)
        {
            // something will trigger the transition of states 
            //_machine.changeState<HeartAlertState>();
            if (Player.Instance.State == "Alert") _machine.changeState<HeartAlertState>();
        }

        public override void end()
        {
        
        }
    }
}
