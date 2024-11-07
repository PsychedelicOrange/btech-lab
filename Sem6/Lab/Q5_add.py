lst = list(input("Enter the list of elements: ").split())

for i in range(len(lst)//2):
    lst[i], lst[-i-1] = lst[-i-1], lst[i]

print("Reversed list:", lst)
