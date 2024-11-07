def sum_natural(n):
    if n <= 1:
        return n
    else:
        return n + sum_natural(n-1)

n = int(input("Enter a positive integer: "))
if n < 0:
    print("Invalid input")
else:
    print(f"Sum of natural numbers from 1 to {n}: {sum_natural(n)}")
