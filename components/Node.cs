using System.Collections.Generic;

class Node<Key, Value> {
    public List<KeyValuePair<Key, Value>> StoredKeyValuePairs
    {get;}

    public Node() {
        StoredKeyValuePairs = new List<KeyValuePair<Key, Value>>();
    }

    public void addDataPoint(KeyValuePair<Key, Value> dataPoint) {
        StoredKeyValuePairs.Add(dataPoint);
    }

    public int getNumberOfStoredKeys() {
        return StoredKeyValuePairs.Count;
    }

    public KeyValuePair<Key, Value> getKeyValuePair(Key key) {
        foreach (KeyValuePair<Key, Value> keyValuePair in StoredKeyValuePairs) {
            if (keyValuePair.Key.Equals(key)) {
                return keyValuePair;
            }
        }
        return null;
    }
}
