using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_State_Controller : MonoBehaviour
{
    private Animator _animator;
    private int i = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walking(float _walk)
    {
        _animator.SetFloat("walking", Mathf.Abs(_walk));
    }

    public void Punch()
    {
        _animator.SetTrigger("doPunch");
        
    }


}
