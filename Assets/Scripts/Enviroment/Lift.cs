using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    SliderJoint2D sliderJoint2D;
    JointMotor2D motor;

    void Start()
    {
        sliderJoint2D = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            motor = sliderJoint2D.motor;

            motor.motorSpeed *= -1;

            sliderJoint2D.motor = motor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            motor = sliderJoint2D.motor;

            motor.motorSpeed *= -1;

            sliderJoint2D.motor = motor;
        }
    }
}
