using System.Collections.Generic;

class Node {
    List<DataPoint> listOfDataPoints;

    public Node() {
        this.listOfDataPoints = new List<DataPoint>();
    }

    public void addDataPoint(DataPoint d) {
        this.listOfDataPoints.Add(d);
    }

    public int getNodeSize() {
        return listOfDataPoints.Count;
    }

    public DataPoint getDataPoint(int key) {
        foreach (DataPoint dP in this.listOfDataPoints) {
            if (dP.getKey() == key) {
                return dP;
            }
        }
        return null;
    }
}
