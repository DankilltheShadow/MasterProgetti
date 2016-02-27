using UnityEngine;
using System.Collections;

/*
Università di Verona - Master Videogame programming 2016
Corso HLP - Roberto Mangiafico

Excercise: Having trouble figuring out what's causing an intermittent bug. The issue is that sometimes the "explosion" animation 
will trigger multiple times when either holding the A key or pressing it rapidly, but not always.

Rewrite the code to solve the problem.
 */
public class ShooterWrong : MonoBehaviour 
{
	void Start() 
	{
        
	}
	
	void Update()
	{
        if (!m_bIsUsable)
        {
		    CooldownManager();
        }
        else
        {
		    Cast();
        }
	}
	
	void Cast() 
	{
		if (Input.GetKey(KeyCode.A))
		{
			Debug.Log(string.Format("explosion at {0} is usable = {1}",m_fTimerShooting, m_bIsUsable));
			m_bIsUsable = false;
            m_fTimerShooting = Time.time + mk_fCooldowntimer;
		}
	}
	
	void CooldownManager() 
	{
		if (Time.time > m_fTimerShooting)
		{
			m_bIsUsable = true;
		}
	}

	//VARS
	private bool 	m_bIsUsable;
	private const float mk_fCooldowntimer = 0.5f;
    private float 	m_fTimerShooting;
}