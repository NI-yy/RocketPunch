using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchObjectController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RangeArea"))
        {
            Destroy(this.gameObject);
        }
    }
}
