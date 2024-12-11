using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    //処理に必要なオブジェクト
    List<GameObject> canvas = new List<GameObject>();
    List<GameObject> defaultFocus_Canvas = new List<GameObject>();
    List<GameObject> window = new List<GameObject>();
    List<GameObject> defaultFocus_Window = new List<GameObject>();

    //処理に使用するフラグ
    bool isMenu = false;
    bool isWindow = false;

    //ポップアップの処理に使用する変数
    List<GameObject> activeWindow = new List<GameObject>();
    List<GameObject> previousFocus = new List<GameObject>();

    void Start()
    {
        //メニュー画面に必要なキャンバスの取得
        canvas.Add(GameObject.Find("MenuCanvas").transform.gameObject);
        //canvas.Add(GameObject.Find("").transform.gameObject);
        canvas.Add(GameObject.Find("FormationCanvas").transform.gameObject);

        //ポップアップに必要なウインドウの取得
        window.Add(GameObject.Find("ResetWindow").transform.gameObject);
        window.Add(GameObject.Find("DoneResetWindow").transform.gameObject);
        window.Add(GameObject.Find("ExitWindow").transform.gameObject);
        window.Add(GameObject.Find("DoneExitWindow").transform.gameObject);

        //キャンバスごとの最初に選択されるボタンの取得
        for (int n = 0; n < canvas.Count; n++)
        {
            GameObject addObjParent = canvas[n].transform.Find("ButtonSpace").gameObject;
            GameObject addObj = addObjParent.transform.GetChild(0).gameObject;
            defaultFocus_Canvas.Add(addObj);
        }

        //ウインドウごとの最初に選択されるボタンの取得
        for (int n = 0; n < window.Count; n++)
        {
            GameObject addObjParent = window[n].transform.Find("ButtonSpace").gameObject;
            GameObject addObj = addObjParent.transform.GetChild(0).gameObject;
            defaultFocus_Window.Add(addObj);
        }

        //シーン開始時はメニュー画面は非表示に
        CanvasHide();
        WindowHide();
    }

    void Update()
    {
        //キャンセルボタンを押したときに
        if (Input.GetButtonDown("Cancel"))
        {
            //メニュー画面が非表示なら表示する
            if (!isMenu)
            {
                CanvasDisplay(0);
                isMenu = true;
            }
            else if (isWindow)
            {
                CurrentWindowHide();
            }
            //メニュー画面が表示されているなら非表示にする
            else if (canvas[0].activeSelf)
            {
                CanvasHide();
                isMenu = false;
            }
            else
            {
                CanvasDisplay(0);
            }
        }
    }

    //UIの制御
    #region
    //キャンバスをすべて非表示に
    void CanvasHide()
    {
        for (int n = 0; n < canvas.Count; n++)
        {
            canvas[n].SetActive(false);
        }
    }

    //ウインドウをすべて非表示に
    void WindowHide()
    {
        for (int n = 0; n < window.Count; n++)
        {
            window[n].SetActive(false);
        }
    }

    public void CurrentWindowHide()
    {
        activeWindow[activeWindow.Count - 1].SetActive(false);
        EventSystem.current.SetSelectedGameObject(previousFocus[previousFocus.Count - 1]);

        activeWindow.RemoveAt(activeWindow.Count - 1);
        previousFocus.RemoveAt(previousFocus.Count - 1);

        if (activeWindow.Count <= 0)
        {
            isWindow = false;
        }
    }

    public void ActiveWindowHide()
    {
        WindowHide();
        EventSystem.current.SetSelectedGameObject(previousFocus[previousFocus.Count - activeWindow.Count]);

        for (; 0 < activeWindow.Count;)
        {
            activeWindow.RemoveAt(activeWindow.Count - 1);
            previousFocus.RemoveAt(previousFocus.Count - 1);
        }

        isWindow = false;
    }

    //指定のキャンバスを表示する
    public void CanvasDisplay(int index)
    {
        //不要なキャンバスを非表示に
        CanvasHide();

        canvas[index].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultFocus_Canvas[index]);
    }

    public void WindowDisplay(int index)
    {
        //ウインドウを開く前に選択されていたボタンを保存
        GameObject currentFocus = EventSystem.current.currentSelectedGameObject;
        previousFocus.Add(currentFocus);

        //ウインドウの表示
        window[index].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultFocus_Window[index]);

        //開いたウインドウの保存
        activeWindow.Add(window[index]);

        isWindow = true;
    }

    public void WindowChange(int index)
    {
        activeWindow[activeWindow.Count - 1].SetActive(false);
        activeWindow.RemoveAt(activeWindow.Count - 1);

        //ウインドウの表示
        window[index].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultFocus_Window[index]);

        //開いたウインドウの保存
        activeWindow.Add(window[index]);
    }
    #endregion

    //メニューの処理
    public void ExitGame(int index)
    {
        WindowChange(index);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
