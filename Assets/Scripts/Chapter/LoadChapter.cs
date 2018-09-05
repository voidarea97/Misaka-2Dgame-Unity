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

        switch((num-1)%2)
        {
            case 0:
                chapterNow = Instantiate(chapter1, chapters.transform);
                break;
            case 1:
                chapterNow = Instantiate(chapter2, chapters.transform);
                break;
        }
        chapterNow.SetActive(true);
        chapterNow.name = "ChapterNow";

    }

    void Awake () {
        //chapters = GameObject.FindGameObjectsWithTag("Chapter");
        
        chapters = GameObject.Find("/Chapters");
        
        chapter1 = chapters.transform.Find("Chapter1").gameObject;
        chapter2 = chapters.transform.Find("Chapter2").gameObject;
        //chapter1 = chapters.transform.Find("Chapter3").gameObject;
        //chapter1 = chapters.transform.Find("Chapter4").gameObject;
    }

}
