using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [NonSerialized]
    public float HP;
    [NonSerialized]
    public float HPMax;
    [NonSerialized]
    public float energy;
    [NonSerialized]
    public float energyMax;
    [NonSerialized]
    public float shotEnergy;
    [NonSerialized]
    public float shotEnergyMax;
    [NonSerialized]
    public float shotPower;
    [NonSerialized]
    public GameObject _gameObject;
    [NonSerialized]
    public Transform _transform;
    [NonSerialized]
    public Vector2 shipPosition;
    [NonSerialized]
    public float shieldEnergyMax;
    [NonSerialized]
    public float shieldCumulation;
    [NonSerialized]
    public int aimingCount;


    [NonSerialized]
    public float minShotTime;
    [NonSerialized]
    public float maxShotTime;

    [NonSerialized]
    public Vector2 attackDirection;

    [NonSerialized]
    public GameObject ObjectPulled;
    [NonSerialized]
    public List<GameObject> ObjectPulledList;

    [NonSerialized]
    public float accuracy;
    [NonSerialized]
    public float shotImpulse;

    public GameObject shield;
    public Shield shieldClass;

    public GameObject aimingObj;
    public GameObject preBursteffec;
    public ParticleSystem shotEffect;

    public SpriteRenderer _spriteRendererOfLifeLine;
    [NonSerialized]
    public MaterialPropertyBlock matBlockOfLifeLineSprite;

    public SpriteRenderer _spriteRendererOfShieldLine;
    [NonSerialized]
    public MaterialPropertyBlock matBlockOfShieldLineSprite;

    public SpriteRenderer _spriteRendererOfEnergyLine;
    [NonSerialized]
    public MaterialPropertyBlock matBlockOfEnergyLineSprite;

    public SpriteRenderer _spriteRendererOfShotLine;
    [NonSerialized]
    public MaterialPropertyBlock matBlockOfShotLineSprite;

    [NonSerialized]
    public Transform bulletTransform;
    [NonSerialized]
    public Vector2 bulletRotateBase;

    [NonSerialized]
    public bool shotingCoroutineIsOn;
    [NonSerialized]
    public bool actionsAreOn;

    public int indexOfShip;

    [NonSerialized]
    public float HPAddValue;
    [NonSerialized]
    public float ShieldAddValue;
    [NonSerialized]
    public float energyAddValue;
    [NonSerialized]
    public float shotAddValue;


    public virtual void StartSettings() {
        if (_gameObject == null) _gameObject = gameObject;
        if (_transform == null) _transform = _gameObject.transform;
        if (matBlockOfLifeLineSprite == null) matBlockOfLifeLineSprite = new MaterialPropertyBlock();
        if (matBlockOfShieldLineSprite == null) matBlockOfShieldLineSprite = new MaterialPropertyBlock();
        if (matBlockOfEnergyLineSprite == null) matBlockOfEnergyLineSprite = new MaterialPropertyBlock();
        if (matBlockOfShotLineSprite == null) matBlockOfShotLineSprite = new MaterialPropertyBlock();
        shipPosition = (Vector2)_transform.position;
        addToFleetManager();
        shieldCumulation = 0;
        shotEnergy = 0;
        bulletRotateBase = new Vector2(shipPosition.x, shipPosition.y + 1) - shipPosition;
        aimingCount = 0;
        aimingObj.SetActive(false);
        preBursteffec.SetActive(false);
        shotingCoroutineIsOn = false;
        actionsAreOn = false;
        HPAddValue = 0.2f;
        ShieldAddValue = 0.3f; //uses energy
        energyAddValue = 1;
        shotAddValue = 1;
    }



    public virtual void addToFleetManager() {

    }
    public virtual void removeFromFleetManager()
    {

    }

    public void updateLifeLine()
    {
        _spriteRendererOfLifeLine.GetPropertyBlock(matBlockOfLifeLineSprite);
        matBlockOfLifeLineSprite.SetFloat("_Fill", HP / HPMax);
        _spriteRendererOfLifeLine.SetPropertyBlock(matBlockOfLifeLineSprite);
    }
    public void updateShieldLine()
    {
        _spriteRendererOfShieldLine.GetPropertyBlock(matBlockOfShieldLineSprite);
        matBlockOfShieldLineSprite.SetFloat("_Fill", shieldCumulation / shieldEnergyMax);
        _spriteRendererOfShieldLine.SetPropertyBlock(matBlockOfShieldLineSprite);
    }
    public void updateEnergyLine()
    {
        _spriteRendererOfEnergyLine.GetPropertyBlock(matBlockOfEnergyLineSprite);
        matBlockOfEnergyLineSprite.SetFloat("_Fill", energy / energyMax);
        _spriteRendererOfEnergyLine.SetPropertyBlock(matBlockOfEnergyLineSprite);
    }

    public void updateShotLine()
    {
        _spriteRendererOfShotLine.GetPropertyBlock(matBlockOfShotLineSprite);
        matBlockOfShotLineSprite.SetFloat("_Fill", shotEnergy / shotEnergyMax);
        _spriteRendererOfShotLine.SetPropertyBlock(matBlockOfShotLineSprite);
    }

    public void reduceHP(float value) {
        HP -= value;
        updateLifeLine();
        if (HP < 0) HP = 0;
        if (HP == 0) disactivateShip();
        if (!preBursteffec.activeInHierarchy && HP <= HPMax * 0.3f) preBursteffec.SetActive(true);
    }

    public void consumeEnergy(float value) {
        energy -= value;
        updateEnergyLine();
    }

    public void increaseEnergy()
    {
        energy+=energyAddValue;
        if (energy > energyMax) energy = energyMax;
        updateEnergyLine();
    }

    public void disactivateShip()
    {
        removeFromFleetManager();
        makeBurst();
        CameraManager.Instance.shakeCamera();
        AudioManager.Instance.explosionPlay();
        _gameObject.SetActive(false);
    }

    public void makeBurst()
    {
        ObjectPulledList = ObjectPuller.current.GetShipBurstList(indexOfShip);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = _transform.position;
        ObjectPulled.SetActive(true);
    }

    public virtual bool canShot() {
        return false;
    }

    public virtual void makeShot()
    {
        shotEffect.Play();
        AudioManager.Instance.shotSoundPlay(indexOfShip);
        if (canShot())
        {
            shotingCoroutineIsOn = true;
            StartCoroutine(makeExtraShot());
        }
        if (aimingCount>0) aimingCount--;
        if (aimingObj.activeInHierarchy && aimingCount<=0) aimingObj.SetActive(false);
        updateShotLine();
        if (!shotingCoroutineIsOn) {
            actionsAreOn = false;
        }
    }
    public IEnumerator makeExtraShot()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minShotTime, maxShotTime));
        shotingCoroutineIsOn = false;
        if (canShot()) makeShot();
        else actionsAreOn = false;
    }

    public void checkActions() {
        if (canShot())
        {
            makeShot();
        }
        if (shieldCumulation >= shieldEnergyMax && shieldEnergyMax <= energy) activatePowerShiled(); //power shield activation is less important then shot
        //GameManager.instance.checkAllShipsIfActionIsFinished();
    }

    public void cumulateShiled() {
        //no shield mode is necessary to off the shiled to speed up battle finish in case if there left less than or equal 4 ships from each side
        if (!GameManager.instance.noShieldsMode)
        {
            if (!shield.activeInHierarchy) shieldCumulation += ShieldAddValue;
            updateShieldLine();
        }
    }

    public void activatePowerShiled() {
        shieldClass.shieldEnergy = shieldEnergyMax;
        shieldClass.shieldEnergyMax = shieldEnergyMax;
        shieldCumulation = 0;
        shieldClass.shipIndex = indexOfShip;
        consumeEnergy(shieldEnergyMax);
        shield.SetActive(true);
        shieldClass.updateShieldLine();
    }
    public void activatePowerShiledOnStart()
    {
        shieldClass.shieldEnergy = shieldEnergyMax;
        shieldClass.shieldEnergyMax = shieldEnergyMax;
        shield.SetActive(true);
        shieldClass.updateShieldLine();
    }

    //shield heal consumes energy as well
    public void healShield()
    {
        //no shield mode is necessary to off the shiled to speed up battle finish in case if there left less than or equal 4 ships from each side
        if (!GameManager.instance.noShieldsMode)
        {
            if (shieldClass.shieldEnergy < shieldEnergyMax && ShieldAddValue <= energy)
            {
                consumeEnergy(ShieldAddValue);
                shieldClass.shieldEnergy += ShieldAddValue;
                shieldClass.updateShieldLine();
            }
            if (shieldClass.shieldEnergy > shieldEnergyMax)
            {
                shieldClass.shieldEnergy = shieldEnergyMax;
                shieldClass.updateShieldLine();
            }
        }
    }

    public void healHP() {
        HP += HPAddValue; 
        if (HP > HPMax) HP = HPMax;
        if (preBursteffec.activeInHierarchy && HP > HPMax * 0.3f) preBursteffec.SetActive(false);
        updateLifeLine();
    }


    public void increaseShotPower() {
        shotEnergy+= shotAddValue;
        if (shotEnergyMax < shotEnergy) shotEnergy = shotEnergyMax;

        updateShotLine();
    }

    public void increaseAimingCount()
    {
        aimingCount++;
        if (!aimingObj.activeInHierarchy) aimingObj.SetActive(true);    
    }

    //Rotates the attack vector to add some randomness
    public Vector2 RotateAttackVector(Vector2 attackDirection, float delta)
    {
        return new Vector2(
            attackDirection.x * Mathf.Cos(delta) - attackDirection.y * Mathf.Sin(delta),
            attackDirection.x * Mathf.Sin(delta) + attackDirection.y * Mathf.Cos(delta)
        );
    }

}
