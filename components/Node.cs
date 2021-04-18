using System.Collections.Generic;

class Node<Key, Value> {
    List<KeyValuePair<Key, Value>> storedKeyValuePairs;

    public Node() {
        this.storedKeyValuePairs = new List<KeyValuePair<Key, Value>>();
    }

    public void addDataPoint(KeyValuePair<Key, Value> dataPoint) {
        this.storedKeyValuePairs.Add(dataPoint);
    }

    public int getNumberOfStoredKeys() {
        return storedKeyValuePairs.Count;
    }

    public KeyValuePair<Key, Value> getKeyValuePair(Key key) {
        foreach (KeyValuePair<Key, Value> keyValuePair in this.storedKeyValuePairs) {
            if (keyValuePair.getKey().Equals(key)) {
                return keyValuePair;
            }
        }
        return null;
    }
}
