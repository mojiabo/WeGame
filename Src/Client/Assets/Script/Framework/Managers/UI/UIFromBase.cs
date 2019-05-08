using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UIFromBase : MonoBehaviour
    {
        public void ToClose()
        {
            Destroy(gameObject);
        }

    }
}
