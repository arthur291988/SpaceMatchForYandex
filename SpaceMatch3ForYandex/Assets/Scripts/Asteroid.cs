using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    private GameObject _gameobject;
    private Transform _transform;
    private SpriteRenderer SpriteRenderer;

    private Vector2 moveDir;
    private Vector3 rotation;
    private float speed;
    private float rotationSpeed;
    private float scale;
    private int burstScale;
    private int spriteNumber;

    private GameObject ObjectPulled;
    private List<GameObject> ObjectPulledList;
    [SerializeField]
    private SpriteAtlas atlas;

    private float HP;
    private const float MaxHPSmall = 1f;
    private const float MaxHPMed =2f;


    private void OnEnable()
    {
        if (_gameobject == null) _gameobject = gameObject;
        if (_transform == null) _transform=transform;
        if (SpriteRenderer == null) SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        speed = UnityEngine.Random.Range(0.3f, 0.7f);
        rotationSpeed = UnityEngine.Random.Range(0, 2) > 0 ? UnityEngine.Random.Range(10, 40) : UnityEngine.Random.Range(-10, -40);
        rotation = new Vector3(0, 0, rotationSpeed);
        scale = UnityEngine.Random.Range(0.1f,0.15f);
        moveDir =  Vector2.right;
        _transform.localScale = new Vector2(scale, scale);
        burstScale = 0;
        HP = scale > 0.13f ? MaxHPMed : MaxHPSmall;
        spriteNumber = UnityEngine.Random.Range(1,4);
        SpriteRenderer.sprite = atlas.GetSprite(spriteNumber.ToString());
    }
    private void disactivateAsteroid(bool isBurst) {
        BackgroundManager.Instance.pullNewAsteroid();
        if (isBurst) {
            makeBurst();
        }
        _gameobject.SetActive(false);
    }

    public virtual void makeBurst()
    {
        ObjectPulledList = ObjectPuller.current.GetShipBurstList(burstScale); 
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = _transform.position;
        ObjectPulled.SetActive(true);
    }

    public void reduceHP(float value)
    {
        HP -= value;
        if (HP < 0) HP = 0;
        if (HP == 0) disactivateAsteroid(true);
    }

    public float getHP() {
        return HP;
    } 


    // Update is called once per frame
    void Update()
    {
        _transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        _transform.Rotate(rotation * Time.deltaTime, Space.World);

        if (_transform.position.x > CommonData.Instance.horisScreenSize / 2 + 1) {
            disactivateAsteroid(false); ;
        }
    }
}
