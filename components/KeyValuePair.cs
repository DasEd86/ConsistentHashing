class KeyValuePair <Key, Value>{
    private Key key;
    private Value value;
    public KeyValuePair(Key key, Value value) {
        this.key = key;
        this.value = value;
    }

    public Key getKey() {
        return this.key;
    }

    public Value getValue() {
        return this.value;
    }
}
