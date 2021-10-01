using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    public float speed;
   
    private float y;
    private float x;
    private int moving;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //mouseTarget();
    }

    void Move()
    {
        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");

        if(y != 0 || x != 0)
        {
            if (y > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, (45 * x), 0), Time.deltaTime * 15f);
            }
            else if(y < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180 + (-45 * x), 0), Time.deltaTime * 15f);
            }
            else if (x > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 15f);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 15f);
            }
            moving = 1;
            anim.SetInteger("transition", 1);
        }
        else
        {
            moving = 0;
            anim.SetInteger("transition", 0);
        }
   
        transform.Translate(0, 0, moving * Time.deltaTime * speed);
    }

    /*void mouseTarget()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out RaycastHit hit, 1000))
        {
            if (hit.rigidbody != GetComponent<Rigidbody>())
            {
                transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));
            }
        }
    }*/
}
