#include <iostream>
#define max_elements 100
class Stack
{
    int array[max_elements];
    int top =-1;
    void push(int data);
    int pop();
    int peek()
    {
        return array[top];
    }
    void _is_empty()
    {
        if(top==-1)
            return 1;
        else
            return 0;
    }
    void push(int data){
        array[++top] =data;
    }
    int pop()
    {
        if(_is_empty())
        {
            std::cout<<"STACK UNDERFLOW";
            return nullptr;
        }
        else
        {
            return array[top--];
        }
    }
    bool _search(int data)
    {
        for(int i=top;i>-1;i--)
            if(data==array[i])
                return 1;
        return 0;
    }
};
class Node{
public:
    int data;
    Node* next;
    Node* _end;
    bool _empty;
    Node(int data)
    {
        this->data = data;
        next = nullptr;
        _end = this;
    }
    bool _is_empty()
    {
        return _empty;
    }
    static Node* _enqueue(int data,Node* root)
    {
        if(root)
            Node* temp= new Node(data);temp->next =root;return temp;
        else
            return new Node(data);
    }
    Node* _dequeue(Node* root)
    {
        Node* temp= root;
        if(!temp)
        {
            std::cout<<"ListEmpty, cant dequeue!";
            return nullptr;
        }
        if(!temp->next)
        {
            _empty=1;
           return root;
        }
        while(temp->next->next)
        {
            temp = temp->next;
        }
        Node* retemp = temp->next;
        temp->next = nullptr;
        return retemp;
    }
};
int return_unvisited_child(int parent,bool** adj ,Stack* visited) //returns -1 if all visited
{
    for(int i=0;i<6;i++)
        if(adj[parent][i]&&!visited->_search(i))
            return i;
    return -1;
}
bool if_all_visited(int parent,bool* adj,Stack* visited)
{
    int sum=0;
    for(int i=0;i<6;i++)
        sum+=adj[parent][i];
    if(!sum)
        return 1;
    else
        return 0;
}
int main()
{
    //graph
    bool adj[6][6] = {0,1,0,0,1,0,
                      1,0,1,0,1,0,
                      0,1,0,1,0,0,
                      0,0,1,0,1,1,
                      1,1,0,1,0,1,
                      0,0,0,1,0,0};
    //visited[6] ={1,0,0,0,0,0};
    int ans[6] ={1,-1,-1,-1,-1,-1};
    int counter=0;
    int start_node = 0;
    Node* root =new Node(start_node);
    //breadth first search

    while(root->_is_empty())
    {
        Node* currentNode = _dequeue(root);
        for(int i =0;i<6;i++)
        {
            if(adj[currentNode][i])
            {   //visited[i]=1;
                ans[++counter]=i;
                root = Node::_enqueue(i,root);
            }
        }
    }
    //depth first search
    Stack temp;
    Stack visited;
    temp.push(start_node);
    visited.push(start_node);
    while(!temp._is_empty())
    {
        if(!if_all_visited(temp.peek(),addj,temp))
            visited.push(return_unvisited_child(temp.peek(),adj ,visited));temp.push(visited.peek()); //returns -1 if all visited
        else
            temp.pop();
    }
    // mother node
    int flag =0;
    for(int i=0;i<6;i++)
    {
        flag=0;
        for(int j =0;j<6;j++)
        {
            if(!adj[i][j])
                flag =1;
        }
        if(!flag)
            std::cout<<"motherNode found At "<<i;
    }
    //transpose of a graph
    for (int i =0;i<6;i++)
    {
        for(int j =i;j<6;j++)
        {
            std::swap(adj[i][j],adj[i][j]);
        }
    }
}
