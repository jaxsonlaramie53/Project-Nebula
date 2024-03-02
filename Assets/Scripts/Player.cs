using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 180f;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            HandleShipAcceleration();
            HandleShipRotation();
        }
    }

    private void FixedUpdate() {
        if (isAlive && isAccelerating) {
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.velocity = Vector2.ClampMagnitude(shipRigidbody.velocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration() {
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
    }

    private void HandleShipRotation() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);
        }
    }

}
