# Consistent Hashing
Consistent hashing is a hash map that facilitates adding and removing nodes [Wikipedia](https://en.wikipedia.org/wiki/Consistent_hashing). Compared to a traditional hash approach, a lower number of entries has to be remapped when a node is added or removed. This repo provides a demo implementation.

## Assumptions
- All nodes cover the same number of addresses. The last node gets assigned the remaining addresses, if the results of the hash function cannot be split equally, 
