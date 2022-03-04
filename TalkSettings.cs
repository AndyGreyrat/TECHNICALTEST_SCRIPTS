using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class TalkSettings : ScriptableObject
{
    public float TimeSpell = 0.1f;
    public KeyCode keySkip = KeyCode.G;
    public KeyCode keySkip2 = KeyCode.Joystick1Button5;
    public KeyCode keyToNext;
    public KeyCode TALK = KeyCode.E;
    public KeyCode TALKC = KeyCode.Joystick1Button3;
}
