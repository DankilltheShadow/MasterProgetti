using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

using UnityEngine.Assertions;

namespace MasterGD.Daniel
{
    public class Movement : MonoBehaviour
    {
        public event Action<float> OnPositionReached;

        public delegate void MovementEvent(float fAdvancedTime);
        public event MovementEvent OnOtherPositionReached;

        #region PUBLIC
        public void StartMovement()
        {
            if (!m_bMoving)
            {
                m_bMoving = true;

                ComputeNextPoint();

                transform.position = m_vStartPosition;
            }
        }

        #endregion

        #region INTERNAL
        private void Start()
        {
            if (m_bAutoStart)
            {
                StartMovement();
            }
        }

        private void Update()
        {
            if (m_bMoving)
            {
                ExecuteMovement();
            }
        }

        private void ExecuteMovement()
        {
            m_fElapsedTime += Time.deltaTime;

            if (m_fElapsedTime < m_fTotalTime)
            {
                transform.position += m_vDirection * m_fSpeed * Time.deltaTime;
            }
            else
            {
                m_iCurrentPoint = (m_bForward ? m_iCurrentPoint + 1 : m_iCurrentPoint - 1);

                transform.position = m_vEndPosition;

                m_fElapsedTime -= m_fTotalTime;

                if (m_bForward && m_iCurrentPoint == m_aoPoints.Length)
                {
                    //Move finished
                    switch (m_eLoopType)
                    {
                        case eLoopType.LOOP:
                            m_iCurrentPoint = 0;
                            ComputeNextPoint();
                            transform.position = m_vStartPosition;
                            break;
                        case eLoopType.PINGPONG:
                            m_bForward = false;
                            --m_iCurrentPoint;
                            ComputeNextPoint();
                            break;
                        case eLoopType.NONE:
                            m_bMoving = false;
                            break;
                    }
                }
                else if (!m_bForward && m_iCurrentPoint == 0)
                {
                    //Move finished - The only case that bring me here is PingPong loop back
                    m_bForward = true;
                    ComputeNextPoint();
                }
                else
                {
                    ComputeNextPoint();
                    transform.position += m_vDirection * m_fSpeed * m_fElapsedTime;
                }


                if (m_bForward && OnPositionReached != null)
                {
                    OnPositionReached(m_fElapsedTime);
                }
                else if (!m_bForward && OnOtherPositionReached != null)
                {
                    OnOtherPositionReached(m_fElapsedTime);
                }

            }
        }

        private void ComputeNextPoint()
        {
                m_vStartPosition = m_aoPoints[m_iCurrentPoint].position;

            if (m_bForward)
            {
                if (m_iCurrentPoint + 1 < m_aoPoints.Length)
                {
                    m_vEndPosition = m_aoPoints[m_iCurrentPoint + 1].position;
                }
            }
            else if (m_iCurrentPoint > 0)
            {
                    m_vEndPosition = m_aoPoints[m_iCurrentPoint - 1].position;

            }

            m_vDirection = m_vEndPosition - m_vStartPosition;
            m_fTotalTime = m_vDirection.magnitude / m_fSpeed;

            m_vDirection.Normalize();
        }

        public void SetRandomPoint()
        {
            m_aoPoints = new Transform[2];
            Vector3 tmpm_vStartPosition = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f));
            Vector3 tmpm_vEndPosition = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f), 1.0f);
            GameObject oCopy = new GameObject();
            oCopy.transform.position = tmpm_vStartPosition;
            m_aoPoints[0] = oCopy.transform;
            GameObject oCopy2 = new GameObject();
            oCopy2.transform.position = tmpm_vEndPosition;
            m_aoPoints[1] = oCopy2.transform;
            m_eLoopType = eLoopType.PINGPONG;
            StartMovement();
        }
        #endregion

        //VARS
        [SerializeField]
        private Transform[] m_aoPoints;
        [SerializeField]
        private eLoopType m_eLoopType;
        [SerializeField]
        private float m_fSpeed = 10.0f;
        [SerializeField]
        private bool m_bAutoStart = false;

        private enum eLoopType
        {
            NONE = 0,
            LOOP,
            PINGPONG
        }

        private Vector3 m_vStartPosition;
        private Vector3 m_vEndPosition = new Vector3(10.0f, 10.0f, 1.0f);

        private Vector3 m_vDirection;
        private float m_fElapsedTime = 0.0f;
        private float m_fTotalTime = 0.0f;
        private bool m_bForward = true;
        private bool m_bMoving = false;

        private int m_iCurrentPoint = 0;

    }
}