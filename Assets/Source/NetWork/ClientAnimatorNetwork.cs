using Unity.Netcode.Components;
using UnityEngine;

[DisallowMultipleComponent]
public class ClientAbimatorNetwork : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}