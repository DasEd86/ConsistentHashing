using System;

class DataPoint {
    private int key;
    private int value;
    public DataPoint(int k, int v) {
        this.key = k;
        this.value = v;
    }

    public int getKey() {
        return this.key;
    }

    public int getValue() {
        return this.value;
    }
}
