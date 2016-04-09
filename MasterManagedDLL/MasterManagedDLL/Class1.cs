using System;
using UnityEngine;
using UnityEditor;

namespace MasterManagedDLL
{
    public class GameObjectData
    {
        public static string GOName(GameObject oTestGO)
        {
            return oTestGO.name + sk_sDLLData;
        }

        private static string sk_sDLLData = "From Managed DLL";
    }
}
