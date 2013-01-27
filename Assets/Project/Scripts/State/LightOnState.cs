using Assets.Project.Scripts.Model;

namespace Assets.Project.Scripts.State
{
    public class LightOnState : SKState<LightModel>
    {
        public override void begin()
        {
            // set some modifier that the 
        }

        public override void update(float deltaTime)
        {
            // on some condition switch state
            _machine.changeState<LightOffState>();

            // or go back to on perhaps
            _machine.changeState<LightFlickerState>();
        }

        public override void end()
        {

        }
    }
}
