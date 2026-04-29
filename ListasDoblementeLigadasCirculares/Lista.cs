using System.Text;

namespace ListasSimplementeLigadas
{
    internal class Lista
    {
        private Nodo nodoInicial;

        public Lista()
        {
            nodoInicial = new Nodo();
            // Lista vacía: nodoInicial apunta a sí mismo en ambas direcciones (circular)
            nodoInicial.Siguiente = nodoInicial;
            nodoInicial.Anterior = nodoInicial;
        }

        private bool EstaVacia()
        {
            return nodoInicial.Siguiente == nodoInicial;
        }
        private void Vaciar()
        {
            nodoInicial.Siguiente = nodoInicial;
            nodoInicial.Anterior = nodoInicial;
        }

        public void Agregar(string valor)
        {
            Nodo nodoNuevo = new Nodo(valor);

            // El último nodo real es nodoInicial.Anterior
            Nodo nodoUltimo = nodoInicial.Anterior!;
            nodoNuevo.Siguiente = nodoInicial; // nuevo → nodoInicial
            nodoNuevo.Anterior = nodoUltimo;  // nuevo ← ultimo

            nodoUltimo.Siguiente = nodoNuevo;   // ultimo → nuevo
            nodoInicial.Anterior = nodoNuevo;   // nodoInicial ← nuevo
        }
        public void AgregarInicio(string valor)
        {
            Nodo nodoNuevo = new Nodo(valor);

            Nodo nodoPrimero = nodoInicial.Siguiente!;

            nodoNuevo.Siguiente = nodoPrimero;  // nuevo → primero
            nodoNuevo.Anterior = nodoInicial;  // nuevo ← nodoInicial

            nodoInicial.Siguiente = nodoNuevo;    // nodoInicial → nuevo
            nodoPrimero.Anterior = nodoNuevo;    // primero ← nuevo
        }
        public Nodo? Buscar(string valor)
        {
            if (EstaVacia()) return null;

            Nodo nodoActual = nodoInicial.Siguiente!;

            while (nodoActual != nodoInicial)
            {
                if (nodoActual.Valor == valor)
                    return nodoActual;

                nodoActual = nodoActual.Siguiente!;
            }
            return null;
        }

        public bool Eliminar(string valor)
        {
            Nodo? nodoActual = Buscar(valor);
            if (nodoActual == null) return false;

            nodoActual.Anterior!.Siguiente = nodoActual.Siguiente;
            nodoActual.Siguiente!.Anterior = nodoActual.Anterior;
            nodoActual.Siguiente = null;
            nodoActual.Anterior = null;

            return true;
        }

        public string Imprimir()
        {
            if (EstaVacia()) return "La lista está vacía.";

            StringBuilder resultado = new StringBuilder();
            Nodo nodoActual = nodoInicial.Siguiente!;

            while (nodoActual != nodoInicial)
            {
                resultado.Append(nodoActual.Valor + " ");
                nodoActual = nodoActual.Siguiente!;
            }

            return resultado.ToString().TrimEnd();
        }

        public string ImprimirInverso()
        {
            if (EstaVacia()) return "La lista está vacía.";

            StringBuilder resultado = new StringBuilder();
            Nodo nodoActual = nodoInicial.Anterior!;

            while (nodoActual != nodoInicial)
            {
                resultado.Append(nodoActual.Valor + " ");
                nodoActual = nodoActual.Anterior!;
            }

            return resultado.ToString().TrimEnd();
        }
    }
}
