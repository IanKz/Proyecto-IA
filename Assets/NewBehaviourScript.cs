using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class CollisionDetector
{

    public Vector3 centralRay, sideRay1, sideRay2;
    public Vector3 centralRayEnd, sideRay1End, sideRay2End;
    float angleVariation = 40f;
    GameObject character = GameObject.Find("agent");
    float maxSpeed = 1;
    Vector3 velocity;
    
    public void GenerateRays()
    {
        float lookAhead = 15f;
        float lookSide = lookAhead/2f;

        //Define points
        Vector3 centralPoint = (character.transform.position) + (Vector3.up * lookAhead);
        Vector3 sidePoint = (character.transform.position) + Vector3.up * lookSide;

        //Define rays
        Vector3 sideRay = sidePoint - character.transform.position;
        centralRay = centralPoint - character.transform.position;
        sideRay1 = Quaternion.AngleAxis(-angleVariation, Vector3.forward) * sideRay;
        sideRay2 = Quaternion.AngleAxis(angleVariation, Vector3.forward) * sideRay;

    }

    public void RotateRays()
    {

    	velocity = new Vector3((float)-Math.Sin(character.transform.rotation.z/57), (float)Math.Cos(character.transform.rotation.z/57), 0);
    	velocity.Normalize();
        //Rotate rays in direction of character movement
        //First rotate the central ray
        centralRay = Vector3.RotateTowards(centralRay, velocity * centralRay.magnitude, maxSpeed * Time.deltaTime, 0f);

        //Rotate siderays 
        sideRay1 = Vector3.RotateTowards(sideRay1,  velocity* sideRay1.magnitude, maxSpeed * Time.deltaTime, 0f);
        sideRay2 = Vector3.RotateTowards(sideRay2, velocity* sideRay2.magnitude, maxSpeed * Time.deltaTime, 0f);
        Vector3 halfCentralRay = centralRay.normalized*(centralRay.magnitude* 0.5f);
        sideRay1 = Quaternion.AngleAxis(-angleVariation,Vector3.forward) * halfCentralRay;
        sideRay2 = Quaternion.AngleAxis(angleVariation, Vector3.forward) * halfCentralRay;

        centralRayEnd = centralRay + character.transform.position;
        sideRay1End = sideRay1 + character.transform.position;
        sideRay2End = sideRay2 + character.transform.position;

    }

    public bool LineIntersectsCircle(Vector3 rayStart, Vector3 rayEnd, Vector3 center, float radius)
    {
        return HandleUtility.DistancePointLine(center, rayStart, rayEnd)<=radius;
    }

    public Vector3 RayIntersects(Vector3 center, float radius)
    {
        //Calculates which ray is intersecting some obstacle
        if (LineIntersectsCircle(character.transform.position, centralRayEnd, center, radius))
        {
            //Debug.Log("c");
            return centralRayEnd;
        }

        if (LineIntersectsCircle(character.transform.position, sideRay1End, center, radius))
        {
            //Debug.Log("1");
            return sideRay1End;
        }

        if (LineIntersectsCircle(character.transform.position, sideRay2End, center, radius))
        {
            //Debug.Log("2");
            return sideRay2End;
        }

        return Vector3.positiveInfinity;
    }
    
}
