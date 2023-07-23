using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherTile : MonoBehaviour
{
    //private static Tile selected; // 1 
    [NonSerialized]
    public Vector2 Position;
    [NonSerialized]
    public Vector2 MoveToShipPosition;
    [NonSerialized]
    public Vector2 MoveToBottomPosition;

    [NonSerialized]
    public Ship moveToShip;

    [NonSerialized]
    public Transform _transform;
    [NonSerialized]
    public GameObject _gameObject;
    [NonSerialized]
    public SpriteRenderer _spriteRenderer;

    [NonSerialized]
    public bool isMovingToShip;
    [NonSerialized]
    public bool isMovingToBottomOfScreen;

    [NonSerialized]
    public int spriteNumber;
    [NonSerialized]
    public int indexOfResource; //0-shot; 1-energy, 2-Shield, 3-HP

    [NonSerialized]
    public bool isControlTile;

    private float moveSpeed;
    private float moveSpeedToShip;

    [NonSerialized]
    public GameObject ObjectPulled;
    [NonSerialized]
    public List<GameObject> ObjectPulledList;

    private Vector3 rotationVector;

    [SerializeField]
    private TrailRenderer trailRenderer;           

    private void Start()
    {
        rotationVector = new Vector3 (0,0,UnityEngine.Random.Range(-1f, 1f));
    }

    private void OnEnable()
    {
        moveSpeed = 0.15f;
        moveSpeedToShip = 0.08f;
        if (_gameObject == null) _gameObject = gameObject;
    }

    public void setInitialCommand() {
        MoveToBottomPosition = new Vector2(UnityEngine.Random.Range(CommonData.Instance.horisScreenSize/2 - 0.5f, CommonData.Instance.horisScreenSize/-2 + 0.5f),
            CommonData.Instance.vertScreenSize / -2 + UnityEngine.Random.Range(0.5f, 1.5f));
        isMovingToBottomOfScreen = true;
    }

    private void disactivateTile() {
        moveToShip = null;
        GridManager.Instance.gatherTiles.Remove(this);
        makeBurst();
        trailRenderer.Clear();
        trailRenderer.enabled = false;
        _gameObject.SetActive(false);
    }

    private void makeBurst() {
        ObjectPulledList = ObjectPuller.current.GetBurstList(indexOfResource);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = _transform.position;
        ObjectPulled.SetActive(true);
    }

    public void setMoveToShipCommand(Vector2 moveToPos, Ship ship) {
        moveToShip = ship;
        MoveToShipPosition = moveToPos + (moveToPos - (Vector2)_transform.position).normalized;
        trailRenderer.enabled = true;
        Invoke("startMoveToShip", UnityEngine.Random.Range(0, 0.6f));
    }

    private void startMoveToShip () => isMovingToShip = true;

    private void transferResourceToShip()
    {
        if (indexOfResource==0) moveToShip.increaseShotPower(); //shot
        if (indexOfResource == 1) moveToShip.increaseEnergy(); //energy
        //shiled
        if (indexOfResource == 2)
        {
            if (moveToShip.shield.activeInHierarchy) moveToShip.healShield();
            else moveToShip.cumulateShiled();
        } 
        if (indexOfResource == 3) moveToShip.healHP(); //HP
        if (indexOfResource ==4) moveToShip.increaseAimingCount(); //aiming
    }

    private void FixedUpdate()
    {
        if (isMovingToBottomOfScreen)
        {
            _transform.position = Vector2.Lerp(_transform.position, MoveToBottomPosition, moveSpeed);
            if (((Vector2)_transform.position - MoveToBottomPosition).magnitude < 0.1f)
            {
                isMovingToBottomOfScreen = false;
                _transform.position = MoveToBottomPosition;
            }
        }

        if (isMovingToShip)
        {
            _transform.position = Vector2.Lerp(_transform.position, MoveToShipPosition, moveSpeedToShip);
            if (((Vector2)_transform.position - moveToShip.shipPosition).magnitude < 0.3f)
            {
                isMovingToShip = false;
                transferResourceToShip();
                disactivateTile();
            }
        }

        transform.Rotate(rotationVector);
    }

}
