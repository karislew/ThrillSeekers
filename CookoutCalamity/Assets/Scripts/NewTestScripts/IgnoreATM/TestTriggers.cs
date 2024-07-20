using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggers : MonoBehaviour
{
    public event System.Action<Collider2D> EnteredTrigger;
    public event System.Action<Collider2D> ExitedTrigger;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        EnteredTrigger?.Invoke(col);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        ExitedTrigger?.Invoke(col);
    }

}
