using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

using MasterManagedDLL;

public class testManagerDLL : MonoBehaviour {
    [DllImport("MasterUnmanagedDLL")]
    public static extern int Multiply(int iA, int iB);

    [DllImport("MasterUnmanagedDLL")]
    public static extern void Sort(int[] aiData, int iLength);
    // Use this for initialization
    void Start () {
        //    m_oMyMath = new MyMath();
        //    Debug.Log("Mult 3 * 5 =" + m_oMyMath.Multiply(3,5));
        Debug.Log("New name = " + GameObjectData.GOName(this.gameObject));
        Debug.Log("Mult 3 * 5 =" + Multiply(3, 5));

        Debug.Log("" + m_aiData[0]);
        Sort(m_aiData, m_aiData.Length);
        Debug.Log("" + m_aiData[0]);
    }

    //private MyMath m_oMyMath;
    private int[] m_aiData = new int[] { 2, 5, 1, 3, 8 };
}
