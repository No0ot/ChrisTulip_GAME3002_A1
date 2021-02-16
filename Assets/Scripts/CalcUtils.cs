using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CalculationTools
{
    public class CalcUtils
    {
      public static float GetRotationAngle(Vector3 target, Vector3 pos)
        {
            if(target != Vector3.zero)
            {
                float val = GetLookAtValue(target, pos);

                val *= Mathf.Rad2Deg;
                return val;
            }
            return 0.0f;
        }

        public static float GetLookAtValue(Vector3 target, Vector3 pos)
        {
            Vector3 TargetDir = (target - pos);

            float DotResult = Vector3.Dot(target, Vector3.forward);

            return Mathf.Acos((DotResult) / (target.magnitude * Vector3.forward.magnitude)) *  Mathf.Sin(target.x);
        }

        public static Quaternion RotateTowardsTarget(Vector3 target, Vector3 pos)
        {
            return Quaternion.Euler(0f, GetRotationAngle(target, pos), 0f);
        }

        public static Quaternion UpdateProjectileFacingRotation(Vector3 target, Vector3 pos)
        {
            return RotateTowardsTarget(target, pos);
        }
    }
}

