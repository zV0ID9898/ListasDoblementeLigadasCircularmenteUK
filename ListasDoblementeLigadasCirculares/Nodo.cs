namespace ListasSimplementeLigadas
{
    internal class Nodo
    {
        public string Valor { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo? Anterior { get; set; }

        public Nodo(string valor = "", Nodo? siguiente = null, Nodo? anterior = null)
        {
            Valor = valor;
            Siguiente = siguiente;
            Anterior = anterior;
        }
    }
}
