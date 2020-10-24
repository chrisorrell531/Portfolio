using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestroy : MonoBehaviour
{

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
