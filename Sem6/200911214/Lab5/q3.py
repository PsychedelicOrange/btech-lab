def mulsum(array1,array2):
    sum = 0
    for i in range(len(array1)):
        sum+= array1[i]*array2[i]
        
    return sum
def getcol(N,test_tuple):
    return list(map(lambda sub: sub[N], test_tuple))
m1 = ((1,2,4),(3,5,6),(3,1,6))
m2 = ((12,3,2),(2,1,2),(2,30,4))
result = [[0,0,0],[0,0,0],[0,0,0]]
for i in range(len(m1)):
    for j in range(len(m1[0])):
        result[i][j] = mulsum(m1[i][:],getcol(j,m2))
print(result)

        
