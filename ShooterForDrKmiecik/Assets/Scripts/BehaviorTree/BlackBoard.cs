using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard
{
    private Dictionary<string, object> _memory;

    public BlackBoard()
    {
        _memory = new Dictionary<string, object>();
    }

    public void SetValue(string key, int id, object value)
    {
        string generatedKey = GenerateKey(key, id);
        if (!_memory.ContainsKey(generatedKey))
        {
            _memory.Add(generatedKey, value);
            return;
        }
        _memory[generatedKey] = value;

        return;
    }

    public object GetValue(string key, int id)
    {
        string generatedKey = GenerateKey(key, id);
        if (_memory.ContainsKey(generatedKey))
        {
            return _memory[generatedKey];
        }

        return null;
    }

    private string GenerateKey(string key, int id)
    {
        return key + "ID" + id.ToString();
    }
    
}
