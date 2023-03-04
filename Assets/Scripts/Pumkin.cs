using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pumkin : MonoBehaviour
{
    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    private SpringJoint2D spring;
    private Transform catapult;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;
    private float maxStretchSqr;
    private float circleRadius;
    private bool clickedOn;
    private Vector2 prevVelocity;
    private Rigidbody2D rigidbody2d;
    private CircleCollider2D circle;

    public GameObject nextBall;
    private bool collided;

    public GameObject gameOverUi;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        catapult = spring.connectedBody.transform;
    }

    void Start()
    {
        LineRendererSetup();
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        circleRadius = circle.radius;
        rigidbody2d.isKinematic = true;
    }
    void Update()
    {
        //if (Input.touchCount >= 1)
        //{
        //    if (Input.touches[0].phase == TouchPhase.Began)
        //    {

        //        spring.enabled = false;
        //        clickedOn = true;
        //        rigidbody2d.isKinematic = true;
        //    }

        //    if (Input.touches[0].phase == TouchPhase.Ended)
        //    {
        //        Stats.pumkins--;
        //        spring.enabled = true;
        //        rigidbody2d.isKinematic = false;
        //        clickedOn = false;
        //    }
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    spring.enabled = false;
        //    clickedOn = true;
        //    rigidbody2d.isKinematic = true;
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    Stats.pumkins--;
        //    spring.enabled = true;
        //    rigidbody2d.isKinematic = false;
        //    clickedOn = false;
        //}

        if (clickedOn)
            Dragging();


        if (spring != null)
        {
            if (!rigidbody2d.isKinematic && prevVelocity.sqrMagnitude > rigidbody2d.velocity.sqrMagnitude)
            {
                Destroy(spring);
                rigidbody2d.velocity = prevVelocity;
            }
            if (!clickedOn)
                prevVelocity = rigidbody2d.velocity;

            if (!collided)
                catapultLineFront.enabled = true;
            catapultLineBack.enabled = true;

            LineRendererUpdate();

            return;
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
    }

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Foreground";
        catapultLineBack.sortingLayerName = "Foreground";

        catapultLineFront.sortingOrder = 4;
        catapultLineBack.sortingOrder = 1;
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
        rigidbody2d.isKinematic = true;
        GetComponent<AudioSource>().Play();
    }

    void OnMouseUp()
    {
        Stats.pumkins--;
        spring.enabled = true;
        rigidbody2d.isKinematic = false;
        clickedOn = false;
        GetComponent<AudioSource>().Stop();
    }

    void Dragging()
    {
        

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
        if (catapultToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }
        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + 0.48f);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        
        Destroy(gameObject);
        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            return;
        }
        return;
    }
}
