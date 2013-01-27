using Assets.Project.Scripts.Model;
using Assets.Scripts.Singleton;

namespace Assets.Project.Scripts.State
{
    public class HeartDangerState : SKState<HeartModel>
    {

        public override void begin()
        {
            // upon reaching this state your heart health decreases to 60
            Player.Instance.Sensitivity = 12;
            Player.Instance.Rate = 2.5f;
        }

        public override void update(float deltaTime)
        {
            // something will trigger the transition of states 
            //_machine.changeState<HeartPanicState>();

            // or back one state
            //_machine.changeState<HeartAlertState>();
            Common.Common.ChangeHeartState(Player.Instance.HeartHealth, _machine);
        }

        public override void end()
        {
        
        }
    }
}
