namespace ListasSimplementeLigadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            //string datos = lista.Imprimir();
            //Console.WriteLine(datos);

            lista.Agregar("A");
            lista.Agregar("B");
            lista.Agregar("C");
            lista.Agregar("D");
            Console.WriteLine(lista.Imprimir());
        }
    }
}
