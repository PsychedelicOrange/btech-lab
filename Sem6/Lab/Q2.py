rows = int(input("Enter number of rows in matrix: "))
cols = int(input("Enter number of columns in matrix: "))

matrix = []
for i in range(rows):
    row = []
    for j in range(cols):
        elem = int(input(f"Enter element [{i}][{j}]: "))
        row.append(elem)
    matrix.append(row)

transpose = [[matrix[j][i] for j in range(rows)] for i in range(cols)]

print(transpose)
