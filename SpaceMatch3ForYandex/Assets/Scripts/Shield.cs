using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [NonSerialized]
    public float shieldEnergy;
    [NonSerialized]
    public float shieldEnergyMax;
    private GameObject _gameObject;
    private Transform _transform;
    private Vector2 _position;

    [NonSerialized]
    public int shipIndex;

    public SpriteRenderer _spriteRendererOfShieldLine;
    [NonSerialized]
    public MaterialPropertyBlock matBlockOfShieldLineSprite;


    [NonSerialized]
    public GameObject ObjectPulled;
    [NonSerialized]
    public List<GameObject> ObjectPulledList;


    // Start is called before the first frame update
    void Start()
    {
        _gameObject = gameObject;
    }

    private void OnEnable()
    {
        if (matBlockOfShieldLineSprite == null) matBlockOfShieldLineSprite = new MaterialPropertyBlock();
        if (_transform == null) _transform = transform;
        _position = _transform.position;
    }

    public void reduceShield(float value)
    {
        shieldEnergy -= value;
        if (shieldEnergy < 0) shieldEnergy = 0;
        updateShieldLine();
        if (shieldEnergy == 0) disactivateShield();
    }

    public void updateShieldLine()
    {
        _spriteRendererOfShieldLine.GetPropertyBlock(matBlockOfShieldLineSprite);
        matBlockOfShieldLineSprite.SetFloat("_Fill", shieldEnergy / shieldEnergyMax);
        _spriteRendererOfShieldLine.SetPropertyBlock(matBlockOfShieldLineSprite);
    }

    public void disactivateShield()
    {
        makeBurst();
        _gameObject.SetActive(false);
    }

    public void makeBurst()
    {
        ObjectPulledList = ObjectPuller.current.GetShieldBurstList(shipIndex);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = _position;
        ObjectPulled.SetActive(true);
    }

}
