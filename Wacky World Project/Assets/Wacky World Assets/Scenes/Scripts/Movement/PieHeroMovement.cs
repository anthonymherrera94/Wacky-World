using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieHeroMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    [SerializeField]
    Ability ability;

    //[SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(direction != Vector3.zero)
            transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0f);


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            ability.Use();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        
    }
}
