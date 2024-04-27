using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteAnimation : ScriptableObject
{
    public List<Sprite> anim;
    public string animName;
    public float animLength;
    public bool loop;
}
