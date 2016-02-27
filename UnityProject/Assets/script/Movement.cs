﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour 
{
	private void Start() 
	{
		m_vDirection = mk_vEndPosition - mk_vStartPosition;
		m_fTotalTime = m_vDirection.magnitude / mk_fSpeed;

		m_vDirection.Normalize();

		transform.position = mk_vStartPosition;
	}
	
	private void Update() 
	{
		m_fElapsedTime += Time.deltaTime;

		if(m_fElapsedTime < m_fTotalTime)
		{
			transform.position += m_vDirection * mk_fSpeed * Time.deltaTime;
		}
		else
		{
			transform.position = (m_bForward ? mk_vEndPosition : mk_vStartPosition);

			m_fElapsedTime -= m_fTotalTime;

			m_bForward = !m_bForward;
			m_vDirection = -m_vDirection;

			transform.position += m_vDirection * mk_fSpeed * m_fElapsedTime;
		}
	}

	//VARS
	private Vector3 m_vDirection;
    private float m_fTotalTime = 0.0f;
    private bool m_bForward = true;
    private float m_fElapsedTime = 0.0f;

    [SerializeField] private float 	mk_fSpeed = 10.0f;
    [SerializeField] private Vector3 	mk_vStartPosition;
    [SerializeField] private Vector3 	mk_vEndPosition;
}
