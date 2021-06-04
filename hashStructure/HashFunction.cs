class HashFunction {
    private int size;

    public HashFunction(int hSize) {
        this.size = hSize;
    }

    public int hashIt(int key) {
        return key % size;
    }
}
