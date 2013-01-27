using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Project.Scripts.Model;

namespace Assets.Project.Scripts.State
{
    public class LightOffState : SKState<LightModel>
    {
        public override void begin()
        {
            // set some modifier that the 
        }

        public override void update(float deltaTime)
        {
            // on some condition switch state
            //_machine.changeState<LightFlickerState>();

            // or go back to on perhaps
            //_machine.changeState<LightOnState>();
        }

        public override void end()
        {

        }
    }
}
