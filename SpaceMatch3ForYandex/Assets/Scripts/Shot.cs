using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [HideInInspector]
    public Transform _shotTransform;
    [HideInInspector]
    public Rigidbody2D _shotRigidBody2D;
    [HideInInspector]
    public GameObject _gameObject;
    //[HideInInspector]
    //public TrailRenderer _trailRenderer;
    [HideInInspector]
    public float _harm;

    [NonSerialized]
    public GameObject ObjectPulled;
    [NonSerialized]
    public SpriteRenderer _spriteRenderer;
    [NonSerialized]
    public float yBound;
    [NonSerialized]
    public List<GameObject> ObjectPulledList;

    [NonSerialized]
    public Vector2 contactPointOfCollider;

    private void Awake()
    {
        //_trailRenderer = gameObject.GetComponent<TrailRenderer>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        yBound = _spriteRenderer.bounds.size.y / 2;
    }

    //private void Start()
    //{
    //}

    private void OnEnable()
    {
        //_trailRenderer.Clear();
        if (_gameObject == null) _gameObject = gameObject;
        if (_shotTransform == null) _shotTransform = transform;
        if (_shotRigidBody2D == null) _shotRigidBody2D = GetComponent<Rigidbody2D>();
        GameManager.instance.addShot(this);
        contactPointOfCollider = Vector2.zero;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint = collision.contacts[0];
        contactPointOfCollider = contactPoint.point;
    }

    public void reduceHarm(float harm)
    {
        _harm -= harm;
        if (harm <= 0) disactivateShot(true);
    }

    public void disactivateShot(bool isCollided)
    {
        GameManager.instance.removeShot(this);
        if (isCollided) makeBurst();
        _gameObject.SetActive(false);

    }

    public void makeBurst()
    {
        ObjectPulledList = ObjectPuller.current.GetBulletBurstList();
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = contactPointOfCollider;
        ObjectPulled.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (_shotTransform.position.y > CommonData.Instance.vertScreenSize / 2 + 1 || _shotTransform.position.y < -2 
            || _shotTransform.position.x < CommonData.Instance.horisScreenSize / -2 - 1 || _shotTransform.position.x > CommonData.Instance.horisScreenSize / 2 + 1)
        {
            disactivateShot(false);
        }
    }
}
