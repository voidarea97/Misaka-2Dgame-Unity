using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnime : MonoBehaviour {

    Animator heroAnimator;

	void Start () {
        heroAnimator = gameObject.GetComponent<Animator>();
	}

    public void StartRun()
    {
        heroAnimator.SetBool("Run", true);
    }

    public void EndRun()
    {
        heroAnimator.SetBool("Run", false);
    }
    public void StartSkill(string skillName)
    {
        heroAnimator.SetBool(skillName, true);
    }
    public void EndSkill(string skillName)
    {
        heroAnimator.SetBool(skillName, false);
    }
    public void TriggerBehit()
    {
        heroAnimator.SetTrigger("Behit");
    }
    //public void EndBehit()
    //{
    //    heroAnimator.SetBool("Behit", false);
    //}
}
