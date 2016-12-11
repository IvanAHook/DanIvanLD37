using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimationTimer : MonoBehaviour
{

    public float minRandomTime = 4f, maxRandomTime = 10f;
    public float minRandomSpeed = 0.7f, maxRandomSpeed = 1.5f;
    private Animator _animator;
    private float _counter;

	// Use this for initialization
	void Start ()
	{
	    _counter = Random.Range(2f, 4f);
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _counter -= Time.deltaTime;

	    if (_counter <= 0)
	    {
	        _counter = Random.Range(4f, 10f);
	        PlayAnimation();
	    }
	}

    private void PlayAnimation()
    {
        _animator.speed = Random.Range(0.7f, 1.5f);
        _animator.Play("Wind", 0);
    }
}
