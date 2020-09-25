using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP
{
    public class CheckPointClass : MonoBehaviour
    {
        public int RequiredBall;
        public int NumberOfBall;

        public void AddBallToCheckPoint()
        {
            NumberOfBall += 1;
        }

        public void SetNumberOfRequiredBall(int number)
        {
            RequiredBall = number;
        }

        public bool CompareNumberOfBalls()
        {
            if (NumberOfBall >= RequiredBall)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
