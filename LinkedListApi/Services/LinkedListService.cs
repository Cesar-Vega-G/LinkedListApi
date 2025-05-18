using LinkedListApi.Models;

namespace LinkedListApi.Services
{
    public class LinkedListService
    {
        private Node? head;

        public IEnumerable<Node> GetAll()
        {
            var current = head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public Guid Add(string value)
        {
            var newNode = new Node { Value = value };

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            return newNode.Id;
        }

        public bool Delete(Guid id)
        {
            if (head == null)
                return false;

            if (head.Id == id)
            {
                head = head.Next;
                return true;
            }

            var current = head;
            while (current.Next != null && current.Next.Id != id)
            {
                current = current.Next;
            }

            if (current.Next == null)
                return false;

            current.Next = current.Next.Next;
            return true;
        }
    }
}
