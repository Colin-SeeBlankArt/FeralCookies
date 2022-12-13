/*
* This class is the version of our save system that uses the "SaveGameFree" plugin under the hood
*/

using System.Threading;
using System.Threading.Tasks;
using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;

public class SaveGamesFreeJsonSaveManagerImplementation : ISaveManagerImplementation
{
    public SaveGamesFreeJsonSaveManagerImplementation()
    {
        SaveGame.SavePath = SaveGamePath.DataPath;
    }
    
    private readonly ISaveGameSerializer m_serializer = new SaveGameJsonSerializer();
    
    public Task SaveDataAsync<T>(string key, T value, CancellationToken cancelToken = new CancellationToken())
    {
        cancelToken.ThrowIfCancellationRequested();
        
        SaveGame.Save(key, value, m_serializer);
        return Task.CompletedTask;
    }

    public Task<T> LoadDataAsync<T>(string key, T defaultIfNotFound = default, CancellationToken cancelToken = new CancellationToken()) where T : new()
    {
        cancelToken.ThrowIfCancellationRequested();
        
        var loadedValue = SaveGame.Load(key, defaultIfNotFound, m_serializer) ?? new T();
        return Task.FromResult(loadedValue);
    }
}