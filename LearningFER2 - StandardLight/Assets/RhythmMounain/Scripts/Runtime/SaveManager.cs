using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

/*
 * Add public fields to this object to have them saved after playthroughs
 */
[Serializable]
public class GameSessionData
{
    //public DateTime TimeCreated;
    public int TotalBricks;
    public int PlayerScore;
    public int GreenStack;
    public int RedStack;
    public int Penalties;
    public int BlueStack;
    public int PurpStack;
    public int RdSprkTot;
    public int GrnSprkTot;

    /*public int PollQuest_[Loop];
     *public int TimeElapsed;
     */
}

[Serializable]
public class GameSaveData
{
    // Each session is recorded independently so we never lose a detail
    public GameSessionData[] SessionData;
}

/*
 * This interface allows us to entirely swap the guts of the save system if we want to make it work with a hosted web service later on
 * All api hooks assume a request/response pattern and are not guaranteed to complete in a single frame
 */
public interface ISaveManagerImplementation
{
    Task SaveDataAsync<T>(string key, T value, CancellationToken cancelToken = new CancellationToken());

    Task<T> LoadDataAsync<T>(string key, T defaultIfNotFound = default,
        CancellationToken cancelToken = new CancellationToken()) where T : new();
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                var managerObject = new GameObject("**SaveManager");
                s_instance = managerObject.AddComponent<SaveManager>();
            }

            return s_instance;
        }
    }
    
    private static SaveManager s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    private void OnDestroy()
    {
        s_instance = null;
    }

    private readonly ISaveManagerImplementation m_implementation = new SaveGamesFreeJsonSaveManagerImplementation();

    public void SaveData<T>(string key, T value)
    {
        m_implementation.SaveDataAsync(key, value);
    }

    /*
     * Loads a save value from the underlying system. The process may take several frames and the result will be sent to your callback
     */
    public async void LoadData<T>(string key, Action<T> callback, T defaultIfNotFound = default) where T : new()
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentException($"{nameof(key)} is null or empty");
        if (callback == null) throw new ArgumentNullException(nameof(callback));
        
        // This api is blocking so you can get the results on the calling thread
        var result = await m_implementation.LoadDataAsync(key, defaultIfNotFound);
        callback(result);
    }

    /*
     * Loads a save value from the underlying system. This guarantees that you get the result to store in your calling thread
     * but it comes at the cost of performance. This blocks the game thread which prevents any other thing from working until
     * the result is returned.
     */
    public T LoadDataBlocking<T>(string key, T defaultIfNotFound = default) where T : new()
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentException($"{nameof(key)} is null or empty");

        var result = m_implementation.LoadDataAsync(key, defaultIfNotFound).Result;
        return result;
    }
    
}