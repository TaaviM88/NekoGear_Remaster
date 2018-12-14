using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 1f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float tilt;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.Log("Ei löydy rigidbodia. Lisää tälle se asap. " + this.name);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalMove, horizontalMove, 0);

        _rb.velocity = movement * speed;

        transform.position += new Vector3(horizontalMove, verticalMove, 0);

        _rb.rotation = Quaternion.Euler(_rb.velocity.x * -tilt,90, _rb.velocity.y * -tilt);
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.07f, 0.93f);
        pos.y = Mathf.Clamp01(pos.y);
        //pos.y = Mathf.Clamp(0.07f, pos.y, 0.093f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

}
