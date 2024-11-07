def fibonacci(n):
    if n <= 1:
        return n
    else:
        return fibonacci(n-1) + fibonacci(n-2)

n_terms = int(input("Enter the number of terms: "))

if n_terms <= 0:
    print("Invalid input! Number of terms must be positive.")
else:
    print("Fibonacci sequence:")
    for i in range(n_terms):
        print(fibonacci(i))
