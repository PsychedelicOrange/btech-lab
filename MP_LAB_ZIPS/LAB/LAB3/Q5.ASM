DATA SEGMENT
        NUM1 DW 1234H,5678H
        NUM2 DW 0FFEDH,0CBA9H
	NUM3 DW ?,?
        BORROW DB 0
DATA ENDS
CODE SEGMENT
	ASSUME CS:CODE,DS:DATA
START: MOV AX,DATA
	MOV DS,AX
        MOV AX,NUM1+2
        MOV DX,NUM1
        MOV BX,NUM2+2
        MOV CX,NUM2
        SUB AX,BX
        SBB DX,CX
        JNC NEXT
                INC BORROW
        NEXT:
        MOV NUM3+2,AX
        MOV NUM3,DX
        MOV AH,4CH
        INT 21H
CODE ENDS
END START
