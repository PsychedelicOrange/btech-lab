rows_A = int(input("Enter number of rows in matrix A: "))
cols_A = int(input("Enter number of columns in matrix A: "))

A = []
for i in range(rows_A):
    row = []
    for j in range(cols_A):
        elem = int(input(f"Enter element A[{i}][{j}]: "))
        row.append(elem)
    A.append(row)

rows_B = int(input("Enter number of rows in matrix B: "))
cols_B = int(input("Enter number of columns in matrix B: "))

B = []
for i in range(rows_B):
    row = []
    for j in range(cols_B):
        elem = int(input(f"Enter element B[{i}][{j}]: "))
        row.append(elem)
    B.append(row)

if cols_A != rows_B:
    print("Invalid matrices for multiplication")
else:
    C = [[sum(A[i][k] * B[k][j] for k in range(cols_A)) for j in range(cols_B)] for i in range(rows_A)]
    print(C)
