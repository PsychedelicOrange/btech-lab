DATA SEGMENT
ARR DW 10,-2,3,5,11
DATA ENDS
CODE SEGMENT
ASSUME CS:CODE,DS:DATA
START:MOV AX,DATA
MOV DS,DATA
MOV SI, OFFSET ARR
MOV AX,[SI]
MOV DI,SI
MOV CX,5
OUTER:
PUSH CX
        INNER:
                INC DI
                INC DI
                MOV BX,[DI]
                CMP AX,BX
                JL NEXT
                MOV BX,[SI]
                XCHG [SI],AX
                MOV AX,BX

        LOOP INNER
        INC SI
        INC SI
POP CX
LOOP OUTER
