using System;

class Program {
    static void Main(string[] args) {
        const int TEST_DATA_SIZE = 12;
    
        Random rnd = new Random();
        ConsistentHash consistentHash = new ConsistentHash(3, 4);
        for (int i = 0; i <= TEST_DATA_SIZE; i++) {
            consistentHash.addDataPoint(new KeyValuePair<int, int>(i, rnd.Next(99)));
        }
        Console.Out.WriteLine(consistentHash);
    }
}
