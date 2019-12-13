using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 1f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    [SerializeField] float padding = 1f;
    public float playerRotationX = 0;
    public float playerRotationY = 0;
    public float playerRotaionZ = 0;

    public float tilt;
    Rigidbody _rb;
    public bool canMove = true;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.Log("Ei löydy rigidbodia. Lisää tälle se asap. " + this.name);
        }

        //transform.Rotate(new Vector3(playerRotationX, playerRotationY, playerRotaionZ));
        transform.eulerAngles = new Vector3(playerRotationX, playerRotationY, playerRotaionZ);
        SetUpBoundaries();
    }

    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        else
        {
            Move();
        }
        #region old move design
        /* Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
         pos.x = Mathf.Clamp(pos.x, 0.07f, 0.93f);
         pos.y = Mathf.Clamp01(pos.y);
         pos.z = Mathf.Clamp(pos.z, 43f, 43.01f);
         //pos.y = Mathf.Clamp(0.07f, pos.y, 0.093f);
         transform.position = Camera.main.ViewportToWorldPoint(pos);*/
        #endregion
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    # region old move design
        /*if(canMove) 
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(verticalMove, horizontalMove, 0);

            _rb.velocity = movement * speed;

            transform.position += new Vector3(horizontalMove, verticalMove, 0);

            _rb.rotation = Quaternion.Euler(_rb.velocity.x * tilt, playerRotationY, _rb.velocity.y * -tilt);
        }
        */
#endregion
    }
   
    private void Move()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalMove, horizontalMove, 0);

        _rb.velocity = movement * speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x+horizontalMove,xMin,xMax), Mathf.Clamp(transform.position.y + verticalMove,yMin, yMax), 0);

        _rb.rotation = Quaternion.Euler(_rb.velocity.x * tilt, playerRotationY, _rb.velocity.y * -tilt);
        /*
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        //rotation test
        transform.position = new Vector2(newXPos, newYPos);
        transform.rotation = Quaternion.Euler(deltaY * tilt, deltaX * playerRotationY, playerRotaionZ);
        _rb.rotation = Quaternion.Euler(_rb.velocity.x * tilt, playerRotationY, _rb.velocity.y * -tilt);
        */
    }

    public void DisableControls(bool move)
    {
        canMove = move;
    }
}
