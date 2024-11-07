DATA SEGMENT
        ARRAY DB 99H,99H,99H,99H,99H,99H,99H,98H,99H,0A0H
        CT EQU $-ARRAY
        SUM DB 0
        CARRY DB 0
DATA ENDS
CODE SEGMENT
        ASSUME CS:CODE,DS:DATA
START:
        MOV AX,DATA
        MOV DS,AX
        LEA SI,ARRAY
        MOV CX,CT
        MOV AX,0
        COMP:
                ADD AL,[SI]
                JNC HARD
                        INC CARRY
                HARD:
                INC SI
        LOOP COMP
        MOV SUM,AL
        MOV AH,4CH
        INT 21H
CODE ENDS
END START


