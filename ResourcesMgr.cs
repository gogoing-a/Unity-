using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesMgr : Inst<ResourcesMgr>
{
    private Dictionary<string, Object> _cacheDic = new Dictionary<string, Object>();

    private Dictionary<ResourceRequest, bool> _requestDic = new Dictionary<ResourceRequest, bool>();

    public override void Init()
    {
        base.Init();
    }

    public Object LoadResources<K>(string assetsName)
    {
        Object assets = null ;
        if (!_cacheDic.ContainsKey(assetsName))
        {

#if UNITY_EDITOR
            var resourceRequest = Resources.LoadAsync<Object>(assetsName);
            resourceRequest.completed += ResourceRequestCompleted;
            if (!_requestDic.ContainsKey(resourceRequest))
            {
                _requestDic.Add(resourceRequest, true);
            }

#elif PLATFORM_STANDALONE

#elif UNITY_ANDROID

#endif
            if (assets != null)
            {
                _cacheDic.Add(assetsName, assets);
            }
            else
            {

            }
        }
        return assets;
    }

    private void ResourceRequestCompleted(AsyncOperation obj)
    {
        
    }

    public void UnLoadResources(Object assets)
    {
        //if (_cacheDic.ContainsKey(assets))
        //{
        //    Resources.UnloadAsset(assets);
        //}
    }
}
