using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalBoundry = 9.0f;
    public float verticalBoundry = 5.0f;
    public float tiltAngle = 30.0f;
    public float rotationSpeed = 10.0f;

    private Quaternion defaultRotation;


    private void Start()
    {
        defaultRotation = Quaternion.Euler(0, 0, 0);
    }


    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        

        transform.Translate(movement);

        float clampedX = Mathf.Clamp(transform.position.x, -horizontalBoundry, horizontalBoundry);
        float clampedY = Mathf.Clamp(transform.position.y, -verticalBoundry, verticalBoundry);
        transform.position = new Vector3(clampedX, clampedY, 0);

        Quaternion targetRotation = defaultRotation;

        if(verticalInput > 0)
        {
            targetRotation = Quaternion.Euler(-tiltAngle, 0, 0);

        }else if(verticalInput < 0)
        {

            targetRotation = Quaternion.Euler(tiltAngle, 0, 0);

        }

        // Aplicar rotación suave
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
