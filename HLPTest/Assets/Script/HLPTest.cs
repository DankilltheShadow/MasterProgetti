using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using HLPTestManagedDLL;

namespace MasterGameDev.Daniel
{
    public class HLPTest : MonoBehaviour
    {
        #region VARS
        [SerializeField]
        private string[] m_asMyArrayOfString;
        [HideInInspector]
        public float[] m_afMyFloatArray;

        public MyStruct m_MyStruct;

        private const int m_kiArraySize = 10;
        private const int m_kiMinValue = 0;
        private const int m_kiMaxValue = 10;
        #endregion

        void Awake()
        {
            BoxCollider _BoxColl = gameObject.GetComponent<BoxCollider>();
            if(_BoxColl == null)
            {
                gameObject.AddComponent<BoxCollider>();
                Debug.LogWarning("BoxCollider not present");
            }
        }


        // Use this for initialization
        void Start()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                    Debug.Log("Windows");
                    break;
                case RuntimePlatform.WindowsEditor:
                    Debug.Log("Editor di Windows");
                    break;
                case RuntimePlatform.OSXPlayer:
                    Debug.Log("Apple");
                    break;
                case RuntimePlatform.OSXEditor:
                    Debug.Log("Editor Apple");
                    break;
                case RuntimePlatform.LinuxPlayer:
                    Debug.Log("Linux");
                    break;
                case RuntimePlatform.Android:
                    Debug.Log("Android");
                    break;
                default:
                    Debug.Log("Not supported platform");
                    break;
            }


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                string _sOutput = "Array:";

                int[] _iaTempArray = new int[m_kiArraySize];
                FillArray(_iaTempArray, m_kiArraySize, m_kiMinValue, m_kiMaxValue);

                foreach (int _iElement in _iaTempArray)
                {
                    _sOutput = _sOutput +" "+ _iElement;
                }

                Debug.Log(_sOutput); 
            }
        }

        #region SERIALIZABLE
        [System.Serializable]
        public struct MyStruct
        {
            public int iMyStructInt;
            public Vector3 v3MyStructVector3;
            public bool bMyBool;
        }
        #endregion
        #region IMPORT
        [DllImport("HLPTestUnManagedDLL")]
        public static extern void FillArray(int[] iaArray, int iSize, int iMinValue = 0, int iMaxValue = 10);
        #endregion


    }
}

/// Answer to the following questions:
/// -----What's the main differences from C# and C++?
/// C# ha garbage collector e non gestisce i puntatori.
/// -----What's the difference from the keyword ref and out? Make an example of use of the two keyword
/// ref viene usata per passare una variabile tramite reference, out è la stessa cosa ma obbliga alla modifica del valore all'interno della funzione.
/// -----What's mean when a variable is serialized? How is managed a serialized variable?
/// Una variabile serialized viene salvata da unity in un file apposito e il valore può essere modificato tramite editor.
/// E' usata ad esempio per gestire dei parametri di default che possono essere modificati e salvati.
/// -----Which issues can araise instantiating an object only when needed and deleting it when no more needed? How can we avoid those issues?
/// Istanziare un oggetto è un'operazione costosa e si potrebbe avere un drop delle performance, è quindi consigliato creare un pool di oggetti
/// istanziandoli quindi all'avvio del gioco
/// -----What is a prefab? Why can be useful during the development? How the "Apply" button behave on a prefab instance?
/// Un prefab è template di un GameObject, è utile se si devono instanziare tanti GameObject simili o uguali permettendo di creare l'oggetto base
/// e semmai modificando i singoli parametri quando necessario. Il tasto Apply permette di salvare le modifiche fatte su un istanza direttamente nel prefab sovrascrivendo
/// i precedenti valori.