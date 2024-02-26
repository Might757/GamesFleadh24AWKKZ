using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonController : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawnPoint;
    public GameObject pivotPoint;
    

    public float angle;
    public float projectilePower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Capture MOuse Position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pivotPoint.transform.position;

        //Calculate thr angle based on the mouse position
        angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;

        //update the platform rotation
        if (angle > -98 && angle < 98) 
        {
            pivotPoint.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
       
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Log a keyboard press
            Debug.Log("The spacebar has been pressed");

            //calculate velocity
            Vector2 velocity = new Vector2(
                projectilePower * Mathf.Sin(angle * Mathf.Deg2Rad),
                projectilePower * Mathf.Cos(angle * Mathf.Deg2Rad)
                );

            //Spawwn the projectile at spawn point
            GameObject spawnedProjectile = Instantiate(projectile,
                                           projectileSpawnPoint.transform.position,
                                           Quaternion.identity);

            //get access to the rigid body

            Rigidbody2D rb = spawnedProjectile.GetComponent<Rigidbody2D>();

            //apply the velocity to the rigid body
            rb.position = projectileSpawnPoint.transform.position;
            rb.velocity = velocity;

        }
        
    }
}
