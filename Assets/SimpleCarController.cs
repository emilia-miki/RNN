using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class SimpleCarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private bool firstLaunch = true;
        
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Tab) || firstLaunch)
        {
            firstLaunch = false;
            GameObject car = GameObject.FindWithTag("car");
            string[] attributes = System.IO.File.ReadAllLines("car.cfg");
            
            string[] values;
            print("Attributes updated");
            
            foreach (string attr in attributes)
            {
                values = attr.Split('=');
                if (values[0].StartsWith("wheel"))
                {
                    GameObject[] wheels = GameObject.FindGameObjectsWithTag("wheel");
                    switch(values[0])
                    {
                        case "wheelMass":
                            foreach (GameObject wh in wheels)
                            {
                                wh.GetComponent<WheelCollider>().mass = float.Parse(values[1]);
                            }
                            break;
                        case "wheelRadius":
                            foreach (GameObject wh in wheels)
                            {
                                wh.GetComponent<WheelCollider>().radius = float.Parse(values[1]);
                            }
                            break;
                        case "wheelDampingRate":
                            foreach (GameObject wh in wheels)
                            {
                                wh.GetComponent<WheelCollider>().wheelDampingRate = float.Parse(values[1]);
                            }
                            break;
                        case "wheelSuspensionDistance":
                            foreach (GameObject wh in wheels)
                            {
                                wh.GetComponent<WheelCollider>().suspensionDistance = float.Parse(values[1]);
                            }
                            break;
                        case "wheelForceAppPointDistance":
                            foreach (GameObject wh in wheels)
                            {
                                wh.GetComponent<WheelCollider>().forceAppPointDistance = float.Parse(values[1]);
                            }
                            break;
                        case "wheelSpring":
                            foreach (GameObject wh in wheels)
                            {
                                JointSpring spr = wh.GetComponent<WheelCollider>().suspensionSpring;
                                spr.spring = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().suspensionSpring = spr;
                            }
                            break;
                        case "wheelDamper":
                            foreach (GameObject wh in wheels)
                            {
                                JointSpring spr = wh.GetComponent<WheelCollider>().suspensionSpring;
                                spr.damper = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().suspensionSpring = spr;
                            }
                            break;
                        case "wheelTargetPosition":
                            foreach (GameObject wh in wheels)
                            {
                                JointSpring spr = wh.GetComponent<WheelCollider>().suspensionSpring;
                                spr.targetPosition = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().suspensionSpring = spr;
                            }
                            break;
                        case "wheelForwardExtremumSlip":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve ff = wh.GetComponent<WheelCollider>().forwardFriction;
                                ff.extremumSlip = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().forwardFriction = ff;
                            }
                            break;
                        case "wheelForwardExtremumValue":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve ff = wh.GetComponent<WheelCollider>().forwardFriction;
                                ff.extremumValue = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().forwardFriction = ff;
                            }
                            break;
                        case "wheelForwardAsimptoteSlip":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve ff = wh.GetComponent<WheelCollider>().forwardFriction;
                                ff.asymptoteSlip = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().forwardFriction = ff;
                            }
                            break;
                        case "wheelForwardAsimptoteValue":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve ff = wh.GetComponent<WheelCollider>().forwardFriction;
                                ff.asymptoteValue = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().forwardFriction = ff;
                            }
                            break;
                        case "wheelForwardStiffness":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve ff = wh.GetComponent<WheelCollider>().forwardFriction;
                                ff.stiffness = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().forwardFriction = ff;
                            }
                            break;
                        case "wheelSidewaysExtremumSlip":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve sf = wh.GetComponent<WheelCollider>().sidewaysFriction;
                                sf.extremumSlip = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().sidewaysFriction = sf;
                            }
                            break;
                        case "wheelSidewaysExtremumValue":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve sf = wh.GetComponent<WheelCollider>().sidewaysFriction;
                                sf.extremumValue = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().sidewaysFriction = sf;
                            }
                            break;
                        case "wheelSidewaysAsimptoteSlip":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve sf = wh.GetComponent<WheelCollider>().sidewaysFriction;
                                sf.asymptoteSlip = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().sidewaysFriction = sf;
                            }
                            break;
                        case "wheelSidewaysAsimptoteValue":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve sf = wh.GetComponent<WheelCollider>().sidewaysFriction;
                                sf.asymptoteValue = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().sidewaysFriction = sf;
                            }
                            break;
                        case "wheelSidewaysStiffness":
                            foreach (GameObject wh in wheels)
                            {
                                WheelFrictionCurve sf = wh.GetComponent<WheelCollider>().sidewaysFriction;
                                sf.stiffness = float.Parse(values[1]);
                                wh.GetComponent<WheelCollider>().sidewaysFriction = sf;
                            }
                            break;
                    }
                    
                    continue;
                }
                switch(values[0])
                {
                    case "motorTorque":
                        maxMotorTorque = float.Parse(values[1]);
                        break;
                    case "steeringAngle":
                        maxSteeringAngle = float.Parse(values[1]);
                        break;
                    case "mass":
                        car.GetComponent<Rigidbody>().mass = float.Parse(values[1]);
                        break;
                    case "drag":
                        car.GetComponent<Rigidbody>().drag = float.Parse(values[1]);
                        break;
                    case "angularDrag":
                        car.GetComponent<Rigidbody>().angularDrag = float.Parse(values[1]);
                        break;    
                }
            }
        }
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}