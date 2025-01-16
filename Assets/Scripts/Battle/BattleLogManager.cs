using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BattleLogManager : Singleton<BattleLogManager>, PerformLoading
{
    List<string> logList = new List<string>();

    //必要なアセットの読み込み
    #region
    // Addressablesのアドレスを設定
    [Header("Textのアドレス")]
    [SerializeField] string textAddress = "BattleLogText";

    GameObject logObject;
    GameObject logSpace;

    bool _loadEnd = false;
    public bool loadEnd
    {
        get { return _loadEnd; }
        private set { _loadEnd = value; }
    }

    void Awake()
    {
        // Addressablesを使ってPlayerDatabaseをロード
        Addressables.LoadAssetAsync<GameObject>(textAddress).Completed += OnPlayerDatabaseLoaded;
        logSpace = GameObject.Find("LogSpace");
    }

    // PlayerDatabaseの読み込みが完了した際に呼ばれる
    void OnPlayerDatabaseLoaded(AsyncOperationHandle<GameObject> handle)
    {
        // 成功したら、playerDB変数に代入
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            logObject = handle.Result;
            loadEnd = true;
        }
        else Debug.LogError("Failed to load PlayerDatabase");
    }
    #endregion

    public void LogDisplay(string logMessage)
    {
        logList.Add(logMessage);

        GameObject logObj = Instantiate(logObject);
        logObj.transform.SetParent(logSpace.transform, false);

        GameObject textObj = logObj.transform.GetChild(0).gameObject;
        TextMeshProUGUI logText = textObj.GetComponent<TextMeshProUGUI>();
        logText.text = logMessage;
    }
}
