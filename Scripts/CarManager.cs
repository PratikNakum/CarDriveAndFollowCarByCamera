using UnityEngine;
using System.Collections;

namespace Tag.Pratik{
public class CarManager : MonoBehaviour
{
        #region PUBLIC_VARS
        public CarMovement[] car; 
        #endregion

        #region PRIVATE_VARS
        private int count = 1;
        private CarMovement curruntCar ;
        #endregion

        #region UNITY_CALLBACKS
        private void Start()
        {
            curruntCar = car[count];
        }
        private void Update()
        {
            ChangeCar();
            curruntCar.MoveCar();
        }
        private void LateUpdate()
        {
            curruntCar.FollowCar();
            curruntCar.GetInBoundry();
        }
        #endregion

        #region PUBLIC_FUNCTIONS
        #endregion

        #region PRIVATE_FUNCTIONS

        private void ChangeCar()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                curruntCar = car[count % car.Length];
                count++;
            }
        }

        #endregion

        #region CO-ROUTINES
        #endregion

        #region EVENT_HANDLERS
        #endregion

        #region UI_CALLBACKS
        #endregion
    }
}