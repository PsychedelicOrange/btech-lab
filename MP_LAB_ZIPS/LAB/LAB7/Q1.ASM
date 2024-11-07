DATA SEGMENT
ARR DB 00H,01H,02H,03H,04H,05H,06H,07H,08H,09H
STA DB 02H
FBIT DB 0
DATA ENDS
CODE SEGMENT
ASSUME CS:CODE,DS:DATA
START:MOV AX,DATA
MOV DS,AX
        MOV SI,OFFSET ARR
        MOV DL,STA
        MOV CX,10
        BACK:
        MOV BL,[SI]
        CMP BL,DL
        JE FOUND
        INC SI
        LOOP BACK
        MOV AH,4CH
        INT 21H
        FOUND:
        MOV FBIT,1
        MOV AH,4CH
        INT 21H
        CODE ENDS
        END START
        
