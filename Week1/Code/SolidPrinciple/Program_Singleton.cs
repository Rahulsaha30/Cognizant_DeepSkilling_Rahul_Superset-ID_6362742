﻿using System;

public class Singleton
{
  //we create a private instance of this student class
  private static Singleton? student;

  //then we create a private constructor of this student class so it is not accessible 
  private Singleton(){
    Console.WriteLine("Student created");
  }

  public static Singleton getStudent() {
  if (student == null)
  {
    student = new Singleton();
  }
  return student;
  }

  public void studentMessage() {
  Console.WriteLine("HELLO");
}
}
class Program
{
    static void Main()
    {
        Singleton obj1 = Singleton.getStudent();
        obj1.studentMessage();

       Singleton obj2 = Singleton.getStudent();
        obj2.studentMessage();

        Console.WriteLine(obj1 == obj2); 
    }
}