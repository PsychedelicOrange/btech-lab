m1 = ((1,2,4),(3,5,6),(3,1,6))
m2 = ((12,3,2),(2,1,2),(2,30,4))
result = [[0,0,0],[0,0,0],[0,0,0]]

for i in range(len(m1)):
    for j in range(len(m1[0])):
        result[i][j] = m1[i][j]+m2[i][j]
print (result)
