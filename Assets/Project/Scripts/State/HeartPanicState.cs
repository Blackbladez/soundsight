using Assets.Project.Scripts.Model;
using Assets.Scripts.Singleton;

namespace Assets.Project.Scripts.State
{
    public class HeartPanicState : SKState<HeartModel>
    {

        public override void begin()
        {
            // upon reaching this state your heart health decreases to 60
            Player.Instance.Sensitivity = 20;
            Player.Instance.Rate = 3.0f;
        }

        public override void update(float deltaTime)
        {
            // slowly deterioate your heart health based on conditions

            // if this state ever transitions to another state
            //_machine.changeState<HeartDangerState>();
            Common.Common.ChangeHeartState(Player.Instance.HeartHealth, _machine);
        }

        public override void end()
        {
        

        }
    }
}
