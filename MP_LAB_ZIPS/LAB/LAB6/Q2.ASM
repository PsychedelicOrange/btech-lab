DATA SEGMENT
NUM DB 9
RES DW ?
DATA ENDS

CODE SEGMENT
ASSUME CS:CODE,DS:DATA
START: MOV AX,DATA
MOV DS,AX

MOV AX,0
MOV AL,NUM

CALL FAC AX

FAC PROC CNUM
        CMP AX,1
        JE NEXT
        DEC AX
        CALL FAC AX
        MUL BX
        
        NEXT:

        
