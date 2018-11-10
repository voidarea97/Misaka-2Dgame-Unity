using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnime : MonoBehaviour {
    Animator Animator;

    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    public void StartRun()
    {
        Animator.SetBool("Run", true);
    }

    public void EndRun()
    {
        Animator.SetBool("Run", false);
    }
    public void StartSkill(string skillName)
    {
        Animator.SetBool(skillName, true);
    }
    public void EndSkill(string skillName)
    {
        Animator.SetBool(skillName, false);
    }
    public void TriggerBehit()
    {
        Animator.SetTrigger("Behit");
    }
    public void TriggerAtk()
    {
        Animator.SetTrigger("Atk");
    }
}
