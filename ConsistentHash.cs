using System;
using System.Collections.Generic;

class ConsistentHash {
    private int numberOfNodes;

    private int hashMapSize;
    private Dictionary<int, Node> nodes;

    private HashFunction hash;

    public ConsistentHash(int numOfNodes, int hashSize) {
        this.numberOfNodes = numOfNodes;
        this.hashMapSize = hashSize;
        this.nodes = new Dictionary<int, Node>();
        this.hash = new HashFunction(this.hashMapSize);
        this.initializeNodes();
    }

    private void initializeNodes() {
        int stepSize = this.hashMapSize / this.numberOfNodes;
        int mod = this.hashMapSize % this.numberOfNodes;

        for (int i = 0; i < numberOfNodes; i++) {
            int start = i * stepSize;
            int end = ((i * stepSize) + stepSize) - 1;

            if (mod != 0 && (i == numberOfNodes - 1)) {
                end = this.hashMapSize - 1;
            }

            this.nodes.Add(start, new Node());
        }
    }

    public void addDataPoint(DataPoint d) {
        int hashedKey = this.hash.hashIt(d.getKey());

        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey && hashedKey <= nodeKey + (this.hashMapSize / this.numberOfNodes)) {
                this.nodes[nodeKey].addDataPoint(d);
                break;
            }
        }
    }

    public void printStateOfDB() {
        foreach (int key in this.nodes.Keys) {
            Console.Out.WriteLine("Hash Start: " + key + " Size: " + this.nodes[key].getNodeSize());
        }
    }

    public DataPoint getDataPoint(int key) {
        int hashedKey = this.hash.hashIt(key);

        foreach (int nodeKey in this.nodes.Keys) {
            if (hashedKey >= nodeKey && hashedKey <= nodeKey + (this.hashMapSize / this.numberOfNodes)) {
                return this.nodes[nodeKey].getDataPoint(key);
            }
        }
        return null;
    }

    public void addNode() {
        // Add a new Node at the end
        // Output reorganisations
    }

    public void removeNode(int id) {
        // Remove node with the given id
    }
}
