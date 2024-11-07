#include <iostream>

using std::cin;
using std::cout;

int count =0;
int count2 =0;

void printArray(int* a, int n)
{
    for(int i=0;i<n;i++)
    {
        cout<<a[i]<<" ";
    }
}
int binarySearch(int *a ,int n)
{
    int s;
    cin>>s;
    int l=0,h=n-1,m=n/2;
    while(l!=h)
    {
        cout<<"\nl,m,h: "<<l<<m<<h;
        count++;// statement l!=h
        count++;// for if statement
        if(s>a[m])
        {
            l=m+1; count ++;
            m=(l+h)/2; count ++;
        }
        else if (s<a[m])
        {   count++;
            h=m-1;count++;
            m=(l+h)/2;count++;
        }
        else{count++; // for if above 'else if' is false
             count++;return m;
        }
    }
    return m;
}
void bubbleSort(int*a ,int n)
{
    int flag =1; count2++;
    while(flag == 1)
    {count2++;
        flag = 0;count2 ++;
        for(int i=0;i<n-1;i++)
        {count2++;
         count2++; // for if
           if(a[i]>a[i+1])
            {
                int temp = a[i];
                a[i] = a[i+1];
                a[i+1] = temp;
                 count2 ++;
                flag =1; count2++;
            }
        }
    }
    count2++;// for while
}
void selectionSort(int* a, int n)
{int smallest;
    for (int i=0;i<n;i++)
    {
        smallest = i;count2++;
        for (int j =i+1;j<n;j++)
        {
            if(a[smallest]>a[j])
                smallest =j;
        }count2++;
        int temp = a[i];count2++;
        a[i]= a[smallest];count2++;
        a[smallest] = temp;count2++;
    }count2++;

}
void insertionSort(int*a,int n)
{
    for (int i =0 ; i<n;i++)
    {count2++;
        for(int j = i; j > 0 && a[j-1]>a[j];j--)
        {count2++;
            int temp = a[j];
            a[j] = a[j-1];
            a[j-1]= a[j];
        }count2++;
    }count2++;
}
int main()
{
    //take input
 int n;
 cin>>n;
 int* a = new int[n];
 for(int i=0;i<n;i++)
 {
     cin>>a[i];
 }
//sort before binary Search
cout<<"\n before sort: ";printArray(a,n);
//bubbleSort(a,n);
selectionSort(a,n);
cout<<"\n after sort: ";printArray(a,n);
//binary search
cout<<"\nFound at index: "<<binarySearch(a,n);
//cout<<"\nSteps in Bubble Sort: "<< count2;
//cout<<"\nSteps in Selection Sort: "<< count2;
cout<<"\nStep in Insertion Sort: "<<count2;
cout<<"\nSteps in binary search: "<< count;
return 0;
}
