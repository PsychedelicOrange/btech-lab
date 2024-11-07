numbers = [[12,7],
           [4,5],
           [3,8]]
transpose = [[0,0,0],[0,0,0]]
for i in range(len(numbers)):
    for j in range(len(numbers[0])):
                   transpose[j][i] = numbers[i][j]
print(transpose)
