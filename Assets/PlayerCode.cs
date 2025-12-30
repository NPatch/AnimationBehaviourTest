using Assets;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour, IBlocking
{
    public readonly Dictionary<int, string> States = new Dictionary<int, string>()
    {
        { Animator.StringToHash("Idle") , "Idle"},
        { Animator.StringToHash("SwordAttack") , "SwordAttack"},
        { Animator.StringToHash("Jump02") , "Jump02"},
        { Animator.StringToHash("Death") , "Death"}
    };

    public bool UnblockOnTransition { get => true; }
    public int TargetTagHash { get => Animator.StringToHash("Blocking"); }

    public void BlockStuff(int name_hash)
    {
        Debug.Log($"Blocking {gameObject.name} stuff when entering {States[name_hash]} state.");
    }

    public void UnblockStuff(int name_hash)
    {
        Debug.Log($"Unblocking {gameObject.name} stuff when exiting {States[name_hash]} state.");
    }
}
