using System;

class Program {
    static void Main(string[] args) {
        Random rnd = new Random(); 

        ConsistentHash consistentHash = new ConsistentHash(5, 10);
        consistentHash.addDataPoint(new DataPoint(5, 13));
        consistentHash.addDataPoint(new DataPoint(6, 49));
        consistentHash.addDataPoint(new DataPoint(7, 2));
        consistentHash.addDataPoint(new DataPoint(8, 66));
        consistentHash.addDataPoint(new DataPoint(9, 120));
        consistentHash.addDataPoint(new DataPoint(10, 101));
        consistentHash.addDataPoint(new DataPoint(11, 90));
        consistentHash.addDataPoint(new DataPoint(12, 9));
        consistentHash.printStateOfDB();

        Console.Out.WriteLine(consistentHash.getDataPoint(12).getKey() + " " + consistentHash.getDataPoint(12).getValue());
        Console.Out.WriteLine(consistentHash.getDataPoint(9).getKey() + " " + consistentHash.getDataPoint(9).getValue());
    }
}
