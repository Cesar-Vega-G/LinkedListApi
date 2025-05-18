
using System;

namespace LinkedListApi.Models
{
    public class Node
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // Identificador único
        public string Value { get; set; }              // El valor del nodo
        public Node? Next { get; set; }                // Referencia al siguiente nodo
    }
}
