rows = int(input("Enter number of rows in matrices: "))
cols = int(input("Enter number of columns in matrices: "))

A = []
for i in range(rows):
    row = []
    for j in range(cols):
        elem = int(input(f"Enter element A[{i}][{j}]: "))
        row.append(elem)
    A.append(row)

B = []
for i in range(rows):
    row = []
    for j in range(cols):
        elem = int(input(f"Enter element B[{i}][{j}]: "))
        row.append(elem)
    B.append(row)

C = [[A[i][j] + B[i][j] for j in range(cols)] for i in range(rows)]
print(C)
