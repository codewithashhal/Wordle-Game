// using System;

// // 1️⃣ Class
// class Person
// {
//     // 2️⃣ Fields (variables / data members)
//     private string name;
//     private int age;

//     // 3️⃣ Constructor
//     public Person(string name, int age)
//     {
//         this.name = name;
//         this.age = age;
//     }

//     // 4️⃣ Method (behavior)
//     public void Introduce()
//     {
//         Console.WriteLine("My name is " + name + " and I am " + age + " years old.");
//     }

//     // 5️⃣ Property (getter & setter)
//     public int Age
//     {
//         get { return age; }
//         set { age = value; }
//     }
// }

// // 6️⃣ Main class
// class Program
// {
//     static void Main()
//     {
//         // 7️⃣ Object creation
//         Person p1 = new Person("Ali", 20);

//         // 8️⃣ Method call
//         p1.Introduce();

//         // 9️⃣ Property usage
//         p1.Age = 21;
//         Console.WriteLine(p1.Age);
//     }
// }
