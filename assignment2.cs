/*
1. When to use String vs. StringBuilder in C# ?
ANS: The string object is immutable. Everytime you use one of the method in the System.String
    class, you create a new string object in memory. To modify a string without creating a new 
    object, can use System.Text.StringBuilder class. It can boost performance when concatenating
    many string together in a loop.

2. What is the base class for all arrays in C#?
ANS: Array.

3. How do you sort an array in C#?
ANS: array.sort()

4. What property of an array object can be used to get the total number of elements in
an array?
ANS:array.Length

5. Can you store multiple data types in System.Array?
ANS: yes.

6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
Practice Arrays
ANS:CopyTo require to have a destination array, Clone create a new array.

*/

/*-------------------(1)---------------------------*/
int[] arr = new int[10] {1,2,3,4,5,6,7,8,9,10};
int l=arr.Length;
string[] arrS = new string[l];

for (int i = 0; i < l; i++)
{
    arrS[i] = arr[i].ToString();
    Console.WriteLine(arr[i]);
    Console.WriteLine(arrS[i]);
}

/*-------------------(2)-------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public class ShoppingList
    {
        private string[] shopList= new string[10] {"null", "null", "null", "null" ,"null" ,"null" ,"null" ,"null", "null","null" };
        
        private int listNum = 0;
        
        public void AddItem(string str)
        {
            if (listNum==10)
            {
                Console.WriteLine("the list is full");
            }

            for (int i = 0; i < shopList.Length; i++)
            {
                if (shopList[i] == "null")
                {
                    shopList[i]=str;
                    listNum++;
                    break;
                }
            }
            Console.WriteLine(String.Join(" ", shopList));
        }

        public int DelItem(string str)
        {
            int i = Array.IndexOf(shopList,str);
            if (i >= 0)
            {
                shopList[i] = "null";
                listNum--;
            }
            return listNum;
        }

        public void clearList()
        {
            Array.Clear(shopList, 0, shopList.Length);
            listNum = 0;
        }
    }
}

using Exercise03;
bool flag = true;
ShoppingList sl = new ShoppingList();
while (flag)
{
    Console.WriteLine("Enter command (+ item,- item, or -- to clear)");
    string input=Console.ReadLine();
    if (input[0]=='+')
    {
        sl.AddItem(input.Substring(2));
    }
    if (input[0] == '-')
    {
        int listNum = sl.DelItem(input.Substring(2));
        if (listNum == 0)
        {
            flag=false;
        }
    }
    if (input[0] == '-' && input[1]=='-')
    {
        sl.clearList();
    }
}

/*-------------------(3)-----------------------*/
int[] FindPrimesInRange(int startNum, int endNum)
{
    int r=endNum-startNum+1;
    int[] primes = new int[r];
    int num=0;
    for (int i=startNum; i<=endNum; i++)
    {
        bool flag = true;
        for(int j=2; j<i; j++)
        {
            if(i%j==0)
            {
                flag = false;
                break;
            }
        }
        if (flag)
        {
            primes[num] = i;
            num++;
        }
    }
    return primes;
}

int[] arr=FindPrimesInRange(2, 10);
foreach(int num in arr)
{
    Console.WriteLine(num);
}

/*-------------------(4)-------------------------*/
int[] RotateArr(int[] arr, int k)
{
    int l=arr.Length;
    int[] res=new int[l];
    int[] next=new int[l];

    for (int i=1; i<=k; i++)
    {
        for (int j=0; j<l; j++)
        {
            int temp = (j + i) % l;
            next[temp]=arr[j];
            res[temp] += next[temp];
        }
    }
    return res;

}

int[] input = { 3, 2, 4, -1 };
int[] res= RotateArr(input,2);
foreach (int num in res)
{
    Console.WriteLine(num);
}

/*-------------------(5)--------------------------*/
int[] LongestSeq(int[] arr)
{
    int maxSqe = 1;
    int maxIdx = 0;
    int startIdx = 0;
    while(startIdx < arr.Length)
    {
        int s = 1;
        while (startIdx + s< arr.Length)
        {
            if (arr[startIdx+s] == arr[startIdx])
            { 
                if(s>maxSqe)
                {
                    maxSqe = s;
                    maxIdx = startIdx;
                }
                s++;
            }else
            {
                break;
            }

        }
        startIdx++;
    }
    int[] res= new int[maxSqe]; 
    for (int j=0; j<maxSqe; j++)
    {
        res[j] = arr[maxIdx + j];
    }
    return res;
}

/*-------------------(7)------------------------*/
int MostFrequent(int[] arr)
{
    Dictionary<int, int> map = new Dictionary<int, int>();
    foreach(int i in arr)
    {
        if(map.ContainsKey(i))
        { map[i] += 1;
        }else
        { map[i] = 1;
        }
    }
    int maxSeq=0;
    int res = arr[0];
    foreach(int i in map.Keys)
    {
        if (map[i]>maxSeq)
        {
            maxSeq = map[i];
            res= i;
        }
    }
    return res;
}

/*---------------------Practice String(1)----------------------------*/
string ReverseSre(string str)
{
    int l=str.Length;
    for (int i=l-1; i>=0; i--)
    {
        Console.WriteLine(str[i]);
    }

    char[] charArr=str.ToCharArray();
    Array.Reverse(charArr);
    string res=String.Join("", charArr);
    Console.WriteLine(res);
    return res;
}
string res=ReverseSre("24tvcio98");

/*---------------------------(2)-------------------------------*/
string ReverseSentence(string str)
{
    char[] separators = new char[] {'.',',',':',';','=','(',')','&','[',']','"','/','!','?',' ','\\'} ;
    string[] arr = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(arr);

    string[] arr1 = str.Split(' ');
    for (int i = 0; i < arr1.Length; i++)
    {
        char st = arr1[i][0];
        int stIdx = Array.IndexOf(separators,st);
        char nd = arr1[i][-1];
        int ndIdx = Array.IndexOf(separators, nd);
        if (stIdx!=-1 &&  ndIdx!= -1)
        {
            arr1[i] = st + arr[i]+ nd;
        }
        else if (stIdx != -1 && ndIdx== -1)
        {
            arr1[i] = st + arr[i];
        }
        else if (stIdx == -1 && ndIdx != -1)
        {
            arr1[i] = arr[i] + nd;
        }else
        {
            arr1[i] = arr[i];
        }
    }
    string res=string.Join(' ',arr1);
    return res;

}

/*---------------------------(3)-------------------------------*/

void Palinddromes(string str)
{
    char[] seperators = new char[] { ' ', ',' };
    string[] strArr = str.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
    string[] res = new string[strArr.Length];
    int i = 0;
    foreach(string strStr in strArr)
    {
        char[] temp=strStr.ToCharArray();
        Array.Reverse(temp);
        string strStr1=String.Join("", temp);
        if (strStr1==strStr)
        {
            res[i] = strStr;
            i++;
        }
    }
    Array.Sort(res);
    foreach(string resStr in res)
    {
        Console.WriteLine(resStr);
    }
}

/*---------------------(4)-----------------------*/
string[] ParseURL(string url)
{
    string[] stringSeperator=new string[] { "://","/" }; 
    string[] urlArr=url.Split(stringSeperator, StringSplitOptions.RemoveEmptyEntries);
    string protocal=urlArr[0];
    string server=urlArr[1];
    string resource=urlArr[2];
    return urlArr;
}