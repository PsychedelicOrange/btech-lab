# include <iostream>
#include <cstdio>
using std::cin;
using std::cout;
int strlen(char *a)
{int i=0;
    while(a[i]!='\0')
    {
        i++;
    }
    return i;
}
int findSubstring(char* a ,char*b)
{
    for(int i =0; i<strlen(a);i++)
    {
        if(a[i]=b[0])
        {
            int flag = 0;
            for(int j = 0;j<strlen(b);j++)
            {
                if(a[i+j]!=b[j])
                {
                    flag =1;
                    break;
                }
            }
            if(!flag)
            {
                cout<<"\nSubstring found at index: "<<i;
            }
        }
    }
}
int main()
{
    char a[100];
    char b[100];
    scanf("%s",b);
    scanf("%s",a);
    cout<<"\nnumber of chars :"<<strlen(a);
    cout<<"\nnumber of chars :"<<strlen(b);
    findSubstring(a,b);
}
