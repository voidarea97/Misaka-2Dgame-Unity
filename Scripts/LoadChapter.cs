using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChapter : MonoBehaviour {

    //public GameObject [] chapters;
    public GameObject chapters;
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;
    public GameObject chapter4;

    public GameObject chapterNow;   //当前活动的章节地图

    public void Load(int num)
    {
        switch(num)
        {
            case 1:
                chapterNow=Instantiate(chapter1, chapters.transform);
                chapterNow.SetActive(true);
                chapterNow.name = "ChapterNow";
                //Camera.main.gameObject.GetComponent<Follow>().FollowHero()
                break;
        }
        
    }

    void Awake () {
        //chapters = GameObject.FindGameObjectsWithTag("Chapter");
        chapters = GameObject.Find("/Chapters");
        chapter1 = chapters.transform.Find("Chapter1").gameObject;
	}

}
