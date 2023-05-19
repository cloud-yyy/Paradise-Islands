using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    public void Save(object data, string key, Action<bool> callback = null);
    public void Load<T>(string key, Action<T> callback);
}
