using Assets.Project.Scripts.Model;

namespace Assets.Project.Scripts.State
{
    public class LightFlickerState : SKState<LightModel>
    {
        public override void begin()
        {
            // start an animation flicker dealy

        }

        public override void update(float deltaTime)
        {
            // on some condition switch state
            _machine.changeState<LightOffState>();

            // or go back to on perhaps
            _machine.changeState<LightOnState>();
        }

        public override void end()
        {
            
        }
    }
}
