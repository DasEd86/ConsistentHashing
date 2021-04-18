using System.Text;
using System.Collections.Generic;

class ConsistentHash {
    private int numberOfNodes;

    private int hashMapSize;
    private Dictionary<int, Node<int, int>> nodes;

    private HashFunction hash;

    public ConsistentHash(int numOfNodes, int hashSize) {
        this.numberOfNodes = numOfNodes;
        this.hashMapSize = hashSize;
        this.nodes = new Dictionary<int, Node<int, int>>();
        this.hash = new HashFunction(this.hashMapSize);
        this.initializeNodes();
    }

    private void initializeNodes() {
        int stepSize = this.hashMapSize / this.numberOfNodes;
        for (int i = 0; i < numberOfNodes; i++) {
            int start = i * stepSize;
            this.nodes.Add(start, new Node<int, int>());
        }
    }

    public void addDataPoint(KeyValuePair<int, int> keyValuePair) {
        int hashedKey = this.hash.hashIt(keyValuePair.getKey());

        int i = 0;
        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey) {
                if (hashedKey < (nodeKey + (this.hashMapSize / this.numberOfNodes))
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
        stringBuilder.AppendLine("Hash size: " + this.numberOfNodes);
        foreach (int key in this.nodes.Keys) {
            stringBuilder.AppendLine("Hash Start: " + key + " Size: " + this.nodes[key].getNumberOfStoredKeys());
        }
        return stringBuilder.ToString();
    }

    public KeyValuePair<int, int> getDataPoint(int key) {
        int hashedKey = this.hash.hashIt(key);

        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey && hashedKey <= nodeKey + (this.hashMapSize / this.numberOfNodes)) {
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
