using UnityEngine;
using System.Collections;

namespace MasterGD.Daniel { 
    public class Creator : MonoBehaviour {

	    // Use this for initialization
	    private void Start () {
            ////m_oNewGO = new GameObject(mk_sDefaultName);
            //m_oNewGO = GameObject.Instantiate(m_oMyReference);

            //m_oMyShooter = gameObject.AddComponent<ShooterWrong>();
            //m_oMyMovement = gameObject.AddComponent<Movement>();
           // if(oPrefab != null)
           for(int i = 0; i < 10; ++i) { 
            GameObject oCopy = GameObject.Instantiate(oPrefab);
            oCopy.GetComponent<Movement>().SetRandomPoint();
            }

        }
	
	    // Update is called once per frame
	    private void Update () {
	
	    }

        private void OnEnable()
        {
            if (m_oMyMovement != null)
            {
                m_oMyMovement.OnPositionReached += PositionReached;
            }

            if (m_oMyMovement != null)
            {
                m_oMyMovement.OnOtherPositionReached += OtherPositionReached;
            }
        }

        private void OnDisable()
        {
            if (m_oMyMovement != null)
            {
                m_oMyMovement.OnPositionReached -= PositionReached;
            }

            if (m_oMyMovement != null)
            {
                m_oMyMovement.OnOtherPositionReached -= OtherPositionReached;
            }
        }

        #region callback
        private void PositionReached(float fAdvancedTime)
        {
            Debug.Log("PositionReached object" + m_oMyMovement.name + " Advanced time =" + fAdvancedTime);
        }

        private void OtherPositionReached(float fAdvancedTime)
        {
            Debug.Log("OtherPositionReached object" + m_oMyMovement.name + " Advanced time =" + fAdvancedTime);
        }
        #endregion

        //[SerializeField]
        //private GameObject m_oMyReference;
        [SerializeField]
        private GameObject oPrefab;
        //private GameObject m_oNewGO;
        [SerializeField]
        private Movement m_oMyMovement;

        //private const string mk_sDefaultName = "NewObject";
        //private ShooterWrong m_oMyShooter;
    }
}