DATA SEGMENT
ARR DW 000AH,0A00H,00A0H,0AA00H
GCDRES DW ?
DATA ENDS
CODE SEGMENT
ASSUME CS:CODE, DS:DATA
START:
MOV AX,DATA
MOV DS,AX
MOV AX,ARR
MOV BX,ARR+2
CALL GCD
MOV AX,CX
MOV BX,ARR+4
CALL GCD
MOV AX,CX
MOV BX,ARR+6
CALL GCD
MOV GCDRES,CX
GCD PROC
       AGAIN:
       CMP AX,BX
       JE STORE
       JA NEXT
       XCHG AX,BX
       NEXT:
       DIV BX
       CMP DX,0000H
       JE STORE
       MOV AX,DX
       JMP AGAIN
       STORE:
       MOV CX,BX
       RET
GCD ENDP
MOV AH,4CH
INT 21H
CODE ENDS
END START
       

