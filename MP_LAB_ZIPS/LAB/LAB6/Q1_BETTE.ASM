DATA SEGMENT
ARR DW 000AH,0A00H,00A0H,0AA00H
RES DW ?
DATA ENDS

CODE SEGMENT
ASSUME CS:CODE,DS:DATA
START: MOV AX,DATA
MOV DS,AX
MOV SI,OFFSET ARR
MOV AX,[SI]
MOV CX,2
BACK:
        INC SI
        INC SI
        MOV BX,[SI]
        CALL GCD
LOOP BACK
MOV RES,AX

GCD PROC
        AGAIN:
        CMP AX,BX
        JE LOL
        JA NEXT
        XCHG AX,BX
        NEXT:
        DIV BX
        CMP DX,0
        JE LOL
        MOV AX,DX
        JMP AGAIN
        LOL:
        MOV AX,BX
        RET
GCD ENDP

MOV AH,4CH
INT 21H

CODE ENDS
END START
