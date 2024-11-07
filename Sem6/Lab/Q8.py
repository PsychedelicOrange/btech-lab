set1 = set(input("Enter the elements of the first set (separated by spaces): ").split())
set2 = set(input("Enter the elements of the second set (separated by spaces): ").split())

print("Set operations:")
print(f"Union: {set1.union(set2)}")
print(f"Intersection: {set1.intersection(set2)}")
print(f"Difference (set1 - set2): {set1.difference(set2)}")
print(f"Symmetric Difference: {set1.symmetric_difference(set2)}")
