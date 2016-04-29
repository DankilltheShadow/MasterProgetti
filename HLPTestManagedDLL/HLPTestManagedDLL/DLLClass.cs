using System;
using UnityEngine;

namespace HLPTestManagedDLL
{
    public class DLLClass
    {
        public event Action MyEvent;
        public event Action<float> MyEventFloat;

        private float m_fTime;
        public void setEventTime(float fTime)
        {
            m_fTime = fTime;
        }

        private float m_fFunction = 0.0f;
        public void setFloatValue(float fValue)
        {
            m_fFunction = fValue;
        }

        void Update()
        {
            if (m_fTime <= Time.time)
            {
                if (MyEvent != null)
                {
                    MyEvent();
                }

                if (MyEventFloat != null)
                {
                    MyEventFloat(m_fFunction);
                }
            }

        }

        
    }
}
