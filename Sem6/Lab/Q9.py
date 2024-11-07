lst = input("Enter a list of elements (separated by spaces): ").split()

if lst == lst[::-1]:
    print("The list is a palindrome!")
else:
    print("The list is not a palindrome.")
