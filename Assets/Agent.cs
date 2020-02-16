using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	
	public Vector3 position;
	public Vector3 velocity;
	public float rotation;
    public JumpPoint jp = new JumpPoint();

	public Steering steering;
	public float maxSpeed;

    Vector3 inicialScale;
    public bool jump = false;
    public bool col = false;

    public Agent(){

        position = Vector3.zero;
        velocity = Vector3.zero;
        rotation = 0;
        jp = new JumpPoint();
        steering = null;
        maxSpeed = 0;
        jump = false;
        col = false;

    }

    void Start()
    {
        
        steering = new Steering();
        velocity = Vector3.zero;
        jump = false;
        inicialScale = transform.localScale;

    }

	void Update(){

        if (!jump && !col){
            // Update position and orientation
            velocity += steering.linear * Time.deltaTime;

            rotation += steering.angular * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + rotation * Time.deltaTime * Mathf.Rad2Deg);
            // Update velocity and rotation

            if (velocity.magnitude > maxSpeed){
                velocity.Normalize();
                velocity *= maxSpeed;

            }      
        }
        else{

            transform.position += velocity*Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+(velocity.z*Time.deltaTime));

            bool highEnough = transform.position.z-jp.landingPos.z > 0.1;

            if (highEnough){

                float distJumpPad = (transform.position - jp.pointPos).magnitude;
                float midPointJump = jp.deltaPos.magnitude/2;

                if (distJumpPad < midPointJump){

                    transform.localScale += new Vector3(transform.position.z*0.05f, transform.position.z*0.05f, 0);

                }
                else if (distJumpPad > 2*midPointJump) { 

                    transform.position = new Vector3(transform.position.x, transform.position.x, jp.landingPos.z);
                    velocity = new Vector3(velocity.x, velocity.y, 0f);
                    jump = false;
                    transform.localScale = inicialScale;

                }
                else{

                    transform.localScale -= new Vector3(transform.position.z*0.05f, transform.position.z*0.05f, 0);

                }

            }

        }  
        
	}


    public Quaternion newOrientation(Quaternion current, Vector3 velocity){
        // Make sure we have a velocity.
        if (velocity.magnitude > 0){
            // Calculate orientation from the velocity.
            return Quaternion.Euler(current.x,current.y,Mathf.Atan2(-velocity.x, velocity.y)*Mathf.Rad2Deg);
        } else {
            return current;
        }
    } 


}