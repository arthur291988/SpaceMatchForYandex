
using UnityEngine;

public class DisactivateEffect : MonoBehaviour
{
    //disactivates any effect prefab after it was pulled from Object Puller
    private GameObject _GO;

    [SerializeField]
    private float time;

    private void OnEnable()
    {
        if (_GO == null) _GO = gameObject;
        Invoke("setFalseGameObj", time);
    }

    private void setFalseGameObj()
    {
        _GO.SetActive(false);
    }
}
