using System;

namespace ProgrammingPractice
{

    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
        public Node Insert(Node head, int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return head;
            }
            var temp = head;
            while (head.next != null)
            {
                head = head.next;
            }
            head.next = new Node(data);

            return temp;
        }
        public void Display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
    }

    class calculator : AdvancedArithmetic
    {
        public int divisorSum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
    public interface AdvancedArithmetic
    {
        int divisorSum(int n);
    }


}
