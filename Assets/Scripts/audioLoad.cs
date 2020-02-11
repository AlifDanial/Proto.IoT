using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLoad : MonoBehaviour
{
    public audioInstantiate instantiate;

    public void importAudio()
    {
        instantiate.Import();
    }
}
