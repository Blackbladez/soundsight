using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Project.Scripts.Model;
using Assets.Project.Scripts.State;

namespace Assets.Project.Scripts.Common
{
    public static class Common
    {
        public static void ChangeHeartState(int HeartRate, SKStateMachine<HeartModel> Machine )
        {
            if (HeartRate <= 20)
            {
                Machine.changeState<HeartCalmState>();
            }
            else if (HeartRate <= 40)
            {
                Machine.changeState<HeartAlertState>();
            }
            else if (HeartRate <= 60)
            {
                Machine.changeState<HeartDangerState>();
            }
            else if (HeartRate <= 99)
            {
                Machine.changeState<HeartPanicState>();
            }
            else
            {
                //dead
            }
        }
    }


}
