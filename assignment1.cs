/*
1. What type would you choose for the following “numbers”?
A person’s telephone number -- string
A person’s height --float
A person’s age  --int
A person’s gender (Male, Female, Prefer Not To Answer) --string
A person’s salary --money
A book’s ISBN -- long
A book’s price --money
A book’s shipping weight --float
A country’s population --int
The number of stars in the universe --long
The number of employees in each of the small or medium businesses in the
United Kingdom (up to about 50,000 employees per business) --int

2. What are the difference between value type and reference type variables? What is
boxing and unboxing?
ANS: 1.value type will directly hold the value, while reference type hold the memory address or reference for the value.
     2.value type are stored in stack memory, while reference type store in heap memory.
     3.value type will not be collected by garbage collector, while reference type will be collected by garbage collector.
     4.value type can be created by Struc or Enum, reference type can be created by class, interface,delegate,or array.
     5.vaule type can not accept null value, reference type can accept null.

     Boxing: convert a value type to a reference type.
     Unboxing: convert a reference type to a value type.

3. What is meant by the terms managed resource and unmanaged resource in .NET
ANS: managed resource: managed by garbage collector.
     unmanaged resource: files, steams, database connections.

4. Whats the purpose of Garbage Collector in .NET?
ANS: The garbage collector manages the allocation and release of memory for an application.
*/

Console.WriteLine("sbyte: size= {0}, minValue={1}, maxValue={2}",sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
Console.WriteLine("byte: size= {0}, minValue={1}, maxValue={2}", sizeof(byte), byte.MinValue, byte.MaxValue);
Console.WriteLine("short: size= {0}, minValue={1}, maxValue={2}", sizeof(short), short.MinValue, short.MaxValue);
Console.WriteLine("ushort: size= {0}, minValue={1}, maxValue={2}", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
Console.WriteLine("int: size= {0}, minValue={1}, maxValue={2}", sizeof(int), int.MinValue, int.MaxValue);
Console.WriteLine("uint: size= {0}, minValue={1}, maxValue={2}", sizeof(uint), uint.MinValue, uint.MaxValue);
Console.WriteLine("long: size= {0}, minValue={1}, maxValue={2}", sizeof(long), long.MinValue, long.MaxValue);
Console.WriteLine("ulong: size= {0}, minValue={1}, maxValue={2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
Console.WriteLine("float: size= {0}, minValue={1}, maxValue={2}", sizeof(float), float.MinValue, float.MaxValue);
Console.WriteLine("double: size= {0}, minValue={1}, maxValue={2}", sizeof(double), double.MinValue, double.MaxValue);
Console.WriteLine("decimal: size= {0}, minValue={1}, maxValue={2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
Console.WriteLine("---------------------------------------------");

void ConvertTime(int century)
{
    long years;
    years = century * 100;

    long days;
    days = years * 365;

    long hours;
    hours = days * 24;

    long minutes;
    minutes = hours * 60;

    long seconds;
    seconds = minutes * 60;

    long milliseconds;
    milliseconds = seconds * 1000;

    long micoseconds;
    micoseconds = milliseconds * 1000;

    long nanoseconds;
    nanoseconds = milliseconds * 1000;

    Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", century, years,days,hours,minutes,seconds,milliseconds,micoseconds,nanoseconds);
}

ConvertTime(1);
ConvertTime(5);

Console.WriteLine("---------------------------------------------");


/*
1. What happens when you divide an int variable by 0?
ANS: throw an error : division by constant 0.

2. What happens when you divide a double variable by 0?
ANS: output : infinity ∞

3. What happens when you overflow an int variable, that is, set it to a value beyond its
range?
ANS: throw an error, ask if it is a explicit conversion form int to uint. 

4. What is the difference between x = y++; and x = ++y;?
ANS: x = y++; increment happens after assignment
     x = ++y; increment happens before assignment

5. What is the difference between break, continue, and return when used inside a loop
statement?
ANS: break--jump out of the loop.
     continue -- break one iteration in the loop.
     return -- jump out the loop and jump out the method.

6. What are the three parts of a for statement and which of them are required?
ANS: statement 1: set the variable before loop start.
     statement 2: define the condition for the loop to run. it is required
     statement 3: update the variables every time after code block has been excuted.

7. What is the difference between the = and == operators?
ANS: = : assignment operator
     ==: equality operator

8. Does the following statement compile? for ( ; true; ) ;
ANS: Yes.

9. What does the underscore _ represent in a switch expression?
ANS: replace the default keyword to signify that it match anything if reached.

10. What interface must an object implement to be enumerated over by using the foreach
statement?
ANS: Array.
*/
/* ----------------------(1)-------------------------*/
void FizzBuzz()
{
    int max = 100;
    for (int i = 1; i <= max; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine($"{i} : fizzbuzz");
        }
        if (i % 3 == 0)
        {
            Console.WriteLine($" {i} :fizz");
        }
        if (i % 5 == 0)
        {
            Console.WriteLine($"{i} :buzz");
        }

    }
}
FizzBuzz();
/* -----------------------------------------------*/

//ANS: it will throw an error: the name 'WriteLine' does not exist in the current context
int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
}


/* ----------------------(2)-------------------------*/
void PrintStar(int row)
{
    int maxStarNum = 2 * (row - 1) + 1;
    for (int i = 0; i < row; i++)
    {
        int starNum = i * 2 + 1;
        int startIdx = maxStarNum / 2 - starNum/2;
        string starPre = new String(' ', startIdx);
        string star = new String('*', starNum);
        string starPost = new String(' ', startIdx);
        Console.WriteLine(starPre+star+starPost);

    }
}
PrintStar(5);

/* ---------------------(3)--------------------------*/
void GuessNum()
{
    int correctNumber = new Random().Next(3) +1;
    int guessedNumber = int.Parse(Console.ReadLine());
    if (correctNumber == guessedNumber)
    { Console.WriteLine("correct answer"); }
    else if(correctNumber > guessedNumber)
    { Console.WriteLine("low"); }
    else if (correctNumber < guessedNumber)
    { Console.WriteLine("high"); }
    else
    { Console.WriteLine("outside range"); }
}
GuessNum();

/* ----------------------(4)-------------------------*/
double Caldays()
{
    Console.WriteLine("input the birthday");
    string str = Console.ReadLine();
    var dt = DateTime.Parse(str);
    DateTime dtNow = DateTime.Now;
    TimeSpan difference = dtNow.Subtract(dt);
    var span = difference.Days;
    //Console.WriteLine(dt);
    //Console.WriteLine(dtNow);
    //Console.WriteLine(span);
    int daysToNextAnniversary = 10000 - (span % 10000);
    DateTime nextAnni = dt.AddDays(daysToNextAnniversary);
    return span;

}
Caldays();

/* -----------------------(5)------------------------*/
void Greeting()
{
    DateTime dt=DateTime.Now;
    int hours = dt.Hour;
    //Console.WriteLine(hours);
    if (0<hours && hours<=6)
    { Console.WriteLine("GOOD Night"); }
    if (6 < hours && hours <= 12)
    { Console.WriteLine("GOOD Morning"); }
    if (12 < hours && hours <= 18)
    { Console.WriteLine("GOOD Afternoon"); }
    if (18 < hours && hours <= 24)
    { Console.WriteLine("GOOD Evening"); }

}
Greeting();
/* ----------------------(6)-------------------------*/
void Counting(int num)
{
    int[] arr = {1,2,3,4};

    foreach(int i in arr)
    {
        int j = 0;
        while(j<num)
        {
            j = j + i;
            Console.WriteLine(j);
        }
    }

}
Counting(24);