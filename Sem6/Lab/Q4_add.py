lst = list(input("Enter the list of elements: ").split())

new_lst = []
for i in lst:
    if i not in new_lst:
        new_lst.append(i)

print("List after removing duplicates:", new_lst)
