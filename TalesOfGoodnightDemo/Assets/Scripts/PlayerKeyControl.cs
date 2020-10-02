using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyControl : MonoBehaviour
{
    Animator anim;
    public Quaternion newrotation;
    [SerializeField] float smooth = 0.05f; // set rotation smoothness - which is kind of like rotation speed
    [SerializeField] float moveSpeed = 4f; // set character movement speed

    [SerializeField] Transform camera;


   
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Movement(v, h);
    }


    void Movement(float v, float h)
    {
        if (h != 0f || v != 0f)
        {
            Rotate(v, h);
            transform.Translate(new Vector3(h, 0f, v) * Time.deltaTime * moveSpeed, Space.World);
            anim.SetFloat("forwardSpeed", 0.1f);
        } else
        {
            anim.SetFloat("forwardSpeed", 0);
        }
    }

    void Rotate (float v, float h)
    {
        if (v > 0)
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 45, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 305, 0);
            }
            else
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y, 0);
            }
        }
        else if (v < 0)
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 135, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 225, 0);
            }
            else
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 180, 0);
            }
        }
        else
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 90, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, camera.eulerAngles.y + 270, 0);
            }
            else
            {
                newrotation = transform.rotation;
            }
        }

        newrotation.x = 0;
        newrotation.z = 0;
        //We only want player to rotate in y axis 
        transform.rotation = Quaternion.Slerp(transform.rotation, newrotation, smooth);
        //Slerp from player's current rotation to the new intended rotaion smoothly 
    }


}
