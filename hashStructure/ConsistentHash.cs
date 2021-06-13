using System;
using System.Text;
using System.Collections.Generic;

class ConsistentHash {
    private int numberOfNodes;
    private int hashFunction;

    private Dictionary<int[], Node<int, int>> nodes;

    private HashFunction hash;

    private int stepSize;

    public ConsistentHash(int numOfNodes, int hashSize) {
        this.numberOfNodes = numOfNodes;
        this.hashFunction = hashSize;
        this.nodes = new Dictionary<int[], Node<int, int>>(numberOfNodes);
        this.hash = new HashFunction(this.hashFunction);
        this.initializeNodes();
    }

    private void initializeNodes() {
        this.stepSize = this.hashFunction / this.numberOfNodes;

        for (int i = 0; i < numberOfNodes; i++) {
            int[] nodeKey = {i * this.stepSize, ((i + 1) * this.stepSize) - 1};
            this.nodes.Add(nodeKey, new Node<int, int>());
        }
    }

    public void addValue(KeyValuePair<int, int> keyValuePair) {
        int hashedKey = this.hash.hashIt(keyValuePair.Key);

        foreach (int[] nodeKeyRange in this.nodes.Keys) {
            if (this.isKeyInRange(hashedKey, nodeKeyRange)) {
                this.nodes[nodeKeyRange].addKeyValuePair(keyValuePair);
                break;
            }
        }
        throw new Exception($"Could not find node to store key: {keyValuePair.Key}");
    }

    private bool isKeyInRange(int key, int[] range) {
        return key >= range[0] && key <= range[1];

    }

    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Nodes: {this.numberOfNodes}");
        stringBuilder.AppendLine($"Hash function: mod({this.hashFunction})");
        stringBuilder.AppendLine();
        foreach (int[] key in this.nodes.Keys) {
            stringBuilder.AppendLine($"Keys: [{key[0]}, {key[1]}]");
            stringBuilder.Append("Stored: ");

            Array.ForEach(this.nodes[key].storedKeyValuePairs.ToArray(), 
                element => stringBuilder.Append($"{element.Key} "));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
        }
        return stringBuilder.ToString();
    }

    public void addNode() {
        // TODO: Add new Node to hash and output results
    }

    public void removeNode(int id) {
        // TODO: Remove node with the given id
    }
}
