using UnityEngine;
using System.Collections;
using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Tag.Pratik{
public class CarMovement : MonoBehaviour
{
        #region PUBLIC_VARS
        public float carSpeed;
        public Renderer groundPlan;
        public Transform cameraObject;
        public Vector3 cameraPositionBehindcar;
        #endregion

        #region PRIVATE_VARS
        private float cameraMoveSpeed;
        private float carRotationSpeed;
        #endregion

        #region UNITY_CALLBACKS
        private void Start()
        {
            cameraMoveSpeed = 1;
            carRotationSpeed = 1;
             carSpeed = 30;
        }
        //private void Update()
        //{
        //    MoveCar();
        //}
      


        #endregion

        #region PUBLIC_FUNCTIONS
        public void MoveCar()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * carSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += (-transform.forward) * carSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * carRotationSpeed );
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * carRotationSpeed);
            }
        }
        public void FollowCar()
        {
            cameraObject.LookAt(transform.position);
            Vector3 cameraBehindCar = transform.TransformPoint(cameraPositionBehindcar);
            cameraObject.position = Vector3.Lerp(cameraObject.position, cameraBehindCar, cameraMoveSpeed * Time.deltaTime);
        }

        public void GetInBoundry()
        {
            float maxRediousOfCircle = FindMaxRadiousOfCircleOnPlane();
            transform.position = Vector3.ClampMagnitude(transform.position, maxRediousOfCircle);
        }
    
        private float FindMaxRadiousOfCircleOnPlane()
        {
           return Mathf.Min(groundPlan.bounds.size.x,groundPlan.bounds.size.z)/2;   // groundPlan.bounds.size.z -->find the length of the plane
            
        }
        #endregion

        #region PRIVATE_FUNCTIONS
        #endregion

        #region CO-ROUTINES
        #endregion

        #region EVENT_HANDLERS
        #endregion

        #region UI_CALLBACKS
        #endregion
    }
}