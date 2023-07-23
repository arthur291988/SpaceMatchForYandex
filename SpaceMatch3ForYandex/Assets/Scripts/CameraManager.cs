using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    public void shakeCamera() {
        animator.SetBool("Shake", true);
        Invoke("setFalseShake",0.1f);
    }

    private void setFalseShake () =>  
        animator.SetBool("Shake", false);
}
