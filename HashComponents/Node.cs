using System.Collections.Generic;

class Node<K, V> {
    public List<KeyValuePair<K, V>> storedKeyValuePairs
    {get;}

    public Node() {
        storedKeyValuePairs = new List<KeyValuePair<K, V>>();
    }

    public void addKeyValuePair(KeyValuePair<K, V> dataPoint) {
        storedKeyValuePairs.Add(dataPoint);
    }

    public int getNumberOfStoredKeys() {
        return storedKeyValuePairs.Count;
    }

    public KeyValuePair<K, V> getKeyValuePair(K key) {
        foreach (KeyValuePair<K, V> keyValuePair in storedKeyValuePairs) {
            if (keyValuePair.Key.Equals(key)) {
                return keyValuePair;
            }
        }
        return null;
    }
}
