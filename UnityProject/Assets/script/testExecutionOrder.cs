using UnityEngine;
using System.Collections;

public class testExecutionOrder : MonoBehaviour {
    public string m_iID;

    void Reset()
    {
        Debug.Log(string.Concat(m_iID,": Reset"));
    }

    void Awake()
    {
        Debug.Log(string.Concat(m_iID, ": Awake"));
    }

    void OnEnable()
    {
        Debug.Log(string.Concat(m_iID, ": OnEnable"));
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log(string.Concat(m_iID, ": Start"));
    }

    void FixedUpdate()
    {
        Debug.Log(string.Concat(m_iID, ": FixedUpdate"));
    }

    void LateUpdate()
    {
        Debug.Log(string.Concat(m_iID, ": LateUpdate"));
    }
    void OnWillRenderObject()
    {
        Debug.Log(string.Concat(m_iID, ": OnWillRenderObject"));
    }

    void OnPreCull()
    {
        Debug.Log(string.Concat(m_iID, ": OnPreCull"));
    }

    void OnBecameVisible()
    {
        Debug.Log(string.Concat(m_iID, ": OnBecameVisible"));

    }
    void OnBecameInvisible()
    {
        Debug.Log(string.Concat(m_iID, ": OnBecameInvisible"));
    }

    void OnPreRender()
    {
        Debug.Log(string.Concat(m_iID, ": OnPreRender"));
    }

    void OnRenderObject()
    {
        Debug.Log(string.Concat(m_iID, ": OnRenderObject"));
    }

    void OnPostRender()
    {
        Debug.Log(string.Concat(m_iID, ": ResetOnPostRender"));
    }

    void OnGUI()
    {
        Debug.Log(string.Concat(m_iID, ": OnGUI"));
    }

    void OnCollision()
    {
        Debug.Log(string.Concat(m_iID, ": OnCollision"));
    }

    void OnApplicationPause()
    {
        Debug.Log(string.Concat(m_iID, ": OnApplicationPause"));
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(string.Concat(m_iID, ": Update"));
    }

    void OnDisable()
    {
        Debug.Log(string.Concat(m_iID, ": OnDisable"));
    }

    void OnApplicationQuit()
    {
        Debug.Log(string.Concat(m_iID, ": OnApplicationQuit"));
    }

    void OnDestroy()
    {
        Debug.Log(string.Concat(m_iID, ": OnDestroy"));
    }
}
