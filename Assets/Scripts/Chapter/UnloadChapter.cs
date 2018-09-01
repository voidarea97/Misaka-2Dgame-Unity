using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadChapter : MonoBehaviour {

    public GameObject chapterNow;   //当前活动的章节地图

    void OnEnable () {
        chapterNow = GameObject.Find("/Chapters/ChapterNow");
	}
    public void Unload()
    {
        chapterNow.SetActive(false);
        Destroy(chapterNow);
    }
}
