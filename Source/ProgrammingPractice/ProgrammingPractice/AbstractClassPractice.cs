using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPractice
{
    class AbstractClassPractice
    {
    }

   
abstract class Book
{
    
    protected String title;
    protected  String author;
    public Book() { }
    public Book(String t,String a){
        title=t;
        author=a;
    }
    public abstract void display();
}
class MyBook : Book
{
    int price;
   // public MyBook() { }
    public MyBook(string _title, string _author, int _price) :base(_title,_author)
        {
        title= _title;
        author = _author;
        price = _price;
    }
    public override void display()
    {
        Console.WriteLine("Title : " + title);
        Console.WriteLine("Author : " + author);
        Console.WriteLine("Price : " + price);
    }
}
}
