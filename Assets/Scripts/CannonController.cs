using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonController : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawnPoint;
    public GameObject pivotPoint;
    [SerializeField] private GameObject anglePivot;
    

    public float angle;
    public float projectilePower;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Capture Mouse Position
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = Camera.main.nearClipPlane + 1;
        //screenPos.y += 1000;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(screenPos) - pivotPoint.transform.position;


        // try

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        //Calculate the angle based on the mouse position
        angle = Vector3.Angle(pivotPoint.transform.position, mousePos);
        Debug.DrawRay(pivotPoint.transform.position, mousePos, Color.cyan);
        Debug.Log(angle);


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
