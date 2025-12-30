using Assets;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCode : MonoBehaviour, IBlocking
{
    public bool UnblockOnTransition { get => true; }
    public int TargetTagHash { get => Animator.StringToHash("Blocking"); }

    public readonly Dictionary<int, string> States = new Dictionary<int, string>()
    {
        { Animator.StringToHash("Monster13_Idle") , "Monster13_Idle"},
        { Animator.StringToHash("Monster13_Walk") , "Monster13_Walk"}
    };

    public void BlockStuff(int name_hash)
    {
        Debug.Log($"Blocking {gameObject.name} stuff when entering {States[name_hash]} state.");
    }

    public void UnblockStuff(int name_hash)
    {
        Debug.Log($"Unblocking {gameObject.name} stuff when exiting {States[name_hash]} state.");
    }
}
