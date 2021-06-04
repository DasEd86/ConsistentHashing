using System;
using System.Text;
using System.Collections.Generic;

class ConsistentHash {
    private int numberOfNodes;
    private int hashMapSize;

    private Dictionary<int, Node<int, int>> nodes;

    private HashFunction hash;

    private int stepSize;

    public ConsistentHash(int numOfNodes, int hashSize) {
        this.numberOfNodes = numOfNodes;
        this.hashMapSize = hashSize;
        this.nodes = new Dictionary<int, Node<int, int>>();
        this.hash = new HashFunction(this.hashMapSize);
        this.initializeNodes();
    }

    private void initializeNodes() {
        this.stepSize = this.hashMapSize / this.numberOfNodes;

        for (int i = 0; i < numberOfNodes; i++) {
            int start = i * this.stepSize;
            this.nodes.Add(start, new Node<int, int>());
        }
    }

    public void addDataPoint(KeyValuePair<int, int> keyValuePair) {
        int hashedKey = this.hash.hashIt(keyValuePair.Key);

        int i = 0;
        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey) {
                if (hashedKey < (nodeKey + this.stepSize)
                    || (i + 1) == this.numberOfNodes) {
                    this.nodes[nodeKey].addDataPoint(keyValuePair);
                    break;
                }
            }
            i++;
        }
    }

    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Total hash size: {this.numberOfNodes}");
        stringBuilder.AppendLine($"Hash function: mod({this.hashMapSize})");
        stringBuilder.AppendLine();
        foreach (int key in this.nodes.Keys) {
            stringBuilder.AppendLine($"Hash keys start: {key}, # of nodes: {this.nodes[key].getNumberOfStoredKeys()}");
            stringBuilder.Append("Values: ");

            Array.ForEach(this.nodes[key].StoredKeyValuePairs.ToArray(), 
                element => stringBuilder.Append(element.Key + " "));

            stringBuilder.Append("\n\n");
        }
        return stringBuilder.ToString();
    }

    public KeyValuePair<int, int> getDataPoint(int key) {
        int hashedKey = this.hash.hashIt(key);

        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey && hashedKey <= nodeKey + this.stepSize) {
                return this.nodes[nodeKey].getKeyValuePair(key);
            }
        }
        return null;
    }

    public void addNode() {
        // TODO: Add new Node to hash and output results
    }

    public void removeNode(int id) {
        // TODO: Remove node with the given id
    }
}
