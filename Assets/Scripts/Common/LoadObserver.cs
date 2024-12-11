using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadObserver : Singleton<LoadObserver>
{
    PerformLoading[] loadScript;

    bool _loadEnd = false;
    public bool loadEnd
    {
        get { return _loadEnd; }
        private set { _loadEnd = value; }
    }

    void Start()
    {
        //ロードが必要なスクリプトを取得する
        loadScript = FindObjectsOfType<MonoBehaviour>().OfType<PerformLoading>().ToArray();
    }

    void Update()
    {
        if (!loadEnd) LoadCheck();
    }

    void LoadCheck()
    {
        for (int n = 0; n < loadScript.Length; n++)
        {
            //ロードが終わっていないものがあったら処理を終える
            if (!loadScript[n].loadEnd) return;
        }

        //すべてロードが終わっていたらtrueにする
        loadEnd = true;
    }
}
